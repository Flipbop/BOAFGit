using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class StoryDialogueCenti 
{
    public StoryDialogueCenti()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>(){
            
            {"Centi_Intro_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmCenti ],
                bg = "BGRunStart",
                dialogue = [
                    new(AmCat, "neutral", "Rise and shine! We got things to do- oh, what's this?", true),
                    new(AmCenti, "gameover", "..."),
                    new(AmCat, "squint", "A cyborg? I guess it just needs power.", true),
                    new(AmCenti, "gameover", "BOOTUP SEQUENCE INITIATED."),
                    new(AmCenti, "squint", "...urgh..."),
                    new(AmCat, "neutral", "Hello!", true),
                    new(AmCenti, "squint", "I'm awake? How long has it been?"),
                    new(AmCat, "neutral", "I don't know, I just found you here.", true),
                    new(AmCenti, "squint", "Strange. Name is Centi."),
                    new(AmCat, "neutral", "We've got an enemy ship right outside that you are gonna have to help us deal with.", true),
                    new(AmCenti, "neutral", "Alright, alright..."),
                ]
            }},
            {"Centi_Post_Cicada", new(){
                type = NodeType.@event,
                lookup = [ "after_any" ],
                once = true,
                allPresent = [ AmCenti ],
                requiredScenes = ["Centi_Intro_0"],
                bg = "BGRunStart",
                dialogue = [
                    new(AmCat, "neutral", "Well, that's over.", true),
                    new(AmCenti, "squint", "Does this happen all the time?"),
                    new(AmCat, "neutral", "Pretty much. What are you doing here?", true),
                    new(AmCenti, "neutral", "I went down for a nap and woke up here. I don't know what is going on."),
                    new(AmCenti, "squint", "You mind telling me?"),
                    new(AmCat, "neutral", "Oh! We're kinda stuck in a time loop. Do you happen to have all your memories?", true),
                    new(AmCenti, "squint", "Unfortunately."),
                    new(AmCat, "squint", "That's odd, most people don't.", true),
                    new(AmCenti, "neutral", "What do you mean?"),
                    new(AmCat, "neutral", "Nothing you need to worry about, I'm sure it's nothing.", true),
                    new(AmCenti, "neutral", "If you say so."),
                ]
            }},
            {"Centi_Intro_1", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmCenti ],
                requiredScenes = ["Centi_Intro_0", "Centi_Memory_1"],
                bg = "BGRunStart",
                dialogue = [
                    new(AmCat, "worried", "You died?!", true),
                    new(AmCenti, "sob", "To put it lightly."),
                    new(AmCat, "worried", "And Drake just left you?", true),
                    new(AmCat, "squint", "Wait, that actually seems in character for her.", true),
                    new(AmCenti, "squint", "Kind of. It's complicated. If we could talk to her things could be explained better."),
                    new(AmCat, "neutral", "Well, we can wait for her to show up on the ship, or just find her in a fight.", true),
                    new(AmCenti, "squint", "In combat, preferably. I have some... emotions to get rid of."),
                    new(AmCat, "worried", "Oh...", true),
                ]
            }},
            {"Centi_Pre_Drake", new(){
                type = NodeType.@event,
                lookup = [ "before_eunice" ],
                once = true,
                priority = true,
                allPresent = [ AmCenti ],
                requiredScenes = ["Centi_Intro_1", "Centi_Memory_1"],
                dialogue = [
                    new(AmCenti, "angry", "Eunice!"),
                    new(AmDrake, "nervous", "Centi?!", true),
                    new(AmDrake, "nervous", "It's been a while, hasn't it...?", true),
                    new(AmCenti, "angry", "Sure has."),
                    new(AmDrake, "nervous", "What are you doing here?", true),
                    new(AmCenti, "angry", "You are the reason I am dead. This is your fault."),
                    new(AmDrake, "nervous", "Is it too late to say I'm sorry?", true),
                    new(AmCenti, "worried", "Quite."),
                ]
            }},
            {"Centi_Post_Drake", new(){
                type = NodeType.@event,
                lookup = [ "after_eunice" ],
                once = true,
                allPresent = [ AmCenti ],
                requiredScenes = ["Centi_Pre_Smiff"],
                dialogue = [
                    
                ]
            }},
            {"Centi_Intro_2", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                priority = true,
                allPresent = [ AmCenti ],
                requiredScenes = ["Centi_Intro_1", "Centi_Memory_2"],
                bg = "BGRunStart",
                dialogue = [
                    
                ]
            }},
            {"Centi_Dizzy_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmCenti, AmDizzy ],
                bg = "BGRunStart",
                requiredScenes = [ "Centi_Intro_0", "Centi_Memory_3" ],
                dialogue = [
                   
                ]
            }},
            {"Centi_Isaac_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                bg = "BGRunStart",
                allPresent = [AmCenti, AmIsaac],
                once = true,
                requiredScenes = ["Centi_Intro_0", "Goat_1"],
                dialogue = [
                    
                ]
            }},
            {"Centi_Riggs_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmCenti, AmRiggs ],
                bg = "BGRunStart",
                requiredScenes = [ "Centi_Intro_0", "Centi_Memory_1"],
                dialogue = [
                    
                ]
            }},
            {"Centi_Drake_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                bg = "BGRunStart",
                allPresent = [ AmCenti, AmDrake ],
                requiredScenes = [ "Centi_Post_Smiff", "Centi_Memory_2"],
                dialogue = [
                    
                ]
            }},
            {"Centi_Luna_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmCenti, AmLuna ],
                bg = "BGRunStart",
                requiredScenes = [ "Centi_Intro_0", "Luna_Intro_0_PREEMPTIVE"],
                dialogue = [
                    
                ]
            }},
        });
    }
}