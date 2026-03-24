using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;

namespace Flipbop.BOAF;

internal sealed class SystemRelianceArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("SystemReliance", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.CentiDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Centi/Artifacts/SystemReliance.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi","artifact", "SystemReliance", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Centi","artifact", "SystemReliance", "description"]).Localize
		});
		
		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(Card), nameof(Card.GetDataWithOverrides)),
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(ACost_Begin_Postfix)
			));
	}
	
	public override void OnReceiveArtifact(State state)
	{
		state.GetCurrentQueue().QueueImmediate( new ACardSelect()
		{
			browseAction = new CardSelectAddSystemReliance(),
			browseSource = CardBrowse.Source.Deck,
			filterTemporary = false
		});
	}
	
	private static void ACost_Begin_Postfix(ref CardData __result, Card __instance)
	{
		if (ModEntry.Instance.helper.ModData.GetModDataOrDefault<bool>(__instance, "SystemReliant", false))
		{
			__result.cost -= 1;
		}
	}
}

public class CardSelectAddSystemReliance : CardAction
{
	public override Route? BeginWithRoute(G g, State s, Combat c)
	{
		if (selectedCard != null)
		{
			ModEntry.Instance.helper.Content.Cards.SetCardTraitOverride(s, selectedCard, ModEntry.Instance.helper.Content.Cards.RetainCardTrait, true, true);
			ModEntry.Instance.helper.Content.Cards.SetCardTraitOverride(s, selectedCard, ModEntry.Instance.helper.Content.Cards.ExhaustCardTrait, true, true);
			ModEntry.Instance.helper.Content.Cards.SetCardTraitOverride(s, selectedCard, ModEntry.Instance.helper.Content.Cards.BuoyantCardTrait, true, true);

			ModEntry.Instance.helper.ModData.SetModData(selectedCard, "SystemReliant", true);

			return new CustomShowCards
			{
				messageKey = $"{ModEntry.Instance.Package.Manifest.UniqueName}::{nameof(SystemRelianceArtifact)}::ShowCards",
				Message = ModEntry.Instance.Localizations.Localize(["Centi","artifact", "SystemReliance", "ui"]),
				cardIds = [selectedCard.uuid]
			};
		}
		return null;
	}

	public override string? GetCardSelectText(State s)
	{
		return "Select a card to add <c=cardtrait>retain, exhaust, and buoyant</c> to, and reduce its cost by 1, forever.";
	}
	
	private sealed class CustomShowCards : ShowCards
	{
		public required string Message;

		public override void Render(G g)
		{
			DB.currentLocale.strings[messageKey] = Message;
			base.Render(g);
		}
	}
}