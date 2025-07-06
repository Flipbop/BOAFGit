using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class HarvestCard : Card, IRegisterable
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
			Art = ModEntry.Instance.placeholderSprite.Sprite,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Cards/TurtleShot.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull", "card", "Harvest", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "8A3388",
			cost = 2,
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.A =>
			[
				new AAttack { damage = GetDmg(s, 2) },
				new AAttack { damage = GetDmg(s, 2) },
				new AAttack { damage = GetDmg(s, 1) }
			],
			Upgrade.B => [
				new AAttack { damage = GetDmg(s, 1), piercing = true},
				new AAttack { damage = GetDmg(s, 1), piercing = true},
				new AAttack { damage = GetDmg(s, 1), piercing = true}
			],
			_ => [
				new AAttack { damage = GetDmg(s, 1) },
				new AAttack { damage = GetDmg(s, 1) },
				new AAttack { damage = GetDmg(s, 1) }
			]
		};
}
