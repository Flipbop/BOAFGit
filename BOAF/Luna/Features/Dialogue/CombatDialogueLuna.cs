using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using Flipbop.BOAF;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class CombatDialogueLuna
{
    public CombatDialogueLuna()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {
            {
                "ThatsALotOfDamageToUs_Luna_0", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    minDamageDealtToPlayerThisTurn = 3,
                    allPresent = [AmLuna],
                    dialogue =
                    [
                        new(AmLuna, "nervous", "Not good! Not good!")
                    ]
                }
            },
            {
                "ThatsALotOfDamageToUs_Luna_1", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    minDamageDealtToPlayerThisTurn = 3,
                    allPresent = [AmLuna],
                    dialogue =
                    [
                        new(AmLuna, "nervous", "Uh oh..")
                    ]
                }
            },
            {
                "ThatsALotOfDamageToUs_Luna_2", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    minDamageDealtToPlayerThisTurn = 3,
                    allPresent = [AmLuna],
                    dialogue =
                    [
                        new(AmLuna, "angry", "Hey, back off!")
                    ]
                }
            },
            {
                "ThatsALotOfDamageToThem_Luna_0", new()
                {
                    type = NodeType.combat,
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisTurn = 10,
                    allPresent = [AmLuna],
                    dialogue =
                    [
                        new(AmLuna, "neutral", "That's the stuff.")
                    ]
                }
            },
            {
                "ThatsALotOfDamageToThem_Luna_1", new()
                {
                    type = NodeType.combat,
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisTurn = 10,
                    allPresent = [AmLuna],
                    dialogue =
                    [
                        new(AmLuna,  "Aww, look at them squirm!")
                    ]
                }
            },
            {
                "WeGotShotButTookNoDamage_Luna_0", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    lastTurnPlayerStatuses = [Status.perfectShield],

                    oncePerRun = true,
                    allPresent = [AmLuna],
                    dialogue =
                    [
                        new(AmLuna, "squint", "Huh? Oh, we're fine.")
                    ]
                }
            },
            {
                "WeGotShotButTookNoDamage_Luna_1", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    lastTurnPlayerStatuses = [Status.perfectShield],

                    oncePerRun = true,
                    allPresent = [AmLuna],
                    dialogue =
                    [
                        new(AmLuna, "squint", "Is that going to leave a mark?")
                    ]
                }
            },
            {
                "WeGotShotButTookNoDamage_Luna_2", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    lastTurnPlayerStatuses = [Status.perfectShield],

                    oncePerRun = true,
                    allPresent = [AmLuna],
                    dialogue =
                    [
                        new(AmLuna, "All good here.")
                    ]
                }
            },
            {
                "WeAreMovingAroundALot_Luna_0", new()
                {
                    type = NodeType.combat,
                    minMovesThisTurn = 3,
                    oncePerRun = true,
                    allPresent = [AmLuna],
                    dialogue =
                    [
                        new(AmLuna, "neutral", "Weeeeee!")
                    ]
                }
            },
            {
                "ShopKeepBattleInsult", new()
                {
                    edit =
                    [
                        new("66ea84d6", AmLuna, "nervous", "I'm sorry."),
                    ]
                }
            },
            {
                "HandOnlyHasTrashCards_Luna_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    handFullOfTrash = true,
                    allPresent = [AmLuna],
                    dialogue =
                    [
                        new(AmLuna, "squint", "I'm not touching that...")
                    ]
                }
            },
            {
                "HandOnlyHasUnplayableCards_Luna_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    handFullOfUnplayableCards = true,
                    allPresent = [AmLuna],
                    dialogue =
                    [
                        new(AmLuna, "squint", "What do we do now?")
                    ]
                }
            },
            {
                "BooksWentMissing_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["booksWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingBooks],
                    dialogue =
                    [
                        new(AmLuna, "nervous", "Books! No!!!")
                    ]
                }
            },
            {
                "CatWentMissing_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CatWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingCat],
                    dialogue =
                    [
                        new(who: AmLuna, "nervous", "What kind of magic do you need to make a ship's CPU disappear?")
                    ]
                }
            },
            {
                "DizzyWentMissing_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["dizzyWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingDizzy],
                    dialogue =
                    [
                        new(AmLuna, "nervous", "Hey, uh, Dizzy is gone...")
                    ]
                }
            },
            {
                "DrakeWentMissing_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["drakeWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingDrake],
                    dialogue =
                    [
                        new(AmLuna, "squint", "She may have been a jerk, but at least she was hot.")
                    ]
                }
            },
            {
                "IsaacWentMissing_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["issacWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingIsaac],

                    dialogue =
                    [
                        new(AmLuna, "nervous", "Where did he go?!")
                    ]
                }
            },
            {
                "MaxWentMissing_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["maxWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingMax],
                    dialogue =
                    [
                        new(AmLuna, "neutral", "Uh, Max?")
                    ]
                }
            },
            {
                "PeriWentMissing_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["periWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingPeri],
                    dialogue =
                    [
                        new(AmLuna, "nervous", "Bring Peri back!")
                    ]
                }
            },
            {
                "RiggsWentMissing_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["riggsWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingRiggs],
                    dialogue =
                    [
                        new(AmLuna, "nervous", "Did she wander off again?")
                    ]
                }
            },
            {
                "CullWentMissing_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CullWentMissing"],
                    lastTurnPlayerStatuses = [MissingCull],
                    dialogue =
                    [
                        new(AmLuna, "nervous", "Is that a side-effect of necromancy?")
                    ]
                }
            },
            {
                "JayWentMissing_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["JayWentMissing"],
                    lastTurnPlayerStatuses = [MissingJay],
                    dialogue =
                    [
                        new(AmLuna, "nervous", "Well now who is gonna fix the ship?!")
                    ]
                }
            },
            /*{
                "CentiWentMissing_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CentiWentMissing"],
                    lastTurnPlayerStatuses = [MissingCenti],
                    dialogue =
                    [
                        new(AmLuna, "nervous", "How did we lose an 8ft tall cyborg?")
                    ]
                }
            },
            {
                "EvaWentMissing_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["EvaWentMissing"],
                    lastTurnPlayerStatuses = [MissingEva],
                    dialogue =
                    [
                        new(AmLuna, "She's probably confused and lost right now...")
                    ]
                }
            },*/
            {
                "WeDontOverlapWithEnemyAtAll_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    priority = true,
                    shipsDontOverlapAtAll = true,
                    nonePresent = ["crab", "scrap"],
                    oncePerRun = true,
                    oncePerRunTags = ["NoOverlapBetweenShips"],
                    dialogue =
                    [
                        new(AmLuna, "neutral", "They can't hit us now!")
                    ]
                }
            },
            {
                "WeDontOverlapWithEnemyAtAllButWeDoHaveASeekerToDealWith_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    priority = true,
                    shipsDontOverlapAtAll = true,
                    oncePerCombatTags = ["NoOverlapBetweenShipsSeeker"],
                    anyDronesHostile = ["missile_seeker"],
                    nonePresent = ["crab"],
                    dialogue =
                    [
                        new(AmLuna, "squint", "That seeker is still tagging us.")
                    ]
                }
            },
            {
                "BlockedALotOfAttackWithArmor_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    enemyShotJustHit = true,
                    minDamageBlockedByPlayerArmorThisTurn = 3,
                    oncePerCombatTags = ["YowzaThatWasALOTofArmorBlock"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmLuna, "neutral", "Armor is the best.")
                    ]
                }
            },
            {
                "BlockedAnEnemyAttackWithArmor_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    enemyShotJustHit = true,
                    minDamageBlockedByPlayerArmorThisTurn = 1,
                    oncePerCombatTags = ["WowArmorISPrettyCoolHuh"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmLuna, "neutral", "Good old fashioned armor.")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna, AmDizzy],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmLuna, "nervous", "Uh, this can't be good."),
                        new(AmDizzy, "nervous", "Shields up!")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Luna_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna, AmPeri],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmPeri, "mad", "C'mon, don't back down!"),
                        new(AmLuna, "squint", "I'm trying! I'm trying!")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Luna_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna, AmRiggs],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmRiggs, "nervous", "Please stop!"),
                        new(AmLuna, "nervous", "What she said!")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Luna_3", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna, AmDrake],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmDrake, "squint", "This loop was bad anyways."),
                        new(AmLuna, "squint", "You're just saying that.")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Luna_4", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna, AmBooks],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmBooks, "paws", "Crap! The ship is badly hurt!"),
                        new(AmLuna, "nervous", "It can't be that bad, right?")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Luna_5", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna, AmMax],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmMax, "squint", "Again with this?"),
                        new(AmLuna, "nervous", "Never gets any easier...")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Luna_6", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna, AmCat],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmLuna, "nervous", "I don't wanna fight anymore."),
                        new(AmCat, "grumpy", "If only that were an option.")
                    ]
                }
            },
            /*{
                "Duo_AboutToDieAndLoop_Luna_7", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna, AmCenti],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCenti, "Batteries beginning to fail."),
                        new(AmLuna, "nervous", "That's not good! You need to keep them charged!")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Luna_8", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna, AmEva],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmEva, "sad", "I wanna go home."),
                        new(AmLuna, "sad", "I do too, but we have to finish this first.")
                    ]
                }
            },*/
            {
                "EmptyHandWithEnergy_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    handEmpty = true,
                    minEnergy = 1,
                    dialogue =
                    [
                        new(AmLuna, "neutral", "How are we gonna spend that energy?")
                    ]
                }
            },
            {
                "EmptyHandWithEnergy_Luna_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    handEmpty = true,
                    minEnergy = 1,
                    dialogue =
                    [
                        new(AmLuna, "squint", "This is a waste of perfectly good energy."),
                    ]
                }
            },
            {
                "EnemyArmorHitLots_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    playerShotJustHit = true,
                    minDamageBlockedByEnemyArmorThisTurn = 3,
                    oncePerCombat = true,
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmLuna, "squint", "Stop shooting the armor.")
                    ]
                }
            },
            {
                "EnemyArmorHit_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    playerShotJustHit = true,
                    minDamageBlockedByEnemyArmorThisTurn = 1,
                    oncePerCombat = true,
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmLuna, "squint", "Target something else.")
                    ]
                }
            },
            {
                "EnemyHasBrittle_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    enemyHasBrittlePart = true,
                    oncePerRunTags = ["yelledAboutBrittle"],
                    dialogue =
                    [
                        new(AmLuna, "A few rounds to the brittle part should do us some good.")
                    ]
                }
            },
            {
                "EnemyHasBrittle_Luna_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    enemyHasBrittlePart = true,
                    oncePerRunTags = ["yelledAboutBrittle"],
                    dialogue =
                    [
                        new(AmLuna, "Hit that brittle spot!")
                    ]
                }
            },
            {
                "EnemyHasWeakness_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    enemyHasWeakPart = true,
                    oncePerRunTags = ["yelledAboutWeakness"],
                    dialogue =
                    [
                        new(AmLuna, "Their ship is weak. How sloppy!")
                    ]
                }
            },
            {
                "ExpensiveCardPlayed_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    minCostOfCardJustPlayed = 4,
                    oncePerCombatTags = ["ExpensiveCardPlayed"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmLuna, "neutral", "I feel like we just got ripped off.")
                    ]
                }
            },
            {
                "FreezeIsMaxSize_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna, "crystal"],
                    turnStart = true,
                    enemyIntent = "biggestCrystal",
                    oncePerCombatTags = ["biggestCrystalShout"],
                    dialogue =
                    [
                        new(AmLuna, "squint", "Ooh, pretty!")
                    ]
                }
            },
            {
                "JustHitGeneric_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 1,
                    dialogue =
                    [
                        new(AmLuna, "Solid hit!")
                    ]
                }
            },
            {
                "JustHitGeneric_Luna_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 1,
                    dialogue =
                    [
                        new(AmLuna, "Nice!")
                    ]
                }
            },
            {
                "JustHitGeneric_Luna_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 1,
                    dialogue =
                    [
                        new(AmLuna, "Great shot!")
                    ]
                }
            },
            {
                "JustPlayedADraculaCard_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    whoDidThat = Deck.dracula,
                    nonePresent = ["dracula"],
                    dialogue =
                    [
                        new(AmLuna, "squint", "I don't like this dark magic.")
                    ]
                }
            },
            {
                "JustPlayedAnEphemeralCard_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    whoDidThat = Deck.ephemeral,
                    priority = true,
                    dialogue =
                    [
                        new(AmLuna, "squint", "And there it goes.")
                    ]
                }
            },
            {
                "LookOutMissile_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna, AmPeri],
                    priority = true,
                    once = true,
                    oncePerRunTags = ["goodMissileAdvice"],
                    anyDronesHostile = ["missile_corrode"],
                    dialogue =
                    [
                        new(AmLuna, "nervous", "Not a fan of the melty missile"),
                        new(AmPeri,"We can always shoot it.")
                    ]
                }
            },
            {
                "ManyFlips_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    minTimesYouFlippedACardThisTurn = 4,
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmLuna, "squint", "Flip flip!")
                    ]
                }
            },
            {
                "ManyTurns_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    minTurnsThisCombat = 9,
                    oncePerCombatTags = ["manyTurns"],
                    dialogue =
                    [
                        new(AmLuna, "squint", "I'm getting bored.")
                    ]
                }
            },
            {
                "ManyTurns_Luna_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    minTurnsThisCombat = 9,
                    oncePerCombatTags = ["manyTurns"],
                    dialogue =
                    [
                        new(AmLuna, "squint", "Can we just go?")
                    ]
                }
            },
            {
                "OneHitPointThisIsFine_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    enemyShotJustHit = true,
                    maxHull = 1,
                    dialogue =
                    [
                        new(AmLuna, "nervous", "Someone needs to repair this hull, stat!")
                    ]
                }
            },
            {
                "OneHitPointThisIsFine_Luna_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    enemyShotJustHit = true,
                    maxHull = 1,
                    lastTurnPlayerStatuses = [Status.corrode],
                    dialogue =
                    [
                        new(AmLuna, "nervous", "Just a little bit further...")
                    ]
                }
            },
            {
                "OverheatGeneric_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    goingToOverheat = true,
                    oncePerCombatTags = ["OverheatGeneric"],
                    dialogue =
                    [
                        new(AmLuna, "I don't like the heat.")
                    ]
                }
            },
            {
                "StrafeMissedGood_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    playerShotJustMissed = true,
                    playerShotWasFromStrafe = true,
                    hasArtifacts = ["Recalibrator", "GrazerBeam"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmLuna, "I guess that works. Would have rather hit them.")
                    ]
                }
            },
            {
                "TookZeroDamageAtLowHealth_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    maxDamageDealtToPlayerThisTurn = 0,
                    dialogue =
                    [
                        new(AmLuna, "Let's not do that again.")
                    ]
                }
            },
            {
                "VeryManyTurns_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    minTurnsThisCombat = 20,
                    oncePerCombatTags = ["veryManyTurns"],
                    oncePerRun = true,
                    turnStart = true,
                    dialogue =
                    [
                        new(AmLuna, "squint", "Okay this is a little bit insane.")
                    ]
                }
            },
            {
                "WeGotHurtButNotTooBad_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    enemyShotJustHit = true,
                    minDamageDealtToPlayerThisTurn = 1,
                    maxDamageDealtToPlayerThisTurn = 1,
                    dialogue =
                    [
                        new(AmLuna, "angry", "Ow!")
                    ]
                }
            },
            {
                "WeMissedOopsie_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    playerShotJustMissed = true,
                    oncePerCombat = true,
                    doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                    dialogue =
                    [
                        new(AmLuna, "squint", "Are we supposed to do that?")
                    ]
                }
            },
            {
                "WeMissedOopsie_Luna_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    playerShotJustMissed = true,
                    oncePerCombat = true,
                    doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                    dialogue =
                    [
                        new(AmLuna, "Can we not miss them next time?")
                    ]
                }
            },
            {
                "WeAreCorroded_Multi_0", new()
                {
                    dialogue =
                    [
                        new(AmLuna, "nervous", "Oh it smells bad too!")
                    ]
                }
            },
            {
                "WeAreCorroded_Multi_1", new()
                {
                    dialogue =
                    [
                        new(AmLuna,  "Someone gonna wipe that off?")
                    ]
                }
            },
            {
                "BanditThreats_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmLuna, "angry", "Can you, like, let us move, please?")
                    ]
                }
            },
            {
                "CrabFacts1_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmLuna, "Really?")
                    ]
                }
            },
            {
                "CrabFacts2_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmLuna, "Wow!")
                    ]
                }
            },
            {
                "CrabFactsAreOverNow_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmLuna, "neutral", "Aw man.")
                    ]
                }
            },
            {
                "DillianShouts", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmLuna, "squint", "Do I know you?")
                    ]
                }
            },
            {
                "OverheatDrakeFix_Multi_6", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmLuna, "squint", "Drake, just stop."),
                    ]
                }
            },
            {
                "OverheatDrakesFault_Multi_9", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmLuna, "angry", "Really? C'mon.")
                    ]
                }
            },
            {
                "RiderAvast", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmLuna, "squint", "Yar-har!")
                    ]
                }
            },
            {
                "SkunkFirstTurnShouts_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmLuna, "Anything shiny in these rocks?"),
                        new(EMod.countFromStart, 2, AmDuncan, "Yes, but you can't have it!")

                    ]
                }
            },
            {
                "SogginsEscapeIntent_1", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmLuna, "neutral", "Slow your roll.")
                    ]
                }
            },
            {
                "Soggins_Missile_Shout_1", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmLuna, "squint", "How does this keep happening?")
                    ]
                }
            },
            {
                "WeJustGainedHeatAndDrakeIsHere_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmLuna, "angry", "This is your fault, you know?"),
                        new(EMod.countFromStart, 1, AmDrake, "sly", "Oh I know.")
                    ]
                }
            },
            {
                "LunaWentMissing_Multi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmPeri],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["LunaWentMissing"],
                    lastTurnPlayerStatuses = [MissingLuna],
                    dialogue =
                    [
                        new(AmPeri, "angry", "Hey! She was valuable!")
                    ]
                }
            },
            {
                "LunaWentMissing_Multi_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmRiggs],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["LunaWentMissing"],
                    lastTurnPlayerStatuses = [MissingLuna],
                    dialogue =
                    [
                        new(AmRiggs, "nervous", "Where did the owl go?")
                    ]
                }
            },
            {
                "LunaWentMissing_Multi_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmDizzy],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["LunaWentMissing"],
                    lastTurnPlayerStatuses = [MissingLuna],
                    dialogue =
                    [
                        new(AmDizzy, "intense", "Uh oh.")
                    ]
                }
            },
            {
                "LunaWentMissing_Multi_3", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCat],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["LunaWentMissing"],
                    lastTurnPlayerStatuses = [MissingLuna],
                    dialogue =
                    [
                        new(AmCat, "I don't know how to do magic without her!")
                    ]
                }
            },
            {
                "LunaWentMissing_Multi_4", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmIsaac],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["LunaWentMissing"],
                    lastTurnPlayerStatuses = [MissingLuna],
                    dialogue =
                    [
                        new(AmIsaac, "Is that permanent?")
                    ]
                }
            },
            {
                "LunaWentMissing_Multi_5", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmDrake],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["LunaWentMissing"],
                    lastTurnPlayerStatuses = [MissingLuna],
                    dialogue =
                    [
                        new(AmDrake, "Oh, well that sucks.")
                    ]
                }
            },
            {
                "LunaWentMissing_Multi_6", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmMax],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["LunaWentMissing"],
                    lastTurnPlayerStatuses = [MissingLuna],
                    dialogue =
                    [
                        new(AmMax, "That can't be good.")
                    ]
                }
            },
            {
                "LunaWentMissing_Multi_7", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmBooks],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["LunaWentMissing"],
                    lastTurnPlayerStatuses = [MissingLuna],
                    dialogue =
                    [
                        new(AmBooks, "Pretty owl lady? Where did you go?")
                    ]
                }
            },
            {
                "LunaJustHit_Multi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 1,
                    whoDidThat = AmLunaDeck,
                    oncePerCombatTags = ["LunaShotAGuy"],
                    dialogue =
                    [
                        new(AmLuna, "neutral", "OMG, I hit them!")
                    ]
                }
            },
            {
                "LunaGotPerfect_Multi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    oncePerRun = true,
                    lastTurnPlayerStatuses = [Status.perfectShield],
                    dialogue =
                    [
                        new(AmLuna, "neutral", "Nice. Now I can be reckless."),
                    ]
                }
            },
        });
    }
}