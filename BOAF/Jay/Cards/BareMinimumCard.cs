using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using daisyowl.text;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class BareMinimumCard : Card, IRegisterable
{
	private static IKokoroApi.IV2.IConditionalApi Conditional => ModEntry.Instance.KokoroApi.Conditional;

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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Cards/ApologizeNextLoop.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","card", "UnstableSpirit", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "8A3388",
			cost = 1,
			artOverlay = ModEntry.Instance.RareCullBorder,
			flippable = true
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.A => [
				new ASpawn() {thing = new Wisp(){DeathTurn = 1 + c.turn}, fromPlayer = true},
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(6),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					).SetShowOperator(false),
					new ADroneMove(){dir = -1, playerDidIt = true}
				).AsCardAction,
				new ASpawn() {thing = new DormantGreaterWisp(), fromPlayer = true},
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(4),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					).SetShowOperator(false),
					new ADroneMove(){dir = -1, playerDidIt = true}
				).AsCardAction,
				new ASpawn() {thing = new GreaterWisp(){DeathTurn = 1 + c.turn}, fromPlayer = true},
			],
			Upgrade.B => [
				new ASpawn() {thing = new DormantWisp(), fromPlayer = true},
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(4),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					).SetShowOperator(false),
					new ADroneMove(){dir = -1, playerDidIt = true}
				).AsCardAction,
				new ASpawn() {thing = new Wisp() {DeathTurn = 1 + c.turn}, fromPlayer = true},
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(2),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					).SetShowOperator(false),
					new ADroneMove(){dir = -1, playerDidIt = true}
				).AsCardAction,
				new ASpawn() {thing = new DormantGreaterWisp(), fromPlayer = true},
			],
			_ => [
				new ASpawn() {thing = new DormantWisp(), fromPlayer = true},
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(6),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					).SetShowOperator(false),
					new ADroneMove(){dir = -1, playerDidIt = true}
				).AsCardAction,
				new ASpawn() {thing = new Wisp() {DeathTurn = 1 + c.turn}, fromPlayer = true},
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(4),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					).SetShowOperator(false),
					new ADroneMove(){dir = -1, playerDidIt = true}
				).AsCardAction,
				new ASpawn() {thing = new DormantGreaterWisp(), fromPlayer = true},
			]
		};
	
}
	

