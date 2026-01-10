using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class RageCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Cards/MaximumEffort.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","card", "Rage", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = upgrade == Upgrade.B ? 3: 2,
			exhaust = upgrade == Upgrade.B,
			artOverlay = ModEntry.Instance.UncommonCullBorder

		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.A => [
				new AHarvestAttack() {damage = GetDmg(s, 1)},
				new AHarvestAttack() {damage = GetDmg(s, 2)},
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status), 
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual, 
						Conditional.Constant(4), 
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					).SetShowOperator(false),
					new AStatus() {targetPlayer = true, status = Status.overdrive, statusAmount = 1}
				).AsCardAction,
			],
			Upgrade.B => [
				new AAttack() {damage = GetDmg(s, 1)},
				new AAttack() {damage = GetDmg(s, 2)},
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status), 
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual, 
						Conditional.Constant(9), 
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					).SetShowOperator(false),
					new AStatus() {targetPlayer = true, status = Status.powerdrive, statusAmount = 1}
				).AsCardAction,
			],
			_=>[
				new AAttack() {damage = GetDmg(s, 1)},
				new AAttack() {damage = GetDmg(s, 2)},
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status), 
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual, 
						Conditional.Constant(4), 
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
						).SetShowOperator(false),
					new AStatus() {targetPlayer = true, status = Status.overdrive, statusAmount = 1}
				).AsCardAction,
			]
		};
}
