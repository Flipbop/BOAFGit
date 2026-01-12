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
			ShouldAppearOnMap = (_, map) => IRegisterableEnemy.IfEnabled(thisType, map is MemoryMap ? BattleType.Elite : null)
		}));
		
	}

	public override bool HasCoolerExplosion()
	{
		return true;
	}

	public override void OnCombatStart(State s, Combat c)
	{
		c.bg = new BGCobaltAftermath();
		AStatus a = new AStatus();
		a.targetPlayer = false;
		a.status = Status.survive;
		a.statusAmount = 1;
		a.timer = 0.0;
		c.QueueImmediate(a);
		c.noReward = true;
	}

	public override Ship BuildShipForSelf(State s)
	{
		character = new Character
		{
			type = "void"
		};
		List<Part> parts = [
			new Part {
				key = "cannon.left",
				type = PType.cannon,
				skin = "wing_knight"
			},
			new Part {
				key = "wing",
				type = PType.wing,
				skin = "missiles_gemini_off",
			},
			new Part {
				key = "power.left",
				type = PType.cannon,
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
				type = PType.cannon,
				skin = "wing_knight",
				flip = true
			},
			new Part {
				key = "wing",
				type = PType.wing,
				skin = "missiles_gemini_off",
				flip = true
			},
			new Part {
				key = "cannon.right",
				type = PType.cannon,
				skin = "wing_knight",
				flip = true
			},
		];
		return new Ship {
			x = 6,
			hull = 15,
			hullMax = 15,
			shieldMaxBase = 0,
			ai = this,
			chassisUnder = "chassis_lawless",
			parts = parts
		};
	}
	
	public override Song? GetSong(State s)
	{
		return Song.Polytrope;
	}

	public override void OnSurvived(State s, Combat c)
	{
		base.OnSurvived(s, c);
		c.QueueImmediate(new AHeal(){healAmount = 14, targetPlayer = false});
		c.QueueImmediate(new AStatus(){status = Status.powerdrive, statusAmount = 1, targetPlayer = false, dialogueSelector = "Anger_Power_Up"});
	}

	public override EnemyDecision PickNextIntent(State s, Combat c, Ship ownShip)
	{
		return MoveSet(aiCounter++, () => new EnemyDecision {
			actions = AIHelpers.MoveToAimAt(s, ownShip, s.ship, "cannon.left"),
			intents = [
				new IntentAttack
				{
					key = "power.left",
					damage = 1,
				},
				new IntentAttack
				{
					key = "cannon.left",
					damage = 1,
					multiHit = 5,
				},
			]
			
		}, () => new EnemyDecision
		{
			actions = AIHelpers.MoveToAimAt(s, ownShip, s.ship, "power.left"),
			intents = [
				new IntentAttack
				{
					key = "power.right",
					damage = 1,
				},
				new IntentAttack
				{
					key = "power.left",
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
			]
		}, () => new EnemyDecision
		{
			actions = AIHelpers.MoveToAimAt(s, ownShip, s.ship, "power.right"),
			intents = [
				new IntentAttack
				{
					key = "cannon.right",
					damage = 1,
				},
				new IntentAttack
				{
					key = "power.right",
					damage = 1,
					multiHit = 5,
				},
			]
		}, () => new EnemyDecision
		{
			actions = AIHelpers.MoveToAimAt(s, ownShip, s.ship, "cannon.right"),
			intents = [
				new IntentAttack
				{
					key = "cannon.left",
					damage = 1,
				},
				new IntentAttack
				{
					key = "cannon.right",
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
			]
		});
	}
}
