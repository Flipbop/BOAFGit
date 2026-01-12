using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;

namespace Flipbop.BOAF;

internal sealed class EnchantedScytheArtifact : Artifact, IRegisterable
{
	private static ISpriteEntry ActiveSprite = null!;
	private static ISpriteEntry InactiveSprite = null!;
	
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		ActiveSprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Cull/Artifacts/EnchantedScythe.png"));
		InactiveSprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Cull/Artifacts/EnchantedScytheOff.png"));
		
		helper.Content.Artifacts.RegisterArtifact("EnchantedScythe", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.CullDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = InactiveSprite.Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "EnchantedScythe", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "EnchantedScythe", "description"]).Localize
		});
		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(Ship), nameof(Ship.DirectHullDamage)),
			prefix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Ship_DirectHullDamage_Prefix)),
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Ship_DirectHullDamage_Postfix))
		);
	}

	public bool currentlyActive = false;
	public override int ModifyBaseDamage(int baseDamage, Card? card, State state, Combat? combat, bool fromPlayer)
	{
		if (state.ship.Get(ModEntry.Instance.SoulEnergyStatus.Status) >= 5 && fromPlayer)
		{
			currentlyActive = true;
			return base.ModifyBaseDamage(baseDamage, card, state, combat, fromPlayer) +1;
		}
		currentlyActive = false;
		return base.ModifyBaseDamage(baseDamage, card, state, combat, fromPlayer);
	}

	public override void OnCombatEnd(State state)
	{
		currentlyActive = false;
	}
	
	private void Ship_DirectHullDamage_Prefix(Ship __instance, out int __state)
		=> __state = __instance.hull;

	private void Ship_DirectHullDamage_Postfix(Ship __instance, State s, Combat c, in int __state)
	{
		var damageTaken = __state - __instance.hull;
		if (damageTaken <= 0)
			return;

		if (!__instance.isPlayerShip)
		{
			if (s.ship.Get(ModEntry.Instance.SoulEnergyStatus.Status) == 5) currentlyActive = false;
			
			return;
		}
		if (s.ship.Get(ModEntry.Instance.SoulEnergyStatus.Status) == 4) currentlyActive = true;
	}

	public override Spr GetSprite()
	{
		if (currentlyActive)
		{
			return ActiveSprite.Sprite;
		}
		return InactiveSprite.Sprite;
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
			}];
		return tooltips;
	}
}
