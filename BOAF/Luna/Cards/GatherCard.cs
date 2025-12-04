using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class GatherCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/Cards/Gather.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna","card", "Gather", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 1,
			exhaust = upgrade != Upgrade.B,
			buoyant = upgrade == Upgrade.A,
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=>upgrade switch
		{
			Upgrade.B => [
				new AStatus(){statusAmount = 1, status = ModEntry.Instance.ResidualDustStatus.Status, targetPlayer = true},
			],
			_ => [
				new AStatus(){statusAmount = 2, status = ModEntry.Instance.ResidualDustStatus.Status, targetPlayer = true},
			]
		};
}
