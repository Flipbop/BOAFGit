using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class HarvestCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Cards/TurtleShot.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull", "card", "Harvest", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 1,
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
							Conditional.Constant(4),
							IKokoroApi.IV2.IConditionalApi.EquationStyle.Possession
						).SetShowOperator(false),
						new AHarvestAttack { damage = GetDmg(s, 2) })
					.AsCardAction,
				new AHarvestAttack { damage = GetDmg(s, 2) },
			],
			Upgrade.A => [
				new AHarvestAttack { damage = GetDmg(s, 1) },
				new AHarvestAttack { damage = GetDmg(s, 1) },
				new AHarvestAttack { damage = GetDmg(s, 1) },
			],
			_ => [
				new AHarvestAttack { damage = GetDmg(s, 1) },
				new AHarvestAttack { damage = GetDmg(s, 1) },
			]
		};
}
