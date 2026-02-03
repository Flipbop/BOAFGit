using HarmonyLib;
using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class AquaHeartArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("CodeInspection", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.CentiDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites
				.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Centi/Artifacts/AquaHeart.png"))
				.Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi", "artifact", "AquaHeart", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Centi", "artifact", "AquaHeart", "description"])
				.Localize
		});
	}

	public override void OnReceiveArtifact(State state)
	{
		base.OnReceiveArtifact(state);
		AReconfigure.codeInspectionAmount = 0;
	}

	public override int? GetDisplayNumber(State s)
	{
		return AReconfigure.codeInspectionAmount;
	}
	
}
