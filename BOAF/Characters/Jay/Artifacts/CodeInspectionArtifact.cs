using HarmonyLib;
using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class CodeInspectionArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("CodeInspection", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.JayDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites
				.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Jay/Artifacts/CodeInspection.png"))
				.Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Jay", "artifact", "CodeInspection", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Jay", "artifact", "CodeInspection", "description"])
				.Localize
		});
	}

	public override void OnReceiveArtifact(State state)
	{
		base.OnReceiveArtifact(state);
		AReconfigure.codeInspectionAmount = 0;
	}

	public override int? GetDisplayNumber(State s)
	{
		return AReconfigure.codeInspectionAmount;
	}

	public override List<Tooltip>? GetExtraTooltips()
	{
		List<Tooltip> tooltips = [new TTCard { card = new InspectionCard() }, new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::Reconfigure")
		{
			Icon = ModEntry.Instance.reconfigureSprite.Sprite,
			TitleColor = Colors.action,
			Title = ModEntry.Instance.Localizations.Localize(["Jay", "action", "Reconfigure", "name"]),
			Description = ModEntry.Instance.Localizations.Localize(["Jay", "action", "Reconfigure", "description"]),
			vals = [1]
		}];
		return tooltips;
	}
}
