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
            
            //Remove the _PREEMPTIVE from every tag when everything is finished
            {"Cull_Intro_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmCull ],
                bg = "BGRunStart",
                dialogue = [
                    new(AmCat, "Alright everyone, wakey wakey!"),
                    new(AmCull, "gameover", "..."),
                    new(AmCat, "grumpy", "HEY WAKE UP!"),
                    new(AmCull, "nervous", "AH I'M UP!"),
                    new(AmCull, "squint", "Uh, where am I? And what are you doing here?"),
                    new(AmCat, "Time loop, do you remember anything?"),
                    new(AmCull, "nervous","Oh right uhhhh..."),
                    new(AmCull, "nervous", "No nope nothing comes to mind hehe..."),
                    new(AmCat, "Sounds normal, we'll get those memories back soon enough!")
                ]
            }},
            {"Cull_Intro_1_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmCull ],
                requiredScenes = ["Cull_Intro_0_PREEMPTIVE", "Cull_Memory_1"],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCull, "neutral", "Sorry, I'm not gonna reveal any lore for my mod until EVERYTHING is finished!" ),
                    new (AmCull,"neutral","You are just gonna have to wait until then!" )
                ]
            }},
            {"Cull_Intro_2_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmCull ],
                requiredScenes = ["Cull_Intro_1_PREEMPTIVE", "Cull_Memory_2"],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCull, "neutral", "Sorry, I'm not gonna reveal any lore for my mod until EVERYTHING is finished!" ),
                    new (AmCull,"neutral","You are just gonna have to wait until then!" )
                ]
            }},
            {"Cull_Peri_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmCull, AmPeri ],
                bg = "BGRunStart",
                requiredScenes = [ "Cull_Intro_0_PREEMPTIVE", "Peri_1", "Cull_Memory_2" ],
                dialogue = [
                    new (AmPeri, "Cull, I was hoping to say I'm sorry when I got the chance." ),
                    new (AmCull,"What for?" ),
                    new (AmPeri, "For blowing you up." ),
                    new (AmCull,"squint","Oh, that." ),
                    new (AmCull,"It's alright. If you didn't then I would have just blown you up." ),
                    new (AmCull,"Besides, I wouldn't have ever gotten to meet you all if I lived!" ),
                    new (AmPeri,"nap", "That's true, I am pretty great." ),
                    new (AmPeri, "Thanks for understanding. Glad you aren't taking your death too hard." ),
                    new (AmCull, "Of course!"),
                    new (AmCull, "sad", "..."),
                    new (AmCull, "sad", "...of course."),
                ]
            }},
            {"Cull_Isaac_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                bg = "BGRunStart",
                allPresent = [AmCull, AmIsaac],
                once = true,
                priority = true,
                requiredScenes = ["Cull_Intro_0_PREEMPTIVE", "Goat_1"],
                dialogue = [
                    new (AmCull, "I was wondering how you make your drones, it might come in handy one day for me." ),
                    new (AmIsaac,"Oh! I'm glad you asked! They are all premade, but I assemble them myself. I just order the parts online." ),
                    new (AmCull, "That's cool! Are they easy to modify?" ),
                    new (AmIsaac,"Very easy." ),
                    new (AmCull, "I wonder how they would respond to a bit of Soul Energy..." ),
                    new (AmIsaac,"panic","..." ),
                ]
            }},
            {"Cull_Riggs_0__PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmCull, AmRiggs ],
                bg = "BGRunStart",
                requiredScenes = [ "Cull_Intro_0_PREEMPTIVE", "Cull_Memory_2"],
                dialogue = [
                    new (AmCull, "squint", "Now that I think about it, you were never one of the targets I was sent to kill." ),
                    new (AmRiggs,"neutral","Why's that?" ),
                    new (AmCull, "I'm only sent to kill those that have died before, so unless you've never died you should be a target." ),
                    new (AmRiggs,"Well I guess I didn't die then." ),
                    new (AmCull, "squint", "Strange. You aren't even in my database now that I look closer. Like you ceased to exist." ),
                ]
            }},
            {"Cull_Drake_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = ["after_crystal"],
                bg = "BGCrystalNebula",
                once = true,
                allPresent = [ AmCull, AmDrake ],
                requiredScenes = [ "Cull_Intro_0_PREEMPTIVE"],
                dialogue = [
                    new (AmDrake, "That necromancy you have is some powerful stuff. I bet you would make a great pirate." ),
                    new (AmCull,"squint","Piracy isn't my thing. I'm not too fond of stealing what belongs to others." ),
                    new (AmDrake, "squint", "Oh come on! You've taken lives before! What's a little credits compared to that?" ),
                    new (AmCull,"angry","Hey! The lives I took didn't belong to them, they had already died once before!" ),
                    new (AmDrake, "squint", "And what about yours?"),
                    new (AmCull, "nervous", "Oh.")
                ]
            }},
            {"Cull_Isaac_Animism_PREEMPTIVE", new(){
                type = NodeType.@event,
                once = true,
                allPresent = [ AmCull, AmIsaac ],
                requiredScenes = [ "Cull_Intro_0_PREEMPTIVE", "Cull_Isaac_0_PREEMPTIVE"],
                hasArtifactTypes = [typeof(AnimismArtifact)],
                dialogue = [
                    new (AmIsaac, "squint", "How do you plan on getting Soul Energy when an object out there is destroyed?" ),
                    new (AmCull,"squint","Not sure. I think the objects have souls that can be harvested when they are destroyed."),
                    new (AmIsaac, "panic", "Are you telling me that my drones have souls?!"),
                    new (AmCull, "nervous", "Oh, I didn't even think about that. I guess they do."),
                    new (AmIsaac, "squint", "I'm not sure how I feel about my drones getting shot down anymore.")
                ]
            }}
        });
    }
}