using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

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
	}
	
	
}
