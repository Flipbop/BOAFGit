using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using daisyowl.text;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class AgressiveDefenseCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Centi/Cards/AgressiveDefense.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi","card", "AggressiveDefense", "name"]).Localize
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
				new AStatus() {status = Status.shield, statusAmount = 1, targetPlayer = true},
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new AquaCoreCheck(), 1),
					new AStatus() { status = Status.tempShield, statusAmount = 2, targetPlayer = true }).AsCardAction,
				new AAttack{damage = GetDmg(s, 2)}
			],
			Upgrade.A => [
				new AStatus() {status = Status.tempShield, statusAmount = 1, targetPlayer = true},
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new AquaCoreCheck(), 1),
					new AStatus() { status = Status.tempShield, statusAmount = 3, targetPlayer = true }).AsCardAction,
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new DemonCoreCheck(), 1),
					new AAttack{damage = GetDmg(s, 3)}).AsCardAction,
			],
			_ => [
				new AStatus() {status = Status.tempShield, statusAmount = 1, targetPlayer = true},
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new AquaCoreCheck(), 1),
					new AStatus() { status = Status.tempShield, statusAmount = 2, targetPlayer = true }).AsCardAction,
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new DemonCoreCheck(), 1),
					new AAttack{damage = GetDmg(s, 2)}).AsCardAction,
			],
		};
}