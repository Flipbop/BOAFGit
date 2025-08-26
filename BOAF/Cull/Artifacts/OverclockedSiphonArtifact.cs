using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class OverclockedSiphonArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("OverclockedSiphon", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.CullDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Cull/Artifacts/Kickstart.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "OverclockedSiphon", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "OverclockedSiphon", "description"]).Localize
		});
	}

	public int turnCounter = 0;

	public override void OnTurnStart(State state, Combat combat)
	{
		base.OnTurnStart(state, combat);
		if (turnCounter >= 3)
		{
			combat.Queue(new AStatus(){targetPlayer = true, status = ModEntry.Instance.SoulEnergyStatus.Status, statusAmount = 1});
			turnCounter = 0;
		}
		else
		{
			turnCounter++;
		}
	}
	public override int? GetDisplayNumber(State s)
	{
		return turnCounter;
	}
}
