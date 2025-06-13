using FSPRO;
using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class NecromancyCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","card", "Necromancy", "name"]).Localize
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
			Upgrade.A => [
				new AStatus { targetPlayer = true, status = Status.shield, statusAmount = 2 },
				new AStatus { targetPlayer = true, status = Status.tempShield, statusAmount = 2 },
				new AImpairSelf{id = this.uuid},
			],
			Upgrade.B => [
				new AStatus { targetPlayer = true, status = Status.evade, statusAmount = 2 },
				new AImpairSelf{id = this.uuid},
			],
			_ => [
				new AAttack {disabled = flipped, damage = GetDmg(s, 2) },
				new AImproveASelf {disabled = flipped, id = this.uuid},
				new ADummyAction(),
				new AAttack {disabled = !flipped, damage = GetDmg(s, 2) },
				new AImproveBSelf {disabled = !flipped, id = this.uuid},
			]
		};
}