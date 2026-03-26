using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class CentiExeCard : Card, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Cards.RegisterCard("CentiExe", new()
		{
			CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				deck = Deck.colorless,
				rarity = Rarity.uncommon,
				upgradesTo = [Upgrade.A, Upgrade.B]
			},
			Art = StableSpr.cards_colorless,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi", "card", "CentiExe", "name"]).Localize
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
			description = ModEntry.Instance.Localizations.Localize(["Centi","card", "CentiExe", "description", upgrade.ToString()], new { Count = GetChoiceCount() })
		};

	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = new(); 
		
		var rand = new Rand(s.rngCurrentEvent.seed);
		var potentialCore = new WeightedRandom<Core>();
		potentialCore.Add(new(25,new DemonCore()));
		potentialCore.Add(new(25,new AquaCore()));
		potentialCore.Add(new(25,new StoneCore()));
		potentialCore.Add(new(8,new LavaCore()));
		potentialCore.Add(new(8,new MossCore()));
		potentialCore.Add(new(8,new BrimstoneCore()));
		potentialCore.Add(new(1,new InfinityCore()));
		var core = potentialCore.Next(rand);
		
		actions.Add(new ASpawn{thing = core});
		actions.Add(new ACardOffering
		{
			amount = GetChoiceCount(),
			limitDeck = ModEntry.Instance.CentiDeck.Deck,
			makeAllCardsTemporary = true,
			overrideUpgradeChances = false,
			canSkip = false,
			inCombat = true,
			discount = -1,
			dialogueSelector = $".summon{ModEntry.Instance.CentiDeck.UniqueName}"
		});
		
		return actions;
	}
}
