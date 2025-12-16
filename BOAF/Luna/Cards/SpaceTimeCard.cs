using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class SpaceTimeCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/Cards/SpaceTime.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna", "card", "SpaceTime", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 2,
			floppable = upgrade != Upgrade.B
		};

	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = new();
		
		CardAction actionB = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 1),
				new AStatus() { status = Status.timeStop, statusAmount = 3, targetPlayer = true }).AsCardAction;
		CardAction actionNone = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 1),
				new AStatus() { status = Status.timeStop, statusAmount = 2, targetPlayer = true }).AsCardAction;
		
		actionNone.disabled = flipped;
		
		if (upgrade == Upgrade.A)
		{
			actions.Add(new AStatus(){statusAmount = 2, targetPlayer = true, status = Status.stunCharge, disabled = flipped});
			actions.Add(actionNone);
			actions.Add(new ADummyAction());
			actions.Add(new AStatus(){statusAmount = 3, targetPlayer = true, status = Status.stunCharge, disabled = !flipped});
		} else if (upgrade == Upgrade.B)
		{
			actions.Add(new AStatus(){statusAmount = 1, targetPlayer = true, status = Status.stunCharge});
			actions.Add(actionB);
		} else 
		{
			actions.Add(new AStatus(){statusAmount = 1, targetPlayer = true, status = Status.stunCharge, disabled = flipped});
			actions.Add(actionNone);
			actions.Add(new ADummyAction());
			actions.Add(new AStatus(){statusAmount = 2, targetPlayer = true, status = Status.stunCharge, disabled = !flipped});
		}
		return actions;
	}
}
