﻿using HarmonyLib;
using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class CleoCatArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		if (ModEntry.Instance.DuoArtifactsApi is not { } api)
			return;

		helper.Content.Artifacts.RegisterArtifact("CleoCat", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = api.DuoArtifactVanillaDeck,
				pools = [ArtifactPool.Common]
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Cull/Artifacts/Duo/CleoCat.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Duo", "CleoCat", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Duo", "CleoCat", "description"]).Localize
		});

		api.RegisterDuoArtifact(MethodBase.GetCurrentMethod()!.DeclaringType!, [ModEntry.Instance.CullDeck.Deck, Deck.colorless]);

		NoneOfTheAboveCard.Register(package, helper);

		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(CardReward), nameof(CardReward.Render)),
			prefix: new HarmonyMethod(AccessTools.DeclaredMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(CardReward_Render_Prefix)), priority: Priority.Last)
		);
	}

	public override List<Tooltip>? GetExtraTooltips()
		=> [new TTCard { card = new NoneOfTheAboveCard() }];

	private static void CardReward_Render_Prefix(CardReward __instance, G g)
	{
		if (g.state.route is not Combat)
			return;
		if (__instance.cards.Any(card => card is NoneOfTheAboveCard))
			return;
		if (g.state.EnumerateAllArtifacts().FirstOrDefault(a => a is CleoCatArtifact) is not { } artifact)
			return;

		artifact.Pulse();

		if (__instance.cards.Count >= 7)
			__instance.cards.RemoveAt(g.state.rngCardOfferings.NextInt() % __instance.cards.Count);

		__instance.cards.Add(new NoneOfTheAboveCard
		{
			temporaryOverride = true,
			drawAnim = 1,
			flipAnim = 1,
		});
	}

	private sealed class NoneOfTheAboveCard : Card, IRegisterable
	{
		public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
		{
			helper.Content.Cards.RegisterCard("CleoCatNoneOfTheAboveCard", new()
			{
				CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
				Meta = new()
				{
					deck = ModEntry.Instance.DuoArtifactsApi!.DuoArtifactVanillaDeck,
					rarity = ModEntry.GetCardRarity(MethodBase.GetCurrentMethod()!.DeclaringType!),
					upgradesTo = [Upgrade.A, Upgrade.B],
					dontOffer = true,
				},
				Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Cards/Duo/CleoCatNoneOfTheAbove.png")).Sprite,
				Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Duo", "CleoCatNoneOfTheAbove", "name"]).Localize
			});
		}

		public override CardData GetData(State state)
			=> new()
			{
				cost = 0,
				exhaust = true,
				temporary = true
			};

		public override List<CardAction> GetActions(State s, Combat c)
			=> [
				new AEnergy
				{
					changeAmount = upgrade == Upgrade.A ? 2 : 1
				},
				new ADrawCard
				{
					count = upgrade == Upgrade.B ? 4 : 1
				}
			];
	}
}