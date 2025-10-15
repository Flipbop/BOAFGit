using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using daisyowl.text;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class SensoryShotCard : Card, IRegisterable
{
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/Cards/SensoryShot.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Jay","card", "SensoryShot", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 2,
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.B => [
				new ADetect{Amount = 1},
				new AAttack{damage = GetDmg(s, 2), piercing = true}
			],
			Upgrade.A => [
				new ADetect{Amount = 1},
				new AAttack{damage = GetDmg(s, 3)}
			],
			_ => [
				new ADetect{Amount = 1},
				new AAttack{damage = GetDmg(s, 2)}
			],
		};
}