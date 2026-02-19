using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class PunishmentCard : Card, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Cards.RegisterCard(MethodBase.GetCurrentMethod()!.DeclaringType!.Name, new()
		{
			CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				deck = ModEntry.Instance.CentiDeck.Deck,
				rarity = ModEntry.GetCardRarity(MethodBase.GetCurrentMethod()!.DeclaringType!),
				upgradesTo = [Upgrade.A, Upgrade.B]
			},
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Centi/Cards/Punishment.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi", "card", "Punishment", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 2,
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.B => [
				new AStatus() { status = Status.shield, statusAmount = 2, targetPlayer = true },
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new DemonCoreCheck(), 1),
					new ASpawn() {thing = new SpaceMine()}).AsCardAction,
			],
			Upgrade.A => [
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StoneCoreCheck(), 1),
					new AStatus() { status = Status.shield, statusAmount = 3, targetPlayer = true }).AsCardAction,
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new DemonCoreCheck(), 1),
					new ASpawn() {thing = new SpaceMine(){bigMine = true}}).AsCardAction,
			],
			_ => [
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StoneCoreCheck(), 1),
					new AStatus() { status = Status.shield, statusAmount = 2, targetPlayer = true }).AsCardAction,
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new DemonCoreCheck(), 1),
					new ASpawn() {thing = new SpaceMine()}).AsCardAction,
			]
		};
}
