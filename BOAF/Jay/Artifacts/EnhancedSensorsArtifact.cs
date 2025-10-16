using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class EnhancedSensorsArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("EnhancedSensors", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.JayDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Jay/Artifacts/EnhancedSensors.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Jay","artifact", "EnhancedSensors", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Jay","artifact", "EnhancedSensors", "description"]).Localize
		});
	}
}
