using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class WispArrayCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Cards/DoItYourself.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","card", "WispArray", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "8A3388",
			cost = 2,
			artOverlay = ModEntry.Instance.UncommonCullBorder
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.A =>
			[
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(6),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					),
					new ASpawn() {thing = new Wisp(){DeathTurn = 3}, offset = -1}
				).AsCardAction,
				new ASpawn() {thing = new GreaterWisp(){DeathTurn = 3}},
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(6),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					),
					new ASpawn() {thing = new Wisp(){DeathTurn = 3}, offset = 1}
				).AsCardAction,
			],
			Upgrade.B => [
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(4),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					),
					new ASpawn() {thing = new Wisp(){DeathTurn = 3}, offset = -1}
				).AsCardAction,
				new ASpawn() {thing = new GreaterWisp(){DeathTurn = 3}},
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(4),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					),
					new ASpawn() {thing = new Wisp(){DeathTurn = 3}, offset = 1}
				).AsCardAction,
				],
			_ =>
			[
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(6),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					),
					new ASpawn() {thing = new Wisp(){DeathTurn = 3}, offset = -1}
				).AsCardAction,
				new ASpawn() {thing = new Wisp(){DeathTurn = 3}},
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(6),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					),
					new ASpawn() {thing = new Wisp(){DeathTurn = 3}, offset = 1}
				).AsCardAction,
			]
		};
	
		
}
