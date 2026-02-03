using System.Collections.Generic;
using HarmonyLib;
using Nanoray.PluginManager;
using Nickel;
using System.Linq;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class DebrisNetArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("DebrisNet", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.CentiDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Centi/Artifacts/DebrisNet.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi","artifact", "DebrisNet", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Centi","artifact", "DebrisNet", "description"]).Localize
		});
	}
	public override void OnPlayerTakeNormalDamage(State state, Combat combat, int rawAmount, Part? part)
	{
		base.OnPlayerTakeNormalDamage(state, combat, rawAmount, part);
		combat.QueueImmediate(new AReconfigure(){Amount = 1});
		combat.QueueImmediate(new ADetect(){Amount = 1});
	}
	
}
