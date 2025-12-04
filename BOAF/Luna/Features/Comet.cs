using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using Microsoft.Extensions.Logging;
using Nanoray.PluginManager;
using Nanoray.Shrike;
using Nanoray.Shrike.Harmony;
using Nickel;

namespace Flipbop.BOAF;

internal sealed class Comet : Asteroid, IRegisterable
{
	private static ISpriteEntry CometSprite = null!;
	private static ISpriteEntry CometIcon = null!;

	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		CometSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/Midrow/Comet.png"));
		CometIcon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/Icons/Comet.png"));
	}

	public override void Render(G g, Vec v)
		=> DrawWithHilight(g, CometSprite.Sprite, v + GetOffset(g), flipY: targetPlayer);

	public override Spr? GetIcon()
		=> CometIcon.Sprite;

	public override List<Tooltip> GetTooltips()
		=> [
			new GlossaryTooltip($"midrow.{ModEntry.Instance.Package.Manifest.UniqueName}::Comet")
			{
				Icon = CometIcon.Sprite,
				TitleColor = Colors.midrow,
				Title = ModEntry.Instance.Localizations.Localize(["Luna","midrow", "Comet", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Luna","midrow", "Comet", "description"]),
			},
			.. (bubbleShield ? [new TTGlossary("midrow.bubbleShield")] : Array.Empty<Tooltip>()),
			new GlossaryTooltip($"status.{ModEntry.Instance.Package.Manifest.UniqueName}::ResidualDust")
			{
				Icon = ModEntry.Instance.residualDustSprite.Sprite,
				TitleColor = Colors.status,
				Title = ModEntry.Instance.Localizations.Localize(["Luna","status", "ResidualDust", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Luna","status", "ResidualDust", "description"]),
				vals = [1]
			}
		];
	

	public override List<CardAction>? GetActionsOnDestroyed(State s, Combat c, bool wasPlayer, int worldX)
	{
		List<CardAction> actions = new List<CardAction>();
		actions.Add(new AStatus(){statusAmount = 1, status = ModEntry.Instance.ResidualDustStatus.Status, targetPlayer = true}); 
		return actions;
	}
}