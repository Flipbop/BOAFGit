using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class NorthStarCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/Cards/NorthStar.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna","card", "NorthStar", "name"]).Localize
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
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 2),
				new AStatus() { status = Status.evade, statusAmount = 4, targetPlayer = true }).AsCardAction;
		CardAction actionA = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 1),
				new AStatus() { status = Status.evade, statusAmount = 3, targetPlayer = true }).AsCardAction;
		CardAction actionNone = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 1),
				new AStatus() { status = Status.evade, statusAmount = 2, targetPlayer = true }).AsCardAction;
		
		actionB.disabled = flipped;
		actionA.disabled = flipped;
		actionNone.disabled = flipped;
		
		if (upgrade == Upgrade.A)
		{
			actions.Add(new AMove(){dir = 2, disabled = flipped});
			actions.Add(actionA);
			actions.Add(new ADummyAction());
			actions.Add(new AMove(){dir = -3, disabled = !flipped});
		} else if (upgrade == Upgrade.B)
		{
			actions.Add(new AMove(){dir = 2, disabled = flipped});
			actions.Add(actionB);
			actions.Add(new ADummyAction());
			actions.Add(new AStatus() { status = Status.evade, statusAmount = 1, targetPlayer = true });
		} else 
		{
			actions.Add(new AMove(){dir = 2, disabled = flipped});
			actions.Add(actionNone);
			actions.Add(new ADummyAction());
			actions.Add(new AMove(){dir = -2, disabled = !flipped});
		}
		return actions;
	}
}
