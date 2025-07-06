using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class SoulSiphonArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("SoulSiphon", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.CullDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!),
				
			},
			Sprite = ModEntry.Instance.placeholderSprite.Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "SoulSiphon", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "SoulSiphon", "description"]).Localize
		});
	}

	public override void OnEnemyGetHit(State state, Combat combat, Part? part)
	{
		base.OnEnemyGetHit(state, combat, part);
		combat.Queue(new AStatus() {statusAmount = 1, status = ModEntry.Instance.SoulEnergyStatus.Status, targetPlayer = true});
	}

	public override void OnPlayerTakeNormalDamage(State state, Combat combat, int rawAmount, Part? part)
	{
		base.OnPlayerTakeNormalDamage(state, combat, rawAmount, part);
		combat.Queue(new AStatus() {statusAmount = -1, status = ModEntry.Instance.SoulEnergyStatus.Status, targetPlayer = true});
	}

	public override void OnTurnStart(State state, Combat combat)
	{
		base.OnTurnStart(state, combat);
		if (state.ship.Get(ModEntry.Instance.SoulEnergyStatus.Status) >= 10)
		{
			combat.Queue(new AStatus() {statusAmount = 1, status = ModEntry.Instance.FearStatus.Status, targetPlayer = false});
		}
	}
}
