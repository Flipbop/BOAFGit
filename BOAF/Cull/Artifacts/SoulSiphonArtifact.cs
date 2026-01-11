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
				unremovable = true
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Cull/Artifacts/SoulSiphon.png")).Sprite,
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
		var artifact = s.EnumerateAllArtifacts().OfType<SoulSiphonArtifact>().FirstOrDefault();
		if (artifact is null)
			return;
		if (__instance.isPlayerShip)
		{
			if (s.ship.Get(ModEntry.Instance.SoulEnergyStatus.Status) <= 0) return;
			if (s.EnumerateAllArtifacts().OfType<CursedLanternArtifact>().FirstOrDefault() != null)
			{
				c.Queue(new AStatus() {statusAmount = -2, status = ModEntry.Instance.SoulEnergyStatus.Status, targetPlayer = true});
			}
			else
			{
				c.Queue(new AStatus() {statusAmount = -1, status = ModEntry.Instance.SoulEnergyStatus.Status, targetPlayer = true});
			}
			return;
		}
		if (s.ship.Get(ModEntry.Instance.SoulEnergyStatus.Status) >= 10) return;

		c.QueueImmediate(new AStatus() {status = ModEntry.Instance.SoulEnergyStatus.Status, statusAmount = 1, targetPlayer = true});
		if (c.otherShip.Get(ModEntry.Instance.SoulEnergyStatus.Status) >= 9)
		{
			c.Queue(new AStatus() {status = ModEntry.Instance.FearStatus.Status, statusAmount = 1, targetPlayer = false});
		}
	}
	

	public override void OnTurnStart(State state, Combat combat)
	{
		base.OnTurnStart(state, combat);
		if (state.ship.Get(ModEntry.Instance.SoulEnergyStatus.Status) >= 10)
		{
			combat.Queue(new AStatus() {statusAmount = 1, status = ModEntry.Instance.FearStatus.Status, targetPlayer = false});
		}
	}
	
	public override List<Tooltip>? GetExtraTooltips()
	{
		List<Tooltip> tooltips =
		[
			new GlossaryTooltip($"status.{ModEntry.Instance.Package.Manifest.UniqueName}::SoulEnergy")
			{
				Icon = ModEntry.Instance.soulEnergySprite.Sprite,
				TitleColor = Colors.status,
				Title = ModEntry.Instance.Localizations.Localize(["Cull", "status", "SoulEnergy", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Cull", "status", "SoulEnergy", "description"])
			}, new GlossaryTooltip($"status.{ModEntry.Instance.Package.Manifest.UniqueName}::Fear")
			{
				Icon = ModEntry.Instance.fearSprite.Sprite,
				TitleColor = Colors.status,
				Title = ModEntry.Instance.Localizations.Localize(["Cull", "status", "Fear", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Cull", "status", "Fear", "description"])
			}];
		return tooltips;
	}
	
}
