using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;

namespace Flipbop.BOAF;

internal sealed class ComponentPouchArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("ComponentPouch", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.LunaDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!),
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Luna/Artifacts/ComponentPouch.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna","artifact", "ComponentPouch", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Luna","artifact", "ComponentPouch", "description"]).Localize
		});
	}

	public bool initialBoostReady = false;

	public override void OnReceiveArtifact(State state)
	{
		base.OnReceiveArtifact(state);
		StardustManager.StardustMax += 5;
		initialBoostReady = true;
	}

	public override void OnCombatStart(State state, Combat combat)
	{
		base.OnCombatStart(state, combat);
		if (initialBoostReady)
		{
			combat.QueueImmediate(new AStatus(){statusAmount = 5, targetPlayer = true, status = ModEntry.Instance.StardustStatus.Status});
			initialBoostReady = false;
		}
	}

	public override void OnCombatEnd(State state)
	{
		base.OnCombatEnd(state);
		if (state.ship.hull <= 0)
		{
			StardustManager.StardustMax -= 5;
		}
	}
}
