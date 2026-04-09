using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Microsoft.Extensions.Logging;

namespace Flipbop.BOAF;

internal sealed class BubbleGeneratorArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("BubbleGenerator", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = Deck.colorless,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!),
				unremovable = true
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Ship/Neptune/Artifacts/BubbleGenerator.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["ship","artifact", "BubbleGenerator", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["ship","artifact", "BubbleGenerator", "description"]).Localize
		});
		
		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(Ship), nameof(Ship.Set)),
			prefix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Bubble_Bay_Swap_Prefix)),
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Bubble_Bay_Swap_Postfix))
		);
	}

	private static void Bubble_Bay_Swap_Prefix(Ship __instance, out int __state)
	{
		
		__state = __instance.Get(Status.bubbleJuice);
		
	}
	private static void Bubble_Bay_Swap_Postfix(Ship __instance, in int __state)
	{

		if (__state > __instance.Get(Status.bubbleJuice))
		{

			foreach (Part p in __instance.parts)
			{					
				if (p.active && p.skin == ModEntry.Instance.neptuneBaySprite)
				{
					p.active = false;
				} else if (!p.active && p.skin == ModEntry.Instance.neptuneBaySprite)
				{
					p.active = true;
				}
			}
		}
	}
	
	public override void OnTurnStart(State state, Combat combat)
    	{
    		base.OnTurnStart(state, combat);
    		combat.QueueImmediate(new AStatus() {status = Status.bubbleJuice, statusAmount = 1, targetPlayer = true});
    	}
}
