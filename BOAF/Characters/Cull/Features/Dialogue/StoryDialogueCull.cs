using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class StoryDialogueCull 
{
    public StoryDialogueCull()
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
                    new(AmCat, "Alright everyone, wakey wakey!", true),
                    new(AmCull, "gameover", "..."),
                    new(AmCat, "grumpy", "HEY WAKE UP!", true),
                    new(AmCull, "nervous", "AH I'M UP!"),
                    new(AmCull, "squint", "Uh, where am I? And what are you doing here?"),
                    new(AmCat, "Time loop, do you remember anything?", true),
                    new(AmCull, "nervous","Oh right uhhhh..."),
                    new(AmCull, "nervous", "No nope nothing comes to mind, hehe..."),
                    new(AmCat, "Sounds normal, we'll get those memories back soon enough!", true)
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
                    new (AmPeri, "Cull, I was hoping to say I'm sorry when I got the chance.", true ),
                    new (AmCull,"What for?" ),
                    new (AmPeri, "For blowing you up.", true ),
                    new (AmCull,"squint","Oh, that." ),
                    new (AmCull,"It's alright. If you didn't then I would have just blown you up." ),
                    new (AmCull,"Besides, I wouldn't have ever gotten to meet you all if I lived!" ),
                    new (AmPeri,"nap", "That's true, I am pretty great.", true ),
                    new (AmPeri, "Thanks for understanding. Glad you aren't taking your death too hard.", true ),
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
                    new (AmIsaac,"Oh! I'm glad you asked! They are all premade, but I assemble them myself. I just order the parts online.", true ),
                    new (AmCull, "That's cool! Are they easy to modify?" ),
                    new (AmIsaac,"Very easy.", true ),
                    new (AmCull, "I wonder how they would respond to a bit of Soul Energy..." ),
                    new (AmIsaac,"panic","...", true ),
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
                    new (AmRiggs,"neutral","Why's that?", true ),
                    new (AmCull, "I'm only sent to kill those that have died before, so unless you've never died you should be a target." ),
                    new (AmRiggs,"Well I guess I didn't die then.", true ),
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
                    new (AmDrake, "That necromancy you have is some powerful stuff. I bet you would make a great pirate.", true ),
                    new (AmCull,"squint","Piracy isn't my thing. I'm not too fond of stealing what belongs to others." ),
                    new (AmDrake, "squint", "Oh come on! You've taken lives before! What's a little credits compared to that?", true ),
                    new (AmCull,"angry","Hey! The lives I took didn't belong to them, they had already died once before!" ),
                    new (AmDrake, "squint", "And what about yours?", true),
                    new (AmCull, "nervous", "Oh.")
                ]
            }},
            {"Cull_Isaac_Animism_PREEMPTIVE", new(){
                type = NodeType.@event,
                once = true,
                allPresent = [ AmCull, AmIsaac ],
                lookup = ["before_any"],
                requiredScenes = [ "Cull_Intro_0_PREEMPTIVE", "Cull_Isaac_0_PREEMPTIVE"],
                hasArtifactTypes = [typeof(AnimismArtifact)],
                dialogue = [
                    new (AmIsaac, "squint", "How do you plan on getting Soul Energy when an object out there is destroyed?", true ),
                    new (AmCull,"squint","Not sure. I think the objects have souls that can be harvested when they are destroyed."),
                    new (AmIsaac, "panic", "Are you telling me that my drones have souls?!", true),
                    new (AmCull, "nervous", "Oh, I didn't even think about that. I guess they do."),
                    new (AmIsaac, "squint", "I'm not sure how I feel about my drones getting shot down anymore.", true)
                ]
            }},
            {"Cull_Jay_0__PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmCull, AmJay ],
                bg = "BGRunStart",
                requiredScenes = [ "Cull_Intro_0_PREEMPTIVE", "Jay_Intro_0"],
                dialogue = [
                    new (AmJay, "squint", "I've been wondering, Cull, where do you get your magic from?", true),
                    new (AmCull, "Ya know, I've never really thought about. It just kinda comes naturally to me."),
                    new (AmJay, "Really? You don't know? Well it's gotta come from somewhere!", true),
                    new (AmCull, "I imagine it does. I just don't know where. Don't really care to find out, either."),
                    new (AmJay, "Not even a little curious?", true),
                    new (AmCull, "Nope!")
                ]
            }},
            {"Cull_Luna_0__PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmCull, AmLuna ],
                bg = "BGRunStart",
                requiredScenes = [ "Cull_Memory_1", "Luna_Intro_0_PREEMPTIVE"],
                dialogue = [
                    new (AmLuna, "Necromancy was always forbidden in the school I learned magic at.", true), 
                    new (AmLuna, "squint", "I am not entirely sure why.", true),
                    new (AmCull, "It's not exactly a useful or even safe skill for the public to learn."),
                    new (AmLuna, "Then where did you learn it?", true),
                    new (AmCull, "squint", "Oh! I uhhh... \nhmmm..."),
                    new (AmCull, "nervous", "I don't remember."),
                    new (AmLuna, "squint", "How do you not remember something like that?", true),
                    new (AmCull, "I've been alive for so long I don't remember anything before my job.")
                ]
            }},
        });
    }
}