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
                        new(AmLuna, "nervous", "Not the ship!")
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
                        new(AmLuna, "squint", "Hey! Cool it!")
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
                        new(AmLuna, "angry", "I just waxed this ship!")
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
                        new(AmLuna, "neutral", "Hooah...")
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
                        new(AmLuna, "squint", "Shame to damage such a beautiful hull such as that.")
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
                        new(AmLuna, "squint", "Did that scratch the paint?")
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
                        new(AmLuna, "squint", "Should I be worried?")
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
                        new(AmLuna, "No harm, no foul.")
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
                        new(AmLuna, "neutral", "Moving around so we don't damage the ship? I like it.")
                    ]
                }
            },
            {
                "ShopKeepBattleInsult", new()
                {
                    edit =
                    [
                        new("66ea84d6", AmLuna, "nervous", "Please have mercy."),
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
                        new(AmLuna, "squint", "Someone clean this mess up.")
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
                        new(AmLuna, "squint", "How does this even happen?")
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
                        new(AmLuna, "squint", "The crystal mage is missing.")
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
                        new(who: AmLuna, "nervous", "How does CAT even go missing, isn't she a part of the ship?")
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
                        new(AmLuna, "nervous", "Who's gonna shield the ship now?")
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
                        new(AmLuna, "squint", "Honestly, I'm fine with her being gone.")
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
                        new(AmLuna, "nervous", "Isaac? Isaac!")
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
                        new(AmLuna, "neutral", "Where did Max go?")
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
                        new(AmLuna, "nervous", "Uhhh, don't we need her? For like, attacking?")
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
                        new(AmLuna, "nervous", "Bring back the possum girl!")
                    ]
                }
            },
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
                        new(AmLuna, "neutral", "They can't hit us if we aren't even close to them.")
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
                        new(AmLuna, "squint", "They can't hit us- oh wait, seeker.")
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
                        new(AmLuna, "neutral", "Ah, I love armor.")
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
                        new(AmLuna, "neutral", "My plating never fails.")
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
                        new(AmLuna, "nervous", "Can't we do something about this?"),
                        new(AmDizzy, "frown", "My shields can only do so much.")
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
                        new(AmPeri, "mad", "Don't give up!"),
                        new(AmLuna, "squint", "I was just about to.")
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
                        new(AmRiggs, "nervous", "Hey, can you like, not shoot us?"),
                        new(AmLuna, "squint", "They aren't listening.")
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
                        new(AmDrake, "squint", "C'mon, not now."),
                        new(AmLuna, "squint", "Reset?")
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
                        new(AmBooks, "paws", "Fiddlesticks!"),
                        new(AmLuna, "nervous", "Woah! Books!")
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
                        new(AmMax, "squint", "Start over?"),
                        new(AmLuna, "squint", "Almost.")
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
                        new(AmLuna, "nervous", "Can we just leave?"),
                        new(AmCat, "grumpy", "I wish.")
                    ]
                }
            },
            {
                "EmptyHandWithEnergy_Luna_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    handEmpty = true,
                    minEnergy = 1,
                    dialogue =
                    [
                        new(AmLuna, "neutral", "Where did this extra energy come from?")
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
                        new(AmLuna, "squint", "What am I supposed to spend this on?"),
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
                        new(AmLuna, "squint", "Armor is only good when we have it.")
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
                        new(AmLuna, "squint", "Plating is working!")
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
                        new(AmLuna, "That brittle part is gonna cause problems for them.")
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
                        new(AmLuna, "A few rounds to the brittle spot should do the trick.")
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
                        new(AmLuna, "They have a weak spot, strike there!")
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
                        new(AmLuna, "neutral", "Was it worth it?")
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
                        new(AmLuna, "squint", "An expanding ship. Interesting.")
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
                        new(AmLuna, "Nice hit!")
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
                        new(AmLuna, "Excellent!")
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
                        new(AmLuna, "Keep going!")
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
                        new(AmLuna, "neutral", "Are we sure we can trust the space vampire?")
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
                        new(AmLuna, "squint", "I hope we won't need that later.")
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
                        new(AmLuna, "nervous", "That corrode missile will melt the hull!"),
                        new(AmPeri,"Then destroy it!")
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
                        new(AmLuna, "squint", "Bored?")
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
                        new(AmLuna, "squint", "Still going?")
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
                        new(AmLuna, "squint", "Just destroy them already.")
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
                        new(AmLuna, "nervous", "The hull can't take another hit!")
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
                        new(AmLuna, "nervous", "C'mon, hold together...")
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
                        new(AmLuna, "This heat damages the hull.")
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
                        new(AmLuna, "Better than nothing.")
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
                        new(AmLuna, "I don't like how close that was.")
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
                        new(AmLuna, "squint", "Can I take a nap?")
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
                        new(AmLuna, "angry", "Watch it!")
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
                        new(AmLuna, "squint", "Uh, was that intentional?")
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
                        new(AmLuna, "Hit them.")
                    ]
                }
            },
            {
                "WeAreCorroded_Multi_0", new()
                {
                    dialogue =
                    [
                        new(AmLuna, "nervous", "Not the hull!")
                    ]
                }
            },
            {
                "WeAreCorroded_Multi_1", new()
                {
                    dialogue =
                    [
                        new(AmLuna, "angry", "This corrosion isn't good for the ship.")
                    ]
                }
            },
            {
                "BanditThreats_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmLuna, "angry", "Your Engine Stall is very annoying to clean up.")
                    ]
                }
            },
            {
                "CrabFacts1_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmLuna, "squint", "What?")
                    ]
                }
            },
            {
                "CrabFacts2_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmLuna, "squint", "That's preposterous.")
                    ]
                }
            },
            {
                "CrabFactsAreOverNow_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmLuna, "neutral", "Finally.")
                    ]
                }
            },
            {
                "DillianShouts", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmLuna, "squint", "And you are?")
                    ]
                }
            },
            {
                "OverheatDrakeFix_Multi_6", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmLuna, "squint", "Can you stop trying to kill us?"),
                    ]
                }
            },
            {
                "OverheatDrakesFault_Multi_9", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmLuna, "angry", "The hull is at risk cause of you.")
                    ]
                }
            },
            {
                "RiderAvast", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmLuna, "squint", "Old ships have such a nice quality to them.")
                    ]
                }
            },
            {
                "SkunkFirstTurnShouts_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmLuna, "These rocks could make excellent plating."),
                        new(EMod.countFromStart, 2, AmDuncan, "No, they're mine!")

                    ]
                }
            },
            {
                "SogginsEscapeIntent_1", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmLuna, "neutral", "Please wait right there.")
                    ]
                }
            },
            {
                "Soggins_Missile_Shout_1", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmLuna, "squint", "Where did you get those missiles?")
                    ]
                }
            },
            {
                "WeJustGainedHeatAndDrakeIsHere_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmLuna, "angry", "Please stop melting the hull."),
                        new(EMod.countFromStart, 1, AmDrake, "sly", "I don't wanna.")
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
                        new(AmPeri, "nervous", "Where did Luna go?")
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
                        new(AmRiggs, "nervous", "Do blue Lunas normally do that?")
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
                        new(AmDizzy, "intense", "That's not good!")
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
                        new(AmCat, "Oh no.")
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
                        new(AmIsaac, "Ummm...")
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
                        new(AmDrake, "Finally, I can melt the hull in peace.")
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
                        new(AmMax, "Oh that isn't good.")
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
                        new(AmBooks, "Luna? Where are you?")
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
                        new(AmLuna, "neutral", "I hit them!")
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
                        new(AmLuna, "neutral", "Our hull will be fine."),
                    ]
                }
            },
        });
    }
}