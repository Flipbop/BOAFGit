using Nanoray.PluginManager;


using Nickel;
using System.Collections.Generic;
using System.Reflection;
using daisyowl.text;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class BubbleSiphonCard : Card, IRegisterable, IHasCustomCardTraits
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Centi/Cards/BubbleSiphon.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi","card", "BubbleSiphon", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = upgrade == Upgrade.B? 0:1,
		};
	
	public IReadOnlySet<ICardTraitEntry> GetInnateTraits(State state)
	{
		HashSet<ICardTraitEntry> cardTraitEntries = new HashSet<ICardTraitEntry>();
		if (this.upgrade == Upgrade.B)
		{
			this.SetIsCoreDependent(true);
			cardTraitEntries.Add(ModEntry.Instance.CoreDependentTrait);
		}
		return cardTraitEntries;
	}

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.A => [
				new AStatus() { status = ModEntry.Instance.BubbleSiphonStatus.Status, statusAmount = 2, targetPlayer = true },
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new AquaCoreCheck(), 1),
					new AStatus() { status = Status.bubbleJuice, statusAmount = 2, targetPlayer = true }).AsCardAction,
			],
			Upgrade.B => [
				new AStatus() { status = ModEntry.Instance.BubbleSiphonStatus.Status, statusAmount = 1, targetPlayer = true },
				new AStatus() { status = Status.bubbleJuice, statusAmount = 1, targetPlayer = true },
			],
			_ => [
				new AStatus() { status = ModEntry.Instance.BubbleSiphonStatus.Status, statusAmount = 1, targetPlayer = true },
				ModEntry.Instance.KokoroApi.ActionCosts.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new AquaCoreCheck(), 1),
					new AStatus() { status = Status.bubbleJuice, statusAmount = 1, targetPlayer = true }).AsCardAction,
			]
		};
}

