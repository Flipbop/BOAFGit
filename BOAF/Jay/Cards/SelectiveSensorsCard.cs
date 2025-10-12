using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class SelectiveSensorsCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Jay","card", "SelectiveSensors", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "8A3388",
			cost = 1,
			description =
				ModEntry.Instance.Localizations.Localize([
					"Jay", "card", "SelectiveSensors", "description", upgrade.ToString()
				]),
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.A => [
				new AStatus() {status = Status.droneShift, statusAmount = 1, targetPlayer = true},
				new ASpawn(){fromPlayer = true, thing = new GreaterWisp(){ DeathTurn = 1 + c.turn}}],
			Upgrade.B => [
				new AStatus() {status = Status.droneShift, statusAmount = 3, targetPlayer = true},
				new ASpawn(){fromPlayer = true, thing = new Wisp() {DeathTurn = 1 + c.turn}}],
			_=>[
				new AStatus() {status = Status.droneShift, statusAmount = 1, targetPlayer = true},
				new ASpawn(){fromPlayer = true, thing = new Wisp() { DeathTurn = 1 + c.turn}}
			]
		};
}
