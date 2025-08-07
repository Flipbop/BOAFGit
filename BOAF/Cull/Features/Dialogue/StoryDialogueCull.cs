using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class StoryDialogueCull : IRegisterable
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
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
                requiredScenes = [ "Cull_Intro_0_PREEMPTIVE", "Peri_1" ],
                dialogue = [
                    new (AmCull, "squint", "Ok this time it's not cause I'm hiding anything, but because I haven't written any dialogue for Peri yet." ),
                    new (AmCull,"neutral","You are just gonna have to wait as usual!" )
                ]
            }},
            {"Cull_Isaac_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = ["after_crystal"],
                bg = "BGCrystalNebula",
                allPresent = [AmCull, AmIsaac],
                once = true,
                priority = true,
                requiredScenes = ["Cull_Intro_0_PREEMPTIVE"],
                dialogue = [
                    new (AmCull, "squint", "Ok this time it's not cause I'm hiding anything, but because I haven't written any dialogue for Isaac yet." ),
                    new (AmCull,"neutral","You are just gonna have to wait as usual!" )
                ]
            }},
            {"Cull_Riggs_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmCull, AmRiggs ],
                bg = "BGRunStart",
                requiredScenes = [ "Cull_Intro_0_PREEMPTIVE"],
                dialogue = [
                    new (AmCull, "squint", "Ok this time it's not cause I'm hiding anything, but because I haven't written any dialogue for Riggs yet." ),
                    new (AmCull,"neutral","You are just gonna have to wait as usual!" )
                ]
            }},
            {"Cull_Drake_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmCull, AmDrake ],
                bg = "BGRunStart",
                requiredScenes = [ "Cull_Intro_0_PREEMPTIVE"],
                dialogue = [
                    new (AmCull, "squint", "Ok this time it's not cause I'm hiding anything, but because I haven't written any dialogue for Drake yet." ),
                    new (AmCull,"neutral","You are just gonna have to wait as usual!" )
                ]
            }}
        });
    }
}