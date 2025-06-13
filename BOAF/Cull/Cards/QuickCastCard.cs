using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class QuickCastCard : Card, IRegisterable
{
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
			Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cards/QuickBoost.png")).Sprite,
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
			Upgrade.A =>
			[
				new AImproveA { Amount = 1 },
				new AStatus { targetPlayer = true, status = Status.tempShield, statusAmount = 1 },
			],
			Upgrade.B => [
				new AImproveB { Amount = 1 },
				new AStatus { targetPlayer = true, status = Status.tempShield, statusAmount = 2 },
			],
			_ => [
				new AImproveA { Amount = 1 },
				new AStatus { targetPlayer = true, status = Status.tempShield, statusAmount = 1 },
			]
		};
}
