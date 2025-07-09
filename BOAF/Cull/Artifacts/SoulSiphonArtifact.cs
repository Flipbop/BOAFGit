using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;

namespace Flipbop.BOAF;

internal sealed class SoulSiphonArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("SoulSiphon", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.CullDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!),
				
			},
			Sprite = ModEntry.Instance.placeholderSprite.Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "SoulSiphon", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "SoulSiphon", "description"]).Localize
		});
		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(Ship), nameof(Ship.DirectHullDamage)),
			prefix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Ship_DirectHullDamage_Prefix)),
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Ship_DirectHullDamage_Postfix))
		);
	}

	private static void Ship_DirectHullDamage_Prefix(Ship __instance, out int __state)
		=> __state = __instance.hull;

	private static void Ship_DirectHullDamage_Postfix(Ship __instance, State s, Combat c, in int __state)
	{
		var damageTaken = __state - __instance.hull;
		if (damageTaken <= 0)
			return;
		if (__instance.isPlayerShip)
			return;

		var artifact = s.EnumerateAllArtifacts().OfType<SoulSiphonArtifact>().FirstOrDefault();
		if (artifact is null)
			return;
		
		c.QueueImmediate(new AStatus() {status = ModEntry.Instance.SoulEnergyStatus.Status, statusAmount = 1, targetPlayer = true, artifactPulse = artifact.Key()});
		
	}

	public override void OnPlayerTakeNormalDamage(State state, Combat combat, int rawAmount, Part? part)
	{
		base.OnPlayerTakeNormalDamage(state, combat, rawAmount, part);
		combat.Queue(new AStatus() {statusAmount = -1, status = ModEntry.Instance.SoulEnergyStatus.Status, targetPlayer = true});
	}

	public override void OnTurnStart(State state, Combat combat)
	{
		base.OnTurnStart(state, combat);
		if (state.ship.Get(ModEntry.Instance.SoulEnergyStatus.Status) >= 10)
		{
			combat.Queue(new AStatus() {statusAmount = 1, status = ModEntry.Instance.FearStatus.Status, targetPlayer = false});
		}
	}
	
}
