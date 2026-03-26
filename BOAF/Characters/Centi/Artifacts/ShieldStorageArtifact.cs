using System;
using HarmonyLib;
using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class ShieldStorageArtifact : Artifact, IRegisterable, IKokoroApi.IV2.IStatusLogicApi.IHook, IKokoroApi.IV2.IHookPriority
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("ShieldStorage", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.CentiDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites
				.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Centi/Artifacts/ShieldStorage.png"))
				.Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi", "artifact", "ShieldStorage", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Centi", "artifact", "ShieldStorage", "description"])
				.Localize
		});
	}

	public double HookPriority
		=> double.MinValue;

	public int ModifyStatusChange(IKokoroApi.IV2.IStatusLogicApi.IHook.IModifyStatusChangeArgs args)
	{
		if (!args.Ship.isPlayerShip)
			return args.NewAmount;
		if (args.Status != Status.shield)
			return args.NewAmount;

		var maxShield = args.Ship.GetMaxShield();
		var overshield = Math.Max(0, args.NewAmount - maxShield);
		if (overshield <= 0)
			return args.NewAmount;

		var newAmount = args.NewAmount - overshield;
		args.Combat.QueueImmediate(new AStatus
		{
			status = Status.bubbleJuice,
			statusAmount = 1,
			targetPlayer = true,
			artifactPulse = Key(),
		});
		return newAmount;
	}
}
