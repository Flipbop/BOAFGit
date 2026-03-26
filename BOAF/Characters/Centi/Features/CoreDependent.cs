using Nickel;
using System.Linq;
using System.Reflection;
using HarmonyLib;

namespace Flipbop.BOAF;

internal static class CoreDependentExt
{
	public static bool GetIsCoreDependent(this Card self)
		=> ModEntry.Instance.Helper.ModData.GetModDataOrDefault<bool>(self, "CoreDependent");
	public static void SetIsCoreDependent(this Card self, bool value)
		=> ModEntry.Instance.Helper.ModData.SetModData(self, "CoreDependent", value);
}

internal sealed class CoreDependentManager
{
	internal static readonly ICardTraitEntry Trait = ModEntry.Instance.CoreDependentTrait;

	public CoreDependentManager()
	{
		ModEntry.Instance.helper.Content.Cards.OnGetFinalDynamicCardTraitOverrides += (_, data) =>
		{
			State state = data.State;
			if (state.route is Combat combat)
			{
				if (CoreDependentExt.GetIsCoreDependent(data.Card) && !
					    combat.stuff.Values.Any(o => o is Core))
				{
					data.SetOverride(ModEntry.Instance.helper.Content.Cards.UnplayableCardTrait, true);
				}

			}
		};
	}
}
