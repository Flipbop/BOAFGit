using System.Collections.Generic;
using HarmonyLib;
using Nanoray.PluginManager;
using Nickel;
using System.Linq;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class DebrisNetArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("ReactiveMaterials", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.JayDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Jay/Artifacts/ReactiveMaterials.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Jay","artifact", "ReactiveMaterials", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Jay","artifact", "ReactiveMaterials", "description"]).Localize
		});
	}
	public override void OnPlayerTakeNormalDamage(State state, Combat combat, int rawAmount, Part? part)
	{
		base.OnPlayerTakeNormalDamage(state, combat, rawAmount, part);
		combat.QueueImmediate(new AReconfigure(){Amount = 1});
		combat.QueueImmediate(new ADetect(){Amount = 1});
	}
	
	public override List<Tooltip>? GetExtraTooltips()
	{
		List<Tooltip> tooltips = [new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::Reconfigure")
		{
			Icon = ModEntry.Instance.reconfigureSprite.Sprite,
			TitleColor = Colors.action,
			Title = ModEntry.Instance.Localizations.Localize(["Jay", "action", "Reconfigure", "name"]),
			Description = ModEntry.Instance.Localizations.Localize(["Jay", "action", "Reconfigure", "description"]),
			vals = [1]
		}, new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::Detect") {
			Icon = ModEntry.Instance.detectSprite.Sprite,
			TitleColor = Colors.action,
			Title = ModEntry.Instance.Localizations.Localize(["Jay","action", "Detect", "name"]),
			Description = ModEntry.Instance.Localizations.Localize(["Jay","action", "Detect", "description"]),
			vals = [1]
		}];
		return tooltips;
	}
}
