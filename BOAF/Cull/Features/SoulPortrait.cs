using HarmonyLib;
using System;
using System.Linq;
using System.Reflection;
using Flipbop.BOAF;
using Microsoft.Extensions.Logging;
using static HarmonyLib.AccessTools;

namespace Flipbop.BOAF;

internal class SoulPortraitManager
{
	private static ModEntry Instance => ModEntry.Instance;

	public SoulPortraitManager()
	{
		ApplyPatches();
	}
	
	public static void ApplyPatches()
	{
		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(Combat), nameof(Combat.Update)),
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Combat_Update_Postfix))
		);
	}

	/*private static ExternalAnimation GetClosestAnimation(int smug)
	{
		var smugIndex = smug;
		while (true)
		{
			if (Instance.SmugPortraitAnimations.TryGetValue(smugIndex, out var animation))
				return animation;
			smugIndex -= Math.Sign(smugIndex);
			if ((smug == 0 && smugIndex != 0) || Math.Sign(smug) == -Math.Sign(smugIndex))
				return Instance.NeutralPortraitAnimation;
		}
	}*/

	private static void Combat_Update_Postfix(Combat __instance, G g)
	{
		var character = g.state.characters.FirstOrDefault(c => c.deckType == Instance.CullDeck.Deck);
		if (character is null)
			return;

		var soul = g.state.ship.Get(ModEntry.Instance.SoulEnergyStatus.Status);
		if (soul < 10)
		{
			character.loopTag = "neutral";
			return;
		}

		if (soul >= 10)
		{
			character.loopTag = "glow";
			return;
		}

		//character.loopTag = GetClosestAnimation(soul.Value).Tag;
	}
}
