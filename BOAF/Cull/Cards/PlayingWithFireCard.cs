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
			Art = ModEntry.Instance.placeholderSprite.Sprite,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Cards/MaximumEffort.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","card", "PlayingWithFire", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "8A3388",
			cost = upgrade == Upgrade.B ? 1: 2,
			flippable = upgrade == Upgrade.A
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			_=>[]
		};
}
