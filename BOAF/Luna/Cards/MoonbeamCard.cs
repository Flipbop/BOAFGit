using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class MoonbeamCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/Cards/Moonbeam.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna", "card", "Moonbeam", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 3,
			exhaust = upgrade == Upgrade.B,
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.A => [
				new AStardustHint() {hand = true},
				new AAttack(){xHint = 1, damage = GetDmg(s, StardustManager.StardustMax - s.ship.Get(ModEntry.Instance.StardustStatus.Status))},
				new AStatus(){status = ModEntry.Instance.ResidualDustStatus.Status, statusAmount = 1, targetPlayer = true},
			],
			Upgrade.B =>
			[
				new AStardustHint() {hand = true},
				new AAttack(){xHint = 2, damage = GetDmg(s, 2*(StardustManager.StardustMax - s.ship.Get(ModEntry.Instance.StardustStatus.Status)))}
			],
			_ =>
			[
				new AStardustHint() {hand = true},
				new AAttack(){xHint = 1, damage = GetDmg(s, StardustManager.StardustMax - s.ship.Get(ModEntry.Instance.StardustStatus.Status))}
			]

		};

	public sealed class AStardustHint : AVariableHint
	{
		public override Icon? GetIcon(State s)
			=> new(ModEntry.Instance.stardustCostSprite.Sprite, null, Colors.textMain);


		public override List<Tooltip> GetTooltips(State s)
			=> [new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::StardustX")
			{
				Description = ModEntry.Instance.Localizations.Localize(["Luna","action", "MissingDust", "description"])
			}];
	}
}