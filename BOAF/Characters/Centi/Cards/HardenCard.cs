using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class HardenCard : Card, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Cards.RegisterCard(MethodBase.GetCurrentMethod()!.DeclaringType!.Name, new()
		{
			CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				deck = ModEntry.Instance.CentiDeck.Deck,
				rarity = ModEntry.GetCardRarity(MethodBase.GetCurrentMethod()!.DeclaringType!),
				upgradesTo = [Upgrade.A, Upgrade.B]
			},
			Art = StableSpr.cards_colorless,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi", "card", "Harden", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = upgrade == Upgrade.A ? 2 : 3,
			exhaust	= true
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.B => [
				new APartModManager.APartRebuild(){part = s.ship.parts[0], newPartType = PType.missiles, partName = "MISSILE BAY"},
				new ASpawn(){fromPlayer = true, thing = new Missile{missileType = MissileType.normal}},
				new AStatus(){status = Status.energyLessNextTurn, statusAmount = 1, targetPlayer = true}
			],
			_ => [
				new ASpawn(){fromPlayer = true, thing = new Missile{missileType = MissileType.normal}},
				new APartModManager.APartRebuild(){part = s.ship.parts[0], newPartType = PType.missiles, partName = "MISSILE BAY"},
				new AStatus(){status = Status.energyLessNextTurn, statusAmount = 1, targetPlayer = true}
			]
		};
}
