using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using HarmonyLib;
using Nickel;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class FearManager : IKokoroApi.IV2.IStatusRenderingApi.IHook
{
	internal static IStatusEntry FearStatus { get; private set; } = null!;

	public FearManager()
	{
		ModEntry.Instance.KokoroApi.StatusRendering.RegisterHook(this);
		
	}
	

}
