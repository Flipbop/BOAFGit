using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class CommsHubCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Cards/MemoryRecovery.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","card", "FontOfStrength", "name"]).Localize
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
			Upgrade.A => [
				new AAttack() {damage = GetDmg(s, 1)},
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(5),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					).SetShowOperator(false),
					new AStatus() {targetPlayer = true, status = Status.overdrive, statusAmount = 2}
				).AsCardAction,
			],
			Upgrade.B => [
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(7),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					).SetShowOperator(false),
					new AStatus() {targetPlayer = true, status = Status.overdrive, statusAmount = 2}
				).AsCardAction,
				new AAttack() {damage = GetDmg(s, 1)}
			],
			_ => [
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(5),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					).SetShowOperator(false),
					new AStatus() {targetPlayer = true, status = Status.overdrive, statusAmount = 2}
				).AsCardAction
			]
		};
}
