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
	private static ISpriteEntry DormantWispIcon = null!;

	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		WispSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Midrow/Wisp.png"));
		WispIcon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Icons/WispIcon.png"));
		DormantWispIcon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Icons/DormantWispIcon.png"));
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
			new GlossaryTooltip($"midrow.{ModEntry.Instance.Package.Manifest.UniqueName}::DormantWisp")
			{
				Icon = DormantWispIcon.Sprite,
				TitleColor = Colors.midrow,
				Title = ModEntry.Instance.Localizations.Localize(["Cull","midrow", "DormantWisp", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Cull","midrow", "DormantWisp", "description"]),
			},
			.. (bubbleShield ? [new TTGlossary("midrow.bubbleShield")] : Array.Empty<Tooltip>())
		];
	
	public required int DeathTurn {get;set;}

	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = [new AAttack
		{
			fromDroneX = x,
			damage = 1, 
			targetPlayer = targetPlayer,
		}];
		if (c.turn >= DeathTurn - 1)
		{
			actions.Add(new ASpawnFromMidrow() {thing = new DormantWisp(), worldX = x, byPlayer = false});
		}
		return actions;
	}

	public override bool Invincible()
	{
		return true;
	}
}






internal sealed class DormantWisp : AttackDrone, IRegisterable
{
	private static ISpriteEntry DormantWispSprite = null!;
	private static ISpriteEntry DormantWispIcon = null!;

	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		DormantWispSprite =
			helper.Content.Sprites.RegisterSprite(
				package.PackageRoot.GetRelativeFile("assets/Cull/Midrow/DormantWisp.png"));
		DormantWispIcon =
			helper.Content.Sprites.RegisterSprite(
				package.PackageRoot.GetRelativeFile("assets/Cull/Icons/DormantWispIcon.png"));
	}

	public override void Render(G g, Vec v)
		=> DrawWithHilight(g, DormantWispSprite.Sprite, v + GetOffset(g), flipY: targetPlayer);

	public override Spr? GetIcon()
		=> DormantWispIcon.Sprite;

	public override List<Tooltip> GetTooltips()
		=>
		[
			new GlossaryTooltip($"midrow.{ModEntry.Instance.Package.Manifest.UniqueName}::DormantWisp")
			{
				Icon = DormantWispIcon.Sprite,
				TitleColor = Colors.midrow,
				Title = ModEntry.Instance.Localizations.Localize(["Cull", "midrow", "DormantWisp", "name"]),
				Description =
					ModEntry.Instance.Localizations.Localize(["Cull", "midrow", "DormantWisp", "description"]),
			},
			.. (bubbleShield ? [new TTGlossary("midrow.bubbleShield")] : Array.Empty<Tooltip>())
		];
	
	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions =
		[
			new AAttack
			{
				fromDroneX = x,
				damage = 1,
				targetPlayer = targetPlayer,
			}
		];
		actions.Add(new AKillThisDrone { droneX = this.x });
		return actions;
	}
	public override bool Invincible()
	{
		return true;
	}

	public override List<CardAction>? GetActionsOnShotWhileInvincible(State s, Combat c, bool wasPlayer, int damage)
	{
		List<CardAction> actions = [
			new ASpawnFromMidrow() {thing = new Wisp(){DeathTurn = 1 + c.turn}, worldX = x, byPlayer = wasPlayer}];
		return actions;
	}

	public override List<CardAction>? GetActionsOnBonkedWhileInvincible(State s, Combat c, bool wasPlayer, StuffBase thing)
	{
		List<CardAction> actions = [
			new ASpawnFromMidrow() {thing = new Wisp(){DeathTurn = 1 + c.turn}, worldX = x, byPlayer = wasPlayer}];
		return actions;
	}
}






