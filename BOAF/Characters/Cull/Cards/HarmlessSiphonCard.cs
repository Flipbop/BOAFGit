using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class HarmlessSiphonCard : Card, IRegisterable
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
				upgradesTo = [Upgrade.A, Upgrade.B],
				dontOffer = true,
			},
			Art = StableSpr.cards_colorless,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","card", "HarmlessSiphon", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 0,
			temporary = true,
			retain = true,
			recycle = upgrade == Upgrade.B,
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=>upgrade switch
		{
			Upgrade.A =>
			[
				new AStatus() {status = Status.tempShield, statusAmount = 2},
				new AHarvestAttack { damage = GetDmg(s, 1) },
				new AHarvestAttack { damage = GetDmg(s, 1) }
			],
			_ => [
				new AStatus() {status = Status.tempShield, statusAmount = 1},
				new AHarvestAttack { damage = GetDmg(s, 1) }
			]
		};
};
