using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class StoryDialogueJay 
{
    public StoryDialogueJay()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>(){
            
            {"Jay_Intro_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmJay ],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCat, "Alright everyone, let's get going!", flipped: true),
                    new(AmJay, "squint", "This doesn't look familiar. What's going on?"),
                    new(AmCat, "Oh, you are new here. Hello! We're trapped in a time loop!", flipped: true),
                    new(AmJay, "nervous", "A what?!"),
                    new(AmCat, "A time loop! You don't happen to have your memories do you?", flipped: true),
                    new(AmJay, "squint", "I do, but I don't see how that is relevant."),
                    new(AmCat, "squint", "Oh. That's interesting.", flipped: true),
                ]
            }},
            {"Jay_Post_Cicada", new(){
                type = NodeType.@event,
                lookup = [ "after_any" ],
                once = true,
                allPresent = [ AmJay ],
                requiredScenes = ["Jay_Intro_0"],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCat, "squint","Just how much do you remember? No gaps in your memory?", flipped: true),
                    new(AmJay, "No, I remember everything just fine."),
                    new(AmCat, "squint","Strange. Usually people that show up on this ship are missing key memories.", flipped: true),
                    new(AmCat, "squint","But not you. There must be some reason you are here now.", flipped: true),
                    new(AmJay, "squint", "I can still be of use."),
                ]
            }},
            {"Jay_Intro_1", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmJay ],
                requiredScenes = ["Jay_Intro_0", "Jay_Memory_1"],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCat, "squint", "Judging by the fact that space travel has not been revolutionized recently, it didn't work out?", flipped: true ),
                    new (AmJay,"nervous","You could say that." ),
                    new (AmCat, "neutral", "That \"bat dude\" she mentioned, I think I know who that is.", flipped: true ),
                    new (AmJay,"neutral","Really? I need to talk to him!" ),
                    new (AmCat, "neutral", "No guarantee we see him, but we can try!", flipped: true ),
                ]
            }},
            {"Jay_Pre_Smiff", new(){
                type = NodeType.@event,
                lookup = [ "before_batboy" ],
                once = true,
                priority = true,
                allPresent = [ AmJay ],
                requiredScenes = ["Jay_Intro_1", "Jay_Memory_1"],
                dialogue = [
                    new (AmJay, "squint", "Did you ever sell a piece of a weird ship to some bird girl?" ),
                    new (AmSmiff,"neutral","Yeah, why?", flipped: true),
                    new (AmJay, "angry", "The part was faulty." ),
                    new (AmSmiff,"neutral","Not my problem, that was months ago.", flipped: true ),
                    new (AmJay, "angry", "I'm about to make it your problem." ),
                ]
            }},
            {"Jay_Post_Smiff", new(){
                type = NodeType.@event,
                lookup = [ "after_batboy" ],
                once = true,
                allPresent = [ AmJay ],
                requiredScenes = ["Jay_Pre_Smiff"],
                dialogue = [
                    new (AmCat, "worried","Are you ok?", flipped: true),
                    new(AmJay, "As much as I can be."),
                    new(AmCat, "worried","What was that about, anyways?", flipped: true),
                    new(AmJay, "gameover","..."),
                    new(AmJay, "sad", "I'll tell you after the loop."),
                    new (new SetMemoryLevel(){chararcter = ModEntry.Instance.JayDeck.Deck, level = 2})
                ]
            }},
            {"Jay_Intro_2", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmJay ],
                requiredScenes = ["Jay_Intro_1", "Jay_Memory_2"],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCat, "worried", "Oh, I'm so sorry. That can't have been easy to go through.", flipped: true ),
                    new (AmJay,"sad","It's... alright." ),
                    new (AmJay,"sob","There is nothing you could say that I haven't already told myself." ),
                    new (AmCat, "worried", "Don't talk like that! We're all here for you, you are our friends.", flipped: true ),
                    new (AmJay,"cry","Thanks. It means a lot." ),
                ]
            }},
            {"Jay_Peri_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmJay, AmPeri ],
                bg = "BGRunStart",
                requiredScenes = [ "Jay_Intro_0", "Peri_1", "Jay_Memory_2" ],
                dialogue = [
                    
                ]
            }},
            {"Jay_Isaac_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                bg = "BGRunStart",
                allPresent = [AmJay, AmIsaac],
                once = true,
                priority = true,
                requiredScenes = ["Jay_Intro_0", "Goat_1"],
                dialogue = [
                    
                ]
            }},
            {"Jay_Riggs_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmJay, AmRiggs ],
                bg = "BGRunStart",
                requiredScenes = [ "Jay_Intro_0", "Jay_Memory_2"],
                dialogue = [
                    
                ]
            }},
            {"Jay_Drake_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = ["after_crystal"],
                bg = "BGCrystalNebula",
                once = true,
                allPresent = [ AmJay, AmDrake ],
                requiredScenes = [ "Jay_Intro_0"],
                dialogue = [
                    
                ]
            }}
        });
    }
}