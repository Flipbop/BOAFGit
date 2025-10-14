using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class PlayingWithFireCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Cards/MaximumEffort.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","card", "PlayingWithFire", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = upgrade == Upgrade.B ? 2: 1,
			flippable = upgrade == Upgrade.A,
			artOverlay = ModEntry.Instance.UncommonCullBorder

		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.B => [
				new ASpawn(){offset = 1, thing = new SkullBomb(){DeathTurn = 1 + c.turn}, fromPlayer = true},
				new ASpawn(){offset = 2, thing = new SkullBomb(){DeathTurn = 1 + c.turn}, fromPlayer = true},
				new AMove() {dir = -1, targetPlayer = true, }
			],
			_=>[
				new ASpawn(){offset = 2, thing = new SkullBomb(){DeathTurn = 1 + c.turn}, fromPlayer = true},
				new AMove() {dir = -2, targetPlayer = true, }
			]
		};
}
