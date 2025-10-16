using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class BlueprintsArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("Blueprints", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.JayDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Jay/Artifacts/Blueprints.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Jay","artifact", "Blueprints", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Jay","artifact", "Blueprints", "description"]).Localize
		});
	}

	public override void OnReceiveArtifact(State state)
	{
		base.OnReceiveArtifact(state);
		state.ship.parts.Add(new Part() {type = PType.empty, skin = "wing_player_off", flip = true});
		state.ship.parts.Insert(0, new Part() {type = PType.empty, skin = "wing_player_off"});
	}
}
