using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class NoxoiusCloudCard : Card, IRegisterable
{
	private static IKokoroApi.IV2.IConditionalApi Conditional => ModEntry.Instance.KokoroApi.Conditional;

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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Cards/NecessarySacrifice.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","card", "NoxiousCloud", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 2,
			exhaust = true,
			artOverlay = ModEntry.Instance.UncommonCullBorder
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=>upgrade switch
		{
			Upgrade.A =>
			[
				new AStatus() {targetPlayer = true, statusAmount = 2, status = Status.droneShift},
				new ASpawn() {fromPlayer = true, thing = new Missile{missileType = MissileType.corrode}}
			],
			Upgrade.B => [
				new ASpawn() {fromPlayer = true, thing = new Missile{missileType = MissileType.normal}, offset = -1},
				new ASpawn() {fromPlayer = true, thing = new Missile{missileType = MissileType.corrode}}
			],
			_ => [
				new ASpawn() {fromPlayer = true, thing = new Missile{missileType = MissileType.corrode}}
			]
		};
}
