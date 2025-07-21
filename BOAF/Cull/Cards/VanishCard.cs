using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using daisyowl.text;
using Shockah.Kokoro;


namespace Flipbop.BOAF;

internal sealed class VanishCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Cards/SeekerBarrage.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","card", "Vanish", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "8A3388",
			cost = 2,
			exhaust = true,
			artOverlay = ModEntry.Instance.RareCullBorder
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
							Conditional.Constant(5),
							IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
						),
						new AStatus()
							{ targetPlayer = true, statusAmount = 1, status = ModEntry.Instance.CloakedStatus.Status }
					).AsCardAction,
				],
				Upgrade.B =>
				[
					Conditional.MakeAction(
						Conditional.Equation(
							Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
							IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
							Conditional.Constant(6),
							IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
						),
						new AStatus()
							{ targetPlayer = true, statusAmount = 1, status = ModEntry.Instance.CloakedStatus.Status }
					).AsCardAction,
					Conditional.MakeAction(
						Conditional.Equation(
							Conditional.Status(ModEntry.Instance.SoulEnergyStatus.Status),
							IKokoroApi.IV2.IConditionalApi.EquationOperator.GreaterThanOrEqual,
							Conditional.Constant(8),
							IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
						),
						new AStatus() { targetPlayer = true, statusAmount = 1, status = Status.perfectShield }
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
						new AStatus()
							{ targetPlayer = true, statusAmount = 1, status = ModEntry.Instance.CloakedStatus.Status }
					).AsCardAction,
				]
			
		};

}

