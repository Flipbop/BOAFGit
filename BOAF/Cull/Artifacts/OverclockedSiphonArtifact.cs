using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class OverclockedSiphonArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("OverclockedSiphon", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.CullDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Artifacts/Kickstart.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "OverclockedSiphon", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "OverclockedSiphon", "description"]).Localize
		});
	}

	public override List<Tooltip>? GetExtraTooltips()
		=> [new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::Improve A")
			{
				Icon = ModEntry.Instance.ImprovedIcon.Sprite,
				TitleColor = Colors.action,
				Title = ModEntry.Instance.Localizations.Localize(["action", "ImproveA", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["action", "ImproveA", "description"])
			}];

	public override void OnCombatStart(State state, Combat combat)
	{
		base.OnCombatStart(state, combat);
		int Amount = 2;
		int index = state.deck.Count -1;
		while (index >= 0 && Amount > 0)
		{
			
		}
	}
}
