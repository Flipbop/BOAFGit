using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class ShootingGalleryCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Centi/Cards/ShootingGallery.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi", "card", "ShootingGallery", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = 1,
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.A => [
				new AAttack(){damage = GetDmg(s, 1)},
				new AReconfigure(){Amount = 1},
				new AAttack(){damage = GetDmg(s, 2)}
			],
			Upgrade.B =>
			[
				new AAttack(){damage = GetDmg(s, 1)},
				new AReconfigure(){Amount = 1},
				new AAttack(){damage = GetDmg(s, 1)},
				new AReconfigure(){Amount = 1},
				new AAttack(){damage = GetDmg(s, 1)}
			],
			_ =>
			[
				new AAttack(){damage = GetDmg(s, 1)},
				new AReconfigure(){Amount = 1},
				new AAttack(){damage = GetDmg(s, 1)}

			]

		};

}