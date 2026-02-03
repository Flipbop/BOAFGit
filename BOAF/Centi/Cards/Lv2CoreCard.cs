using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class Lv2CoreCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Centi/Cards/Lv2Core.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi","card", "Lv2Core", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = upgrade == Upgrade.B? 3:2,
			description =
				ModEntry.Instance.Localizations.Localize([
					"Centi", "card", "Lv2Core", "description", upgrade.ToString()
				]),
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.A => [
				new APartModManager.APartRebuild(){part = s.ship.parts[0], newPartType = PType.wing},
				new ADetect(){Amount = 3}
			],
			Upgrade.B => [
				new APartModManager.APartRebuild(){part = s.ship.parts[0], newPartType = PType.wing},
				new AReconfigure(){Amount = 1},
				new APartModManager.APartRebuild(){part = s.ship.parts[0], newPartType = PType.wing},
				new ADetect(){Amount = 2}
			],
			_=> [
				new APartModManager.APartRebuild(){part = s.ship.parts[0], newPartType = PType.wing},
				new ADetect(){Amount = 2}
			]
		};
}
