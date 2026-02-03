using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using daisyowl.text;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class PhysicalTraumaCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Centi/Cards/PhysicalTrauma.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi","card", "PhysicalTrauma", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = upgrade == Upgrade.A? 2:3,
			exhaust = true
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.B => [
				new APartModManager.APartRebuild(){part = s.ship.parts[0], newPartType = PType.empty, partName = "SCAFFOLDING"},
				new ADetect(){Amount = 1},
				new AStatus(){status = Status.energyLessNextTurn, statusAmount = 1, targetPlayer = true}
			],
			_ => [
				new APartModManager.APartRebuild(){part = s.ship.parts[0], newPartType = PType.empty, partName = "SCAFFOLDING"},
				new AStatus(){status = Status.energyLessNextTurn, statusAmount = 1, targetPlayer = true}
			]
		};
	
}
	

