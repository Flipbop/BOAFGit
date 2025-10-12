using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class CannonConstructorCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/Cards/CannonConstructor.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Jay", "card", "CannonConstructor", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "8A3388",
			cost = upgrade == Upgrade.A ? 1: 2,
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.B =>[
				new AMove() {dir = -2, targetPlayer = true},
				new ASpawn() {fromPlayer = true, thing = new SpaceMine() {bigMine = true}},
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(5),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					).SetShowOperator(false),
					new AMove() {dir = 1, targetPlayer = true}
				).AsCardAction,
			],
			_ => [
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(4),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					).SetShowOperator(false),
					new AMove() {dir = 1, targetPlayer = true}
				).AsCardAction,
				new ASpawn() {fromPlayer = true, thing = new SpaceMine() {bigMine = true}},
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(6),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					).SetShowOperator(false),
					new AMove() {dir = 1, targetPlayer = true}
				).AsCardAction,
			]
		};
}
