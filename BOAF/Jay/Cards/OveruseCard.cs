using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using daisyowl.text;
using Shockah.Kokoro;


namespace Flipbop.BOAF;

internal sealed class OveruseCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/Cards/Overuse.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Jay","card", "Overuse", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 1,
			exhaust = true,
			description =
				ModEntry.Instance.Localizations.Localize([
					"Jay", "card", "Overuse", "description", upgrade.ToString()
				]),
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
			{
				Upgrade.A =>
				[
					new ADetect(){Amount = 5},
					new APartModManager.APartModification(){part = s.ship.parts[0], modifier = PDamMod.weak}
				],
				Upgrade.B =>
				[
					new ADetect(){Amount = 8},
					new APartModManager.APartModification(){part = s.ship.parts[0], modifier = PDamMod.brittle}
				],
				_ =>
				[
					new ADetect(){Amount = 3},
					new APartModManager.APartModification(){part = s.ship.parts[0], modifier = PDamMod.weak}
				]
			
		};

}

