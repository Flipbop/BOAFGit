using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class OrionsBeltCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/Cards/Surge.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna","card", "OrionsBelt", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = upgrade == Upgrade.A ? 1 : 2,
			floppable = upgrade != Upgrade.B,
			flippable = upgrade == Upgrade.B,
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.B => [
				new AMove(){dir = 2, targetPlayer = true},
				new AAttack() {damage = GetDmg(s, 1), piercing = true},
				new AAttack() {damage = GetDmg(s, 1), stunEnemy = true},
			],
			_ => [
				new AMove(){dir = -2, targetPlayer = true, disabled = flipped},
				new AAttack() {damage = GetDmg(s, 1), piercing = true, disabled = flipped},
				new ADummyAction(),
				new AMove(){dir = 2, targetPlayer = true, disabled = !flipped},
				new AAttack() {damage = GetDmg(s, 1), stunEnemy = true, disabled = !flipped},
			]
		};
}
