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

internal sealed class Wisp : AttackDrone, IRegisterable
{
	private static ISpriteEntry WispSprite = null!;
	private static ISpriteEntry WispIcon = null!;

	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		WispSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Midrow/Wisp.png"));
		WispIcon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Icons/WispIcon.png"));
	}

	public override void Render(G g, Vec v)
		=> DrawWithHilight(g, WispSprite.Sprite, v + GetOffset(g), flipY: targetPlayer);

	public override Spr? GetIcon()
		=> WispIcon.Sprite;

	public override List<Tooltip> GetTooltips()
		=> [
			new GlossaryTooltip($"midrow.{ModEntry.Instance.Package.Manifest.UniqueName}::Wisp")
			{
				Icon = WispIcon.Sprite,
				TitleColor = Colors.midrow,
				Title = ModEntry.Instance.Localizations.Localize(["Cull","midrow", "Wisp", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Cull","midrow", "Wisp", "description"]),
			},
			.. (bubbleShield ? [new TTGlossary("midrow.bubbleShield")] : Array.Empty<Tooltip>())
		];

	public override List<CardAction> GetActions(State s, Combat c)
	{
		var attack = new AAttack
		{
			fromDroneX = x,
			damage = 1, 
			targetPlayer = targetPlayer,
		};
		return [attack];
	}
}