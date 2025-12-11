using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using Flipbop.BOAF;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class CombatDialogueCull
{
    public CombatDialogueCull()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {
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
                "ShopKeepBattleInsult", new()
                {
                    edit =
                    [
                        new("66ea84d6", AmCull, "nervous", "Oh, that's... that's a lot of guns."),
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
            /*{
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
                
            },{
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
                        new(AmCull, "squint", "Still could lose soul energy from that.")
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
            /*{
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
            },
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
                "WeAreCorroded_Multi_0", new()
                {
                    dialogue =
                    [
                        new(AmCull, "squint", "This is gonna hurt.")
                    ]
                }
            },
            {
                "WeAreCorroded_Multi_1", new()
                {
                    dialogue =
                    [
                        new(AmCull, "angry", "OKAY WHO IS MELTING THE SHIP?")
                    ]
                }
            },
            {
                "BanditThreats_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmCull, "squint", "Please no seekers.")
                    ]
                }
            },
            {
                "CrabFacts1_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmCull, "Woah.")
                    ]
                }
            },
            {
                "CrabFacts2_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmCull, "neutral", "That's so cool!")
                    ]
                }
            },
            {
                "CrabFactsAreOverNow_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmCull, "sad", "Aw man.")
                    ]
                }
            },
            {
                "DillianShouts", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmCull, "squint", "Do I know you?")
                    ]
                }
            },
            {
                "OverheatDrakeFix_Multi_6", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmCull, "squint", "You're lucky. Don't try that again."),
                    ]
                }
            },
            {
                "OverheatDrakesFault_Multi_9", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmCull, "angry", "I really don't like this heat.")
                    ]
                }
            },
            {
                "RiderAvast", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmCull, "squint", "What does that even mean?")
                    ]
                }
            },
            {
                "SkunkFirstTurnShouts_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmCull, "Why do you want these rocks?"),
                        new(EMod.countFromStart, 2, AmDuncan, "Cause they're cool!")

                    ]
                }
            },
            {
                "SogginsEscapeIntent_1", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmCull, "neutral", "Hold one moment, we aren't finished.")
                    ]
                }
            },
            {
                "Soggins_Missile_Shout_1", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmCull, "squint", "How does this even happen?")
                    ]
                }
            },
            {
                "WeJustGainedHeatAndDrakeIsHere_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmCull, "angry", "Can we please cool the ship down?"),
                        new(EMod.countFromStart, 1, AmDrake, "sly", "Oh it will cool down, it's just gonna hurt.")
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
        });
    }
}