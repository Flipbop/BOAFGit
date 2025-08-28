using HarmonyLib;
using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class AnimismArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("Animism", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.CullDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites
				.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Cull/Artifacts/Animism.png"))
				.Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull", "artifact", "Animism", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Cull", "artifact", "Animism", "description"])
				.Localize
		});
	}

	public override void OnPlayerDestroyDrone(State state, Combat combat)
	{
		base.OnPlayerDestroyDrone(state, combat);
		combat.Queue(new AStatus() {statusAmount = 1, status = ModEntry.Instance.SoulEnergyStatus.Status, targetPlayer = true});
	}
}
