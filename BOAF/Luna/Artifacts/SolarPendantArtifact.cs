using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;

namespace Flipbop.BOAF;

internal sealed class SolarPendantArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("SolarPendant", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.LunaDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!),
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Luna/Artifacts/SolarPendant.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna","artifact", "SolarPendant", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Luna","artifact", "SolarPendant", "description"]).Localize
		});
	}
}
