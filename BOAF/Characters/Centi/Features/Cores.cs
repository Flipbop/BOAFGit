using System;
using System.Collections.Generic;
using System.Linq;
using Nanoray.PluginManager;
using Nickel;

namespace Flipbop.BOAF;

internal sealed class DemonCore : Asteroid, IRegisterable
{
	private static ISpriteEntry DemonCoreSprite = null!;
	private static ISpriteEntry DemonCoreIcon = null!;

	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		DemonCoreSprite = ModEntry.Instance.DemonCoreSprite;
		DemonCoreIcon = ModEntry.Instance.DemonCoreIcon;
	}

	public override void Render(G g, Vec v)
		=> DrawWithHilight(g, DemonCoreSprite.Sprite, v + GetOffset(g), flipY: targetPlayer);

	public override Spr? GetIcon()
		=> DemonCoreIcon.Sprite;

	public override List<Tooltip> GetTooltips()
		=> [
			new GlossaryTooltip($"midrow.{ModEntry.Instance.Package.Manifest.UniqueName}::DemonCore")
			{
				Icon = DemonCoreIcon.Sprite,
				TitleColor = Colors.midrow,
				Title = ModEntry.Instance.Localizations.Localize(["Centi","midrow", "DemonCore", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Centi","midrow", "DemonCore", "description"]),
			},
			.. (bubbleShield ? [new TTGlossary("midrow.bubbleShield")] : Array.Empty<Tooltip>())
		];

	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = new List<CardAction>();
		if (s.EnumerateAllArtifacts().Any((a) => a is DemonHeartArtifact))
		{
			actions = [new AAttack
			{
				fromDroneX = x,
				damage = 1, 
				targetPlayer = targetPlayer,
			}];
		}
		
		return actions;
	}
}


internal sealed class AquaCore : Asteroid, IRegisterable
{
	private static ISpriteEntry AquaCoreSprite = null!;
	private static ISpriteEntry AquaCoreIcon = null!;

	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		AquaCoreSprite = ModEntry.Instance.AquaCoreSprite;
		AquaCoreIcon = ModEntry.Instance.AquaCoreIcon;
	}

	public override void Render(G g, Vec v)
		=> DrawWithHilight(g, AquaCoreSprite.Sprite, v + GetOffset(g), flipY: targetPlayer);

	public override Spr? GetIcon()
		=> AquaCoreIcon.Sprite;

	public override List<Tooltip> GetTooltips()
		=> [
			new GlossaryTooltip($"midrow.{ModEntry.Instance.Package.Manifest.UniqueName}::AquaCore")
			{
				Icon = AquaCoreIcon.Sprite,
				TitleColor = Colors.midrow,
				Title = ModEntry.Instance.Localizations.Localize(["Centi","midrow", "AquaCore", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Centi","midrow", "AquaCore", "description"]),
			},
			.. (bubbleShield ? [new TTGlossary("midrow.bubbleShield")] : Array.Empty<Tooltip>())
		];

	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = new List<CardAction>();
		if (s.EnumerateAllArtifacts().Any((a) => a is AquaHeartArtifact))
		{
			actions = [new AAttack
			{
				fromDroneX = x,
				isBeam = true,
				targetPlayer = !targetPlayer,
				status = Status.tempShield,
				statusAmount = 2
			}];
		}
		
		return actions;
	}
}

internal sealed class StoneCore : Asteroid, IRegisterable
{
	private static ISpriteEntry StoneCoreSprite = null!;
	private static ISpriteEntry StoneCoreIcon = null!;

	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		StoneCoreSprite = ModEntry.Instance.StoneCoreSprite;
		StoneCoreIcon = ModEntry.Instance.StoneCoreIcon;
	}

	public override void Render(G g, Vec v)
		=> DrawWithHilight(g, StoneCoreSprite.Sprite, v + GetOffset(g), flipY: targetPlayer);

	public override Spr? GetIcon()
		=> StoneCoreIcon.Sprite;

	public override List<Tooltip> GetTooltips()
		=> [
			new GlossaryTooltip($"midrow.{ModEntry.Instance.Package.Manifest.UniqueName}::StoneCore")
			{
				Icon = StoneCoreIcon.Sprite,
				TitleColor = Colors.midrow,
				Title = ModEntry.Instance.Localizations.Localize(["Centi","midrow", "StoneCore", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Centi","midrow", "StoneCore", "description"]),
			},
			.. (bubbleShield ? [new TTGlossary("midrow.bubbleShield")] : Array.Empty<Tooltip>())
		];

	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = new List<CardAction>();
		if (s.EnumerateAllArtifacts().Any((a) => a is StoneHeartArtifact))
		{
			actions = [new AAttack
			{
				fromDroneX = x,
				isBeam = true,
				targetPlayer = !targetPlayer,
				status = Status.shield,
				statusAmount = 1
			}];
		}
		
		return actions;
	}
}

