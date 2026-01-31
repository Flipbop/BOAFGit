using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class DenialCard : Card, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Cards.RegisterCard(MethodBase.GetCurrentMethod()!.DeclaringType!.Name, new()
		{
			CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				deck = Deck.trash,
				rarity = ModEntry.GetCardRarity(MethodBase.GetCurrentMethod()!.DeclaringType!),
			},
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/Cards/Amplifier.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Enemies","card", "Denial", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 1,
			exhaust	= true,
			temporary = true
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=>
		[
			new AStatus() { status = Status.lockdown, statusAmount = 1, targetPlayer = true, dialogueSelector = "Denial_Callout"},
			new AStatus() { status = Status.evade, statusAmount = 2, targetPlayer = true},
		];
};

