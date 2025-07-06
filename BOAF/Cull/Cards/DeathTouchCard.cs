using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class DeathTouchCard : Card, IRegisterable
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
			Art = ModEntry.Instance.placeholderSprite.Sprite,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Cards/FlexibleDefense.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","card", "DeathTouch", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "8A3388",
			cost = 3,
			exhaust = true,
			retain = true,
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.A => [
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(10),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					),
					new AAttack(){damage = GetDmg(s, 12)}
				).AsCardAction,
				new AStatus {targetPlayer = true, status = ModEntry.Instance.SoulDrainStatus.Status, statusAmount = 5},
			],
			Upgrade.B => [
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(10),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					),
					new AAttack(){damage = GetDmg(s, 10)}
				).AsCardAction,
				new AStatus {targetPlayer = true, status = ModEntry.Instance.SoulDrainStatus.Status, statusAmount = 3},
			],
			_ => [
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(10),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					),
					new AAttack(){damage = GetDmg(s, 10)}
				).AsCardAction,
				new AStatus {targetPlayer = true, status = ModEntry.Instance.SoulDrainStatus.Status, statusAmount = 5},
			]
		};
}