internal sealed class LavaCore : Asteroid, IRegisterable
{
	private static ISpriteEntry LavaCoreSprite = null!;
	private static ISpriteEntry LavaCoreIcon = null!;

	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		LavaCoreSprite = ModEntry.Instance.LavaCoreSprite;
		LavaCoreIcon = ModEntry.Instance.LavaCoreIcon;
	}

	public override void Render(G g, Vec v)
		=> DrawWithHilight(g, LavaCoreSprite.Sprite, v + GetOffset(g), flipY: targetPlayer);

	public override Spr? GetIcon()
		=> LavaCoreIcon.Sprite;

	public override List<Tooltip> GetTooltips()
		=> [
			new GlossaryTooltip($"midrow.{ModEntry.Instance.Package.Manifest.UniqueName}::LavaCore")
			{
				Icon = LavaCoreIcon.Sprite,
				TitleColor = Colors.midrow,
				Title = ModEntry.Instance.Localizations.Localize(["Centi","midrow", "LavaCore", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Centi","midrow", "LavaCore", "description"]),
			},
			.. (bubbleShield ? [new TTGlossary("midrow.bubbleShield")] : Array.Empty<Tooltip>())
		];

	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = new List<CardAction>();
		if (s.EnumerateAllArtifacts().Any((a) => a is AquaHeartArtifact))
		{
			actions = [new AAttack
			{
				fromDroneX = x,
				isBeam = true,
				targetPlayer = !targetPlayer,
				status = Status.tempShield,
				statusAmount = 2
			}];
		}
		if (s.EnumerateAllArtifacts().Any((a) => a is DemonHeartArtifact))
		{
			actions = [new AAttack
			{
				fromDroneX = x,
				damage = 1, 
				targetPlayer = targetPlayer,
			}];
		}
		
		return actions;
	}
}

internal sealed class BrimstoneCore : Asteroid, IRegisterable
{
	private static ISpriteEntry BrimstoneCoreSprite = null!;
	private static ISpriteEntry BrimstoneCoreIcon = null!;

	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		BrimstoneCoreSprite = ModEntry.Instance.BrimstoneCoreSprite;
		BrimstoneCoreIcon = ModEntry.Instance.BrimstoneCoreIcon;
	}

	public override void Render(G g, Vec v)
		=> DrawWithHilight(g, BrimstoneCoreSprite.Sprite, v + GetOffset(g), flipY: targetPlayer);

	public override Spr? GetIcon()
		=> BrimstoneCoreIcon.Sprite;

	public override List<Tooltip> GetTooltips()
		=> [
			new GlossaryTooltip($"midrow.{ModEntry.Instance.Package.Manifest.UniqueName}::BrimstoneCore")
			{
				Icon = BrimstoneCoreIcon.Sprite,
				TitleColor = Colors.midrow,
				Title = ModEntry.Instance.Localizations.Localize(["Centi","midrow", "BrimstoneCore", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Centi","midrow", "BrimstoneCore", "description"]),
			},
			.. (bubbleShield ? [new TTGlossary("midrow.bubbleShield")] : Array.Empty<Tooltip>())
		];

	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = new List<CardAction>();
		if (s.EnumerateAllArtifacts().Any((a) => a is StoneHeartArtifact))
		{
			actions = [new AAttack
			{
				fromDroneX = x,
				isBeam = true,
				targetPlayer = !targetPlayer,
				status = Status.shield,
				statusAmount = 1
			}];
		}
		if (s.EnumerateAllArtifacts().Any((a) => a is DemonHeartArtifact))
		{
			actions = [new AAttack
			{
				fromDroneX = x,
				damage = 1, 
				targetPlayer = targetPlayer,
			}];
		}
		
		return actions;
	}
}

