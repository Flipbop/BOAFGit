using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class AmplifierCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Cards/ReroutePower.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","card", "ExcessiveForce", "name"]).Localize
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
			Upgrade.A => [
				new AAttack() {damage = GetDmg(s, 1)},
				Conditional.MakeAction(
						Conditional.Equation(
							Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
							IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
							Conditional.Constant(3),
							IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
						).SetShowOperator(false),
						new AAttack(){damage = GetDmg(s, 2)})
					.AsCardAction,
				Conditional.MakeAction(
						Conditional.Equation(
							Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
							IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
							Conditional.Constant(5),
							IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
						).SetShowOperator(false),
						new AAttack(){damage = GetDmg(s, 2)})
					.AsCardAction,Conditional.MakeAction(
						Conditional.Equation(
							Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
							IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
							Conditional.Constant(8),
							IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
						).SetShowOperator(false),
						new AAttack(){damage = GetDmg(s, 2)})
					.AsCardAction,
				Conditional.MakeAction(
						Conditional.Equation(
							Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
							IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
							Conditional.Constant(9),
							IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
						).SetShowOperator(false),
						new AStatus() {targetPlayer = true, statusAmount = 1, status = ModEntry.Instance.SoulDrainStatus.Status})
					.AsCardAction,
			],
			Upgrade.B => [
				new AAttack() {damage = GetDmg(s, 1)},
				Conditional.MakeAction(
						Conditional.Equation(
							Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
							IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
							Conditional.Constant(2),
							IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
						).SetShowOperator(false),
						new AAttack(){damage = GetDmg(s, 1)})
					.AsCardAction,
				Conditional.MakeAction(
						Conditional.Equation(
							Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
							IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
							Conditional.Constant(4),
							IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
						).SetShowOperator(false),
						new AAttack(){damage = GetDmg(s, 1)})
					.AsCardAction,Conditional.MakeAction(
						Conditional.Equation(
							Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
							IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
							Conditional.Constant(7),
							IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
						).SetShowOperator(false),
						new AAttack(){damage = GetDmg(s, 1)})
					.AsCardAction,
				Conditional.MakeAction(
						Conditional.Equation(
							Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
							IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
							Conditional.Constant(8),
							IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
						).SetShowOperator(false),
						new AStatus() {targetPlayer = true, statusAmount = 2, status = ModEntry.Instance.SoulDrainStatus.Status})
					.AsCardAction,
			],
			_ => [
				new AAttack() {damage = GetDmg(s, 1)},
				Conditional.MakeAction(
						Conditional.Equation(
							Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
							IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
							Conditional.Constant(3),
							IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
						).SetShowOperator(false),
						new AAttack(){damage = GetDmg(s, 1)})
					.AsCardAction,
				Conditional.MakeAction(
						Conditional.Equation(
							Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
							IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
							Conditional.Constant(5),
							IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
						).SetShowOperator(false),
						new AAttack(){damage = GetDmg(s, 1)})
					.AsCardAction,Conditional.MakeAction(
						Conditional.Equation(
							Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
							IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
							Conditional.Constant(8),
							IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
						).SetShowOperator(false),
						new AAttack(){damage = GetDmg(s, 1)})
					.AsCardAction,
				Conditional.MakeAction(
						Conditional.Equation(
							Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
							IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
							Conditional.Constant(9),
							IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
						).SetShowOperator(false),
						new AStatus() {targetPlayer = true, statusAmount = 1, status = ModEntry.Instance.SoulDrainStatus.Status})
					.AsCardAction,
			]
		};
}
