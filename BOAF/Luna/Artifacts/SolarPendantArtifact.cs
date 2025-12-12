using System;
using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using Nanoray.Shrike;
using Nanoray.Shrike.Harmony;

namespace Flipbop.BOAF;

internal sealed class SolarPendantArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("SolarPendant", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.LunaDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!),
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Luna/Artifacts/SolarPendant.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna","artifact", "SolarPendant", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Luna","artifact", "SolarPendant", "description"]).Localize
		});
		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(AAttack), nameof(AAttack.Begin)),
			transpiler: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(TryStunChargeTranspiler))
		);
	}

	private static IEnumerable<CodeInstruction> TryStunChargeTranspiler(IEnumerable<CodeInstruction> instructions,
		ILGenerator il, MethodBase originalMethod)
	{
		try
		{
			var localVars = originalMethod.GetMethodBody()!.LocalVariables;
			
			return new SequenceBlockMatcher<CodeInstruction>(instructions)
				.Find(
					SequenceBlockMatcherFindOccurence.First,
					SequenceMatcherRelativeBounds.WholeSequence,
					ILMatches.Stloc<RaycastResult>(originalMethod).CreateLdlocInstruction(out var raycast)
					)
				.Find(
					SequenceBlockMatcherFindOccurence.First,
					SequenceMatcherRelativeBounds.After,
					ILMatches.LdcI4((int) Status.stunCharge),
					ILMatches.Call("Get"),
					ILMatches.LdcI4(1),
					ILMatches.Instruction(OpCodes.Sub),
					ILMatches.Call("Set"),
					ILMatches.Ldarg(0).CreateLabel(il, out var label)
					)
				.Find(
					SequenceBlockMatcherFindOccurence.First,
					SequenceMatcherRelativeBounds.Before,
					ILMatches.Ldarg(2),
					ILMatches.Ldfld("ship"),
					ILMatches.LdcI4((int) Status.stunCharge)
					)
				.Insert(
					SequenceMatcherPastBoundsDirection.Before,
					SequenceMatcherInsertionResultingBounds.JustInsertion,
					new CodeInstruction(OpCodes.Ldarg_2),
					new CodeInstruction(OpCodes.Ldarg_3),
					raycast.Value,
					new CodeInstruction(OpCodes.Call, AccessTools.DeclaredMethod(typeof(SolarPendantArtifact), nameof(StunChargeCheck))),
					new CodeInstruction(OpCodes.Brfalse, label)
					)
				.AllElements();

		}
        catch (Exception e)
        {
            Console.WriteLine("Solar Pendant FAILURE");
            Console.WriteLine(e);
            return instructions;
        }
	}
	
	private static bool StunChargeCheck(State s, Combat c, RaycastResult result) 
	{
		if (s.EnumerateAllArtifacts().Any((a) => a is SolarPendantArtifact))
		{
			Part? part = c.otherShip.GetPartAtWorldX(result.worldX);
			if (!result.hitDrone && part != null && part.intent != null)
			{
				return true;
			}

			return false;
		}

		return true;
	}
}
