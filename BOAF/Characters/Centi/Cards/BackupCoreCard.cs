using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class BackupCoreCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Centi/Cards/BackupCore.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi","card", "BackupCore", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 1,
			infinite = true,
			description =
			ModEntry.Instance.Localizations.Localize([
			"Centi", "card", "BackupCore", "description", upgrade.ToString()
				]),
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.B => [
				new AStatus(){status = Status.tempShield, statusAmount = 3, targetPlayer = true},
				new AReconfigure(){Amount = 1}
			],
			Upgrade.A => [
				new AStatus(){status = Status.shield, statusAmount = 2, targetPlayer = true},
				new AReconfigure(){Amount = 1}
			],
			_=>[
				new AStatus(){status = Status.shield, statusAmount = 1, targetPlayer = true},
				new AReconfigure(){Amount = 1}
			]
		};
}
