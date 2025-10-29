using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class CannonConstructorCard : Card, IRegisterable
{
	private static IKokoroApi.IV2.IConditionalApi Conditional => ModEntry.Instance.KokoroApi.Conditional;

	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Cards.RegisterCard(MethodBase.GetCurrentMethod()!.DeclaringType!.Name, new()
		{
			CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				deck = ModEntry.Instance.JayDeck.Deck,
				rarity = ModEntry.GetCardRarity(MethodBase.GetCurrentMethod()!.DeclaringType!),
				upgradesTo = [Upgrade.A, Upgrade.B]
			},
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/Cards/CannonConstructor.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Jay", "card", "CannonConstructor", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 4,
			exhaust = true
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.A => [
				new APartModManager.APartRebuild(){part = s.ship.parts[0], newPartType = PType.cannon},
				new AStatus(){status = Status.energyLessNextTurn, statusAmount = 1, targetPlayer = true}
			],
			Upgrade.B =>[
				new APartModManager.APartRebuild(){part = s.ship.parts[0], newPartType = PType.cannon},
				new AAttack(){damage = GetDmg(s,1)},
				new AStatus(){status = ModEntry.Instance.LessEnergyAllTurnsStatus.Status, statusAmount = 1, targetPlayer = true}
			],
			_ => [
				new APartModManager.APartRebuild(){part = s.ship.parts[0], newPartType = PType.cannon},
				new AStatus(){status = ModEntry.Instance.LessEnergyAllTurnsStatus.Status, statusAmount = 1, targetPlayer = true}
			]
		};
}
