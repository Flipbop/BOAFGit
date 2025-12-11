using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

public class AthenaTacticsCard : Card, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Cards.RegisterCard(MethodBase.GetCurrentMethod()!.DeclaringType!.Name, new()
		{
			CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				deck = Deck.colorless,
				rarity = ModEntry.GetCardRarity(MethodBase.GetCurrentMethod()!.DeclaringType!),
				dontOffer = true
			},
			Art = StableSpr.cards_colorless,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["ship", "card", "AthenaTactics", "name"]).Localize
		});
	}

	public List<CardAction> actions = null!;
	public CardData data;
	
	public AthenaTacticsCard(List<CardAction> actions, CardData data)
	{
		this.actions = actions;
		this.data = data;
	}

	public AthenaTacticsCard() {}

	public override CardData GetData(State state)
	{
		if (state.route is NewRunOptions or CardBrowse { browseSource: CardBrowse.Source.Codex })
			return new CardData
			{
				cost = 0,
				description = "This card currently has no effect."
			};

		data.floppable = false;
		return data;
	}

	public override List<CardAction> GetActions(State s, Combat c)
	{
		if (s.route is NewRunOptions or CardBrowse { browseSource: CardBrowse.Source.Codex })
			return new List<CardAction>();

		return actions;
	}
}
