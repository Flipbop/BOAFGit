using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class CommandCenterCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","card", "Flighty", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "8A3388",
			cost = 1,
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.B => [
				new AMove() {isRandom = true, targetPlayer = true, dir = 4},
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(4),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					).SetShowOperator(false),
					new AStatus() {targetPlayer = true, status = Status.evade, statusAmount = 1}
				).AsCardAction
			],
			Upgrade.A => [
				new AMove() {isRandom = true, targetPlayer = true, dir = 2},
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(4),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					).SetShowOperator(false),
					new AStatus() {targetPlayer = true, status = Status.evade, statusAmount = 3}
				).AsCardAction
			],
			_ => [
				new AMove() {isRandom = true, targetPlayer = true, dir = 2},
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(4),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					).SetShowOperator(false),
					new AStatus() {targetPlayer = true, status = Status.evade, statusAmount = 2}
				).AsCardAction
			]
		};
}
