using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class BattleTacticsArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("BattleTactics", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = Deck.colorless,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!),
				unremovable = true
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Ship/Athena/Artifacts/BattleTactics.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["ship","artifact", "BattleTactics", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["ship","artifact", "BattleTactics", "description"]).Localize
		});
	}
	
	public override void OnPlayerPlayCard(int energyCost, Deck deck, Card card, State state, Combat combat, int handPosition,
		int handCount)
	{
		base.OnPlayerPlayCard(energyCost, deck, card, state, combat, handPosition, handCount);

		if (card.GetData(state).floppable)
		{
			Card cardCopy = card.CopyWithNewId();
			List<CardAction> actions = new List<CardAction>();
			foreach (CardAction action in cardCopy.GetActions(state, combat))
			{
				if (action.disabled)
				{
					action.disabled = false;
					actions.Add(action);
				}
				else
				{
					actions.Add(new ADummyAction());
				}
			}
			Card newCard = new AthenaTacticsCard(actions, cardCopy.GetData(state))
			{
				temporaryOverride = true,
				exhaustOverride = true,
			};
			if (state.EnumerateAllArtifacts().Any((a) => a is EndlessPreparationsArtifact)) newCard.discount -= 1;
			combat.QueueImmediate(new AAddCard(){card = newCard, destination = CardDestination.Hand});
		}
	}

	public override List<Tooltip>? GetExtraTooltips()
		=> [new TTCard() {card = new AthenaTacticsCard()},
		];
}
