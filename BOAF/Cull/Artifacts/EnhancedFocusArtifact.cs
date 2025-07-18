﻿using HarmonyLib;
using Nanoray.PluginManager;
using Nickel;
using System.Linq;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class EnhancedFocusArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("EnhancedFocus", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.CullDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Cull/Artifacts/UpgradedTerminal.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "EnhancedFocus", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "EnhancedFocus", "description"]).Localize
		});
	}
	public bool _used = false;
	public override void OnDrawCard(State state, Combat combat, int count)
	{
		int index = combat.hand.Count -1;
		int upgradeCount = 0;
		
		while (index >= 0)
		{
			if (combat.hand[index].upgrade != Upgrade.None)
			{
				upgradeCount++;
			} 
			index--;
		}
		if (upgradeCount >= 3 && !_used)
		{
			_used = true;
			combat.Queue([
				new ADrawCard {count = 1}
			]);
		}
	}
	public override void OnTurnEnd(State state, Combat combat)
	{
		base.OnTurnEnd(state, combat);
		_used = false;
	}
}
