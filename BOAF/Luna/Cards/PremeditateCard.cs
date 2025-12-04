using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using daisyowl.text;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class PremeditateCard : Card, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Cards.RegisterCard(MethodBase.GetCurrentMethod()!.DeclaringType!.Name, new()
		{
			CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				deck = ModEntry.Instance.LunaDeck.Deck,
				rarity = ModEntry.GetCardRarity(MethodBase.GetCurrentMethod()!.DeclaringType!),
				upgradesTo = [Upgrade.A, Upgrade.B],
			},
			Art = StableSpr.cards_colorless,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna","card", "Premeditate", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 1,
			floppable = true
		};

	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = new();
		
		CardAction actionB = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 1),
				new AStatus() { status = Status.energyNextTurn, statusAmount = 3, targetPlayer = true }).AsCardAction;
		CardAction actionNone = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 1),
				new AStatus() { status = Status.energyNextTurn, statusAmount = 2, targetPlayer = true }).AsCardAction;
		
		actionB.disabled = flipped;
		actionNone.disabled = flipped;
		
		if (upgrade == Upgrade.A)
		{
			actions.Add(new AStatus() { status = Status.drawNextTurn, statusAmount = 3, targetPlayer = true, disabled = flipped });
			actions.Add(actionNone);
			actions.Add(new ADummyAction());
			actions.Add(new AStatus() { status = Status.drawNextTurn, statusAmount = 3, targetPlayer = true, disabled = !flipped });
		} else if (upgrade == Upgrade.B)
		{
			actions.Add(new AStatus() { status = Status.drawNextTurn, statusAmount = 2, targetPlayer = true, disabled = flipped });
			actions.Add(actionB);
			actions.Add(new ADummyAction());
			actions.Add(new AStatus() { status = Status.drawNextTurn, statusAmount = 2, targetPlayer = true, disabled = !flipped });
		} else 
		{
			actions.Add(new AStatus() { status = Status.drawNextTurn, statusAmount = 2, targetPlayer = true, disabled = flipped });
			actions.Add(actionNone);
			actions.Add(new ADummyAction());
			actions.Add(new AStatus() { status = Status.drawNextTurn, statusAmount = 2, targetPlayer = true, disabled = !flipped });
		}
		return actions;
	}
};
