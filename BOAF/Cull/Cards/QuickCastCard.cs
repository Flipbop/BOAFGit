using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class QuickCastCard : Card, IRegisterable
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
			Art = ModEntry.Instance.placeholderSprite.Sprite,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Cards/QuickBoost.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","card", "QuickCast", "name"]).Localize
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
				new AStatus { status = Status.droneShift, statusAmount = 2, targetPlayer = true },
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(3),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					),
					new ASpawn() {fromPlayer = true, thing = new Missile{missileType = MissileType.normal}}
				).AsCardAction
			],
			Upgrade.B => [
				new AStatus { status = Status.droneShift, statusAmount = 1, targetPlayer = true },
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(2),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					),
					new ASpawn() {fromPlayer = true, thing = new Missile{missileType = MissileType.normal}}
				).AsCardAction
			],
			_=> [
				new AStatus { status = Status.droneShift, statusAmount = 1, targetPlayer = true },
				Conditional.MakeAction(
				Conditional.Equation(
					Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
					IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
					Conditional.Constant(3),
					IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
				),
				new ASpawn() {fromPlayer = true, thing = new Missile{missileType = MissileType.normal}}
				).AsCardAction
			]
		};
}
