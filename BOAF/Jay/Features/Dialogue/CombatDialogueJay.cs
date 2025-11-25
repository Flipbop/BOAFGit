using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using Flipbop.BOAF;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class CombatDialogueJay
{
    public CombatDialogueJay()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {
            {
                "ThatsALotOfDamageToUs_Jay_0", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    minDamageDealtToPlayerThisTurn = 3,
                    allPresent = [AmJay],
                    dialogue =
                    [
                        new(AmJay, "nervous", "Not the ship!")
                    ]
                }
            },
            {
                "ThatsALotOfDamageToUs_Jay_1", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    minDamageDealtToPlayerThisTurn = 3,
                    allPresent = [AmJay],
                    dialogue =
                    [
                        new(AmJay, "squint", "Hey! Cool it!")
                    ]
                }
            },
            {
                "ThatsALotOfDamageToUs_Jay_2", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    minDamageDealtToPlayerThisTurn = 3,
                    allPresent = [AmJay],
                    dialogue =
                    [
                        new(AmJay, "angry", "I just waxed this ship!")
                    ]
                }
            },
            {
                "ThatsALotOfDamageToThem_Jay_0", new()
                {
                    type = NodeType.combat,
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisTurn = 10,
                    allPresent = [AmJay],
                    dialogue =
                    [
                        new(AmJay, "neutral", "Hooah...")
                    ]
                }
            },
            {
                "ThatsALotOfDamageToThem_Jay_1", new()
                {
                    type = NodeType.combat,
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisTurn = 10,
                    allPresent = [AmJay],
                    dialogue =
                    [
                        new(AmJay, "squint", "Shame to damage such a beautiful hull such as that.")
                    ]
                }
            },
            {
                "WeGotShotButTookNoDamage_Jay_0", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    lastTurnPlayerStatuses = [Status.perfectShield],

                    oncePerRun = true,
                    allPresent = [AmJay],
                    dialogue =
                    [
                        new(AmJay, "squint", "Did that scratch the paint?")
                    ]
                }
            },
            {
                "WeGotShotButTookNoDamage_Jay_1", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    lastTurnPlayerStatuses = [Status.perfectShield],

                    oncePerRun = true,
                    allPresent = [AmJay],
                    dialogue =
                    [
                        new(AmJay, "squint", "Should I be worried?")
                    ]
                }
            },
            {
                "WeGotShotButTookNoDamage_Jay_2", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    lastTurnPlayerStatuses = [Status.perfectShield],

                    oncePerRun = true,
                    allPresent = [AmJay],
                    dialogue =
                    [
                        new(AmJay, "No harm, no foul.")
                    ]
                }
            },
            {
                "WeAreMovingAroundALot_Jay_0", new()
                {
                    type = NodeType.combat,
                    minMovesThisTurn = 3,
                    oncePerRun = true,
                    allPresent = [AmJay],
                    dialogue =
                    [
                        new(AmJay, "neutral", "Moving around so we don't damage the ship? I like it.")
                    ]
                }
            },
            {
                "ShopKeepBattleInsult", new()
                {
                    edit =
                    [
                        new("66ea84d6", AmJay, "nervous", "Please have mercy."),
                    ]
                }
            },
            {
                "HandOnlyHasTrashCards_Jay_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    handFullOfTrash = true,
                    allPresent = [AmJay],
                    dialogue =
                    [
                        new(AmJay, "squint", "Someone clean this mess up.")
                    ]
                }
            },
            {
                "HandOnlyHasUnplayableCards_Jay_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    handFullOfUnplayableCards = true,
                    allPresent = [AmJay],
                    dialogue =
                    [
                        new(AmJay, "squint", "How does this even happen?")
                    ]
                }
            },
            {
                "BooksWentMissing_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["booksWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingBooks],
                    dialogue =
                    [
                        new(AmJay, "squint", "The crystal mage is missing.")
                    ]
                }
            },
            {
                "CatWentMissing_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CatWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingCat],
                    dialogue =
                    [
                        new(who: AmJay, "nervous", "How does CAT even go missing, isn't she a part of the ship?")
                    ]
                }
            },
            {
                "DizzyWentMissing_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["dizzyWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingDizzy],
                    dialogue =
                    [
                        new(AmJay, "nervous", "Who's gonna shield the ship now?")
                    ]
                }
            },
            {
                "DrakeWentMissing_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["drakeWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingDrake],
                    dialogue =
                    [
                        new(AmJay, "squint", "Honestly, I'm fine with her being gone.")
                    ]
                }
            },
            {
                "IsaacWentMissing_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["issacWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingIsaac],

                    dialogue =
                    [
                        new(AmJay, "nervous", "Isaac? Isaac!")
                    ]
                }
            },
            {
                "MaxWentMissing_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["maxWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingMax],
                    dialogue =
                    [
                        new(AmJay, "neutral", "Where did Max go?")
                    ]
                }
            },
            {
                "PeriWentMissing_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["periWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingPeri],
                    dialogue =
                    [
                        new(AmJay, "nervous", "Uhhh, don't we need her? For like, attacking?")
                    ]
                }
            },
            {
                "RiggsWentMissing_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["riggsWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingRiggs],
                    dialogue =
                    [
                        new(AmJay, "nervous", "Bring back the possum girl!")
                    ]
                }
            },
            {
                "WeDontOverlapWithEnemyAtAll_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    priority = true,
                    shipsDontOverlapAtAll = true,
                    nonePresent = ["crab", "scrap"],
                    oncePerRun = true,
                    oncePerRunTags = ["NoOverlapBetweenShips"],
                    dialogue =
                    [
                        new(AmJay, "neutral", "They can't hit us if we aren't even close to them.")
                    ]
                }
            },
            {
                "WeDontOverlapWithEnemyAtAllButWeDoHaveASeekerToDealWith_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    priority = true,
                    shipsDontOverlapAtAll = true,
                    oncePerCombatTags = ["NoOverlapBetweenShipsSeeker"],
                    anyDronesHostile = ["missile_seeker"],
                    nonePresent = ["crab"],
                    dialogue =
                    [
                        new(AmJay, "squint", "They can't hit us- oh wait, seeker.")
                    ]
                }
            },
            {
                "BlockedALotOfAttackWithArmor_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    enemyShotJustHit = true,
                    minDamageBlockedByPlayerArmorThisTurn = 3,
                    oncePerCombatTags = ["YowzaThatWasALOTofArmorBlock"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmJay, "neutral", "Ah, I love armor.")
                    ]
                }
            },
            {
                "BlockedAnEnemyAttackWithArmor_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    enemyShotJustHit = true,
                    minDamageBlockedByPlayerArmorThisTurn = 1,
                    oncePerCombatTags = ["WowArmorISPrettyCoolHuh"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmJay, "neutral", "My plating never fails.")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay, AmDizzy],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmJay, "nervous", "Can't we do something about this?"),
                        new(AmDizzy, "frown", "My shields can only do so much.")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Jay_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay, AmPeri],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmPeri, "mad", "Don't give up!"),
                        new(AmJay, "squint", "I was just about to.")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Jay_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay, AmRiggs],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmRiggs, "nervous", "Hey, can you like, not shoot us?"),
                        new(AmJay, "squint", "They aren't listening.")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Jay_3", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay, AmDrake],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmDrake, "squint", "C'mon, not now."),
                        new(AmJay, "squint", "Reset?")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Jay_4", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay, AmBooks],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmBooks, "paws", "Fiddlesticks!"),
                        new(AmJay, "nervous", "Woah! Books!")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Jay_5", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay, AmMax],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmMax, "squint", "Start over?"),
                        new(AmJay, "squint", "Almost.")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Jay_6", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay, AmCat],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmJay, "nervous", "Can we just leave?"),
                        new(AmCat, "grumpy", "I wish.")
                    ]
                }
            },
            {
                "EmptyHandWithEnergy_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    handEmpty = true,
                    minEnergy = 1,
                    dialogue =
                    [
                        new(AmJay, "neutral", "Where did this extra energy come from?")
                    ]
                }
            },
            {
                "EmptyHandWithEnergy_Jay_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    handEmpty = true,
                    minEnergy = 1,
                    dialogue =
                    [
                        new(AmJay, "squint", "What am I supposed to spend this on?"),
                    ]
                }
            },
            {
                "EnemyArmorHitLots_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    playerShotJustHit = true,
                    minDamageBlockedByEnemyArmorThisTurn = 3,
                    oncePerCombat = true,
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmJay, "squint", "Armor is only good when we have it.")
                    ]
                }
            },
            {
                "EnemyArmorHit_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    playerShotJustHit = true,
                    minDamageBlockedByEnemyArmorThisTurn = 1,
                    oncePerCombat = true,
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmJay, "squint", "Plating is working!")
                    ]
                }
            },
            {
                "EnemyHasBrittle_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    enemyHasBrittlePart = true,
                    oncePerRunTags = ["yelledAboutBrittle"],
                    dialogue =
                    [
                        new(AmJay, "That brittle part is gonna cause problems for them.")
                    ]
                }
            },
            {
                "EnemyHasBrittle_Jay_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    enemyHasBrittlePart = true,
                    oncePerRunTags = ["yelledAboutBrittle"],
                    dialogue =
                    [
                        new(AmJay, "A few rounds to the brittle spot should do the trick.")
                    ]
                }
            },
            {
                "EnemyHasWeakness_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    enemyHasWeakPart = true,
                    oncePerRunTags = ["yelledAboutWeakness"],
                    dialogue =
                    [
                        new(AmJay, "They have a weak spot, strike there!")
                    ]
                }
            },
            {
                "ExpensiveCardPlayed_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    minCostOfCardJustPlayed = 4,
                    oncePerCombatTags = ["ExpensiveCardPlayed"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmJay, "neutral", "Was it worth it?")
                    ]
                }
            },
            {
                "FreezeIsMaxSize_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay, "crystal"],
                    turnStart = true,
                    enemyIntent = "biggestCrystal",
                    oncePerCombatTags = ["biggestCrystalShout"],
                    dialogue =
                    [
                        new(AmJay, "squint", "An expanding ship. Interesting.")
                    ]
                }
            },
            {
                "JustHitGeneric_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 1,
                    dialogue =
                    [
                        new(AmJay, "Nice hit!")
                    ]
                }
            },
            {
                "JustHitGeneric_Jay_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 1,
                    dialogue =
                    [
                        new(AmJay, "Excellent!")
                    ]
                }
            },
            {
                "JustHitGeneric_Jay_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 1,
                    dialogue =
                    [
                        new(AmJay, "Keep going!")
                    ]
                }
            },
            {
                "JustPlayedADraculaCard_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    whoDidThat = Deck.dracula,
                    nonePresent = ["dracula"],
                    dialogue =
                    [
                        new(AmJay, "neutral", "Are we sure we can trust the space vampire?")
                    ]
                }
            },
            {
                "JustPlayedAnEphemeralCard_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    whoDidThat = Deck.ephemeral,
                    priority = true,
                    dialogue =
                    [
                        new(AmJay, "squint", "I hope we won't need that later.")
                    ]
                }
            },
            {
                "LookOutMissile_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay, AmPeri],
                    priority = true,
                    once = true,
                    oncePerRunTags = ["goodMissileAdvice"],
                    anyDronesHostile = ["missile_corrode"],
                    dialogue =
                    [
                        new(AmJay, "nervous", "That corrode missile will melt the hull!"),
                        new(AmPeri,"Then destroy it!")
                    ]
                }
            },
            {
                "ManyFlips_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    minTimesYouFlippedACardThisTurn = 4,
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmJay, "squint", "Bored?")
                    ]
                }
            },
            {
                "ManyTurns_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    minTurnsThisCombat = 9,
                    oncePerCombatTags = ["manyTurns"],
                    dialogue =
                    [
                        new(AmJay, "squint", "Still going?")
                    ]
                }
            },
            {
                "ManyTurns_Jay_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    minTurnsThisCombat = 9,
                    oncePerCombatTags = ["manyTurns"],
                    dialogue =
                    [
                        new(AmJay, "squint", "Just destroy them already.")
                    ]
                }
            },
            {
                "OneHitPointThisIsFine_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    enemyShotJustHit = true,
                    maxHull = 1,
                    dialogue =
                    [
                        new(AmJay, "nervous", "The hull can't take another hit!")
                    ]
                }
            },
            {
                "OneHitPointThisIsFine_Jay_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    enemyShotJustHit = true,
                    maxHull = 1,
                    lastTurnPlayerStatuses = [Status.corrode],
                    dialogue =
                    [
                        new(AmJay, "nervous", "C'mon, hold together...")
                    ]
                }
            },
            {
                "OverheatGeneric_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    goingToOverheat = true,
                    oncePerCombatTags = ["OverheatGeneric"],
                    dialogue =
                    [
                        new(AmJay, "This heat damages the hull.")
                    ]
                }
            },
            {
                "StrafeMissedGood_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    playerShotJustMissed = true,
                    playerShotWasFromStrafe = true,
                    hasArtifacts = ["Recalibrator", "GrazerBeam"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmJay, "Better than nothing.")
                    ]
                }
            },
            {
                "TookZeroDamageAtLowHealth_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    maxDamageDealtToPlayerThisTurn = 0,
                    dialogue =
                    [
                        new(AmJay, "I don't like how close that was.")
                    ]
                }
            },
            {
                "VeryManyTurns_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    minTurnsThisCombat = 20,
                    oncePerCombatTags = ["veryManyTurns"],
                    oncePerRun = true,
                    turnStart = true,
                    dialogue =
                    [
                        new(AmJay, "squint", "Can I take a nap?")
                    ]
                }
            },
            {
                "WeGotHurtButNotTooBad_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    enemyShotJustHit = true,
                    minDamageDealtToPlayerThisTurn = 1,
                    maxDamageDealtToPlayerThisTurn = 1,
                    dialogue =
                    [
                        new(AmJay, "angry", "Watch it!")
                    ]
                }
            },
            {
                "WeMissedOopsie_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    playerShotJustMissed = true,
                    oncePerCombat = true,
                    doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                    dialogue =
                    [
                        new(AmJay, "squint", "Uh, was that intentional?")
                    ]
                }
            },
            {
                "WeMissedOopsie_Jay_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    playerShotJustMissed = true,
                    oncePerCombat = true,
                    doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                    dialogue =
                    [
                        new(AmJay, "Hit them.")
                    ]
                }
            },
            {
                "WeAreCorroded_Multi_0", new()
                {
                    dialogue =
                    [
                        new(AmJay, "nervous", "Not the hull!")
                    ]
                }
            },
            {
                "WeAreCorroded_Multi_1", new()
                {
                    dialogue =
                    [
                        new(AmJay, "angry", "This corrosion isn't good for the ship.")
                    ]
                }
            },
            {
                "BanditThreats_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmJay, "angry", "Your Engine Stall is very annoying to clean up.")
                    ]
                }
            },
            {
                "CrabFacts1_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmJay, "squint", "What?")
                    ]
                }
            },
            {
                "CrabFacts2_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmJay, "squint", "That's preposterous.")
                    ]
                }
            },
            {
                "CrabFactsAreOverNow_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmJay, "neutral", "Finally.")
                    ]
                }
            },
            {
                "DillianShouts", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmJay, "squint", "And you are?")
                    ]
                }
            },
            {
                "OverheatDrakeFix_Multi_6", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmJay, "squint", "Can you stop trying to kill us?"),
                    ]
                }
            },
            {
                "OverheatDrakesFault_Multi_9", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmJay, "angry", "The hull is at risk cause of you.")
                    ]
                }
            },
            {
                "RiderAvast", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmJay, "squint", "Old ships have such a nice quality to them.")
                    ]
                }
            },
            {
                "SkunkFirstTurnShouts_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmJay, "These rocks could make excellent plating."),
                        new(EMod.countFromStart, 2, AmDuncan, "No, they're mine!")

                    ]
                }
            },
            {
                "SogginsEscapeIntent_1", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmJay, "neutral", "Please wait right there.")
                    ]
                }
            },
            {
                "Soggins_Missile_Shout_1", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmJay, "squint", "Where did you get those missiles?")
                    ]
                }
            },
            {
                "WeJustGainedHeatAndDrakeIsHere_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmJay, "angry", "Please stop melting the hull."),
                        new(EMod.countFromStart, 1, AmDrake, "sly", "I don't wanna.")
                    ]
                }
            },
            {
                "JayWentMissing_Multi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmPeri],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["JayWentMissing"],
                    lastTurnPlayerStatuses = [MissingJay],
                    dialogue =
                    [
                        new(AmPeri, "nervous", "Where did Jay go?")
                    ]
                }
            },
            {
                "JayWentMissing_Multi_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmRiggs],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["JayWentMissing"],
                    lastTurnPlayerStatuses = [MissingJay],
                    dialogue =
                    [
                        new(AmRiggs, "nervous", "Do blue jays normally do that?")
                    ]
                }
            },
            {
                "JayWentMissing_Multi_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmDizzy],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["JayWentMissing"],
                    lastTurnPlayerStatuses = [MissingJay],
                    dialogue =
                    [
                        new(AmDizzy, "intense", "That's not good!")
                    ]
                }
            },
            {
                "JayWentMissing_Multi_3", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCat],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["JayWentMissing"],
                    lastTurnPlayerStatuses = [MissingJay],
                    dialogue =
                    [
                        new(AmCat, "Oh no.")
                    ]
                }
            },
            {
                "JayWentMissing_Multi_4", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmIsaac],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["JayWentMissing"],
                    lastTurnPlayerStatuses = [MissingJay],
                    dialogue =
                    [
                        new(AmIsaac, "Ummm...")
                    ]
                }
            },
            {
                "JayWentMissing_Multi_5", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmDrake],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["JayWentMissing"],
                    lastTurnPlayerStatuses = [MissingJay],
                    dialogue =
                    [
                        new(AmDrake, "Finally, I can melt the hull in peace.")
                    ]
                }
            },
            {
                "JayWentMissing_Multi_6", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmMax],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["JayWentMissing"],
                    lastTurnPlayerStatuses = [MissingJay],
                    dialogue =
                    [
                        new(AmMax, "Oh that isn't good.")
                    ]
                }
            },
            {
                "JayWentMissing_Multi_7", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmBooks],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["JayWentMissing"],
                    lastTurnPlayerStatuses = [MissingJay],
                    dialogue =
                    [
                        new(AmBooks, "Jay? Where are you?")
                    ]
                }
            },
            {
                "JayJustHit_Multi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 1,
                    whoDidThat = AmJayDeck,
                    oncePerCombatTags = ["JayShotAGuy"],
                    dialogue =
                    [
                        new(AmJay, "neutral", "I hit them!")
                    ]
                }
            },
            {
                "JayGotPerfect_Multi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    oncePerRun = true,
                    lastTurnPlayerStatuses = [Status.perfectShield],
                    dialogue =
                    [
                        new(AmJay, "neutral", "Our hull will be fine."),
                    ]
                }
            },
        });
    }
}