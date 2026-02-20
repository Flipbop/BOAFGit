using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class ShieldSapperArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("ShieldSapper", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.CentiDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Centi/Artifacts/ShieldSapper.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi","artifact", "ShieldSapper", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Centi","artifact", "ShieldSapper", "description"]).Localize
		});
	}

	public override void OnTurnStart(State state, Combat combat)
	{
		base.OnTurnStart(state, combat);
		if (state.ship.Get(Status.shield) > 0)
		{
			combat.Queue(new AEnergy(){changeAmount = 1});
			combat.Queue(new AStatus(){status = Status.shield, statusAmount = -1, targetPlayer = true});
		}
	}
}
