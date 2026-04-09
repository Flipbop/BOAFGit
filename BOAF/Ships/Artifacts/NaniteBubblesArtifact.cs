using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;

namespace Flipbop.BOAF;

internal sealed class NaniteBubblesArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("NaniteBubbles", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = Deck.colorless,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!),
				unremovable = true
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Ship/Neptune/Artifacts/NaniteBubbles.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["ship","artifact", "NaniteBubbles", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["ship","artifact", "NaniteBubbles", "description"]).Localize
		});
		
		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(AAttack), nameof(AAttack.Begin)),
			prefix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(AAttack_Bubble_Pop_Prefix)),
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(AAttack_Bubble_Pop_Postfix))
		);
	}
	
	private static void AAttack_Bubble_Pop_Prefix(Combat c, out List<StuffBase> __result)
	{
		List<StuffBase> objects = [];
		foreach (var midrowObject in c.stuff)
		{
			if (midrowObject.Value.bubbleShield)
			{
				objects.Add(midrowObject.Value);
			}
		}
		__result = objects;
	}
	
	private static void AAttack_Bubble_Pop_Postfix(State s, Combat c, in List<StuffBase> __result)
	{
		foreach (var midrowObject in c.stuff)
		{
			if (midrowObject.Value.bubbleShield)
			{
				__result.Remove(midrowObject.Value);
			}
		}

		if (__result.Count <= 0)
			return;
		if (s.EnumerateAllArtifacts().FirstOrDefault(a => a is NaniteBubblesArtifact) is not { })
			return;
		foreach (var midrowObject in __result)
		{
			c.QueueImmediate(new ASpawn() {thing = midrowObject, fromPlayer = true, timer = 0.0});
		}
	}
	
}
