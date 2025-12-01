using Nanoray.PluginManager;


using Nickel;
using System.Collections.Generic;
using System.Reflection;
using daisyowl.text;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class HarmingSpellCard : Card, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Cards.RegisterCard(MethodBase.GetCurrentMethod()!.DeclaringType!.Name, new()
		{
			CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				deck = ModEntry.Instance.LunaDeck.Deck,
				rarity = ModEntry.GetCardRarity(MethodBase.GetCurrentMethod()!.DeclaringType!),
				upgradesTo = [Upgrade.A, Upgrade.B]
			},
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/Cards/HarmingSpell.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna","card", "HarmingSpell", "name"]).Localize
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
			Upgrade.A => [
				new ADetect(){Amount = 2},
				new AStatus() {targetPlayer = true, status = ModEntry.Instance.SignalBoosterStatus.Status, statusAmount = 1}
			],
			Upgrade.B => [
				new AStatus() {targetPlayer = true, status = ModEntry.Instance.SignalBoosterStatus.Status, statusAmount = 2},
				new ADetect(){Amount = 1},
			],
			_ => [
				new ADetect(){Amount = 1},
				new AStatus() {targetPlayer = true, status = ModEntry.Instance.SignalBoosterStatus.Status, statusAmount = 1}
			]
		};
}

