using FSPRO;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;


namespace Flipbop.BOAF;

public sealed class AHarvestAttack : AAttack
{
	public override void Begin(G g, State s, Combat c)
	{
		base.Begin(g, s, c);
		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(Ship), nameof(Ship.DirectHullDamage)),
			prefix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Ship_ShieldDamage_Prefix)),
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Ship_ShieldDamage_Postfix))
		);
	}

	private static void Ship_ShieldDamage_Prefix(Ship __instance, out int __state)
		=> __state = __instance.statusEffects[Status.shield] + __instance.statusEffects[Status.tempShield];

	private static void Ship_ShieldDamage_Postfix(Ship __instance, State s, Combat c, in int __state)
	{
		var damageTaken = __state - __instance.statusEffects[Status.shield] + __instance.statusEffects[Status.tempShield];
		if (damageTaken <= 0)
			return;
		if (__instance.isPlayerShip)
			return;
		c.QueueImmediate(new AStatus() {status = ModEntry.Instance.SoulEnergyStatus.Status, statusAmount = 1, targetPlayer = true});

	}
	
	public override Icon? GetIcon(State s)
	{
		return new Icon(ModEntry.Instance.harvestAttackSprite.Sprite, number: damage,color: Colors.redd, flipY: false);
	}

	public override List<Tooltip> GetTooltips(State s)
		=> [
			new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::Impair")
			{
				Icon = ModEntry.Instance.harvestAttackSprite.Sprite,
				TitleColor = Colors.action,
				Title = ModEntry.Instance.Localizations.Localize(["Cull","action", "HarvestAttack", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Cull","action", "HarvestAttack", "description"])
			}
		];
}
