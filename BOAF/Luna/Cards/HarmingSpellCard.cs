using Nanoray.PluginManager;


using Nickel;
using System.Collections.Generic;
using System.Reflection;
using daisyowl.text;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class HarmingSpellCard : Card, IRegisterable
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
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna","card", "HarmingSpell", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = upgrade == Upgrade.A ? 1 : 2,
			floppable = true,
		};

	public override List<CardAction> GetActions(State s, Combat c)
	{
		List<CardAction> actions = new();
		
		CardAction actionB = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 3),
				new AAttack(){damage = GetDmg(s, 7)}).AsCardAction;
		CardAction actionNone = ModEntry.Instance.KokoroApi.ActionCosts
			.MakeCostAction(ModEntry.Instance.KokoroApi.ActionCosts.MakeResourceCost(new StardustCost(), 2),
				new AAttack(){damage = GetDmg(s, 5)}).AsCardAction;
		
		actionB.disabled = flipped;
		actionNone.disabled = flipped;
		
		if (upgrade == Upgrade.B)
		{
			actions.Add(actionB);
			actions.Add(new ADummyAction());
			actions.Add(new AStatus() { status = Status.overdrive, statusAmount = 3, targetPlayer = true, disabled = !flipped});
		} else 
		{
			actions.Add(actionNone);
			actions.Add(new ADummyAction());
			actions.Add(new AStatus() { status = Status.overdrive, statusAmount = 2, targetPlayer = true, disabled = !flipped });
		}
		return actions;
	}
}

