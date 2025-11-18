using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using HarmonyLib;
using Microsoft.Extensions.Logging;
using Nanoray.PluginManager;
using Newtonsoft.Json;
using Nickel;

namespace Flipbop.BOAF;

internal sealed class AngerEnemy : AI, IRegisterableEnemy
{
	[JsonProperty]
	private int aiCounter;

	public static void Register(IModHelper helper)
	{
		Type thisType = MethodBase.GetCurrentMethod()!.DeclaringType!;
		IRegisterableEnemy.MakeSetting(helper, helper.Content.Enemies.RegisterEnemy(new() {
			EnemyType = thisType,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Enemies", "ship","Anger", "name"]).Localize,
			ShouldAppearOnMap = (_, map) => IRegisterableEnemy.IfEnabled(thisType, map is MapFinale ? BattleType.Elite : null)
		}));
	}

	public override void OnCombatStart(State s, Combat c)
	{
		c.bg = new BGRunWin();
	}

	public override Ship BuildShipForSelf(State s)
	{
		character = new Character
		{
			type = "void"
		};
		List<Part> parts = [
			new Part {
				key = "wing",
				type = PType.wing,
				skin = "wing_knight"
			},
			new Part {
				key = "cannon.left",
				type = PType.cannon,
				skin = "missiles_gemini_off",
			},
			new Part {
				key = "power.left",
				type = PType.wing,
				skin = "wing_knight"
			},
			new Part {
				key = "cockpit",
				type = PType.cockpit,
				damageModifier = PDamMod.weak,
				stunModifier = PStunMod.stunnable,
				skin = "cockpit_wizard"
			},
			new Part {
				key = "power.right",
				type = PType.wing,
				skin = "wing_knight",
				flip = true
			},
			new Part {
				key = "cannon.right",
				type = PType.cannon,
				skin = "missiles_gemini_off",
				flip = true
			},
			new Part {
				key = "wing",
				type = PType.wing,
				skin = "wing_knight",
				flip = true
			},
		];
		return new Ship {
			x = 6,
			hull = 40,
			hullMax = 40,
			shieldMaxBase = 0,
			ai = this,
			chassisUnder = "chassis_lawless",
			parts = parts
		};
	}

	public override EnemyDecision PickNextIntent(State s, Combat c, Ship ownShip)
	{
		aiCounter++;
		return MoveSet(aiCounter++, () => new EnemyDecision {
			actions = AIHelpers.MoveToAimAt(s, ownShip, s.ship, "cockpit"),
			intents = [
				new IntentAttack
				{
					key = "cannon.left",
					damage = 2,
				},
				new IntentGiveCard
				{
					key = "cockpit",
					card = new AngerCard(),
					amount = 1,
					destination = CardDestination.Hand
				},
				new IntentAttack
				{
					key = "cannon.right",
					damage = 1,
					multiHit = 5,
				},
			]
			
		}, () => new EnemyDecision
		{
			actions = AIHelpers.MoveToAimAt(s, ownShip, s.ship, "cockpit"),
			intents = [
				new IntentAttack
				{
					key = "cannon.left",
					damage = 1,
					multiHit = 5,
				},
				new IntentGiveCard
				{
					key = "cockpit",
					card = new AngerCard(),
					amount = 1,
					destination = CardDestination.Hand
				},
				new IntentAttack
				{
					key = "cannon.right",
					damage = 2,
				},
			]
		});
	}
}
