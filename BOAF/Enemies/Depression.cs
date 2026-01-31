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

internal sealed class DepressionEnemy : AI, IRegisterableEnemy
{
	[JsonProperty]
	private int aiCounter;
	
	public static void Register(IModHelper helper)
	{
		Type thisType = MethodBase.GetCurrentMethod()!.DeclaringType!;
		IRegisterableEnemy.MakeSetting(helper, helper.Content.Enemies.RegisterEnemy(new() {
			EnemyType = thisType,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Enemies", "ship","Depression", "name"]).Localize,
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
				key = "outerwing.left",
				type = PType.wing,
				skin = "missiles_gemini_off"
			},
			new Part()
			{
				key = "scaffold.left"	,
				type = PType.empty,
				skin = "scaffolding_asym",
			},
			new Part {
				key = "innerwing.left",
				type = PType.wing,
				skin = "missiles_gemini_off"
			},
			new Part {
				key = "cannon.left",
				type = PType.cannon,
				skin = "wing_knight"
			},
			new Part {
				key = "cockpit",
				type = PType.cockpit,
				skin = "cockpit_wizard"
			},
			new Part {
				key = "cannon.right",
				type = PType.cannon,
				skin = "wing_knight",
				flip = true
			},
			new Part {
				key = "innerwing.right",
				type = PType.wing,
				skin = "missiles_gemini_off",
				flip = true
			},
			new Part()
			{
				key = "scaffold.right"	,
				type = PType.empty,
				skin = "scaffolding_asym",
				flip = true
			},
			new Part {
				key = "outerwing.right",
				type = PType.wing,
				skin = "missiles_gemini_off",
				flip = true
			},
		];
		return new Ship {
			x = 6,
			hull = 7,
			hullMax = 7,
			shieldMaxBase = 8,
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
		c.QueueImmediate(new AHeal() {targetPlayer = false, healAmount = 6});
		c.QueueImmediate(new AStatus(){status = ModEntry.Instance.KokoroApi.DriveStatus.Underdrive, statusAmount = 2, targetPlayer = true, dialogueSelector = "Depression_Power_Up"});
	}

	public override EnemyDecision PickNextIntent(State s, Combat c, Ship ownShip)
	{
		return MoveSet(aiCounter++, () => new EnemyDecision {
			actions = AIHelpers.MoveToAimAt(s, ownShip, s.ship, "cockpit"),
			intents = [
				new IntentAttack()
				{
					damage = 3,
					key = "cannon.left"
				},
				new IntentAttack()
				{
					damage = 3,
					key = "cannon.right"
				}
			]
			
		}, () => new EnemyDecision
		{
			actions = AIHelpers.MoveToAimAt(s, ownShip, s.ship, "cockpit"),
			intents = [
				new IntentAttack()
				{
					damage = 2,
					key = "cannon.left"
				},
				new IntentAttack()
				{
					damage = 2,
					key = "cannon.right"
				},
				new IntentStatus()
				{
					status = Status.shield,
					amount = 2,
					key = "cockpit",
					targetSelf = true
				}
			]
		}, () => new EnemyDecision
		{
			actions = AIHelpers.MoveToAimAt(s, ownShip, s.ship, "cockpit"),
			intents = [
				new IntentAttack()
				{
					damage = 2,
					key = "cannon.left"
				},
				new IntentAttack()
				{
					damage = 2,
					key = "cannon.right"
				},
				new IntentStatus()
				{
					status = Status.tempShield,
					amount = 1,
					key = "outerwing.left",
					targetSelf = true
				},
				new IntentStatus()
				{
					status = Status.tempShield,
					amount = 1,
					key = "outerwing.right",
					targetSelf = true
				}
			]
		}, () => new EnemyDecision
		{
			actions = AIHelpers.MoveToAimAt(s, ownShip, s.ship, "cockpit"),
			intents = [
				new IntentAttack()
				{
					damage = 1,
					key = "cannon.left"
				},
				new IntentAttack()
				{
					damage = 1,
					key = "cannon.right"
				},
				new IntentGiveCard
				{
					key = "cockpit",
					card = new DepressionCard(),
					amount = 1,
					destination = CardDestination.Hand
				},
			]
		});
	}
}
