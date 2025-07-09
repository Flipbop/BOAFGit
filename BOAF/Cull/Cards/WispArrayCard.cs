using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;

namespace Flipbop.BOAF;

internal sealed class WispArrayCard : Card, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Cards.RegisterCard(MethodBase.GetCurrentMethod()!.DeclaringType!.Name, new()
		{
			CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				deck = ModEntry.Instance.CullDeck.Deck,
				rarity = ModEntry.GetCardRarity(MethodBase.GetCurrentMethod()!.DeclaringType!),
				upgradesTo = [Upgrade.A, Upgrade.B]
			},
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Cards/DoItYourself.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","card", "WispArray", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "8A3388",
			cost = 2,
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.A =>
			[
				new AAddCard { amount = 1, card = new HarmlessSiphonCard { upgrade = Upgrade.A }, destination = CardDestination.Deck},
				new AStatus { targetPlayer = true, status = Status.shield, statusAmount = 2 },
			],
			_ =>
			[
				new AAddCard { amount = upgrade == Upgrade.B ? 2 : 1, card = new HarmlessSiphonCard(), destination = CardDestination.Deck },
				new AStatus { targetPlayer = true, status = Status.shield, statusAmount = 2 },
			]
		};
	
		
}
