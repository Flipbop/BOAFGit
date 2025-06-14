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
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Artifacts/MagnifiedLasers.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "SoulSiphon", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "SoulSiphon", "description"]).Localize
		});
	}

	public override void OnEnemyGetHit(State state, Combat combat, Part? part)
	{
		base.OnEnemyGetHit(state, combat, part);
		combat.Queue(new AStatus() {statusAmount = 1, status = SoulEnergyManager.SoulEnergyStatus.Status, targetPlayer = true});
	}

	public override void OnPlayerTakeNormalDamage(State state, Combat combat, int rawAmount, Part? part)
	{
		base.OnPlayerTakeNormalDamage(state, combat, rawAmount, part);
		combat.Queue(new AStatus() {statusAmount = -1, status = SoulEnergyManager.SoulEnergyStatus.Status, targetPlayer = true});
	}
}
