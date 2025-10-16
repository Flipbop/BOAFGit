using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class CellTowerArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("CellTower", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.JayDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Jay/Artifacts/CellTower.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Jay","artifact", "CellTower", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Jay","artifact", "CellTower", "description"]).Localize
		});
	}

	public override void OnReceiveArtifact(State state)
	{
		base.OnReceiveArtifact(state);
		state.ship.baseEnergy += 1;
	}
}
