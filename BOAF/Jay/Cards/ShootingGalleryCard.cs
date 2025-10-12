using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class ShootingGalleryCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Cards/ImprovedCannons.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull", "card", "StunningStrike", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "8A3388",
			cost = upgrade == Upgrade.A ? 0 : 1,
			artOverlay = ModEntry.Instance.UncommonCullBorder
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.B =>
			[
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(6),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					).SetShowOperator(false),
					new AStatus() {targetPlayer = true, status = Status.stunCharge, statusAmount = 2}
				).AsCardAction,
				new AHarvestAttack() {damage = GetDmg(s, 2)}
			],
			_ =>
			[
				Conditional.MakeAction(
					Conditional.Equation(
						Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
						IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
						Conditional.Constant(5),
						IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
					).SetShowOperator(false),
					new AStatus() {targetPlayer = true, status = Status.stunCharge, statusAmount = 1}
				).AsCardAction,
				new AHarvestAttack() {damage = GetDmg(s, 2)}
			]

		};

}