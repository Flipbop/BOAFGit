using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Flipbop.BOAF;

internal sealed class MixItUpCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Centi/Cards/MixItUp.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi","card", "MixItUp", "name"]).Localize
		});
	}

	

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = upgrade == Upgrade.A ? 1: 2,
			description =
				ModEntry.Instance.Localizations.Localize([
					"Centi", "card", "MixItUp", "description", upgrade.ToString()
				]),
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.B => [
				new AShuffleShip() {targetPlayer = true},
				new ADetect(){Amount = 1},
				new AShuffleShip() {targetPlayer = true},
				new ADetect(){Amount = 1},
				new AShuffleShip() {targetPlayer = true},
				new ADetect(){Amount = 1},
			],
			_ => [
				new AShuffleShip() {targetPlayer = true},
				new ADetect(){Amount = 3}
			]
			
		};
	public sealed class ASoulHint : AVariableHint
	{
		public override Icon? GetIcon(State s)
			=> new(ModEntry.Instance.soulEnergySprite.Sprite, null, Colors.textMain);


		public override List<Tooltip> GetTooltips(State s)
			=> [new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::SoulEnergyX")
			{
				Description = ModEntry.Instance.Localizations.Localize(["Cull","action", "CurrentSoul", "description"])
			}];
	}
	
}
