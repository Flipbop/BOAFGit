using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;

namespace Flipbop.BOAF;

internal sealed class ChronomancyArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("Chronomancy", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.LunaDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!),
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Luna/Artifacts/Chronomancy.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna","artifact", "Chronomancy", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Luna","artifact", "Chronomancy", "description"]).Localize
		});
	}
	
	public override List<Tooltip>? GetExtraTooltips()
	{
		List<Tooltip> tooltips =
		[
			new GlossaryTooltip($"status.{ModEntry.Instance.Package.Manifest.UniqueName}::Stardust")
			{
				Icon = ModEntry.Instance.stardustSprite.Sprite,
				TitleColor = Colors.status,
				Title = ModEntry.Instance.Localizations.Localize(["Luna", "status", "Stardust", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Luna", "status", "Stardust", "description"])
			}];
		tooltips.Add(new TTGlossary("status.timestop", 1));
		return tooltips;
	}
}
