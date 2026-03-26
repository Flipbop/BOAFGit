using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class LunaExeCard : Card, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Cards.RegisterCard("LunaExe", new()
		{
			CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				deck = Deck.colorless,
				rarity = Rarity.uncommon,
				upgradesTo = [Upgrade.A, Upgrade.B]
			},
			Art = StableSpr.cards_colorless,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna", "card", "LunaExe", "name"]).Localize
		});
	}

	private int GetChoiceCount()
		=> upgrade == Upgrade.B ? 3 : 2;

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "ffffff",
			cost = upgrade == Upgrade.A ? 0 : 1,
			exhaust = true,
			description = ModEntry.Instance.Localizations.Localize(["Luna","card", "LunaExe", "description", upgrade.ToString()], new { Count = GetChoiceCount() })
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> [
			new AShimmeredCardOffering
			{
				amount = GetChoiceCount(),
				limitDeck = ModEntry.Instance.LunaDeck.Deck,
				makeAllCardsTemporary = true,
				overrideUpgradeChances = false,
				canSkip = false,
				inCombat = true,
				discount = -1,
				dialogueSelector = $".summon{ModEntry.Instance.LunaDeck.UniqueName}"
			}
		];
}

public class AShimmeredCardOffering : ACardOffering
{
	public override Route? BeginWithRoute(G g, State s, Combat c)
	{
		var route = (CardReward?) base.BeginWithRoute(g, s, c);
		if (route?.cards != null)
			foreach (Card card in route.cards)
			{
				card.SetIsShimmered(true);
			}
		return route;
	}
}
