using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class EnhancedSensorsArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("EnhancedSensors", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.JayDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Jay/Artifacts/OverclockedSiphon.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Jay","artifact", "OverclockedSiphon", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Jay","artifact", "OverclockedSiphon", "description"]).Localize
		});
	}

	public int turnCounter = 0;

	public override void OnTurnStart(State state, Combat combat)
	{
		base.OnTurnStart(state, combat);
		if (turnCounter >= 2)
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
