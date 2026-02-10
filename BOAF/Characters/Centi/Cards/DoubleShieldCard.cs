using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using daisyowl.text;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class DoubleShieldCard : Card, IRegisterable
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
				upgradesTo = [Upgrade.A, Upgrade.B],
			},
			Art = StableSpr.cards_colorless,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi","card", "DoubleShield", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = upgrade == Upgrade.A? 0 : 1,
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=>upgrade switch
		{
			Upgrade.B =>
			[
				new AStatus() { status = Status.shield, statusAmount = 1, targetPlayer = true },
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new AquaCoreCheck(), 1),
					new AStatus() { status = Status.bubbleJuice, statusAmount = 1, targetPlayer = true }).AsCardAction,
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StoneCoreCheck(), 1),
					new ASpawn(){thing = new Asteroid()}).AsCardAction,
			],
			_ => [
				new AStatus() { status = Status.shield, statusAmount = 1, targetPlayer = true },
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new AquaCoreCheck(), 1),
						new AStatus() { status = Status.bubbleJuice, statusAmount = 1, targetPlayer = true }).AsCardAction,
			]
		};
};
