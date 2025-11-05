using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class CommandCenterCard : Card, IRegisterable
{

	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{

		helper.Content.Cards.RegisterCard(MethodBase.GetCurrentMethod()!.DeclaringType!.Name, new()
		{
			CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				deck = ModEntry.Instance.JayDeck.Deck,
				rarity = ModEntry.GetCardRarity(MethodBase.GetCurrentMethod()!.DeclaringType!),
				upgradesTo = [Upgrade.A, Upgrade.B]
			},
			Art = StableSpr.cards_colorless,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Jay","card", "CommandCenter", "name"]).Localize
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
			Upgrade.B => [
				new APartModManager.APartRebuild{part = s.ship.parts[0], newPartType = PType.cockpit, partName = "COCKPIT"},
				new ADetect(){Amount = 1},
				new AReconfigure(){Amount = 1}
			],
			Upgrade.A => [
				new APartModManager.APartRebuild{part = s.ship.parts[0], newPartType = PType.cockpit, partName = "COCKPIT"},
				new ADetect(){Amount = 2}
			],
			_ => [
				new APartModManager.APartRebuild{part = s.ship.parts[0], newPartType = PType.cockpit, partName = "COCKPIT"},
				new ADetect(){Amount = 1}
			]
		};
}
