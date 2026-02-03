using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class DemonHeartArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("CellTower", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.JayDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Jay/Artifacts/CellTower.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Jay","artifact", "CellTower", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Jay","artifact", "CellTower", "description"]).Localize
		});
	}

	public override void OnCombatStart(State state, Combat combat)
	{
		base.OnCombatStart(state, combat);
		combat.QueueImmediate(new AStatus(){statusAmount = 1, targetPlayer = true, status = ModEntry.Instance.SignalBoosterStatus.Status});
	}
	
	public override List<Tooltip>? GetExtraTooltips()
	{
		List<Tooltip> tooltips = [
			new GlossaryTooltip($"status.{ModEntry.Instance.Package.Manifest.UniqueName}::SignalBooster")
			{
				Icon = ModEntry.Instance.signalBoosterSprite.Sprite,
				TitleColor = Colors.cardtrait,
				Title = ModEntry.Instance.Localizations.Localize(["Jay","status", "SignalBooster", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Jay","status", "SignalBooster", "description"])
			}	
		];
		return tooltips;
	}
}
