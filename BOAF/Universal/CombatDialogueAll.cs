using System.Collections.Generic;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class CombatDialogueAll
{
    public CombatDialogueAll()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {
            #region Cull
            {
                "ThatsALotOfDamageToUs_Cull_0", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    minDamageDealtToPlayerThisTurn = 3,
                    allPresent = [AmCull],
                    dialogue =
                    [
                        new(AmCull, "nervous", "Too much damage! Too much damage!")
                    ]
                }
            },
            {
                "ThatsALotOfDamageToUs_Cull_1", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    minDamageDealtToPlayerThisTurn = 3,
                    allPresent = [AmCull],
                    dialogue =
                    [
                        new(AmCull, "squint", "I needed that!")
                    ]
                }
            },
            {
                "ThatsALotOfDamageToUs_Cull_2", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    minDamageDealtToPlayerThisTurn = 3,
                    allPresent = [AmCull],
                    dialogue =
                    [
                        new(AmCull, "nervous", "Will the ship hold?")
                    ]
                }
            },
            {
                "ThatsALotOfDamageToThem_Cull_0", new()
                {
                    type = NodeType.combat,
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisTurn = 10,
                    allPresent = [AmCull],
                    dialogue =
                    [
                        new(AmCull, "neutral", "You'll regret fighting us.")
                    ]
                }
            },
            {
                "ThatsALotOfDamageToThem_Cull_1", new()
                {
                    type = NodeType.combat,
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisTurn = 10,
                    allPresent = [AmCull],
                    dialogue =
                    [
                        new(AmCull, "squint", "Too bad that's only a small amount of Soul Energy.")
                    ]
                }
            },
            {
                "WeGotShotButTookNoDamage_Cull_0", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    lastTurnPlayerStatuses = [Status.perfectShield],

                    oncePerRun = true,
                    allPresent = [AmCull],
                    dialogue =
                    [
                        new(AmCull, "squint", "Are they even trying?")
                    ]
                }
            },
            {
                "WeGotShotButTookNoDamage_Cull_1", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    lastTurnPlayerStatuses = [Status.perfectShield],

                    oncePerRun = true,
                    allPresent = [AmCull],
                    dialogue =
                    [
                        new(AmCull, "squint", "Did something happen?")
                    ]
                }
            },
            {
                "WeGotShotButTookNoDamage_Cull_2", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    lastTurnPlayerStatuses = [Status.perfectShield],

                    oncePerRun = true,
                    allPresent = [AmCull],
                    dialogue =
                    [
                        new(AmCull, "nervous", "Ok good, not that bad.")
                    ]
                }
            },
            {
                "WeAreMovingAroundALot_Cull_0", new()
                {
                    type = NodeType.combat,
                    minMovesThisTurn = 3,
                    oncePerRun = true,
                    allPresent = [AmCull],
                    dialogue =
                    [
                        new(AmCull, "neutral", "Better to not get hit at all so I don't lose Soul Energy.")
                    ]
                }
            },
            {
                "HandOnlyHasTrashCards_Cull_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    handFullOfTrash = true,
                    allPresent = [AmCull],
                    dialogue =
                    [
                        new(AmCull, "squint", "Ew.")
                    ]
                }
            },
            {
                "HandOnlyHasUnplayableCards_Cull_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    handFullOfUnplayableCards = true,
                    allPresent = [AmCull],
                    dialogue =
                    [
                        new(AmCull, "squint", "What do you think I am supposed to do with this?")
                    ]
                }
            },
            {
                "BooksWentMissing_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["booksWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingBooks],
                    dialogue =
                    [
                        new(AmCull, "squint", "Hey, where'd Books go?")
                    ]
                }
            },
            {
                "CatWentMissing_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CatWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingCat],
                    dialogue =
                    [
                        new(who: AmCull, "nervous", "CAT is missing. Don't we need her?")
                    ]
                }
            },
            {
                "DizzyWentMissing_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["dizzyWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingDizzy],
                    dialogue =
                    [
                        new(AmCull, "nervous", "Oh no.")
                    ]
                }
            },
            {
                "DrakeWentMissing_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["drakeWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingDrake],
                    dialogue =
                    [
                        new(AmCull, "squint", "Ok this might be bad.")
                    ]
                }
            },
            {
                "IsaacWentMissing_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["issacWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingIsaac],

                    dialogue =
                    [
                        new(AmCull, "nervous", "Bring the goat back!")
                    ]
                }
            },
            {
                "MaxWentMissing_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["maxWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingMax],
                    dialogue =
                    [
                        new(AmCull, "neutral", "Ah man, I liked him.")
                    ]
                }
            },
            {
                "PeriWentMissing_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["periWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingPeri],
                    dialogue =
                    [
                        new(AmCull, "nervous", "Hey, where did Peri go?")
                    ]
                }
            },
            {
                "RiggsWentMissing_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["riggsWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingRiggs],
                    dialogue =
                    [
                        new(AmCull, "nervous", "Riggs?!")
                    ]
                }
            },
            {
                "JayWentMissing_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["JayWentMissing"],
                    lastTurnPlayerStatuses = [MissingJay],
                    dialogue =
                    [
                        new(AmCull, "nervous", "Who is in charge of the ship now?!?")
                    ]
                }
            },
            {
                "LunaWentMissing_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["LunaWentMissing"],
                    lastTurnPlayerStatuses = [MissingLuna],
                    dialogue =
                    [
                        new(AmCull, "squint", "Down one mage. Guess I'll have to pick up her slack.")
                    ]
                }
                
            },
            {
                "CentiWentMissing_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CentiWentMissing"],
                    lastTurnPlayerStatuses = [MissingCenti],
                    dialogue =
                    [
                        new(AmCull, "Somebody turn them back on!")
                    ]
                }
                
            },/*
            {
                "EvaWentMissing_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["EvaWentMissing"],
                    lastTurnPlayerStatuses = [MissingEva],
                    dialogue =
                    [
                        new(AmCull, "angry", "Where did she go?!")
                    ]
                }
                
            },*/
            {
                "WeDontOverlapWithEnemyAtAll_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    priority = true,
                    shipsDontOverlapAtAll = true,
                    nonePresent = ["crab", "scrap"],
                    oncePerRun = true,
                    oncePerRunTags = ["NoOverlapBetweenShips"],
                    dialogue =
                    [
                        new(AmCull, "neutral", "Try hitting us now!")
                    ]
                }
            },
            {
                "WeDontOverlapWithEnemyAtAllButWeDoHaveASeekerToDealWith_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    priority = true,
                    shipsDontOverlapAtAll = true,
                    oncePerCombatTags = ["NoOverlapBetweenShipsSeeker"],
                    anyDronesHostile = ["missile_seeker"],
                    nonePresent = ["crab"],
                    dialogue =
                    [
                        new(AmCull, "squint", "I'm not a fan of seekers. This is why.")
                    ]
                }
            },
            {
                "BlockedALotOfAttackWithArmor_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    enemyShotJustHit = true,
                    minDamageBlockedByPlayerArmorThisTurn = 3,
                    oncePerCombatTags = ["YowzaThatWasALOTofArmorBlock"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCull, "nervous", "Wow, they really want to kill us don't they?")
                    ]
                }
            },
            {
                "BlockedAnEnemyAttackWithArmor_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    enemyShotJustHit = true,
                    minDamageBlockedByPlayerArmorThisTurn = 1,
                    oncePerCombatTags = ["WowArmorISPrettyCoolHuh"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCull, "nervous", "Glad we have that armor.")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull, AmDizzy],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCull, "nervous", "I don't want to die!"),
                        new(AmDizzy, "frown", "You'll get used to it.")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Cull_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull, AmPeri],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmPeri, "mad", "Not dead yet!"),
                        new(AmCull, "squint", "Too close.")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Cull_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull, AmRiggs],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmRiggs, "nervous", "I'm not ready to go just yet!"),
                        new(AmCull, "squint", "They don't seem to care.")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Cull_3", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull, AmDrake],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCull, "squint", "This doesn't look good."),
                        new(AmDrake, "squint", "Could be worse.")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Cull_4", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull, AmBooks],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmBooks, "paws", "Cull, use your necromancy to bring us back!"),
                        new(AmCull, "squint", "It's doesn't work like that!")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Cull_5", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull, AmMax],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmMax, "squint", "Run it back?"),
                        new(AmCull, "squint", "If we have to.")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Cull_6", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull, AmCat],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCull, "nervous", "Is this what our enemies are supposed to feel like?"),
                        new(AmCat, "grumpy", "I sure hope so.")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Cull_7", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull, AmJay],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCull, "nervous", "This really doesn't look good."),
                        new(AmJay, "nervous", "You said it.")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Cull_8", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull, AmLuna],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmLuna, "nervous", "Any magic you know to get us out of this, Cull?"),
                        new(AmJay, "nervous", "Unfortunately not!")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Cull_9", new()
                { 
                    type = NodeType.combat, 
                    allPresent = [AmCull, AmCenti], 
                    enemyShotJustHit = true, 
                    maxHull = 2, 
                    oncePerCombatTags = ["aboutToDie"], 
                    oncePerRun = true, 
                    dialogue = 
                    [
                        new(AmCenti, "squint", "Shutting down auxiliary power."), 
                        new(AmCull, "angry", "Don't quit on us just yet!")
                    ]
                }
            },/*
               {
                   "Duo_AboutToDieAndLoop_Cull_10", new()
                   {
                       type = NodeType.combat,
                       allPresent = [AmCull, AmEva],
                       enemyShotJustHit = true,
                       maxHull = 2,
                       oncePerCombatTags = ["aboutToDie"],
                       oncePerRun = true,
                       dialogue =
                       [
                           new(AmEva, "sad", "Not again..."),
                           new(AmCull, "We'll be back, don't worry.")
                       ]
                   }
            },*/
            {
                "EmptyHandWithEnergy_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    handEmpty = true,
                    minEnergy = 1,
                    dialogue =
                    [
                        new(AmCull, "neutral", "Nothing left?")
                    ]
                }
            },
            {
                "EmptyHandWithEnergy_Cull_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    handEmpty = true,
                    minEnergy = 1,
                    dialogue =
                    [
                        new(AmCull, "squint", "Having this much extra energy is wasteful."),
                    ]
                }
            },
            {
                "EnemyArmorHitLots_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    playerShotJustHit = true,
                    minDamageBlockedByEnemyArmorThisTurn = 3,
                    oncePerCombat = true,
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCull, "squint", "Stop hitting the armor.")
                    ]
                }
            },
            {
                "EnemyArmorHit_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    playerShotJustHit = true,
                    minDamageBlockedByEnemyArmorThisTurn = 1,
                    oncePerCombat = true,
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCull, "squint", "That's annoying.")
                    ]
                }
            },
            {
                "EnemyHasBrittle_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    enemyHasBrittlePart = true,
                    oncePerRunTags = ["yelledAboutBrittle"],
                    dialogue =
                    [
                        new(AmCull, "Break them apart!")
                    ]
                }
            },
            {
                "EnemyHasBrittle_Cull_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    enemyHasBrittlePart = true,
                    oncePerRunTags = ["yelledAboutBrittle"],
                    dialogue =
                    [
                        new(AmCull, "That brittle spot is begging to be blasted.")
                    ]
                }
            },
            {
                "EnemyHasWeakness_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    enemyHasWeakPart = true,
                    oncePerRunTags = ["yelledAboutWeakness"],
                    dialogue =
                    [
                        new(AmCull, "Ooh, ooh, hit that weak spot!")
                    ]
                }
            },
            {
                "ExpensiveCardPlayed_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    minCostOfCardJustPlayed = 4,
                    oncePerCombatTags = ["ExpensiveCardPlayed"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCull, "neutral", "Hope that was worth the energy.")
                    ]
                }
            },
            {
                "FreezeIsMaxSize_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull, "crystal"],
                    turnStart = true,
                    enemyIntent = "biggestCrystal",
                    oncePerCombatTags = ["biggestCrystalShout"],
                    dialogue =
                    [
                        new(AmCull, "angry", "How have we not killed this thing yet?")
                    ]
                }
            },
            {
                "JustHitGeneric_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 1,
                    dialogue =
                    [
                        new(AmCull, "Keep going!")
                    ]
                }
            },
            {
                "JustHitGeneric_Cull_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 1,
                    dialogue =
                    [
                        new(AmCull, "Nice!")
                    ]
                }
            },
            {
                "JustHitGeneric_Cull_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 1,
                    dialogue =
                    [
                        new(AmCull, "Yes! More!")
                    ]
                }
            },
            {
                "JustPlayedADraculaCard_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    whoDidThat = Deck.dracula,
                    nonePresent = ["dracula"],
                    dialogue =
                    [
                        new(AmCull, "neutral", "A different flavor of dark magic.")
                    ]
                }
            },
            {
                "JustPlayedAnEphemeralCard_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    whoDidThat = Deck.ephemeral,
                    priority = true,
                    dialogue =
                    [
                        new(AmCull, "squint", "Was it worth it?")
                    ]
                }
            },
            {
                "LookOutMissile_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull, AmPeri],
                    priority = true,
                    once = true,
                    oncePerRunTags = ["goodMissileAdvice"],
                    anyDronesHostile = ["missile_corrode"],
                    dialogue =
                    [
                        new(AmPeri, "mad", "Shoot it down!"),
                        new(AmCull, "nervous", "Especially that corrode missile!")
                    ]
                }
            },
            {
                "ManyFlips_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    minTimesYouFlippedACardThisTurn = 4,
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmCull, "mad", "Hehe, flip flip!")
                    ]
                }
            },
            {
                "ManyTurns_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    minTurnsThisCombat = 9,
                    oncePerCombatTags = ["manyTurns"],
                    dialogue =
                    [
                        new(AmCull, "squint", "Are we done yet?")
                    ]
                }
            },
            {
                "ManyTurns_Cull_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    minTurnsThisCombat = 9,
                    oncePerCombatTags = ["manyTurns"],
                    dialogue =
                    [
                        new(AmCull, "squint", "This is taking too long, just blow them up.")
                    ]
                }
            },
            {
                "OneHitPointThisIsFine_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    enemyShotJustHit = true,
                    maxHull = 1,
                    dialogue =
                    [
                        new(AmCull, "nervous", "Come on...")
                    ]
                }
            },
            {
                "OneHitPointThisIsFine_Cull_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    enemyShotJustHit = true,
                    maxHull = 1,
                    lastTurnPlayerStatuses = [Status.corrode],
                    dialogue =
                    [
                        new(AmCull, "nervous", "Not when we're this close...")
                    ]
                }
            },
            {
                "OverheatGeneric_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    goingToOverheat = true,
                    oncePerCombatTags = ["OverheatGeneric"],
                    dialogue =
                    [
                        new(AmCull, "This heat makes my feathers sticky.")
                    ]
                }
            },
            {
                "StrafeMissedGood_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    playerShotJustMissed = true,
                    playerShotWasFromStrafe = true,
                    hasArtifacts = ["Recalibrator", "GrazerBeam"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmCull, "I suppose that works.")
                    ]
                }
            },
            {
                "TookZeroDamageAtLowHealth_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    maxDamageDealtToPlayerThisTurn = 0,
                    dialogue =
                    [
                        new(AmCull, "Too close for comfort!")
                    ]
                }
            },
            {
                "VeryManyTurns_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    minTurnsThisCombat = 20,
                    oncePerCombatTags = ["veryManyTurns"],
                    oncePerRun = true,
                    turnStart = true,
                    dialogue =
                    [
                        new(AmCull, "squint", "WOW we've been here a LONG time.")
                    ]
                }
            },
            {
                "WeGotHurtButNotTooBad_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    enemyShotJustHit = true,
                    minDamageDealtToPlayerThisTurn = 1,
                    maxDamageDealtToPlayerThisTurn = 1,
                    dialogue =
                    [
                        new(AmCull, "angry", "Hey! Watch it!")
                    ]
                }
            },
            {
                "WeMissedOopsie_Cull_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    playerShotJustMissed = true,
                    oncePerCombat = true,
                    doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                    dialogue =
                    [
                        new(AmCull, "squint", "...")
                    ]
                }
            },
            {
                "WeMissedOopsie_Cull_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    playerShotJustMissed = true,
                    oncePerCombat = true,
                    doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                    dialogue =
                    [
                        new(AmCull, "No hit, no soul.")
                    ]
                }
            },
            {
                "WeAreCorroded_Multi_0_Cull", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    lastTurnPlayerStatuses = [Status.corrode],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCull, "squint", "This is gonna hurt.")
                    ]
                }
            },
            {
                "WeAreCorroded_Multi_1_Cull", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    lastTurnPlayerStatuses = [Status.corrode],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCull, "angry", "OKAY WHO IS MELTING THE SHIP?")
                    ]
                }
            },
            {
                "CullWentMissing_Multi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmPeri],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CullWentMissing"],
                    lastTurnPlayerStatuses = [MissingCull],
                    dialogue =
                    [
                        new(AmPeri, "mad", "Hey, give us back our necromancer!")
                    ]
                }
            },
            {
                "CullWentMissing_Multi_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmRiggs],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CullWentMissing"],
                    lastTurnPlayerStatuses = [MissingCull],
                    dialogue =
                    [
                        new(AmRiggs, "nervous", "Where did the crow go?")
                    ]
                }
            },
            {
                "CullWentMissing_Multi_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmDizzy],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CullWentMissing"],
                    lastTurnPlayerStatuses = [MissingCull],
                    dialogue =
                    [
                        new(AmDizzy, "intense", "Cull!")
                    ]
                }
            },
            {
                "CullWentMissing_Multi_3", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCat],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CullWentMissing"],
                    lastTurnPlayerStatuses = [MissingCull],
                    dialogue =
                    [
                        new(AmCat, "Wuh oh.")
                    ]
                }
            },
            {
                "CullWentMissing_Multi_4", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmIsaac],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CullWentMissing"],
                    lastTurnPlayerStatuses = [MissingCull],
                    dialogue =
                    [
                        new(AmIsaac, "Ummm...")
                    ]
                }
            },
            {
                "CullWentMissing_Multi_5", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmDrake],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CullWentMissing"],
                    lastTurnPlayerStatuses = [MissingCull],
                    dialogue =
                    [
                        new(AmDrake, "Uh, Cull? Where are you?")
                    ]
                }
            },
            {
                "CullWentMissing_Multi_6", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmMax],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CullWentMissing"],
                    lastTurnPlayerStatuses = [MissingCull],
                    dialogue =
                    [
                        new(AmMax, "Woah.")
                    ]
                }
            },
            {
                "CullWentMissing_Multi_7", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmBooks],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CullWentMissing"],
                    lastTurnPlayerStatuses = [MissingCull],
                    dialogue =
                    [
                        new(AmBooks, "Magic crow? Where did you go?")
                    ]
                }
            },
            {
                "CullJustHit_Multi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 1,
                    whoDidThat = AmCullDeck,
                    oncePerCombatTags = ["CullShotAGuy"],
                    dialogue =
                    [
                        new(AmCull, "angry", "Your soul is mine!")
                    ]
                }
            },
            {
                "CullGotPerfect_Multi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    oncePerRun = true,
                    lastTurnPlayerStatuses = [Status.perfectShield],
                    dialogue =
                    [
                        new(AmCull, "neutral",
                            "This shield is a lifesaver! Too bad it doesn't protect our normal shields."),
                    ]
                }
            },
            #endregion
            #region Jay
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
                "CullWentMissing_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CullWentMissing"],
                    lastTurnPlayerStatuses = [MissingCull],
                    dialogue =
                    [
                        new(AmJay, "nervous", "Doesn't he come back?")
                    ]
                }
            },
            {
                "LunaWentMissing_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["LunaWentMissing"],
                    lastTurnPlayerStatuses = [MissingLuna],
                    dialogue =
                    [
                        new(AmJay, "nervous", "Did one of her spells backfire?")
                    ]
                }
            },
            {
                "CentiWentMissing_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CentiWentMissing"],
                    lastTurnPlayerStatuses = [MissingCenti],
                    dialogue =
                    [
                        new(AmJay, "angry", "Who unplugged the cyborg?")
                    ]
                }
            },/*
            {
                "EvaWentMissing_Jay_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["EvaWentMissing"],
                    lastTurnPlayerStatuses = [MissingEva],
                    dialogue =
                    [
                        new(AmJay, "nervous", "Of all people, why her?!")
                    ]
                }
            },*/
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
                "Duo_AboutToDieAndLoop_Jay_7", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay, AmLuna],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmJay, "angry", "Again with this?"),
                        new(AmLuna, "squint", "I am getting sick of dying.")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Jay_8", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay, AmCenti],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCenti, "nervous", "My circuits are beginning to fail."),
                        new(AmJay, "nervous", "Oh no!")
                    ]
                }
            },/*
            {
                "Duo_AboutToDieAndLoop_Jay_9", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay, AmEva],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmEva, "cry", "I don't like it here..."),
                        new(AmJay, "nervous", "It's ok! We'll be ok!")
                    ]
                }
            },*/
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
                "WeAreCorroded_Multi_0_Jay", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    lastTurnPlayerStatuses = [Status.corrode],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmJay, "nervous", "Not the hull!")
                    ]
                }
            },
            {
                "WeAreCorroded_Multi_1_Jay", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmJay],
                    lastTurnPlayerStatuses = [Status.corrode],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmJay, "angry", "This corrosion isn't good for the ship.")
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
            #endregion
            #region Luna
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
            {
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
            },/*
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
            {
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
            },/*
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
                "WeAreCorroded_Multi_0_Luna", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    lastTurnPlayerStatuses = [Status.corrode],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmLuna, "nervous", "Oh it smells bad too!")
                    ]
                }
            },
            {
                "WeAreCorroded_Multi_1_Luna", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmLuna],
                    lastTurnPlayerStatuses = [Status.corrode],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmLuna,  "Someone gonna wipe that off?")
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
            #endregion
            #region Centi
             {
                "ThatsALotOfDamageToUs_Centi_0", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    minDamageDealtToPlayerThisTurn = 3,
                    allPresent = [AmCenti],
                    dialogue =
                    [
                        new(AmCenti, "nervous", "The ship can't sustain this kind or torment!")
                    ]
                }
            },
            {
                "ThatsALotOfDamageToUs_Centi_1", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    minDamageDealtToPlayerThisTurn = 3,
                    allPresent = [AmCenti],
                    dialogue =
                    [
                        new(AmCenti, "squint", "That won't buffer out.")
                    ]
                }
            },
            {
                "ThatsALotOfDamageToUs_Centi_2", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    minDamageDealtToPlayerThisTurn = 3,
                    allPresent = [AmCenti],
                    dialogue =
                    [
                        new(AmCenti, "nervous", "That's a lot of damage...")
                    ]
                }
            },
            {
                "ThatsALotOfDamageToThem_Centi_0", new()
                {
                    type = NodeType.combat,
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisTurn = 10,
                    allPresent = [AmCenti],
                    dialogue =
                    [
                        new(AmCenti, "neutral", "Hell yeah.")
                    ]
                }
            },
            {
                "ThatsALotOfDamageToThem_Centi_1", new()
                {
                    type = NodeType.combat,
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisTurn = 10,
                    allPresent = [AmCenti],
                    dialogue =
                    [
                        new(AmCenti, "neutral", "That's got to hurt.")
                    ]
                }
            },
            {
                "WeGotShotButTookNoDamage_Centi_0", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    lastTurnPlayerStatuses = [Status.perfectShield],

                    oncePerRun = true,
                    allPresent = [AmCenti],
                    dialogue =
                    [
                        new(AmCenti, "neutral", "I love perfect shield.")
                    ]
                }
            },
            {
                "WeGotShotButTookNoDamage_Centi_1", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    lastTurnPlayerStatuses = [Status.perfectShield],

                    oncePerRun = true,
                    allPresent = [AmCenti],
                    dialogue =
                    [
                        new(AmCenti, "squint", "Was something supposed to happen?")
                    ]
                }
            },
            {
                "WeGotShotButTookNoDamage_Centi_2", new()
                {
                    type = NodeType.combat,
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    lastTurnPlayerStatuses = [Status.perfectShield],

                    oncePerRun = true,
                    allPresent = [AmCenti],
                    dialogue =
                    [
                        new(AmCenti, "neutral", "Nothing to be worried about.")
                    ]
                }
            },
            {
                "WeAreMovingAroundALot_Centi_0", new()
                {
                    type = NodeType.combat,
                    minMovesThisTurn = 3,
                    oncePerRun = true,
                    allPresent = [AmCenti],
                    dialogue =
                    [
                        new(AmCenti, "neutral", "Be sure not to wear out the engines.")
                    ]
                }
            },
            {
                "HandOnlyHasTrashCards_Centi_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    handFullOfTrash = true,
                    allPresent = [AmCenti],
                    dialogue =
                    [
                        new(AmCenti, "squint", "What a waste of space.")
                    ]
                }
            },
            {
                "HandOnlyHasUnplayableCards_Centi_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    handFullOfUnplayableCards = true,
                    allPresent = [AmCenti],
                    dialogue =
                    [
                        new(AmCenti, "squint", "Who's fault is this?")
                    ]
                }
            },
            {
                "BooksWentMissing_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["booksWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingBooks],
                    dialogue =
                    [
                        new(AmCenti, "squint", "Who misplaced the small one?")
                    ]
                }
            },
            {
                "CatWentMissing_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CatWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingCat],
                    dialogue =
                    [
                        new(who: AmCenti, "nervous", "Uh... is she supposed to do that?")
                    ]
                }
            },
            {
                "DizzyWentMissing_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["dizzyWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingDizzy],
                    dialogue =
                    [
                        new(AmCenti, "nervous", "I hope I can cover for him while he is gone.")
                    ]
                }
            },
            {
                "DrakeWentMissing_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["drakeWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingDrake],
                    dialogue =
                    [
                        new(AmCenti, "squint", "Not too mad about losing her, actually.")
                    ]
                }
            },
            {
                "IsaacWentMissing_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["issacWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingIsaac],

                    dialogue =
                    [
                        new(AmCenti, "nervous", "Drone bro! Come back!")
                    ]
                }
            },
            {
                "MaxWentMissing_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["maxWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingMax],
                    dialogue =
                    [
                        new(AmCenti, "neutral", "Awww, he was cool.")
                    ]
                }
            },
            {
                "PeriWentMissing_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["periWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingPeri],
                    dialogue =
                    [
                        new(AmCenti, "nervous", "How do we plan on fighting now?")
                    ]
                }
            },
            {
                "RiggsWentMissing_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["riggsWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingRiggs],
                    dialogue =
                    [
                        new(AmCenti, "squint", "Her skills could have been useful...")
                    ]
                }
            },
            {
                "CullWentMissing_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CullWentMissing"],
                    lastTurnPlayerStatuses = [MissingCull],
                    dialogue =
                    [
                        new(AmCenti, "squint", "Is he able to do that normally?")
                    ]
                }
                
            },
            {
                "JayWentMissing_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["JayWentMissing"],
                    lastTurnPlayerStatuses = [MissingJay],
                    dialogue =
                    [
                        new(AmCenti, "squint", "Aw, I liked his nanomachines.")
                    ]
                }
            },
            {
                "LunaWentMissing_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["LunaWentMissing"],
                    lastTurnPlayerStatuses = [MissingLuna],
                    dialogue =
                    [
                        new(AmCenti, "squint", "Magic is so confusing, will she come back?")
                    ]
                }
                
            },
            /*{
                "EvaWentMissing_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["EvaWentMissing"],
                    lastTurnPlayerStatuses = [MissingEva],
                    dialogue =
                    [
                        new(AmCenti, "angry", "Bring her back. Now.")
                    ]
                }
                
            },*/
            {
                "WeDontOverlapWithEnemyAtAll_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    priority = true,
                    shipsDontOverlapAtAll = true,
                    nonePresent = ["crab", "scrap"],
                    oncePerRun = true,
                    oncePerRunTags = ["NoOverlapBetweenShips"],
                    dialogue =
                    [
                        new(AmCenti, "neutral", "Good, now I deploy cores in saftey.")
                    ]
                }
            },
            {
                "WeDontOverlapWithEnemyAtAllButWeDoHaveASeekerToDealWith_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    priority = true,
                    shipsDontOverlapAtAll = true,
                    oncePerCombatTags = ["NoOverlapBetweenShipsSeeker"],
                    anyDronesHostile = ["missile_seeker"],
                    nonePresent = ["crab"],
                    dialogue =
                    [
                        new(AmCenti, "squint", "Ok, who's idea was it to invent seekers?")
                    ]
                }
            },
            {
                "BlockedALotOfAttackWithArmor_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    enemyShotJustHit = true,
                    minDamageBlockedByPlayerArmorThisTurn = 3,
                    oncePerCombatTags = ["YowzaThatWasALOTofArmorBlock"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCenti, "neutral", "Hehe, they can't get through the armor.")
                    ]
                }
            },
            {
                "BlockedAnEnemyAttackWithArmor_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    enemyShotJustHit = true,
                    minDamageBlockedByPlayerArmorThisTurn = 1,
                    oncePerCombatTags = ["WowArmorISPrettyCoolHuh"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCenti, "nervous", "Hopefully that armor holds.")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti, AmDizzy],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCenti, "nervous", "Are these shields not enough?"),
                        new(AmDizzy, "nervous", "I don't know!")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Centi_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti, AmPeri],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmPeri, "mad", "Keep the shields up!"),
                        new(AmCenti, "nervous", "I'm trying!")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Centi_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti, AmIsaac],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmIsaac, "nervous", "We aren't blocking enough shots!"),
                        new(AmCenti, "nervous", "I can only do so much!")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Centi_3", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti, AmDrake],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmDrake, "panic", "Oh no, I'm NOT going out like this!"),
                        new(AmCenti, "squint", "...")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Centi_4", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti, AmBooks],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmBooks, "paws", "Aw nuts! We were so close!"),
                        new(AmCenti, "squint", "Careful with your language, Books.")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Centi_5", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti, AmMax],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCenti, "squint", "Our momentum is gone."),
                        new(AmMax, "squint", "We just gotta lock in.")
                    ]
                }
            },
            {
                "Duo_AboutToDieAndLoop_Centi_6", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti, AmCat],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCenti, "squint", "Should I prepare for rest mode?"),
                        new(AmCat, "squint", "We'll be fine. Hopefully.")
                    ]
                }
            },
            /*
               {
                   "Duo_AboutToDieAndLoop_Centi_10", new()
                   {
                       type = NodeType.combat,
                       allPresent = [AmCenti, AmEva],
                       enemyShotJustHit = true,
                       maxHull = 2,
                       oncePerCombatTags = ["aboutToDie"],
                       oncePerRun = true,
                       dialogue =
                       [
                           new(AmEva, "sad", "I don't like this.."),
                           new(AmCenti, "This isn't the end, alright?")
                       ]
                   }
            },*/
            {
                "EmptyHandWithEnergy_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    handEmpty = true,
                    minEnergy = 1,
                    dialogue =
                    [
                        new(AmCenti, "neutral", "We're out?")
                    ]
                }
            },
            {
                "EmptyHandWithEnergy_Centi_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    handEmpty = true,
                    minEnergy = 1,
                    dialogue =
                    [
                        new(AmCenti, "squint", "I suppose this is better than the reverse."),
                    ]
                }
            },
            {
                "EnemyArmorHitLots_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    playerShotJustHit = true,
                    minDamageBlockedByEnemyArmorThisTurn = 3,
                    oncePerCombat = true,
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCenti, "squint", "Why are we hitting the armor?")
                    ]
                }
            },
            {
                "EnemyArmorHit_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    playerShotJustHit = true,
                    minDamageBlockedByEnemyArmorThisTurn = 1,
                    oncePerCombat = true,
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCenti, "squint", "Armor is only cool when we use it.")
                    ]
                }
            },
            {
                "EnemyHasBrittle_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    enemyHasBrittlePart = true,
                    oncePerRunTags = ["yelledAboutBrittle"],
                    dialogue =
                    [
                        new(AmCenti, "INCREDIBLY WEAK ARMOR DETECTED.")
                    ]
                }
            },
            {
                "EnemyHasBrittle_Centi_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    enemyHasBrittlePart = true,
                    oncePerRunTags = ["yelledAboutBrittle"],
                    dialogue =
                    [
                        new(AmCenti, "Put a slug or two into the brittle spot.")
                    ]
                }
            },
            {
                "EnemyHasWeakness_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    enemyHasWeakPart = true,
                    oncePerRunTags = ["yelledAboutWeakness"],
                    dialogue =
                    [
                        new(AmCenti, "Their hull is already craked a bit.")
                    ]
                }
            },
            {
                "ExpensiveCardPlayed_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    minCostOfCardJustPlayed = 4,
                    oncePerCombatTags = ["ExpensiveCardPlayed"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCenti, "squint", "That better pay off.")
                    ]
                }
            },
            {
                "FreezeIsMaxSize_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti, "crystal"],
                    turnStart = true,
                    enemyIntent = "biggestCrystal",
                    oncePerCombatTags = ["biggestCrystalShout"],
                    dialogue =
                    [
                        new(AmCenti, "nervous", "That thing is... big.")
                    ]
                }
            },
            {
                "JustHitGeneric_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 1,
                    dialogue =
                    [
                        new(AmCenti, "Direct hit!")
                    ]
                }
            },
            {
                "JustHitGeneric_Centi_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 1,
                    dialogue =
                    [
                        new(AmCenti, "Good shot!")
                    ]
                }
            },
            {
                "JustHitGeneric_Centi_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 1,
                    dialogue =
                    [
                        new(AmCenti, "Hit them again!")
                    ]
                }
            },
            {
                "JustPlayedADraculaCard_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    whoDidThat = Deck.dracula,
                    nonePresent = ["dracula"],
                    dialogue =
                    [
                        new(AmCenti, "squint", "Seriously, how does magic work?")
                    ]
                }
            },
            {
                "JustPlayedAnEphemeralCard_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    whoDidThat = Deck.ephemeral,
                    priority = true,
                    dialogue =
                    [
                        new(AmCenti, "squint", "And it's gone.")
                    ]
                }
            },
            {
                "LookOutMissile_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti, AmIsaac],
                    priority = true,
                    once = true,
                    oncePerRunTags = ["goodMissileAdvice"],
                    dialogue =
                    [
                        new(AmIsaac, "How do we want to dispose of that missile?"),
                        new(AmCenti, "neutral", "One of us could throw something at it.")
                    ]
                }
            },
            {
                "ManyFlips_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    minTimesYouFlippedACardThisTurn = 4,
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmCenti, "squint", "Is this entertaining to you?")
                    ]
                }
            },
            {
                "ManyTurns_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    minTurnsThisCombat = 9,
                    oncePerCombatTags = ["manyTurns"],
                    dialogue =
                    [
                        new(AmCenti, "squint", "This is boring.")
                    ]
                }
            },
            {
                "ManyTurns_Centi_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    minTurnsThisCombat = 9,
                    oncePerCombatTags = ["manyTurns"],
                    dialogue =
                    [
                        new(AmCenti, "squint", "Just kill them already.")
                    ]
                }
            },
            {
                "OneHitPointThisIsFine_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    enemyShotJustHit = true,
                    maxHull = 1,
                    dialogue =
                    [
                        new(AmCenti, "nervous", "Uhhhh...")
                    ]
                }
            },
            {
                "OneHitPointThisIsFine_Centi_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    oncePerCombatTags = ["aboutToDie"],
                    oncePerRun = true,
                    enemyShotJustHit = true,
                    maxHull = 1,
                    lastTurnPlayerStatuses = [Status.corrode],
                    dialogue =
                    [
                        new(AmCenti, "nervous", "Not again...")
                    ]
                }
            },
            {
                "OverheatGeneric_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    goingToOverheat = true,
                    oncePerCombatTags = ["OverheatGeneric"],
                    dialogue =
                    [
                        new(AmCenti, "This heat is going to fry my circuits.")
                    ]
                }
            },
            {
                "StrafeMissedGood_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCull],
                    playerShotJustMissed = true,
                    playerShotWasFromStrafe = true,
                    hasArtifacts = ["Recalibrator", "GrazerBeam"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmCenti, "squint","I guess??")
                    ]
                }
            },
            {
                "TookZeroDamageAtLowHealth_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    maxDamageDealtToPlayerThisTurn = 0,
                    dialogue =
                    [
                        new(AmCenti, "nervous","Don't like that at all!")
                    ]
                }
            },
            {
                "VeryManyTurns_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    minTurnsThisCombat = 20,
                    oncePerCombatTags = ["veryManyTurns"],
                    oncePerRun = true,
                    turnStart = true,
                    dialogue =
                    [
                        new(AmCenti, "squint", "I am going to run out of power at the rate this fight is going.")
                    ]
                }
            },
            {
                "WeGotHurtButNotTooBad_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    enemyShotJustHit = true,
                    minDamageDealtToPlayerThisTurn = 1,
                    maxDamageDealtToPlayerThisTurn = 1,
                    dialogue =
                    [
                        new(AmCenti, "angry", "Don't try it.")
                    ]
                }
            },
            {
                "WeMissedOopsie_Centi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    playerShotJustMissed = true,
                    oncePerCombat = true,
                    doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                    dialogue =
                    [
                        new(AmCenti, "squint", "Who's idea was that?")
                    ]
                }
            },
            {
                "WeMissedOopsie_Centi_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    playerShotJustMissed = true,
                    oncePerCombat = true,
                    doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                    dialogue =
                    [
                        new(AmCenti, "Can we not miss next time?")
                    ]
                }
            },
            {
                "WeAreCorroded_Multi_0_Centi", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    lastTurnPlayerStatuses = [Status.corrode],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCenti, "squint", "Please tell me we can end this quickly.")
                    ]
                }
            },
            {
                "WeAreCorroded_Multi_1_Centi", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    lastTurnPlayerStatuses = [Status.corrode],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmCenti, "angry", "This corrosion is going to eat away at both me AND the ship!")
                    ]
                }
            },
            {
                "CentiWentMissing_Multi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmPeri],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CentiWentMissing"],
                    lastTurnPlayerStatuses = [MissingCenti],
                    dialogue =
                    [
                        new(AmPeri, "mad", "Where did they go??")
                    ]
                }
            },
            {
                "CentiWentMissing_Multi_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmRiggs],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CentiWentMissing"],
                    lastTurnPlayerStatuses = [MissingCenti],
                    dialogue =
                    [
                        new(AmRiggs, "nervous", "They will come back, right?")
                    ]
                }
            },
            {
                "CentiWentMissing_Multi_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmDizzy],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CentiWentMissing"],
                    lastTurnPlayerStatuses = [MissingCenti],
                    dialogue =
                    [
                        new(AmDizzy, "intense", "Centi! We need you!")
                    ]
                }
            },
            {
                "CentiWentMissing_Multi_3", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCat],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CentiWentMissing"],
                    lastTurnPlayerStatuses = [MissingCenti],
                    dialogue =
                    [
                        new(AmCat, "Please don't tell me I'm next...")
                    ]
                }
            },
            {
                "CentiWentMissing_Multi_4", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmIsaac],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CentiWentMissing"],
                    lastTurnPlayerStatuses = [MissingCenti],
                    dialogue =
                    [
                        new(AmIsaac, "I'll protect your cores while you are gone, bud.")
                    ]
                }
            },
            {
                "CentiWentMissing_Multi_5", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmDrake],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CentiWentMissing"],
                    lastTurnPlayerStatuses = [MissingCenti],
                    dialogue =
                    [
                        new(AmDrake, "Bring them back. I'm not asking.")
                    ]
                }
            },
            {
                "CentiWentMissing_Multi_6", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmMax],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CentiWentMissing"],
                    lastTurnPlayerStatuses = [MissingCenti],
                    dialogue =
                    [
                        new(AmMax, "Nope. Not good.")
                    ]
                }
            },
            {
                "CentiWentMissing_Multi_7", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmBooks],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CentiWentMissing"],
                    lastTurnPlayerStatuses = [MissingCenti],
                    dialogue =
                    [
                        new(AmBooks, "Robo-bird, come back!")
                    ]
                }
            },
            {
                "CentiJustHit_Multi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    playerShotJustHit = true,
                    minDamageDealtToEnemyThisAction = 1,
                    whoDidThat = AmCullDeck,
                    oncePerCombatTags = ["CentiShotAGuy"],
                    dialogue =
                    [
                        new(AmCenti,  "Clean hit.")
                    ]
                }
            },
            {
                "CentiGotPerfect_Multi_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [AmCenti],
                    oncePerRun = true,
                    lastTurnPlayerStatuses = [Status.perfectShield],
                    dialogue =
                    [
                        new(AmCenti, "neutral", "The most perfect defense."),
                    ]
                }
            },
            #endregion
            #region Eva
            #endregion

            #region Edits
            {
                "ShopKeepBattleInsult", new()
                {
                    edit =
                    [
                        new("66ea84d6", AmCull, "nervous", "Oh, that's... that's a lot of guns."),
                        new("66ea84d6", AmJay, "nervous", "Please have mercy."),
                        new("66ea84d6", AmLuna, "nervous", "I'm sorry."),
                        new("66ea84d6", AmCenti, "nervous", "Now, hold on..."),
                    ],
                }
            },
            {
                "BanditThreats_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmCull, "squint", "Please no seekers."),
                        new(EMod.countFromStart, 1, AmJay, "angry", "Your Engine Stall is very annoying to clean up."),
                        new(EMod.countFromStart, 1, AmLuna, "angry", "Can you, like, let us move, please?"),
                        new(EMod.countFromStart, 1, AmCenti, "Missiles got nothing on me."),
                    ]
                }
            },
            {
                "CrabFacts1_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmCull, "Woah."),
                        new(EMod.countFromStart, 2, AmJay, "squint", "What?"),
                        new(EMod.countFromStart, 2, AmLuna, "Really?"),
                        new(EMod.countFromStart, 2, AmCenti, "Uh, no?"),
                    ]
                }
            },
            {
                "CrabFacts2_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmCull, "neutral", "That's so cool!"),
                        new(EMod.countFromStart, 2, AmJay, "squint", "That's preposterous."),
                        new(EMod.countFromStart, 2, AmLuna, "Wow!"),
                        new(EMod.countFromStart, 2, AmCenti, "Where did you hear that?"),
                    ]
                }
            },
            {
                "CrabFactsAreOverNow_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmCull, "sad", "Aw man."),
                        new(EMod.countFromStart, 1, AmJay, "neutral", "Finally."),
                        new(EMod.countFromStart, 1, AmLuna, "sad", "Awwwwww."),
                        new(EMod.countFromStart, 1, AmCenti, "neutral", "Good."),

                    ]
                }
            },
            {
                "DillianShouts", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmCull, "squint", "Do I know you?"),
                        new(EMod.countFromStart, 1, AmJay, "squint", "And you are?"),
                        new(EMod.countFromStart, 1, AmCenti, "squint", "Have we met?"),

                    ]
                }
            },
            {
                "OverheatDrakeFix_Multi_6", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmCull, "squint", "You're lucky. Don't try that again."),
                        new(EMod.countFromStart, 1, AmJay, "squint", "Can you stop trying to kill us?"),
                        new(EMod.countFromStart, 1, AmLuna, "squint", "Drake, just stop."),
                        new(EMod.countFromStart, 1, AmCenti, "squint", "you're still doing this? Really?"),
                    ]
                }
            },
            {
                "OverheatDrakesFault_Multi_9", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmCull, "angry", "I really don't like this heat."),
                        new(EMod.countFromStart, 1, AmJay, "angry", "The hull is at risk cause of you."),
                        new(EMod.countFromStart, 1, AmLuna, "angry", "Really? C'mon."),
                        new(EMod.countFromStart, 1, AmCenti, "angry", "I thought you would be better than this."),
                    ]
                }
            },
            {
                "RiderAvast", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmCull, "squint", "What does that even mean?"),
                        new(EMod.countFromStart, 2, AmJay, "neutral", "Old ships have such a nice quality to them."),
                        new(EMod.countFromStart, 2, AmLuna, "neutral", "Yar-har!"),
                        new(EMod.countFromStart, 2, AmCenti, "neutral", "Ah, an old fashioned pirate."),
                    ]
                }
            },
            {
                "SkunkFirstTurnShouts_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmCull, "Why do you want these rocks?"),
                        new(EMod.countFromStart, 2, AmJay, "These rocks could make excellent plating."),
                        new(EMod.countFromStart, 2, AmLuna, "Anything shiny in these rocks?"),
                        new(EMod.countFromStart, 2, AmCenti, "They are just rocks..."),
                    ]
                }
            },
            {
                "SogginsEscapeIntent_1", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmCull, "neutral", "Hold one moment, we aren't finished."),
                        new(EMod.countFromStart, 1, AmJay, "neutral", "Please wait right there."),
                        new(EMod.countFromStart, 1, AmLuna, "neutral", "Slow your roll."),
                        new(EMod.countFromStart, 1, AmCenti, "neutral", "Stop right there, frog scum."),
                    ]
                }
            },
            {
                "Soggins_Missile_Shout_1", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmCull, "squint", "How does this even happen?"),
                        new(EMod.countFromStart, 1, AmJay, "squint", "Where did you get those missiles?"),
                        new(EMod.countFromStart, 1, AmLuna, "squint", "How does this keep happening?"),
                        new(EMod.countFromStart, 1, AmCenti, "squint", "Again with this?"),
                    ]
                }
            },
            {
                "WeJustGainedHeatAndDrakeIsHere_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmCull, "angry", "Can we please cool the ship down?"),
                        new(EMod.countFromStart, 1, AmJay, "angry", "Please stop melting the hull."),
                        new(EMod.countFromStart, 1, AmLuna, "angry", "This is your fault, you know?"),
                        new(EMod.countFromStart, 1, AmCenti, "angry", "You really got to stop."),

                    ]
                }
            },
            #endregion
        });
        
    }
}