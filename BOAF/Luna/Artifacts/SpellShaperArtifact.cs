using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;

namespace Flipbop.BOAF;

internal sealed class SpellShaperArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("SpellShaper", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.LunaDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!),
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Luna/Artifacts/SpellShaper.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna","artifact", "SpellShaper", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Luna","artifact", "SpellShaper", "description"]).Localize
		});
	}

	public bool used = false;
	public override void OnPlayerPlayCard(int energyCost, Deck deck, Card card, State state, Combat combat, int handPosition,
		int handCount)
	{
		base.OnPlayerPlayCard(energyCost, deck, card, state, combat, handPosition, handCount);
		if (card.GetData(state).floppable && used == false)
		{
			combat.QueueImmediate(new AEnergy(){changeAmount = 1});
			used = true;
		}
	}

	public override void OnTurnStart(State state, Combat combat)
	{
		base.OnTurnStart(state, combat);
		used = false;
	}
}
