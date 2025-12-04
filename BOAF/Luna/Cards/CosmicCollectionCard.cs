using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using daisyowl.text;
using Shockah.Kokoro;


namespace Flipbop.BOAF;

internal sealed class CosmicCollectionCard : Card, IRegisterable
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
			Art = StableSpr.cards_colorless,//helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/Cards/CosmicCollection.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna","card", "CosmicCollection", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = upgrade switch
			{
				Upgrade.B => 3,
				Upgrade.A => 1,
				_ => 2,
			},
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
			{
				
				Upgrade.B =>
				[
					new AStatus(){statusAmount = 2, targetPlayer = true, status = ModEntry.Instance.KokoroApi.DriveStatus.Pulsedrive},
					new AStatus(){statusAmount = 2, targetPlayer = true, status = Status.stunCharge},
					new AStatus(){statusAmount = 2, targetPlayer = true, status = Status.shield},
					new AStatus(){statusAmount = 2, targetPlayer = true, status = Status.drawNextTurn},
					new AStatus(){statusAmount = 2, targetPlayer = true, status = Status.evade},
				],
				_ =>
				[
					new AStatus(){statusAmount = 1, targetPlayer = true, status = ModEntry.Instance.KokoroApi.DriveStatus.Pulsedrive},
					new AStatus(){statusAmount = 1, targetPlayer = true, status = Status.stunCharge},
					new AStatus(){statusAmount = 1, targetPlayer = true, status = Status.shield},
					new AStatus(){statusAmount = 1, targetPlayer = true, status = Status.drawNextTurn},
					new AStatus(){statusAmount = 1, targetPlayer = true, status = Status.evade},
				]
			
		};
	
}

