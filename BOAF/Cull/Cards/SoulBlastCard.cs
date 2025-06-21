using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Flipbop.BOAF;

internal sealed class SoulBlastCard : Card, IRegisterable
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
			Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Cards/RepairedGlasses.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","card", "SoulBlast", "name"]).Localize
		});
	}

	

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "8A3388",
			cost = upgrade == Upgrade.A ? 1: 2,
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.A =>
			[
				new AStatus { targetPlayer = true, status = Status.energyNextTurn, statusAmount = c.hand.Count(card => card.upgrade != Upgrade.None), xHint = 1},
				new AStatus { targetPlayer = true, status = Status.drawNextTurn, statusAmount = 2}
			],
			Upgrade.B => [
				new ADiscard {count = 2},
				new AStatus { targetPlayer = true, status = Status.energyNextTurn, statusAmount = c.discard.Count(card => card.upgrade != Upgrade.None), xHint = 1},
			],
			_ => [
				new AStatus { targetPlayer = true, status = Status.energyNextTurn, statusAmount = c.hand.Count(card => card.upgrade != Upgrade.None), xHint = 1},
			]
			
		};
	
}
