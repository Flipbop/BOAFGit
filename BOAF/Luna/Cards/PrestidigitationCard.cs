using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class PrestidigitationCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/Cards/Prestidigitation.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna", "card", "Prestidigitation", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = upgrade == Upgrade.B? 1 : 0,
			floppable = true,
		};

	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = new();
		
		CardAction actionB = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 1),
				new AStatus() { status = Status.stunCharge, statusAmount = 4, targetPlayer = true }).AsCardAction;
		CardAction actionA = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 1),
				new AStatus() { status = Status.stunCharge, statusAmount = 3, targetPlayer = true }).AsCardAction;
		CardAction actionNone = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 1),
				new AStatus() { status = Status.stunCharge, statusAmount = 2, targetPlayer = true }).AsCardAction;
		
		actionB.disabled = flipped;
		actionA.disabled = flipped;
		actionNone.disabled = flipped;
		
		if (upgrade == Upgrade.A)
		{
			actions.Add(actionA);
			actions.Add(new ADrawCard(){count = 1});
			actions.Add(new ADummyAction());
			actions.Add(new AStatus() { status = Status.stunCharge, statusAmount = 1, targetPlayer = true });
			actions.Add(new ADrawCard(){count = 1});
		} else if (upgrade == Upgrade.B)
		{
			actions.Add(actionB);
			actions.Add(new ADrawCard(){count = 2});
			actions.Add(new ADummyAction());
			actions.Add(new ADrawCard(){count = 2});
		} else 
		{
			actions.Add(actionNone);
			actions.Add(new ADrawCard(){count = 1});
			actions.Add(new ADummyAction());
			actions.Add(new ADrawCard(){count = 1});
		}
		return actions;
	}
}