internal sealed class MossCore : Asteroid, IRegisterable
{
	private static ISpriteEntry MossCoreSprite = null!;
	private static ISpriteEntry MossCoreIcon = null!;

	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		MossCoreSprite = ModEntry.Instance.MossCoreSprite;
		MossCoreIcon = ModEntry.Instance.MossCoreIcon;
	}

	public override void Render(G g, Vec v)
		=> DrawWithHilight(g, MossCoreSprite.Sprite, v + GetOffset(g), flipY: targetPlayer);

	public override Spr? GetIcon()
		=> MossCoreIcon.Sprite;

	public override List<Tooltip> GetTooltips()
		=> [
			new GlossaryTooltip($"midrow.{ModEntry.Instance.Package.Manifest.UniqueName}::MossCore")
			{
				Icon = MossCoreIcon.Sprite,
				TitleColor = Colors.midrow,
				Title = ModEntry.Instance.Localizations.Localize(["Centi","midrow", "MossCore", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Centi","midrow", "MossCore", "description"]),
			},
			.. (bubbleShield ? [new TTGlossary("midrow.bubbleShield")] : Array.Empty<Tooltip>())
		];

	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = new List<CardAction>();
		if (s.EnumerateAllArtifacts().Any((a) => a is StoneHeartArtifact))
		{
			actions = [new AAttack
			{
				fromDroneX = x,
				isBeam = true,
				targetPlayer = !targetPlayer,
				status = Status.shield,
				statusAmount = 1
			}];
		}
		if (s.EnumerateAllArtifacts().Any((a) => a is AquaHeartArtifact))
		{
			actions = [new AAttack
			{
				fromDroneX = x,
				isBeam = true,
				targetPlayer = !targetPlayer,
				status = Status.tempShield,
				statusAmount = 2
			}];
		}
		return actions;
	}
}

internal sealed class InfinityCore : Asteroid, IRegisterable
{
	private static ISpriteEntry InfinityCoreSprite = null!;
	private static ISpriteEntry InfinityCoreIcon = null!;

	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		InfinityCoreSprite = ModEntry.Instance.InfinityCoreSprite;
		InfinityCoreIcon = ModEntry.Instance.InfinityCoreIcon;
	}

	public override void Render(G g, Vec v)
		=> DrawWithHilight(g, InfinityCoreSprite.Sprite, v + GetOffset(g), flipY: targetPlayer);

	public override Spr? GetIcon()
		=> InfinityCoreIcon.Sprite;

	public override List<Tooltip> GetTooltips()
		=> [
			new GlossaryTooltip($"midrow.{ModEntry.Instance.Package.Manifest.UniqueName}::InfinityCore")
			{
				Icon = InfinityCoreIcon.Sprite,
				TitleColor = Colors.midrow,
				Title = ModEntry.Instance.Localizations.Localize(["Centi","midrow", "InfinityCore", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Centi","midrow", "InfinityCore", "description"]),
			},
			.. (bubbleShield ? [new TTGlossary("midrow.bubbleShield")] : Array.Empty<Tooltip>())
		];

	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = new List<CardAction>();
		if (s.EnumerateAllArtifacts().Any((a) => a is StoneHeartArtifact))
		{
			actions = [new AAttack
			{
				fromDroneX = x,
				isBeam = true,
				targetPlayer = !targetPlayer,
				status = Status.shield,
				statusAmount = 1
			}];
		}
		if (s.EnumerateAllArtifacts().Any((a) => a is AquaHeartArtifact))
		{
			actions = [new AAttack
			{
				fromDroneX = x,
				isBeam = true,
				targetPlayer = !targetPlayer,
				status = Status.tempShield,
				statusAmount = 2
			}];
		}
		if (s.EnumerateAllArtifacts().Any((a) => a is DemonHeartArtifact))
		{
			actions = [new AAttack
			{
				fromDroneX = x,
				damage = 1, 
				targetPlayer = targetPlayer,
			}];
		}
		return actions;
	}
}