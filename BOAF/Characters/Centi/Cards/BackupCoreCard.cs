using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class BackupCoreCard : Card, IRegisterable, IHasCustomCardTraits
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Centi/Cards/BackupCore.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi","card", "BackupCore", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 1,
			description =
			ModEntry.Instance.Localizations.Localize([
			"Centi", "card", "BackupCore", "description", upgrade.ToString()
				]),
		};

	public IReadOnlySet<ICardTraitEntry> GetInnateTraits(State state)
	{
		HashSet<ICardTraitEntry> cardTraitEntries = new HashSet<ICardTraitEntry>();
		if (upgrade != Upgrade.B)
		{
			this.SetIsCoreDependent(true);
			cardTraitEntries.Add(ModEntry.Instance.CoreDependentTrait);
		}
		return cardTraitEntries;
	}

	//CHANGE TO OLD FORM WHEN POSSIBLE
	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = new(); 
		
		var rand = new Rand(s.rngCurrentEvent.seed);
		var potentialCore = new WeightedRandom<Core>();
		potentialCore.Add(new(25,new DemonCore(){bubbleShield = upgrade == Upgrade.B}));
		potentialCore.Add(new(25,new AquaCore(){bubbleShield = upgrade == Upgrade.B}));
		potentialCore.Add(new(25,new StoneCore(){bubbleShield = upgrade == Upgrade.B}));
		potentialCore.Add(new(8,new LavaCore(){bubbleShield = upgrade == Upgrade.B}));
		potentialCore.Add(new(8,new MossCore(){bubbleShield = upgrade == Upgrade.B}));
		potentialCore.Add(new(8,new BrimstoneCore(){bubbleShield = upgrade == Upgrade.B}));
		potentialCore.Add(new(1,new InfinityCore(){bubbleShield = upgrade == Upgrade.B}));
		var core = potentialCore.Next(rand);
		
		actions.Add(new ASpawn{thing = core});
		
		return actions;
	}
}
