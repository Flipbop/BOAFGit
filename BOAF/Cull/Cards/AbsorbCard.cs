using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class AbsorbCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Cards/ScalpedParts.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull", "card", "Absorb", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 1,
			artOverlay = ModEntry.Instance.UncommonCullBorder,
			exhaust = true
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.A => [
				new AStatus() {status = ModEntry.Instance.SoulDrainStatus.Status, statusAmount = 1, targetPlayer = true},
				new AStatus() {status = Status.evade, statusAmount = 3, targetPlayer = true},
			],
			Upgrade.B =>[
				new AStatus() {status = ModEntry.Instance.SoulDrainStatus.Status, statusAmount = 3, targetPlayer = true},
				new AStatus() {status = Status.evade, statusAmount = 4, targetPlayer = true},
			],
			_ => [
				new AStatus() {status = ModEntry.Instance.SoulDrainStatus.Status, statusAmount = 1, targetPlayer = true},
				new AStatus() {status = Status.evade, statusAmount = 2, targetPlayer = true},
			]
		};
}
