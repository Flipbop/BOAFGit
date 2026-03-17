using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class BubbleGeneratorArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("BubbleGenerator", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = Deck.colorless,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!),
				unremovable = true
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Ship/Neptune/Artifacts/BubbleGenerator.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["ship","artifact", "BubbleGenerator", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["ship","artifact", "BubbleGenerator", "description"]).Localize
		});
	}

	public override void OnTurnStart(State state, Combat combat)
	{
		base.OnTurnStart(state, combat);
		combat.QueueImmediate(new AStatus() {status = Status.bubbleJuice, statusAmount = 1, targetPlayer = true});
	}
	
	
}
