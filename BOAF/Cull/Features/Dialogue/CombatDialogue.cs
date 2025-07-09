using Nickel;
using System.Collections.Generic;

namespace Flipbop.BOAF;

internal sealed class CombatDialogue : BaseDialogue
{
	public CombatDialogue() : base(locale => ModEntry.Instance.Package.PackageRoot.GetRelativeFile($"i18n/dialogue-combat-{locale}.json").OpenRead())
	{
		var cullDeck = ModEntry.Instance.CullDeck.Deck;
		var cullType = ModEntry.Instance.CullCharacter.CharacterType;
		var newNodes = new Dictionary<IReadOnlyList<string>, StoryNode>();
		var saySwitchNodes = new Dictionary<IReadOnlyList<string>, Say>();

		ModEntry.Instance.Helper.Events.OnModLoadPhaseFinished += (_, phase) =>
		{
			if (phase != ModLoadPhase.AfterDbInit)
				return;
			InjectStory(newNodes, [], saySwitchNodes, NodeType.combat);
		};
		ModEntry.Instance.Helper.Events.OnLoadStringsForLocale += (_, e) => InjectLocalizations(newNodes, [], saySwitchNodes, e);

		#region TookDamage
		for (var i = 0; i < 3; i++)
			newNodes[["Cull", "TookDamage", "Basic", i.ToString()]] = new()
			{
				enemyShotJustHit = true,
				minDamageDealtToPlayerThisTurn = 1,
				lines = [
					new Say { who = cullType, loopTag = "squint" },
				],
			};

		newNodes[["Cull", "TookDamage", "Dizzy"]] = new()
		{
			enemyShotJustHit = true,
			minDamageDealtToPlayerThisTurn = 1,
			allPresent = [cullType, Deck.dizzy.Key()],
			lines = [
				new Say { who = Deck.dizzy.Key(), loopTag = "nervous" },
				new Say { who = cullType, loopTag = "squint" },
			],
		};
		newNodes[["Cull", "TookDamage", "Riggs"]] = new()
		{
			enemyShotJustHit = true,
			minDamageDealtToPlayerThisTurn = 1,
			allPresent = [cullType, Deck.riggs.Key()],
			lines = [
				new Say { who = Deck.riggs.Key(), loopTag = "nervous" },
				new Say { who = cullType, loopTag = "squint" },
			],
		};
		newNodes[["Cull", "TookDamage", "Peri"]] = new()
		{
			enemyShotJustHit = true,
			minDamageDealtToPlayerThisTurn = 1,
			allPresent = [cullType, Deck.peri.Key()],
			lines = [
				new Say { who = cullType, loopTag = "squint" },
				new Say { who = Deck.peri.Key(), loopTag = "neutral" },
			],
		};
		newNodes[["Cull", "TookDamage", "Isaac"]] = new()
		{
			enemyShotJustHit = true,
			minDamageDealtToPlayerThisTurn = 1,
			allPresent = [cullType, Deck.goat.Key()],
			lines = [
				new Say { who = Deck.goat.Key(), loopTag = "squint" },
				new Say { who = cullType, loopTag = "squint" },
			],
		};
		newNodes[["Cull", "TookDamage", "Drake"]] = new()
		{
			enemyShotJustHit = true,
			minDamageDealtToPlayerThisTurn = 1,
			allPresent = [cullType, Deck.eunice.Key()],
			lines = [
				new Say { who = cullType, loopTag = "squint" },
				new Say { who = Deck.eunice.Key(), loopTag = "neutral" },
			],
		};
		newNodes[["Cull", "TookDamage", "Max"]] = new()
		{
			enemyShotJustHit = true,
			minDamageDealtToPlayerThisTurn = 1,
			allPresent = [cullType, Deck.hacker.Key()],
			lines = [
				new Say { who = Deck.hacker.Key(), loopTag = "mad" },
				new Say { who = cullType, loopTag = "neutral" },
			],
		};
		newNodes[["Cull", "TookDamage", "Books"]] = new()
		{
			enemyShotJustHit = true,
			minDamageDealtToPlayerThisTurn = 1,
			allPresent = [cullType, Deck.shard.Key()],
			lines = [
				new Say { who = cullType, loopTag = "squint" },
				new Say { who = Deck.shard.Key(), loopTag = "paws" },
			],
		};
		newNodes[["Cull", "TookDamage", "CAT"]] = new()
		{
			enemyShotJustHit = true,
			minDamageDealtToPlayerThisTurn = 1,
			allPresent = [cullType, "comp"],
			lines = [
				new Say { who = cullType, loopTag = "neutral" },
				new Say { who = "comp", loopTag = "neutral" },
			],
		};
		#endregion

		for (var i = 0; i < 1; i++)
			newNodes[["Cull", "TookNonHullDamage", "Basic", i.ToString()]] = new StoryNode()
			{
				enemyShotJustHit = true,
				maxDamageDealtToPlayerThisTurn = 0,
				allPresent = [cullType],
				lines = [
					new Say { who = cullType, loopTag = "neutral" },
				],
			};

		#region DealtDamage
		for (var i = 0; i < 4; i++)
			newNodes[["Cull", "DealtDamage", "Basic", i.ToString()]] = new()
			{
				playerShotJustHit = true,
				minDamageDealtToEnemyThisTurn = 1,
				allPresent = [cullType],
				lines = [
					new Say { who = cullType, loopTag = "neutral" },
				],
			};

		newNodes[["Cull", "DealtDamage", "Dizzy"]] = new()
		{
			playerShotJustHit = true,
			minDamageDealtToEnemyThisTurn = 1,
			whoDidThat = cullDeck,
			allPresent = [cullType, Deck.dizzy.Key()],
			lines = [
				new Say { who = Deck.dizzy.Key(), loopTag = "neutral" },
				new Say { who = cullType, loopTag = "explain" },
			],
		};
		newNodes[["Cull", "DealtDamage", "Riggs"]] = new()
		{
			playerShotJustHit = true,
			minDamageDealtToEnemyThisTurn = 1,
			allPresent = [cullType, Deck.riggs.Key()],
			lines = [
				new Say { who = cullType, loopTag = "neutral" },
				new Say { who = Deck.riggs.Key(), loopTag = "neutral" },
			],
		};
		newNodes[["Cull", "DealtDamage", "Peri"]] = new()
		{
			playerShotJustHit = true,
			minDamageDealtToEnemyThisTurn = 1,
			whoDidThat = cullDeck,
			allPresent = [cullType, Deck.peri.Key()],
			lines = [
				new Say { who = Deck.peri.Key(), loopTag = "neutral" },
				new Say { who = cullType, loopTag = "explain" },
			],
		};
		newNodes[["Cull", "DealtDamage", "Isaac"]] = new()
		{
			playerShotJustHit = true,
			minDamageDealtToEnemyThisTurn = 1,
			whoDidThat = cullDeck,
			allPresent = [cullType, Deck.goat.Key()],
			lines = [
				new Say { who = Deck.goat.Key(), loopTag = "neutral" },
				new Say { who = cullType, loopTag = "neutral" },
			],
		};
		newNodes[["Cull", "DealtDamage", "Drake"]] = new()
		{
			playerShotJustHit = true,
			minDamageDealtToEnemyThisTurn = 1,
			allPresent = [cullType, Deck.eunice.Key()],
			lines = [
				new Say { who = cullType, loopTag = "explain" },
				new Say { who = Deck.eunice.Key(), loopTag = "sly" },
			],
		};
		newNodes[["Cull", "DealtDamage", "Max"]] = new()
		{
			playerShotJustHit = true,
			minDamageDealtToEnemyThisTurn = 1,
			allPresent = [cullType, Deck.hacker.Key()],
			lines = [
				new Say { who = cullType, loopTag = "neutral" },
				new Say { who = Deck.hacker.Key(), loopTag = "neutral" },
			],
		};
		newNodes[["Cull", "DealtDamage", "Books"]] = new()
		{
			playerShotJustHit = true,
			minDamageDealtToEnemyThisTurn = 1,
			allPresent = [cullType, Deck.shard.Key()],
			lines = [
				new Say { who = cullType, loopTag = "neutral" },
				new Say { who = Deck.shard.Key(), loopTag = "blush" },
			],
		};
		newNodes[["Cull", "DealtDamage", "CAT"]] = new()
		{
			playerShotJustHit = true,
			minDamageDealtToEnemyThisTurn = 1,
			allPresent = [cullType, "comp"],
			lines = [
				new Say { who = "comp", loopTag = "smug" },
				new Say { who = cullType, loopTag = "neutral" },
			],
		};
		#endregion

		for (var i = 0; i < 3; i++)
			newNodes[["Cull", "DealtBigDamage", "Basic", i.ToString()]] = new()
			{
				playerShotJustHit = true,
				minDamageDealtToEnemyThisTurn = 6,
				whoDidThat = cullDeck,
				allPresent = [cullType],
				lines = [
					new Say { who = cullType, loopTag = "neutral" },
				],
			};

		for (var i = 0; i < 1; i++)
			newNodes[["Cull", "ShieldedDamage", "Basic", i.ToString()]] = new StoryNode()
			{
				enemyShotJustHit = true,
				maxDamageDealtToPlayerThisTurn = 0,
				allPresent = [cullType],
				lines = [
					new Say { who = cullType, loopTag = "neutral" },
				],
			}.SetMinShieldLostThisTurn(1);

		newNodes[["Cull", "Missed", "Basic", "0"]] = new()
		{
			playerShotJustMissed = true,
			allPresent = [cullType],
			lines = [
				new Say { who = cullType, loopTag = "squint" },
			],
		};
		newNodes[["Cull", "Missed", "Basic", "1"]] = new()
		{
			playerShotJustMissed = true,
			allPresent = [cullType],
			lines = [
				new Say { who = cullType, loopTag = "squint" },
			],
		};
		newNodes[["Cull", "Missed", "Basic", "2"]] = new()
		{
			playerShotJustMissed = true,
			allPresent = [cullType],
			lines = [
				new Say { who = cullType, loopTag = "squint" },
			],
		};

		#region AboutToDie
		newNodes[["Cull", "AboutToDie", "Basic", "0"]] = new()
		{
			maxHull = 2,
			oncePerCombatTags = ["aboutToDie"],
			oncePerRun = true,
			allPresent = [cullType],
			lines = [
				new Say { who = cullType, loopTag = "nervous" },
			],
		};
		newNodes[["Cull", "AboutToDie", "Basic", "1"]] = new()
		{
			maxHull = 2,
			oncePerCombatTags = ["aboutToDie"],
			oncePerRun = true,
			allPresent = [cullType],
			lines = [
				new Say { who = cullType, loopTag = "nervous" },
			],
		};
		newNodes[["Cull", "AboutToDie", "Basic", "2"]] = new()
		{
			maxHull = 2,
			oncePerCombatTags = ["aboutToDie"],
			oncePerRun = true,
			allPresent = [cullType],
			lines = [
				new Say { who = cullType, loopTag = "neutral" },
			],
		};

		newNodes[["Cull", "AboutToDie", "Dizzy"]] = new()
		{
			maxHull = 2,
			oncePerCombatTags = ["aboutToDie"],
			oncePerRun = true,
			allPresent = [cullType, Deck.dizzy.Key()],
			lines = [
				new Say { who = Deck.dizzy.Key(), loopTag = "nervous" },
				new Say { who = cullType, loopTag = "nervous" },
			],
		};
		newNodes[["Cull", "AboutToDie", "Riggs"]] = new()
		{
			maxHull = 2,
			oncePerCombatTags = ["aboutToDie"],
			oncePerRun = true,
			allPresent = [cullType, Deck.riggs.Key()],
			lines = [
				new Say { who = Deck.riggs.Key(), loopTag = "nervous" },
				new Say { who = cullType, loopTag = "neutral" },
			],
		};
		newNodes[["Cull", "AboutToDie", "Peri"]] = new()
		{
			maxHull = 2,
			oncePerCombatTags = ["aboutToDie"],
			oncePerRun = true,
			allPresent = [cullType, Deck.peri.Key()],
			lines = [
				new Say { who = Deck.peri.Key(), loopTag = "mad" },
				new Say { who = cullType, loopTag = "nervous" },
			],
		};
		newNodes[["Cull", "AboutToDie", "Isaac"]] = new()
		{
			maxHull = 2,
			oncePerCombatTags = ["aboutToDie"],
			oncePerRun = true,
			allPresent = [cullType, Deck.goat.Key()],
			lines = [
				new Say { who = cullType, loopTag = "nervous" },
				new Say { who = Deck.goat.Key(), loopTag = "sad" },
			],
		};
		newNodes[["Cull", "AboutToDie", "Drake"]] = new()
		{
			maxHull = 2,
			oncePerCombatTags = ["aboutToDie"],
			oncePerRun = true,
			allPresent = [cullType, Deck.eunice.Key()],
			lines = [
				new Say { who = cullType, loopTag = "squint" },
				new Say { who = Deck.eunice.Key(), loopTag = "mad" },
			],
		};
		newNodes[["Cull", "AboutToDie", "Books"]] = new()
		{
			maxHull = 2,
			oncePerCombatTags = ["aboutToDie"],
			oncePerRun = true,
			allPresent = [cullType, Deck.shard.Key()],
			lines = [
				new Say { who = cullType, loopTag = "squint" },
				new Say { who = Deck.shard.Key(), loopTag = "squint" },
			],
		};
		newNodes[["Cull", "AboutToDie", "CAT"]] = new()
		{
			maxHull = 2,
			oncePerCombatTags = ["aboutToDie"],
			oncePerRun = true,
			allPresent = [cullType, "comp"],
			lines = [
				new Say { who = cullType, loopTag = "nervous" },
				new Say { who = "comp", loopTag = "mad" },
			],
		};
		#endregion

		for (var i = 0; i < 1; i++)
			newNodes[["Cull", "HitArmor", "Basic", i.ToString()]] = new()
			{
				playerShotJustHit = true,
				minDamageBlockedByEnemyArmorThisTurn = 1,
				oncePerCombat = true,
				oncePerRun = true,
				allPresent = [cullType],
				lines = [
					new Say { who = cullType, loopTag = "squint" },
				],
			};

		for (var i = 0; i < 1; i++)
			newNodes[["Cull", "ExcessEnergy", "Basic", i.ToString()]] = new()
			{
				handEmpty = true,
				minEnergy = 1,
				allPresent = [cullType],
				lines = [
					new Say { who = cullType, loopTag = "squint" },
				],
			};

		for (var i = 0; i < 1; i++)
			newNodes[["Cull", "EmptyHand", "Basic", i.ToString()]] = new()
			{
				handEmpty = true,
				allPresent = [cullType],
				lines = [
					new Say { who = cullType, loopTag = "neutral" },
				],
			};

		for (var i = 0; i < 1; i++)
			newNodes[["Cull", "TrashHand", "Basic", i.ToString()]] = new()
			{
				handFullOfTrash = true,
				allPresent = [cullType],
				lines = [
					new Say { who = cullType, loopTag = "neutral" },
				],
			};

		for (var i = 0; i < 1; i++)
			newNodes[["Cull", "StartedBattle", "Basic", i.ToString()]] = new()
			{
				turnStart = true,
				maxTurnsThisCombat = 1,
				oncePerCombat = true,
				oncePerRun = true,
				allPresent = [cullType],
				lines = [
					new Say { who = cullType, loopTag = "neutral" },
				],
			};

		for (var i = 0; i < 2; i++)
			newNodes[["Cull", "NoOverlap", "Basic", i.ToString()]] = new()
			{
				priority = true,
				shipsDontOverlapAtAll = true,
				oncePerCombatTags = ["NoOverlapBetweenShips"],
				oncePerRun = true,
				nonePresent = ["crab", "scrap"],
				allPresent = [cullType],
				lines = [
					new Say { who = cullType, loopTag = "neutral" },
				],
			};

		for (var i = 0; i < 2; i++)
			newNodes[["Cull", "NoOverlapButSeeker", "Basic", i.ToString()]] = new()
			{
				priority = true,
				shipsDontOverlapAtAll = true,
				oncePerCombatTags = ["NoOverlapBetweenShipsSeeker"],
				oncePerRun = true,
				anyDronesHostile = ["missile_seeker"],
				nonePresent = ["crab"],
				allPresent = [cullType],
				lines = [
					new Say { who = cullType, loopTag = "squint" },
				],
			};

		for (var i = 0; i < 2; i++)
			newNodes[["Cull", "LongFight", "Basic", i.ToString()]] = new()
			{
				minTurnsThisCombat = 9,
				oncePerCombatTags = ["manyTurns"],
				oncePerRun = true,
				turnStart = true,
				allPresent = [cullType],
				lines = [
					new Say { who = cullType, loopTag = "neutral" },
				],
			};

		for (var i = 0; i < 1; i++)
			newNodes[["Cull", "ReturningFromMissing", "Basic", i.ToString()]] = new()
			{
				priority = true,
				lookup = [$"{ModEntry.Instance.Package.Manifest.UniqueName}::ReturningFromMissing"],
				oncePerRun = true,
				lines = [
					new Say { who = cullType, loopTag = "neutral" },
				],
			};

		#region DealtDamage
		for (var i = 0; i < 2; i++)
			newNodes[["GoingToOverheat", "Basic", i.ToString()]] = new()
			{
				goingToOverheat = true,
				oncePerCombatTags = ["OverheatGeneric"],
				allPresent = [cullType],
				lines = [
					new Say { who = cullType, loopTag = "squint" },
				],
			};

		newNodes[["GoingToOverheat", "Drake"]] = new()
		{
			goingToOverheat = true,
			oncePerCombatTags = ["OverheatGeneric"],
			allPresent = [cullType, Deck.eunice.Key()],
			lines = [
				new Say { who = cullType, loopTag = "neutral" },
				new Say { who = Deck.eunice.Key(), loopTag = "sly" },
			],
		};
		#endregion

		for (var i = 0; i < 1; i++)
			newNodes[["Cull", "Recalibrator", "Basic", i.ToString()]] = new()
			{
				playerShotJustMissed = true,
				hasArtifacts = ["Recalibrator"],
				allPresent = [cullType],
				lines = [
					new Say { who = cullType, loopTag = "neutral" },
				],
			};

		newNodes[["Cull", "StartedBattleAgainstDuncan"]] = new()
		{
			priority = true,
			turnStart = true,
			maxTurnsThisCombat = 1,
			oncePerCombat = true,
			allPresent = [cullType, "skunk"],
			lines = [
				new Say { who = cullType, loopTag = "neutral" },
				new Say { who = "skunk", loopTag = "neutral" },
			],
		};

		newNodes[["Cull", "StartedBattleAgainstDahlia"]] = new()
		{
			priority = true,
			turnStart = true,
			maxTurnsThisCombat = 1,
			oncePerCombat = true,
			allPresent = [cullType, "bandit"],
			lines = [
				new Say { who = "bandit", loopTag = "neutral" },
				new Say { who = cullType, loopTag = "squint" },
			],
		};

		newNodes[["Cull", "StartedBattleAgainstBigCrystal"]] = new()
		{
			priority = true,
			turnStart = true,
			oncePerRun = true,
			requiredScenes = ["Crystal_1", "Crystal_1_1"],
			excludedScenes = ["Crystal_2"],
			allPresent = [cullType, "crystal"],
			lines = [
				new Say { who = cullType, loopTag = "neutral" },
			],
		};

		saySwitchNodes[["Cull", "CrabFacts1_Multi_0"]] = new()
		{
			who = cullType,
			loopTag = "squint"
		};
		saySwitchNodes[["Cull", "CrabFacts2_Multi_0"]] = new()
		{
			who = cullType,
			loopTag = "squint"
		};
	}
}
