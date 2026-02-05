using System;
using System.Collections.Generic;
using System.Linq;
using Nanoray.PluginManager;
using Nickel;

namespace Flipbop.BOAF;

internal sealed class TempShieldDrone : ShieldDrone, IRegisterable
{
	private static ISpriteEntry DroneSprite = null!;
	private static ISpriteEntry DroneIcon = null!;

	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		DroneSprite = ModEntry.Instance.WispSprite;
		DroneIcon = ModEntry.Instance.WispIcon;
	}

	public override void Render(G g, Vec v)
		=> DrawWithHilight(g, DroneSprite.Sprite, v + GetOffset(g), flipY: targetPlayer);

	public override Spr? GetIcon()
		=> DroneIcon.Sprite;

	public override List<Tooltip> GetTooltips()
		=> [
			new GlossaryTooltip($"midrow.{ModEntry.Instance.Package.Manifest.UniqueName}::TempShieldDrone")
			{
				Icon = DroneIcon.Sprite,
				TitleColor = Colors.midrow,
				Title = ModEntry.Instance.Localizations.Localize(["Centi","midrow", "TempShieldDrone", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Centi","midrow", "TempShieldDrone", "description"]),
			},
			.. (bubbleShield ? [new TTGlossary("midrow.bubbleShield")] : Array.Empty<Tooltip>())
		];

	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = new List<CardAction>();
		actions = [new AAttack
		{
			fromDroneX = x,
			isBeam = true, 
			targetPlayer = !targetPlayer,
			statusAmount = 2,
			status = Status.tempShield
		}];
		return actions;
	}
}