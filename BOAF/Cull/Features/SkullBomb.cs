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

internal sealed class SkullBomb : SpaceMine, IRegisterable
{
	private static ISpriteEntry BombSprite = null!;
	private static ISpriteEntry BombIcon = null!;

	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		BombSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Midrow/Wisp.png"));
		BombIcon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Icons/WispIcon.png"));
	}

	public override void Render(G g, Vec v)
		=> DrawWithHilight(g, BombSprite.Sprite, v + GetOffset(g), flipY: targetPlayer);

	public override Spr? GetIcon()
		=> BombIcon.Sprite;

	public override List<Tooltip> GetTooltips()
		=> [
			new GlossaryTooltip($"midrow.{ModEntry.Instance.Package.Manifest.UniqueName}::Wisp")
			{
				Icon = BombIcon.Sprite,
				TitleColor = Colors.midrow,
				Title = ModEntry.Instance.Localizations.Localize(["Cull","midrow", "Skullbomb", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Cull","midrow", "SkullBomb", "description"]),
			},
			.. (bubbleShield ? [new TTGlossary("midrow.bubbleShield")] : Array.Empty<Tooltip>())
		];

	public required int DeathTurn {get;set;}

	public override List<CardAction>? GetActionsOnDestroyed(State s, Combat c, bool wasPlayer, int worldX)
	{
		List<CardAction> actions = [
			new AAttack() {damage = 3, fromDroneX = worldX, targetPlayer = false}, 
			new AAttack() {damage = 3, fromDroneX = worldX, targetPlayer = true}
		];
		if (c.turn >= DeathTurn)
			actions.Add(new AKillThisDrone{droneX = this.x});
		return actions;
	}
}