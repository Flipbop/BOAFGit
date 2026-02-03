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
				key = "wing.left",
				type = PType.wing,
				skin = "missiles_gemini_off"
			},
			new Part {
				key = "cannon.left",
				type = PType.cannon,
				skin = "wing_knight"
			},
			new Part {
				key = "cannon.right",
				type = PType.cannon,
				skin = "wing_knight"
			},
			new Part()
			{
				key = "scaffold"	,
				type = PType.empty,
				skin = "scaffolding_asym",
				flip = true
			},
			new Part {
				key = "cockpit",
				type = PType.cockpit,
				skin = "cockpit_wizard",
				stunModifier = PStunMod.stunnable
			},
			new Part {
				key = "wing.right",
				type = PType.wing,
				skin = "missiles_gemini_off",
				flip = true
			},
		];
		return new Ship {
			x = 6,
			hull = 12,
			hullMax = 12,
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
		c.QueueImmediate(new AHeal() {targetPlayer = false, healAmount = 11});
		c.QueueImmediate(new AStatus(){status = ModEntry.Instance.KokoroApi.DriveStatus.Underdrive, statusAmount = 4, targetPlayer = true, dialogueSelector = "Depression_Power_Up"});
	}

	public override EnemyDecision PickNextIntent(State s, Combat c, Ship ownShip)
	{
		return MoveSet(aiCounter++, () => new EnemyDecision {
			actions = AIHelpers.MoveToAimAt(s, ownShip, s.ship, "cannon.left"),
			intents = [
				new IntentAttack()
				{
					damage = 2,
					key = "cannon.left"
				},
				new IntentAttack()
				{
					damage = 2,
					key = "cannon.right",
					status = ModEntry.Instance.KokoroApi.DriveStatus.Underdrive,
					statusAmount = 1
				}
			]
			
		}, () => new EnemyDecision
		{
			actions = AIHelpers.MoveToAimAt(s, ownShip, s.ship, "cannon.right"),
			intents = [
				new IntentAttack()
				{
					damage = 2,
					key = "cannon.right"
				},
				new IntentStatus()
				{
					status = ModEntry.Instance.KokoroApi.DriveStatus.Underdrive,
					amount = 2,
					key = "cockpit",
					targetSelf = false
				}
			]
		}, () => new EnemyDecision
		{
			actions = AIHelpers.MoveToAimAt(s, ownShip, s.ship, "cannon.left"),
			intents = [
				new IntentAttack()
				{
					damage = 3,
					key = "cannon.left",
					status = ModEntry.Instance.KokoroApi.DriveStatus.Underdrive,
					statusAmount = 1
				},
				new IntentStatus()
				{
					status = Status.shield,
					amount = 5,
					key = "cockpit",
					targetSelf = true
				},
			]
		}, () => new EnemyDecision
		{
			actions = AIHelpers.MoveToAimAt(s, ownShip, s.ship, "cannon.right"),
			intents = [
				new IntentAttack()
				{
					damage = 2,
					key = "cannon.right",
					cardOnHit = new DepressionCard(),
					destination = CardDestination.Hand
				},
				new IntentAttack()
				{
					damage = 2,
					key = "cannon.left",
					cardOnHit = new DepressionCard(),
					destination = CardDestination.Hand
				},
			]
		});
	}
}
