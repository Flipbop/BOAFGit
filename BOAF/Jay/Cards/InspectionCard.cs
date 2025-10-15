using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class InspectionCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/Cards/Inspection.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Jay","card", "Inspection", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 0,
			temporary = true,
			exhaust = upgrade != Upgrade.B
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.A =>
			[
				new ADetect{Amount = 2}
			],
			_ =>
			[
				new ADetect{Amount = 1}
			]
		};
	
		
}
