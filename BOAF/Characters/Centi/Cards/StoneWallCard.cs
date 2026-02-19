using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using System;


namespace Flipbop.BOAF;

internal sealed class StoneWallCard : Card, IRegisterable
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
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi","card", "StoneWall", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = upgrade == Upgrade.A ? 1 : 2,
			exhaust = true,
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.B => [
				new ASpawn(){thing = new Asteroid(){bubbleShield = true}, offset = -1},
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StoneCoreCheck(), 1),
					new ASpawn(){thing = new Asteroid(){bubbleShield = true}}).AsCardAction,
				new ASpawn(){thing = new Asteroid(){bubbleShield = true}, offset = 1}
			],
			_=>[
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StoneCoreCheck(), 1),
					new ASpawn(){thing = new Asteroid(){bubbleShield = true}, offset = -1}).AsCardAction,
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StoneCoreCheck(), 1),
					new ASpawn(){thing = new Asteroid(){bubbleShield = true}}).AsCardAction,
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StoneCoreCheck(), 1),
					new ASpawn(){thing = new Asteroid(){bubbleShield = true}, offset = 1}).AsCardAction,
			]
		};
}
