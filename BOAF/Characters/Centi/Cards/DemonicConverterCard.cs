using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Flipbop.BOAF;

internal sealed class DemonicConverterCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Centi/Cards/ShieldConverter.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi","card", "DemonicConverter", "name"]).Localize
		});
	}

	

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = upgrade == Upgrade.A ? 1: 2,
			
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.B => [
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StoneCoreCheck(), 1),
					new AStatus() { status = Status.shield, statusAmount = 2, targetPlayer = true }).AsCardAction,
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new DemonCoreCheck(), 1),
					new AStatus() { status = Status.stunCharge, statusAmount = 2, targetPlayer = true }).AsCardAction,
				new AAttack() {damage = GetDmg(s, 3)}
			],
			_ => [
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StoneCoreCheck(), 1),
					new AStatus() { status = Status.shield, statusAmount = 1, targetPlayer = true }).AsCardAction,
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new DemonCoreCheck(), 1),
					new AStatus() { status = Status.stunCharge, statusAmount = 1, targetPlayer = true }).AsCardAction,
				new AAttack() {damage = GetDmg(s, 2)}
			]
			
		};
	
}
