using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using daisyowl.text;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class NebulaCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/Cards/Nebula.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna","card", "Nebula", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 2,
			floppable = true
		};

	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = new();
		
		CardAction actionB = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 4),
				new AAttack(){damage = GetDmg(s,7), stunEnemy = true}).AsCardAction;
		CardAction actionA = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 3),
				new AAttack(){damage = GetDmg(s,5), stunEnemy = true}).AsCardAction;
		CardAction actionNone = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 3),
				new AAttack(){damage = GetDmg(s,4), stunEnemy = true}).AsCardAction;
		
		actionB.disabled = flipped;
		actionA.disabled = flipped;
		actionNone.disabled = flipped;
		
		if (upgrade == Upgrade.A)
		{
			actions.Add(new AStatus(){statusAmount = 3, targetPlayer = true, status = Status.shield, disabled = flipped});
			actions.Add(actionA);
			actions.Add(new ADummyAction());
			actions.Add(new AStatus(){statusAmount = 3, targetPlayer = true, status = Status.shield, disabled = !flipped});
		} else if (upgrade == Upgrade.B)
		{
			actions.Add(new AStatus(){statusAmount = 2, targetPlayer = true, status = Status.shield, disabled = flipped});
			actions.Add(actionB);
			actions.Add(new ADummyAction());
			actions.Add(new AStatus(){statusAmount = 4, targetPlayer = true, status = Status.tempShield, disabled = !flipped});
		} else 
		{
			actions.Add(new AStatus(){statusAmount = 2, targetPlayer = true, status = Status.shield, disabled = flipped});
			actions.Add(actionNone);
			actions.Add(new ADummyAction());
			actions.Add(new AStatus(){statusAmount = 2, targetPlayer = true, status = Status.shield, disabled = !flipped});
		}
		return actions;
	}
}
	

