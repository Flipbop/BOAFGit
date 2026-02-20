using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class CorePoweredShieldsCard : Card, IRegisterable, IHasCustomCardTraits
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Centi/Cards/CorePoweredShields.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi","card", "CorePoweredShields", "name"]).Localize
		});
	}
	public IReadOnlySet<ICardTraitEntry> GetInnateTraits(State state)
	{
		this.SetIsCoreDependent(true);
		HashSet<ICardTraitEntry> cardTraitEntries = new HashSet<ICardTraitEntry>()
		{
			ModEntry.Instance.CoreDependentTrait
		};
		return cardTraitEntries;
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
			Upgrade.A => [
				new AStatus(){status = Status.shield, statusAmount = 3, targetPlayer = true},
			],
			Upgrade.B => [
				new AStatus(){status = Status.tempShield, statusAmount = 2, targetPlayer = true},
				new AStatus(){status = Status.shield, statusAmount = 2, targetPlayer = true},
			],
			_ => [
				new AStatus(){status = Status.shield, statusAmount = 2, targetPlayer = true},
			]
		};
}
