﻿using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class EnchantedScytheArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("EnchantedScythe", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.CullDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Cull/Artifacts/PowerEcho.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "EnchantedScythe", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "EnchantedScythe", "description"]).Localize
		});
	}

	public bool _firstCard = true;
	public override void OnPlayerPlayCard(int energyCost, Deck deck, Card card, State state, Combat combat, int handPosition, int handCount)
	{
		base.OnPlayerPlayCard(energyCost, deck, card, state, combat, handPosition, handCount);
		Card newCard = card.CopyWithNewId();
		if ((card.upgrade != Upgrade.None) && _firstCard)
		{
			newCard.temporaryOverride = true;
			newCard.singleUseOverride = true;
			_firstCard = false;
			combat.Queue([
				new AAddCard
				{
					card = newCard, destination = CardDestination.Hand
				},
			]);
		}
	}

	public override void OnTurnStart(State state, Combat combat)
	{
		base.OnTurnStart(state, combat);
		_firstCard = true;
	}
	public override void OnCombatEnd(State state)
	{
		base.OnCombatEnd(state);
		_firstCard = true;
	}
}
