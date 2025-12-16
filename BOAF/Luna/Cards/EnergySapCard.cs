using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class EnergySapCard : Card, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Cards.RegisterCard(MethodBase.GetCurrentMethod()!.DeclaringType!.Name, new()
		{
			CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				deck = ModEntry.Instance.LunaDeck.Deck,
				rarity = ModEntry.GetCardRarity(MethodBase.GetCurrentMethod()!.DeclaringType!),
				upgradesTo = [Upgrade.A, Upgrade.B]
			},
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/Cards/EnergySap.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna","card", "EnergySap", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 2,
			floppable = true,
		};

	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = new();
		
		CardAction actionB = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 1),
				new AStatus() { status = ModEntry.Instance.KokoroApi.DriveStatus.Underdrive, statusAmount = 3, targetPlayer = false }).AsCardAction;
		CardAction actionA = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 2),
				new AStatus() { status = ModEntry.Instance.KokoroApi.DriveStatus.Underdrive, statusAmount = 4, targetPlayer = false }).AsCardAction;
		CardAction actionNone = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 2),
				new AStatus() { status = ModEntry.Instance.KokoroApi.DriveStatus.Underdrive, statusAmount = 3, targetPlayer = false }).AsCardAction;
		
		actionB.disabled = flipped;
		actionA.disabled = flipped;
		actionNone.disabled = flipped;
		
		if (upgrade == Upgrade.A)
		{
			actions.Add(actionA);
			actions.Add(new ADummyAction());
			actions.Add(new AAttack(){damage = GetDmg(s, 3), disabled = !flipped});
		} else if (upgrade == Upgrade.B)
		{
			actions.Add(actionB);
			actions.Add(new ADummyAction());
			actions.Add(new AAttack(){damage = GetDmg(s, 2), disabled = !flipped, piercing = true});
		} else 
		{
			actions.Add(actionNone);
			actions.Add(new ADummyAction());
			actions.Add(new AAttack(){damage = GetDmg(s, 2), disabled = !flipped});
		}
		return actions;
	}
}
