using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
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
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(AStatus_Begin_Postfix))
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
	
	private static void AStatus_Begin_Postfix(AStatus __instance, State s, Combat c)
	{
		// Only do this postfix if we have the artifact
		var artifact = s.EnumerateAllArtifacts().OfType<EnchantedScytheArtifact>().FirstOrDefault();

		if (artifact != null)
		{
			if (s.ship.Get(ModEntry.Instance.SoulEnergyStatus.Status) >= 5)
			{
				artifact.currentlyActive = true;
			}
			else
			{
				artifact.currentlyActive = false;
			}
		}
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
