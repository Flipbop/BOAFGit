using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;

namespace Flipbop.BOAF;

internal sealed class BackupCrystalArtifact : Artifact, IRegisterable
{
	private static ISpriteEntry ActiveSprite = null!;
	private static ISpriteEntry InactiveSprite = null!;

	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		
		ActiveSprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Luna/Artifacts/BackupCrystal.png"));
		InactiveSprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Luna/Artifacts/BackupCrystalUsed.png"));
		
		helper.Content.Artifacts.RegisterArtifact("BackupCrystal", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.LunaDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!),
			},
			Sprite = ActiveSprite.Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna","artifact", "BackupCrystal", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Luna","artifact", "BackupCrystal", "description"]).Localize
		});
	}

	public bool used = false;

	public override void OnReceiveArtifact(State state)
	{
		base.OnReceiveArtifact(state);
		used = false;
	}

	public override Spr GetSprite()
	{
		if (!used)
		{
			return ActiveSprite.Sprite;
		}
		return InactiveSprite.Sprite;
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
		return tooltips;
	}
}
