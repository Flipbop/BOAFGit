using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;

namespace Flipbop.BOAF;

internal sealed class LunarPendantArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("LunarPendant", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.LunaDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!),
				unremovable = true
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Luna/Artifacts/LunarPendant.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna","artifact", "LunarPendant", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Luna","artifact", "LunarPendant", "description"]).Localize
		});
	}

	public int StardustCount = 10;
	private BattleType type = BattleType.Normal;
	
	public override void OnCombatStart(State state, Combat combat)
	{
		base.OnCombatStart(state, combat);
		combat.QueueImmediate(new AStatus(){statusAmount = StardustCount, targetPlayer = true, status = ModEntry.Instance.StardustStatus.Status});

		if (state.map.markers[state.map.currentLocation].contents is MapBattle mb)
		{
			if (mb.battleType == BattleType.Elite)
			{
				type = BattleType.Elite;
			} else if (mb.battleType == BattleType.Boss)
			{
				type = BattleType.Boss;
			} else
			{
				type = BattleType.Normal;
			}
		}
	}

	public override void OnCombatEnd(State state)
	{
		base.OnCombatEnd(state);
		StardustCount = state.ship.Get(ModEntry.Instance.StardustStatus.Status);
		int bonusDust = state.ship.Get(ModEntry.Instance.ResidualDustStatus.Status);
		if (type == BattleType.Normal)
		{
			StardustCount += bonusDust;
			if (state.EnumerateAllArtifacts().Any((a) => a is StellarCharmArtifact))
			{
				StardustCount += 1;
			}
		} else if (type == BattleType.Elite)
		{
			StardustCount += bonusDust;
			if (state.EnumerateAllArtifacts().Any((a) => a is StellarCharmArtifact))
			{
				StardustCount += 1;
			}
		} else if (type == BattleType.Boss)
		{
			StardustCount += 10 + bonusDust;
			if (state.EnumerateAllArtifacts().Any((a) => a is StellarCharmArtifact))
			{
				StardustCount += 1;
			}
		}
		if (StardustCount > StardustManager.StardustMax || state.ship.hull <= 0)
		{
			StardustCount = StardustManager.StardustMax;
		}
	}
	
	public override int? GetDisplayNumber(State s)
	{
		if (s.route is Combat) 
		{
			return null;
		}
		return StardustCount;
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
