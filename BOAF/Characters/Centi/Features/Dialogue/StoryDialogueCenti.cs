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
            
            {"Centi_Intro_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmCenti ],
                bg = "BGRunStart",
                dialogue = [
                    new(AmCat, "neutral", "Rise and shine! We got things to do- oh, what's this?", true),
                    new(AmCenti, "gameover", "..."),
                    new(AmCat, "squint", "A cyborg? I guess it just needs power.", true),
                    new(AmCenti, "gameover", "BOOTUP SEQUENCE INITIATED..."),
                    new(AmCenti, "squint", "...urgh..."),
                    new(AmCat, "neutral", "Hello!", true),
                    new(AmCenti, "squint", "I'm awake? How long has it been?"),
                    new(AmCat, "neutral", "I don't know, I just found you here.", true),
                    new(AmCenti, "squint", "Strange. Name is Centi."),
                    new(AmCat, "neutral", "We've got an enemy ship right outside that you are gonna have to help us deal with.", true),
                    new(AmCenti, "neutral", "Alright, alright..."),
                ]
            }},
            {"Centi_Post_Cicada_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "after_any" ],
                once = true,
                allPresent = [ AmCenti ],
                requiredScenes = ["Centi_Intro_0_PREEMPTIVE"],
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
            {"Centi_Intro_1_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmCenti ],
                requiredScenes = ["Centi_Intro_0_PREEMPTIVE", "Centi_Memory_1"],
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
            {"Centi_Pre_Drake_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "before_eunice" ],
                once = true,
                priority = true,
                allPresent = [ AmCenti ],
                requiredScenes = ["Centi_Intro_1_PREEMPTIVE", "Centi_Memory_1"],
                dialogue = [
                    new(AmCenti, "angry", "Eunice!"),
                    new(AmDrake, "panic", "Centi?!", true),
                    new(AmDrake, "panic", "It's been a while, hasn't it...?", true),
                    new(AmCenti, "angry", "Sure has."),
                    new(AmDrake, "panic", "What are you doing here?", true),
                    new(AmCenti, "angry", "Unimportant. You are the reason I am dead. This is your fault."),
                    new(AmDrake, "panic", "Is it too late to say I'm sorry?", true),
                    new(AmCenti, "angry", "Quite."),
                ]
            }},
            {"Centi_Post_Drake_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "after_eunice" ],
                once = true,
                allPresent = [ AmCenti ],
                requiredScenes = ["Centi_Pre_Drake_PREEMPTIVE"],
                dialogue = [
                    new(AmCat, "mad", "Are you done?", true),
                    new(AmCenti, "angry", "I am now."),
                    new(AmCat, "mad", "I hope this doesn't become a regular thing.", true),
                    new(AmCat, "mad", "I know she abandoned you but she didn't deserve that!", true),
                    new(AmCenti, "sob", "There is more to the story than that."),
                    new(AmCat, "worried", "What? What else is there?", true),
                    new(AmCenti, "sad", "I'll tell you after the loop."),
                    new (new SetMemoryLevel(){chararcter = ModEntry.Instance.CentiDeck.Deck, level = 2})
                ]
            }},
            {"Centi_Intro_2_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                priority = true,
                allPresent = [ AmCenti ],
                requiredScenes = ["Centi_Intro_1_PREEMPTIVE", "Centi_Memory_2"],
                bg = "BGRunStart",
                dialogue = [
                    new(AmCat, "worried", "She brought you back. And you weren't happy.", true),
                    new(AmCenti, "sad", "To put it lightly, yes."),
                    new(AmCat, "worried", "Why not? She brought you back to life!", true),
                    new(AmCenti, "sob", "This isn't living."),
                    new(AmCenti, "sad", "I have to recharge my batteries every few days. I can no longer eat or drink anything. I can be switched off like a machine."),
                    new(AmCenti, "cry", "I died that day. I never came back."),
                    new(AmCenti, "sad", "I am but a crude copy of what I once was."),
                ]
            }},
            {"Centi_Dizzy_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmCenti, AmDizzy ],
                bg = "BGRunStart",
                requiredScenes = [ "Centi_Intro_0_PREEMPTIVE", "Centi_Memory_3" ],
                dialogue = [
                   
                ]
            }},
            {"Centi_Isaac_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                bg = "BGRunStart",
                allPresent = [AmCenti, AmIsaac],
                once = true,
                requiredScenes = ["Centi_Intro_0_PREEMPTIVE", "Goat_1"],
                dialogue = [
                    
                ]
            }},
            {"Centi_Riggs_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmCenti, AmRiggs ],
                bg = "BGRunStart",
                requiredScenes = [ "Centi_Intro_0_PREEMPTIVE", "Centi_Memory_1"],
                dialogue = [
                    
                ]
            }},
            {"Centi_Drake_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                bg = "BGRunStart",
                allPresent = [ AmCenti, AmDrake ],
                requiredScenes = [ "Centi_Post_Drake_PREEMPTIVE", "Centi_Memory_2"],
                dialogue = [
                    
                ]
            }},
        });
    }
}