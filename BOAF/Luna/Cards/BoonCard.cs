using Nanoray.PluginManager;


using Nickel;
using System.Collections.Generic;
using System.Reflection;
using daisyowl.text;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class BoonCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/Cards/HarmingSpell.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna","card", "Boon", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = upgrade == Upgrade.B ? 2 : 1,
			floppable = true,
			exhaust = true,
			retain = upgrade == Upgrade.A,
			buoyant = true,
		};

	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = new();
		
		CardAction actionB = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 3),
				new AStatus(){status = Status.boost, statusAmount = 4, targetPlayer = true}).AsCardAction;
		CardAction actionNone = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 2),
				new AStatus(){status = Status.boost, statusAmount = 2, targetPlayer = true}).AsCardAction;
		
		actionB.disabled = flipped;
		actionNone.disabled = flipped;
		
		if (upgrade == Upgrade.B)
		{
			actions.Add(actionB);
			actions.Add(new ADummyAction());
			actions.Add(new ADrawCard(){count = 2, disabled = !flipped});
		} else 
		{
			actions.Add(actionNone);
			actions.Add(new ADummyAction());
			actions.Add(new ADrawCard(){count = 1, disabled = !flipped});
		}
		return actions;
	}
}

