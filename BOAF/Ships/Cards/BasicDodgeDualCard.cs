using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class BasicDodgeDualCard : Card, IRegisterable
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
				upgradesTo = [Upgrade.A, Upgrade.B],
				dontOffer = true
			},
			Art = StableSpr.cards_colorless,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["ship", "card", "BasicDodgeDual", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = upgrade == Upgrade.None ? 1 : 0,
			floppable = true,
			exhaust = upgrade == Upgrade.B,
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.B => [
				new AStatus(){status = Status.evade, statusAmount = 2, targetPlayer = true, disabled = flipped},
				new ADummyAction(),
				new AStatus(){status = Status.droneShift, statusAmount = 2, targetPlayer = true, disabled = !flipped},
			],
			_ => [
				new AStatus(){status = Status.evade, statusAmount = 1, targetPlayer = true, disabled = flipped},
				new ADummyAction(),
				new AStatus(){status = Status.droneShift, statusAmount = 1, targetPlayer = true, disabled = !flipped},
			]
		};
}
