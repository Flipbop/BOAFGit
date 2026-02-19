using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class CapacitorSlugCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi","card", "CapacitorSlug", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = upgrade == Upgrade.B ? 2 :1,
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.B => [
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new DemonCoreCheck(), 1),
					new AAttack{damage = GetDmg(s, 4)}).AsCardAction,
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StoneCoreCheck(), 1),
					new AStatus() { status = Status.maxShield, statusAmount = 2, targetPlayer = true }).AsCardAction,
			],
			Upgrade.A => [
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new DemonCoreCheck(), 1),
					new AAttack{damage = GetDmg(s, 3)}).AsCardAction,
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StoneCoreCheck(), 1),
					new AStatus() { status = Status.maxShield, statusAmount = 1, targetPlayer = true }).AsCardAction,
				new AStatus() { status = Status.shield, statusAmount = 1, targetPlayer = true }
			],
			_ => [
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new DemonCoreCheck(), 1),
					new AAttack{damage = GetDmg(s, 2)}).AsCardAction,
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StoneCoreCheck(), 1),
					new AStatus() { status = Status.maxShield, statusAmount = 1, targetPlayer = true }).AsCardAction,
			]
		};
}
