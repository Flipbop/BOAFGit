using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;

namespace Flipbop.BOAF;

internal sealed class LetterOfAcceptanceArtifact : Artifact, IRegisterable
{
	private static ISpriteEntry ActiveSprite = null!;
	private static ISpriteEntry InactiveSprite = null!;
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		ActiveSprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Luna/Artifacts/LetterOfAcceptance.png"));
		InactiveSprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Luna/Artifacts/LetterOfAcceptanceUsed.png"));
		
		helper.Content.Artifacts.RegisterArtifact("LetterOfAcceptance", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.LunaDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!),
			},
			Sprite = ActiveSprite.Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna","artifact", "LetterOfAcceptance", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Luna","artifact", "LetterOfAcceptance", "description"]).Localize
		});
		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(Combat), nameof(Combat.TryPlayCard)),
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(TryLetterOfAcceptance))
		);
	}
	
	public bool used = false;

	public static void TryLetterOfAcceptance(Combat __instance, State s, Card card, bool playNoMatterWhatForFree, bool exhaustNoMatterWhat)
	{

		if (s.EnumerateAllArtifacts().Find(a => a is LetterOfAcceptanceArtifact) is not LetterOfAcceptanceArtifact
		    letterOfAcceptance)
		{
			return;
		}

		if (card.GetCurrentCost(s) <= 1 && !letterOfAcceptance.used && !card.GetDataWithOverrides(s).exhaust)
		{
			letterOfAcceptance.used = true;
			
			s.RemoveCardFromWhereverItIs(card.uuid);
			
			s.deck.Insert(0, card);
		}
	}
	
	public override void OnTurnStart(State state, Combat combat)
	{
		base.OnTurnStart(state, combat);
		used = false;
	}
	
	public override Spr GetSprite()
	{
		if (!used)
		{
			return ActiveSprite.Sprite;
		}
		return InactiveSprite.Sprite;
	}
}
