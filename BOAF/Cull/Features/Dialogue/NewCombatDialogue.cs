using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using Flipbop.BOAF;
namespace Flipbop.BOAF;

internal class NewCombatDialogue : IRegisterable
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>(){
            {"ThatsALotOfDamageToUs_Cull_0", new(){
                type = NodeType.combat,
                enemyShotJustHit = true,
                minDamageDealtToPlayerThisTurn = 3,
                allPresent = [ AmCull ],
                dialogue = [
                    new(AmCull, "panic", "Too much damage! Too much damage!")
                ]
            }},
            {"ThatsALotOfDamageToUs_Cull_1", new(){
                type = NodeType.combat,
                enemyShotJustHit = true,
                minDamageDealtToPlayerThisTurn = 3,
                allPresent = [ AmCull ],
                dialogue = [
                    new(AmCull, "shocked", "That's too big of a hole to patch, even for me.")
                ]
            }},
            {"ThatsALotOfDamageToUs_Cull_2", new(){
                type = NodeType.combat,
                enemyShotJustHit = true,
                minDamageDealtToPlayerThisTurn = 3,
                allPresent = [ AmCull ],
                dialogue = [
                    new(AmCull, "intense", "I can fix it... I can fix it...")
                ]
            }},
            {"ThatsALotOfDamageToThem_Cull_0", new(){
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisTurn = 10,
                allPresent = [ AmCull ],
                dialogue = [
                    new(AmCull, "shocked", "That's a lot of damage!")
                ]
            }},
            {"ThatsALotOfDamageToThem_Cull_1", new(){
                type = NodeType.combat,
                playerShotJustHit = true,
                minDamageDealtToEnemyThisTurn = 10,
                allPresent = [ AmCull ],
                dialogue = [
                    new(AmCull, "silly", "Booyah!")
                ]
            }},
            {"WeGotShotButTookNoDamage_Cull_0", new(){
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxDamageDealtToPlayerThisTurn = 0,
                lastTurnPlayerStatuses = [Status.perfectShield],

                oncePerRun = true,
                allPresent = [ AmCull ],
                dialogue = [
                    new(AmCull, "explain", "The results of my constant experimentions. Behold, perfection.")
                ]
            }},
            {"WeGotShotButTookNoDamage_Cull_1", new(){
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxDamageDealtToPlayerThisTurn = 0,
                lastTurnPlayerStatuses = [Status.perfectShield],

                oncePerRun = true,
                allPresent = [ AmCull ],
                dialogue = [
                    new(AmCull, "explain", "See? All that hull perforation wasn't in vain.")
                ]
            }},
            {"WeGotShotButTookNoDamage_Cull_2", new(){
                type = NodeType.combat,
                enemyShotJustHit = true,
                maxDamageDealtToPlayerThisTurn = 0,
                lastTurnPlayerStatuses = [Status.perfectShield],

                oncePerRun = true,
                allPresent = [ AmCull ],
                dialogue = [
                    new(AmCull, "explain", "That could've been really bad... if you didn't believe in my research.")
                ]
            }},
            {"WeAreMovingAroundALot_Cull_0", new(){
                type = NodeType.combat,
                minMovesThisTurn = 3,
                oncePerRun = true,
                allPresent = [ AmCull ],
                dialogue = [
                    new(AmCull, "mad", "Dodge and weave! Dodge and weave!")
                ]
            }},
            {"WeAreMovingAroundALot_Cull_1", new(){
                type = NodeType.combat,
                minMovesThisTurn = 3,
                oncePerRun = true,
                allPresent = [ AmCull ],
                dialogue = [
                    new(AmCull, "explain", "The best form of defence is running away... wait no I meant movement.")
                ]
            }},
            {"ShopKeepBattleInsult", new(){
                edit = [
                    new("66ea84d6", AmCull, "panic", "Who said yes? WHO SAID YES?!"),
                    new("66ea84d6", AmCull, "shocked", "I'm so sorry, my crewmates are idiots! Please forgive us!")
                ]
            }},
            {"HandOnlyHasTrashCards_Cull_0", new(){
                type = NodeType.combat,
                oncePerRun = true,
                handFullOfTrash = true,
                allPresent = [ AmCull ],
                dialogue = [
                    new(AmCull, "intense", "The trash is overflowing into my workspace!")
                ]
            }},
            {"HandOnlyHasUnplayableCards_Cull_0", new(){
                type = NodeType.combat,
                oncePerRun = true,
                handFullOfUnplayableCards = true,
                allPresent = [ AmCull ],
                dialogue = [
                    new(AmCull, "squint", "I can't do anything with this.")
                ]
            }},
            {"BooksWentMissing_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                priority = true,
                oncePerRun = true,
                oncePerCombatTags = ["booksWentMissing"],
                lastTurnPlayerStatuses = [Status.missingBooks],
                dialogue = [
                    new(AmCull, "shocked", "Hey, where'd Books go?")
                ]
            }},
            {"CatWentMissing_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                priority = true,
                oncePerRun = true,
                oncePerCombatTags = ["CatWentMissing"],
                lastTurnPlayerStatuses = [Status.missingCat],
                dialogue = [
                    new(who: AmCull,
                        loopTag: "panic",
                        what: "Uhh maybe if I upload myself to the computer...")
                ]
            }},
            {"DizzyWentMissing_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                priority = true,
                oncePerRun = true,
                oncePerCombatTags = ["dizzyWentMissing"],
                lastTurnPlayerStatuses = [Status.missingDizzy],
                dialogue = [
                    new(AmCull, "intense", "Oh no.")
                ]
            }},
            {"DrakeWentMissing_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                priority = true,
                oncePerRun = true,
                oncePerCombatTags = ["drakeWentMissing"],
                lastTurnPlayerStatuses = [Status.missingDrake],
                dialogue = [
                    new(AmCull, "intense", "Why does it suddenly feel so... lonely?")
                ]
            }},
            {"IsaacWentMissing_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                priority = true,
                oncePerRun = true,
                oncePerCombatTags = ["issacWentMissing"],
                lastTurnPlayerStatuses = [Status.missingIsaac],

                dialogue = [
                    new(AmCull, "panic", "Ah!")
                ]
            }},
            {"MaxWentMissing_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                priority = true,
                oncePerRun = true,
                oncePerCombatTags = ["maxWentMissing"],
                lastTurnPlayerStatuses = [Status.missingMax],
                dialogue = [
                    new(AmCull, "intense", "Now who's gonna fix my broken equipment?")
                ]
            }},
            {"PeriWentMissing_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                priority = true,
                oncePerRun = true,
                oncePerCombatTags = ["periWentMissing"],
                lastTurnPlayerStatuses = [Status.missingPeri],
                dialogue = [
                    new(AmCull, "shocked", "Wait no I already miss her!")
                ]
            }},
            {"RiggsWentMissing_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                priority = true,
                oncePerRun = true,
                oncePerCombatTags = ["riggsWentMissing"],
                lastTurnPlayerStatuses = [Status.missingRiggs],
                dialogue = [
                    new(AmCull, "panic", "BUDDY NOOOOOO!!")
                ]
            }},
            {"WeDontOverlapWithEnemyAtAll_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                priority = true,
                shipsDontOverlapAtAll = true,
                nonePresent = [ "crab", "scrap" ],
                oncePerRun = true,
                oncePerRunTags = [ "NoOverlapBetweenShips" ],
                dialogue = [
                    new(AmCull, "silly", "Gone. Goodbye!")
                ]
            }},
            {"WeDontOverlapWithEnemyAtAllButWeDoHaveASeekerToDealWith_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                priority = true,
                shipsDontOverlapAtAll = true,
                oncePerCombatTags = [ "NoOverlapBetweenShipsSeeker"],
                anyDronesHostile = [ "missile_seeker" ],
                nonePresent = [ "crab" ],
                dialogue = [
                    new(AmCull, "squint", "What's the point of evasive maneuvers if we're gonna get hit anyways?")
                ]
            }},
            {"BlockedALotOfAttackWithArmor_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                enemyShotJustHit = true,
                minDamageBlockedByPlayerArmorThisTurn = 3,
                oncePerCombatTags = ["YowzaThatWasALOTofArmorBlock"],
                oncePerRun = true,
                dialogue = [
                    new(AmCull, "squint", "It would've been better if we just avoided getting hit in the first place.")
                ]
            }},
            {"BlockedAnEnemyAttackWithArmor_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                enemyShotJustHit = true,
                minDamageBlockedByPlayerArmorThisTurn = 1,
                oncePerCombatTags = ["WowArmorISPrettyCoolHuh"],
                oncePerRun = true,
                dialogue = [
                    new(AmCull, "Hey, less work for me!")
                ]
            }},
            {"Duo_AboutToDieAndLoop_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull, AmDizzy ],
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = ["aboutToDie"],
                oncePerRun = true,
                dialogue = [
                    new(AmDizzy, "frown", "Time loop?"),
                    new(AmCull, "solemn", "Despite everything.")
                ]
            }},
            {"Duo_AboutToDieAndLoop_Cull_1", new(){
                type = NodeType.combat,
                allPresent = [ AmCull, AmPeri ],
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = ["aboutToDie"],
                oncePerRun = true,
                dialogue = [
                    new(AmPeri, "mad", "Is that it?"),
                    new(AmCull, "mad", "I hope not.")
                ]
            }},
            {"Duo_AboutToDieAndLoop_Cull_2", new(){
                type = NodeType.combat,
                allPresent = [ AmCull, AmRiggs ],
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = ["aboutToDie"],
                oncePerRun = true,
                dialogue = [
                    new(AmCull, "squint", "Next time, I'm taking the wheel."),
                    new(AmRiggs, "No.")
                ]
            }},
            {"Duo_AboutToDieAndLoop_Cull_3", new(){
                type = NodeType.combat,
                allPresent = [ AmCull, AmDrake ],
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = ["aboutToDie"],
                oncePerRun = true,
                dialogue = [
                    new(AmDrake, "This is all your fault."),
                    new(AmCull, "tired", "...")
                ]
            }},
            {"Duo_AboutToDieAndLoop_Cull_4", new(){
                type = NodeType.combat,
                allPresent = [ AmCull, AmIsaac ],
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = ["aboutToDie"],
                oncePerRun = true,
                dialogue = [
                    new(AmIsaac, "Dang."),
                    new(AmCull, "explain", "Oh well.")
                ]
            }},
            {"Duo_AboutToDieAndLoop_Cull_5", new(){
                type = NodeType.combat,
                allPresent = [ AmCull, AmBooks ],
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = ["aboutToDie"],
                oncePerRun = true,
                dialogue = [
                    new(AmBooks, "Failure!"),
                    new(AmCull, "sad", "Noooooooooowuh!")
                ]
            }},
            {"Duo_AboutToDieAndLoop_Cull_6", new(){
                type = NodeType.combat,
                allPresent = [ AmCull, AmMax ],
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = ["aboutToDie"],
                oncePerRun = true,
                dialogue = [
                    new(AmMax, "mad", "We've lost!"),
                    new(AmCull, "squint", "Not yet we haven't.")
                ]
            }},
            {"Duo_AboutToDieAndLoop_Cull_7", new(){
                type = NodeType.combat,
                allPresent = [ AmCull, AmCat ],
                enemyShotJustHit = true,
                maxHull = 2,
                oncePerCombatTags = ["aboutToDie"],
                oncePerRun = true,
                dialogue = [
                    new(AmCat, "grumpy", "Reset incoming."),
                    new(AmCull, "panic", "Not yet!")
                ]
            }},
            {"EmptyHandWithEnergy_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                handEmpty = true,
                minEnergy = 1,
                dialogue = [
                    new(AmCull, "curious", "That it?")
                ]
            }},
            {"EmptyHandWithEnergy_Cull_1", new(){
                type = NodeType.combat,
                allPresent = [ AmCull, AmDrake ],
                handEmpty = true,
                minEnergy = 1,
                dialogue = [
                    new(AmCull, "squint", "The one time my hands are free, there's nothing to do."),
                    new(AmDrake, "sly", "You don't have hands.")
                ]
            }},
            {"EnemyArmorHitLots_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                playerShotJustHit = true,
                minDamageBlockedByEnemyArmorThisTurn = 3,
                oncePerCombat = true,
                oncePerRun = true,
                dialogue = [
                    new(AmCull, "tired", "You know, if you're gonna be wasting resources doing dumb schenanigans, might as well give them to me for my experiments.")
                ]
            }},
            {"EnemyArmorHit_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                playerShotJustHit = true,
                minDamageBlockedByEnemyArmorThisTurn = 1,
                oncePerCombat = true,
                oncePerRun = true,
                dialogue = [
                    new(AmCull, "squint", "I thought I gave you enough fuel.")
                ]
            }},
            {"EnemyHasBrittle_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                enemyHasBrittlePart = true,
                oncePerRunTags = ["yelledAboutBrittle"],
                dialogue = [
                    new(AmCull, "Break them apart!")
                ]
            }},
            {"EnemyHasBrittle_Cull_1", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                enemyHasBrittlePart = true,
                oncePerRunTags = ["yelledAboutBrittle"],
                dialogue = [
                    new(AmCull, "explain", "If only they were also tarnished. That'd mean double DOUBLE damage. Four times!")
                ]
            }},
            {"EnemyHasWeakness_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                enemyHasWeakPart = true,
                oncePerRunTags = ["yelledAboutWeakness"],
                dialogue = [
                    new(AmCull, "Hit the weak point!")
                ]
            }},
            {"ExpensiveCardPlayed_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                minCostOfCardJustPlayed = 4,
                oncePerCombatTags = ["ExpensiveCardPlayed"],
                oncePerRun = true,
                dialogue = [
                    new(AmCull, "intense", "Did anyone else's lights just flicker?")
                ]
            }},
            {"FreezeIsMaxSize_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull, "crystal" ],
                turnStart = true,
                enemyIntent = "biggestCrystal",
                oncePerCombatTags = ["biggestCrystalShout"],
                dialogue = [
                    new(AmCull, "panic", "Okay, who let the death crystal get this big?")
                ]
            }},
            {"JustHitGeneric_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                dialogue = [
                    new(AmCull, "That's a hit!")
                ]
            }},
            {"JustHitGeneric_Cull_1", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                dialogue = [
                    new(AmCull, "You got 'em.")
                ]
            }},
            {"JustHitGeneric_Cull_2", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                dialogue = [
                    new(AmCull, "Blam!")
                ]
            }},
            {"JustPlayedADraculaCard_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                whoDidThat = Deck.dracula,
                nonePresent = [ "dracula" ],
                dialogue = [
                    new(AmCull, "explain", "Now that's utility I strive for.")
                ]
            }},
            {"JustPlayedASashaCard_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                nonePresent = [ "sasha" ],
                whoDidThat = Deck.sasha,
                dialogue = [
                    new(AmCull, "sad", "If only I too could sports.")
                ]
            }},
            {"JustPlayedAnEphemeralCard_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                whoDidThat = Deck.ephemeral,
                priority = true,
                dialogue = [
                    new(AmCull, "stareatcamera", "Was it worth it?")
                ]
            }},
            {"LookOutMissile_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull, AmPeri ],
                priority = true,
                once = true,
                oncePerRunTags = ["goodMissileAdvice"],
                anyDronesHostile = ["missile_normal", "missile_heavy", "missile_corrode", "missile_breacher"],
                dialogue = [
                    new(AmPeri, "mad", "Shoot it down!"),
                    new(AmCull, "No! Full throttle!")
                ]
            }},
            {"ManyFlips_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                minTimesYouFlippedACardThisTurn = 4,
                oncePerCombat = true,
                dialogue = [
                    new(AmCull, "mad", "Oh my word. Can you pick a side already?!")
                ]
            }},
            {"ManyTurns_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                minTurnsThisCombat = 9,
                oncePerCombatTags = ["manyTurns"],
                dialogue = [
                    new(AmCull, "explain", "Slow and steady wins the race.")
                ]
            }},
            {"ManyTurns_Cull_1", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                minTurnsThisCombat = 9,
                oncePerCombatTags = ["manyTurns"],
                dialogue = [
                    new(AmCull, "tired", "What time is it?")
                ]
            }},
            {"OldSpikeChattyPostRenameGeorge_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull, "spike" ],
                oncePerCombatTags = ["OldSpikeNewName"],
                maxTurnsThisCombat = 1,
                spikeName = "george",
                dialogue = [
                    new("spike", "George time!"),
                    new(AmCull, "Would've sounded better if you were Spike.")
                ]
            }},
            {"OldSpikeChattyPostRenameSpikeTwo_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull, "spike" ],
                oncePerCombatTags = ["OldSpikeNewName"],
                maxTurnsThisCombat = 1,
                spikeName = "spiketwo",
                dialogue = [
                    new("spike", "Get ready! Spike Two is here!"),
                    new(AmCull, "squint", "What kind of name is Spike Two? Are you a sequel or something?")
                ]
            }},
            {"OneHitPointThisIsFine_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                oncePerCombatTags = ["aboutToDie"],
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 1,
                dialogue = [
                    new(AmCull, "panic",  "We're losing hull faster than I can patch them!")
                ]
            }},
            {"OneHitPointThisIsFine_Cull_1", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                oncePerCombatTags = ["aboutToDie"],
                oncePerRun = true,
                enemyShotJustHit = true,
                maxHull = 1,
                lastTurnPlayerStatuses = [Status.corrode],
                dialogue = [
                    new(AmCull, "panic", "Uhhh... maybe I shouldn't have experimented this much.")
                ]
            }},
            {"OverheatGeneric_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                goingToOverheat = true,
                oncePerCombatTags = ["OverheatGeneric"],
                dialogue = [
                    new(AmCull, "My corrosive solution has boiled away.")
                ]
            }},
            {"PlayedManyCards_Cull_0", new(){
                type = NodeType.combat,
                handEmpty = true,
                minCardsPlayedThisTurn = 6,
                allPresent = [ AmCull ],
                dialogue = [
                    new(AmCull, "Wow! Many things done! Good job.")
                ]
            }},
            {"StrafeHit_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                playerShotWasFromStrafe = true,
                oncePerCombat = true,
                dialogue = [
                    new(AmCull, "explain", "You know, I might invest in this strafe tech.")
                ]
            }},
            {"StrafeMissedGood_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                playerShotJustMissed = true,
                playerShotWasFromStrafe = true,
                hasArtifacts = [ "Recalibrator", "GrazerBeam"],
                oncePerCombat = true,
                dialogue = [
                    new(AmCull, "Nothing wasted.")
                ]
            }},
            {"TookZeroDamageAtLowHealth_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                enemyShotJustHit = true,
                maxHull = 2,
                maxDamageDealtToPlayerThisTurn = 0,
                dialogue = [
                    new(AmCull, "Keep 'em busy! I'm working my magic.")
                ]
            }},
            {"VeryManyTurns_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                minTurnsThisCombat = 20,
                oncePerCombatTags = ["veryManyTurns"],
                oncePerRun = true,
                turnStart = true,
                dialogue = [
                    new(AmCull, "tired", "Okay this is getting ridiculous.")
                ]
            }},
            {"WeGotHurtButNotTooBad_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                enemyShotJustHit = true,
                minDamageDealtToPlayerThisTurn = 1,
                maxDamageDealtToPlayerThisTurn = 1,
                dialogue = [
                    new(AmCull, "Totally fixable.")
                ]
            }},
            {"WeMissedOopsie_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                playerShotJustMissed = true,
                oncePerCombat = true,
                doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                dialogue = [
                    new(AmCull, "explain", "Good thing I'm not the one shooting.")
                ]
            }},
            {"WeMissedOopsie_Cull_1", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                playerShotJustMissed = true,
                oncePerCombat = true,
                doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                dialogue = [
                    new(AmCull, "Realign and try again.")
                ]
            }},
            {"WeAreCorroded_Multi_0", new(){
                dialogue = [
                    new(),
                    new(AmCull, "intense", "No wait, stay! I got it.")
                ]
            }},
            {"WeAreCorroded_Multi_1", new(){
                dialogue = [
                    new(),
                    new(AmCull, "Hold on, I got it under control!")
                ]
            }},
            {"WeAreCorroded_Multi_2", new(){
                dialogue = [
                    new(),
                    new(AmCull, "sly", "We can totally fix that in the middle of a fight.")
                ]
            }},
            {"WeAreCorroded_Multi_3", new(){
                dialogue = [
                    new(),
                    new(AmCull, "mad", "Nuh uh.")
                ]
            }},
            {"WeAreCorroded_Multi_4", new(){
                dialogue = [
                    new(),
                    new(AmCull, "squint", "Hush, I'm concentrating.")
                ]
            }},
            {"WeAreCorroded_Multi_5", new(){
                dialogue = [
                    new(),
                    new(AmCull, "explain", "It's all part of the plan.")
                ]
            }},
            {"WeAreCorroded_Multi_6", new(){
                dialogue = [
                    new(),
                    new(AmCull, "mad", "I'm working on it!")
                ]
            }},
            {"WeAreCorroded_Multi_7", new(){
                dialogue = [
                    new(),
                    new(AmCull, "solemn", "Computer, snooze.")
                ]
            }},
            {"WeAreCorroded_Multi_8", new(){
                dialogue = [
                    new(),
                    new(AmCull, "curious", "Uh yes?")
                ]
            }},
            {"TheyGotCorroded_Multi_5", new(){
                dialogue = [
                    new(),
                    new(AmCull, "sly", "Did I do that?")
                ]
            }},
            {"ChunkThreats_Multi_3", new(){
                dialogue = [
                    new(),
                    new(AmCull, "mad", "It's you, the one who's living in my head rent free!")
                ]
            }},
            {"BanditThreats_Multi_0", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "panic", "Uhh I didn't order that.")
                ]
            }},
            {"CrabFacts1_Multi_0", new(){
                edit = [
                    new(EMod.countFromStart, 2, AmCull, "And I haven't had my breakfast today.")
                ]
            }},
            {"CrabFacts2_Multi_0", new(){
                edit = [
                    new(EMod.countFromStart, 2, AmCull, "salavating", "You look very delicious.")
                ]
            }},
            {"CrabFactsAreOverNow_Multi_0", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "readytoeat", "...")
                ]
            }},
            {"DillianShouts", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "solemn", "The feeling's not mutual.")
                ]
            }},
            {"DualNotEnoughDronesShouts_Multi_2", new(){
                edit = [
                    new("9b0ce906", AmCull, "panic", "How did you know I was a robot?")
                ]
            }},
            {"OverheatDrakeFix_Multi_6", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "squint", "Good job. Don't ever do that again."),
                    new(EMod.countFromStart, 1, AmCull, "solemn", "You know, I had the patchkit ready.")
                ]
            }},
            {"OverheatDrakesFault_Multi_9", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "tired", "I'll get the fire extinguisher.")
                ]
            }},
            {"RiderAvast", new(){
                edit = [
                    new(EMod.countFromStart, 2, AmCull, "curious", "A vest?")
                ]
            }},
            {"RiderTiderunnerShouts", new(){
                edit = [
                    new(EMod.countFromStart, 2, AmCull, "squint", "You're not allowed to have it.")
                ]
            }},
            {"SkunkFirstTurnShouts_Multi_0", new(){
                edit = [
                    new(EMod.countFromStart, 2, AmCull, "I'm not an errosion engineer you know.")
                ]
            }},
            {"SogginsEscapeIntent_1", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "tired", "Just get out of here.")
                ]
            }},
            {"SogginsEscapeIntent_3", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "giggle", "Hee hee heeeeeee.")
                ]
            }},
            {"Soggins_Missile_Shout_1", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "mad", "Shoot you with what?")
                ]
            }},
            {"SpikeGetsChatty_Multi_0", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "Here I come.")
                ]
            }},
            {"TookDamageHave2HP_Multi_1", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "mad", "I'm on it!")
                ]
            }},
            {"WeJustGainedHeatAndDrakeIsHere_Multi_0", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "mad", "You're messing up my experiments!")
                ]
            }},
            {"WeAreTarnished_Multi_0", new(){
                type = NodeType.combat,
                oncePerRun = true,
                allPresent = [ AmIsaac ],
                lastTurnPlayerStatuses = [ Tarnished ],
                dialogue = [
                    new(AmIsaac, "panic", "That's not good..."),
                    new(AmCull, "sly", "Oh relax, just don't get hit.")
                ]
            }},
            {"WeAreTarnished_Multi_1", new(){
                type = NodeType.combat,
                oncePerRun = true,
                allPresent = [ AmPeri, AmCull ],
                lastTurnPlayerStatuses = [ Tarnished ],
                dialogue = [
                    new(AmPeri, "mad", "What do you think you're doing?!"),
                    new(AmCull, "silly", "My best!")
                ]
            }},
            {"WeAreTarnished_Multi_2", new(){
                type = NodeType.combat,
                oncePerRun = true,
                allPresent = [ AmPeri ],
                lastTurnPlayerStatuses = [ Tarnished ],
                dialogue = [
                    new(AmPeri, "mad", "We can't afford to get hit now."),
                    new([
                        new(AmCull, "intense", "I'll throw the useless things out the airlock!"),
                        new(AmCull, "sly", "Then don't."),
                        new(AmCull, "Nah, I bet I can patch it right back up.")
                    ])
                ]
            }},
            {"WeAreTarnished_Multi_3", new(){
                type = NodeType.combat,
                oncePerRun = true,
                allPresent = [ AmDrake ],
                lastTurnPlayerStatuses = [ Tarnished ],
                dialogue = [
                    new(AmDrake, "panic", "The heat isn't doing anything.")
                ]
            }},
            {"WeAreTarnished_Multi_4", new(){
                type = NodeType.combat,
                oncePerRun = true,
                allPresent = [ AmDizzy ],
                lastTurnPlayerStatuses = [ Tarnished ],
                dialogue = [
                    new(AmDizzy, "squint", "The ship is falling apart.")
                ]
            }},
            {"WeAreTarnished_Multi_5", new(){
                type = NodeType.combat,
                oncePerRun = true,
                allPresent = [ AmCat ],
                lastTurnPlayerStatuses = [ Tarnished ],
                dialogue = [
                    new(AmCat, "squint", "We need to get away NOW.")
                ]
            }},
            {"TheyGotTarnished_Multi_0", new(){
                type = NodeType.combat,
                oncePerRun = true,
                allPresent = [ AmCull ],
                lastTurnEnemyStatuses = [ Tarnished ],
                dialogue = [
                    new(AmCull, "They're not taking enough damage! Get some headshots!")
                ]
            }},
            {"TheyGotTarnished_Multi_1", new(){
                type = NodeType.combat,
                oncePerRun = true,
                allPresent = [ AmCull ],
                lastTurnEnemyStatuses = [ Tarnished ],
                dialogue = [
                    new(AmCull, "Their hull is weakened, blast 'em!")
                ]
            }},
            {"TheyGotTarnished_Multi_2", new(){
                type = NodeType.combat,
                oncePerRun = true,
                allPresent = [ AmPeri ],
                lastTurnEnemyStatuses = [ Tarnished ],
                dialogue = [
                    new(AmPeri, "My turn!")
                ]
            }},
            {"CullHatesChunk_Multi_0", new(){
                type = NodeType.combat,
                oncePerRun = true,
                allPresent = [ AmCull, "chunk" ],
                lastTurnEnemyStatuses = [ Status.corrode ],
                minTurnsThisCombat = 8,
                dialogue = [
                    new(AmCull, "solemn", "Good riddance.")
                ]
            }},
            {"CullWentMissing_Multi_0", new(){
                type = NodeType.combat,
                allPresent = [ AmPeri ],
                priority = true,
                oncePerRun = true,
                oncePerCombatTags = ["CullWentMissing"],
                lastTurnPlayerStatuses = [MissingCull],
                dialogue = [
                    new(AmPeri, "mad", "Hey, give us back our crew!")
                ]
            }},
            {"CullWentMissing_Multi_1", new(){
                type = NodeType.combat,
                allPresent = [ AmRiggs ],
                priority = true,
                oncePerRun = true,
                oncePerCombatTags = ["CullWentMissing"],
                lastTurnPlayerStatuses = [MissingCull],
                dialogue = [
                    new(AmRiggs, "nervous", "Where did the space snake go?")
                ]
            }},
            {"CullWentMissing_Multi_2", new(){
                type = NodeType.combat,
                allPresent = [ AmDizzy ],
                priority = true,
                oncePerRun = true,
                oncePerCombatTags = ["CullWentMissing"],
                lastTurnPlayerStatuses = [MissingCull],
                dialogue = [
                    new(AmDizzy, "intense", "Cull!")
                ]
            }},
            {"CullWentMissing_Multi_3", new(){
                type = NodeType.combat,
                allPresent = [ AmCat ],
                priority = true,
                oncePerRun = true,
                oncePerCombatTags = ["CullWentMissing"],
                lastTurnPlayerStatuses = [MissingCull],
                dialogue = [
                    new(AmCat, "That's not normal.")
                ]
            }},
            {"CullWentMissing_Multi_4", new(){
                type = NodeType.combat,
                allPresent = [ AmIsaac ],
                priority = true,
                oncePerRun = true,
                oncePerCombatTags = ["CullWentMissing"],
                lastTurnPlayerStatuses = [MissingCull],
                dialogue = [
                    new(AmIsaac, "Ummm...")
                ]
            }},
            {"CullWentMissing_Multi_5", new(){
                type = NodeType.combat,
                allPresent = [ AmDrake ],
                priority = true,
                oncePerRun = true,
                oncePerCombatTags = ["CullWentMissing"],
                lastTurnPlayerStatuses = [MissingCull],
                dialogue = [
                    new(AmDrake, "Hey, I was kidding about turning you into wine. Cull?")
                ]
            }},
            {"CullWentMissing_Multi_6", new(){
                type = NodeType.combat,
                allPresent = [ AmMax ],
                priority = true,
                oncePerRun = true,
                oncePerCombatTags = ["CullWentMissing"],
                lastTurnPlayerStatuses = [MissingCull],
                dialogue = [
                    new(AmMax, "Woah.")
                ]
            }},
            {"CullWentMissing_Multi_7", new(){
                type = NodeType.combat,
                allPresent = [ AmBooks ],
                priority = true,
                oncePerRun = true,
                oncePerCombatTags = ["CullWentMissing"],
                lastTurnPlayerStatuses = [MissingCull],
                dialogue = [
                    new(AmBooks, "Snake lady?")
                ]
            }},
            {"CullJustHit_Multi_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                whoDidThat = AmCullDeck,
                oncePerCombatTags = [ "CullShotAGuy"],
                dialogue = [
                    new(AmCull, "shocked", "Woah! I didn't know I had it in me!")
                ]
            }},
            {"CullJustHit_Multi_1", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                whoDidThat = AmCullDeck,
                oncePerCombatTags = [ "CullShotAGuy"],
                dialogue = [
                    new(AmCull, "solemn", "Aw man, I'm probably getting my certification revoked for this.")
                ]
            }},
            {"CullJustHit_Multi_2", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                playerShotJustHit = true,
                minDamageDealtToEnemyThisAction = 1,
                whoDidThat = AmCullDeck,
                oncePerCombatTags = [ "CullShotAGuy"],
                dialogue = [
                    new(AmCull, "explain", "At least I'm not a doctor. Imagine signing a hypocratic oath.")
                ]
            }},
            {"CullGotPerfect_Multi_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                oncePerRun = true,
                lastTurnPlayerStatuses = [Status.perfectShield],
                dialogue = [
                    new(AmCull, "explain", "Thanks to this new thing, we can safely do reckless behavior."),
                    new([
                        new(AmDizzy, "squint", "I don't think you were the one to come up with this."),
                        new(AmPeri, "mad", "Don't."),
                        new(AmDrake, "Turning up the heat! Don't complain!")
                    ])
                ]
            }},
            {"CullGotBoots_Multi_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                oncePerRun = true,
                lastTurnPlayerStatuses = [Status.hermes],
                dialogue = [
                    new(AmCull, "Boosters boosted!")
                ]
            }},
            {"CullGotBoots_Multi_1", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                oncePerRun = true,
                lastTurnPlayerStatuses = [Status.hermes],
                dialogue = [
                    new(AmCull, "Engines boosted, full throttle!")
                ]
            }},

            // {"", new(){

            //     dialogue = [

            //     ]
            // }},
        });
        LocalDB.DumpStoryToLocalLocale("en", "TheJazMaster.EnemyPack", new Dictionary<string, DialogueMachine>(){
            {"EnemyPack_GooseEscape_Cull_0", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                enemyIntent = "gooseEscape",
                turnStart = true,
                dialogue = [
                    new("Goose", "Honk!"),
                    new(AmCull, "mad", "It's getting away!")
                ]
            }},
            {"EnemyPack_GooseEscape_Cull_1", new(){
                type = NodeType.combat,
                allPresent = [ AmCull ],
                enemyIntent = "gooseEscape",
                turnStart = true,
                dialogue = [
                    new("Goose", "Honk!"),
                    new(AmCull, "sad", "No... I wanted turkey for dinner...")
                ]
            }},
        });

        LocalDB.DumpStoryToLocalLocale("en", "urufudoggo.Weth", new Dictionary<string, DialogueMachine>()
        {
            {"JustPlayedASashaCard_Weth_0", new(){
                dialogue = [
                    new(),
                    new(AmCull, "mad", "In front of me?!")
                ]
            }},
        });
    }
}