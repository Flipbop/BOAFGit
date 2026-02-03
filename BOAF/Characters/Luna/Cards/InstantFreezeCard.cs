using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class InstantFreezeCard : Card, IRegisterable
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
				upgradesTo = [Upgrade.A, Upgrade.B]
			},
			Art = StableSpr.cards_colorless,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna", "card", "InstantFreeze", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 1,
			floppable = upgrade != Upgrade.B
		};

	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = new();
		
		CardAction actionB = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 2),
				new AStatus() { status = Status.lockdown, statusAmount = 3, targetPlayer = false }).AsCardAction;
		CardAction actionA = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 1),
				new AStatus() { status = Status.lockdown, statusAmount = 2, targetPlayer = false  }).AsCardAction;
		CardAction actionNone = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 1),
				new AStatus() { status = Status.lockdown, statusAmount = 1, targetPlayer = false  }).AsCardAction;
		
		actionA.disabled = flipped;
		actionNone.disabled = flipped;
		
		if (upgrade == Upgrade.A)
		{
			actions.Add(actionA);
			actions.Add(new ADummyAction());
			actions.Add(new AStatus() { status = Status.lockdown, statusAmount = 2, targetPlayer = false, disabled  = !flipped});
			actions.Add(new AStatus() { status = Status.lockdown, statusAmount = 1, targetPlayer = true, disabled  = !flipped});
		} else if (upgrade == Upgrade.B)
		{
			actions.Add(actionB);
		} else 
		{
			actions.Add(actionNone);
			actions.Add(new ADummyAction());
			actions.Add(new AStatus() { status = Status.lockdown, statusAmount = 1, targetPlayer = false, disabled  = !flipped});
			actions.Add(new AStatus() { status = Status.lockdown, statusAmount = 1, targetPlayer = true, disabled  = !flipped});
		}
		return actions;
	}
}
