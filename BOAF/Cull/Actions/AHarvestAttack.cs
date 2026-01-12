using FSPRO;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using Microsoft.Extensions.Logging;


namespace Flipbop.BOAF;

public sealed class AHarvestAttack : AAttack
{
	public override void Begin(G g, State s, Combat c)
	{
		ModEntry.Instance.helper.ModData.SetModData(c, "isHarvest", true);
		base.Begin(g, s, c);
		ModEntry.Instance.helper.ModData.SetModData(c, "isHarvest", false);

	}

	public static void ApplyPatches(IHarmony harmony, ILogger logger)
	{
		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(Ship), nameof(Ship.NormalDamage)),
			prefix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Ship_ShieldDamage_Prefix)),
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Ship_ShieldDamage_Postfix))
		);
	}

	private static void Ship_ShieldDamage_Prefix(Ship __instance, out int __state)
	{
		__state = __instance.Get(Status.shield) + __instance.Get(Status.tempShield);
	}

	private static void Ship_ShieldDamage_Postfix(Ship __instance, State s, Combat c, in int __state)
	{
		var damageTaken = __state - (__instance.Get(Status.shield) + __instance.Get(Status.tempShield));
		if (damageTaken <= 0)
			return;
		if (__instance.isPlayerShip)
			return;
		if (!ModEntry.Instance.helper.ModData.GetModDataOrDefault<bool>(c, "isHarvest", false))
			return;
		c.QueueImmediate(new AStatus() {status = ModEntry.Instance.SoulEnergyStatus.Status, statusAmount = 1, targetPlayer = true});
	}
	
	public override Icon? GetIcon(State s)
	{
		return new Icon(ModEntry.Instance.harvestAttackSprite.Sprite, number: damage,color: Colors.redd, flipY: false);
	}

	public override List<Tooltip> GetTooltips(State s)
		=> [
			new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::HarvestAttack")
			{
				Icon = ModEntry.Instance.harvestAttackSprite.Sprite,
				TitleColor = Colors.action,
				Title = ModEntry.Instance.Localizations.Localize(["Cull","action", "HarvestAttack", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Cull","action", "HarvestAttack", "description"])
			},
			new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::SoulEnergy")
			{
				Icon = ModEntry.Instance.soulEnergySprite.Sprite,
				TitleColor = Colors.action,
				Title = ModEntry.Instance.Localizations.Localize(["Cull","status", "SoulEnergy", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Cull","status", "SoulEnergy", "description"])
			}
		];
}
