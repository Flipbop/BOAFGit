using Nickel;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal static class ShimmeredExt
{
	public static bool GetIsShimmered(this Card self)
		=> ModEntry.Instance.Helper.ModData.GetModDataOrDefault<bool>(self, "Shimmered");
	public static void SetIsShimmered(this Card self, bool value)
		=> ModEntry.Instance.Helper.ModData.SetModData(self, "Shimmered", value);
}

internal sealed class ShimmeredManager : IKokoroApi.IV2.IActionCostsApi.IResourceProvider
{
	internal static readonly ICardTraitEntry Trait = ModEntry.Instance.ShimmeredTrait;

	public ShimmeredManager()
	{
		ModEntry.Instance.KokoroApi.ActionCosts.RegisterResourceProvider(this, 1000);
	}

	public int GetCurrentResourceAmount(IKokoroApi.IV2.IActionCostsApi.IResourceProvider.IGetCurrentResourceAmountArgs args)
	{
		if (args.Card is not { } card)
			return 0;
		if (!args.Card.GetIsShimmered())
			return 0;
		if (ModEntry.Instance.KokoroApi.ActionCosts.AsStatusResource(args.Resource) is { } statusResource && statusResource.Status == ModEntry.Instance.StardustStatus.Status)
			return 999;
		return 0;
	}

	public void PayResource(IKokoroApi.IV2.IActionCostsApi.IResourceProvider.IPayResourceArgs args)
	{
		if (args.Card is not { } card)
			return;
		args.Card.SetIsShimmered(false);
	}
}