internal sealed class GreaterWisp : AttackDrone, IRegisterable
{
	private static ISpriteEntry GreaterWispSprite = null!;
	private static ISpriteEntry GreaterWispIcon = null!;
	private static ISpriteEntry DormantGreaterWispIcon = null!;

	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		GreaterWispSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Midrow/GreaterWisp.png"));
		GreaterWispIcon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Icons/GreaterWispIcon.png"));
		DormantGreaterWispIcon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Icons/DormantGreaterWispIcon.png"));
	}

	public override void Render(G g, Vec v)
		=> DrawWithHilight(g, GreaterWispSprite.Sprite, v + GetOffset(g), flipY: targetPlayer);

	public override Spr? GetIcon()
		=> GreaterWispIcon.Sprite;

	public override List<Tooltip> GetTooltips()
		=> [
			new GlossaryTooltip($"midrow.{ModEntry.Instance.Package.Manifest.UniqueName}::GreaterWisp")
			{
				Icon = GreaterWispIcon.Sprite,
				TitleColor = Colors.midrow,
				Title = ModEntry.Instance.Localizations.Localize(["Cull","midrow", "GreaterWisp", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Cull","midrow", "GreaterWisp", "description"]),
			},
			new GlossaryTooltip($"midrow.{ModEntry.Instance.Package.Manifest.UniqueName}::DormantWisp")
			{
				Icon = DormantGreaterWispIcon.Sprite,
				TitleColor = Colors.midrow,
				Title = ModEntry.Instance.Localizations.Localize(["Cull","midrow", "DormantGreaterWisp", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Cull","midrow", "DormantGreaterWisp", "description"]),
			},
			.. (bubbleShield ? [new TTGlossary("midrow.bubbleShield")] : Array.Empty<Tooltip>())
		];
	
	public required int DeathTurn {get;set;}

	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = [new AAttack
		{
			fromDroneX = x,
			damage = 2, 
			targetPlayer = targetPlayer,
		}];
		if (c.turn >= DeathTurn - 1)
		{
			actions.Add(new ASpawnFromMidrow() {thing = new DormantGreaterWisp(), worldX = x, byPlayer = false});
		}
		return actions;
	}

	public override bool Invincible()
	{
		return true;
	}
}






internal sealed class DormantGreaterWisp : AttackDrone, IRegisterable
{
	private static ISpriteEntry DormantGreaterWispSprite = null!;
	private static ISpriteEntry DormantGreaterWispIcon = null!;

	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		DormantGreaterWispSprite =
			helper.Content.Sprites.RegisterSprite(
				package.PackageRoot.GetRelativeFile("assets/Cull/Midrow/DormantGreaterWisp.png"));
		DormantGreaterWispIcon =
			helper.Content.Sprites.RegisterSprite(
				package.PackageRoot.GetRelativeFile("assets/Cull/Icons/DormantGreaterWispIcon.png"));
	}

	public override void Render(G g, Vec v)
		=> DrawWithHilight(g, DormantGreaterWispSprite.Sprite, v + GetOffset(g), flipY: targetPlayer);

	public override Spr? GetIcon()
		=> DormantGreaterWispIcon.Sprite;

	public override List<Tooltip> GetTooltips()
		=>
		[
			new GlossaryTooltip($"midrow.{ModEntry.Instance.Package.Manifest.UniqueName}::DormantGreaterWisp")
			{
				Icon = DormantGreaterWispIcon.Sprite,
				TitleColor = Colors.midrow,
				Title = ModEntry.Instance.Localizations.Localize(["Cull", "midrow", "DormantGreaterWisp", "name"]),
				Description =
					ModEntry.Instance.Localizations.Localize(["Cull", "midrow", "DormantGreaterWisp", "description"]),
			},
			.. (bubbleShield ? [new TTGlossary("midrow.bubbleShield")] : Array.Empty<Tooltip>())
		];
	
	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions =
		[
			new AAttack
			{
				fromDroneX = x,
				damage = 2,
				targetPlayer = targetPlayer,
			}
		];
		actions.Add(new AKillThisDrone { droneX = this.x });
		return actions;
	}
	public override bool Invincible()
	{
		return true;
	}

	public override List<CardAction>? GetActionsOnShotWhileInvincible(State s, Combat c, bool wasPlayer, int damage)
	{
		List<CardAction> actions = [
			new ASpawnFromMidrow() {thing = new GreaterWisp(){DeathTurn = 1 + c.turn}, worldX = x, byPlayer = wasPlayer}];
		return actions;
	}

	public override List<CardAction>? GetActionsOnBonkedWhileInvincible(State s, Combat c, bool wasPlayer, StuffBase thing)
	{
		List<CardAction> actions = [
			new ASpawnFromMidrow() {thing = new GreaterWisp(){DeathTurn = 1 + c.turn}, worldX = x, byPlayer = wasPlayer}];
		return actions;
	}
}

public sealed class AKillThisDrone : CardAction
{
	public required int droneX;
	public bool fromPlayer = false; 
  
	public override void Begin(G g, State s, Combat c)
	{
		c.DestroyDroneAt(s, droneX, fromPlayer);
	}
}