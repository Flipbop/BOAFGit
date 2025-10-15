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
            {"Jay_Intro_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmJay ],
                bg = "BGRunStart",
                dialogue = [
                    new(AmJay, "squint", "This isn't my docking bay..."),
                    new(AmCat, "You're new! What's your name?"),
                    new(AmJay, "The name is Jay. Where am I, exactly?"),
                    new(AmCat, "You're in space, about to be shot down by another ship."),
                    new(AmJay, "nervous", "What?!"),
                    new(AmCat, "Oh yeah, you might want to go help with that."),
                ]
            }},
            {"Jay_Intro_1_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmJay ],
                requiredScenes = ["Jay_Intro_0_PREEMPTIVE", "Jay_Memory_1"],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCull, "neutral", "Sorry, I'm not gonna reveal any lore for my mod until EVERYTHING is finished!" ),
                    new (AmCull,"neutral","You are just gonna have to wait until then!" )
                ]
            }},
            {"Jay_Intro_2_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmJay ],
                requiredScenes = ["Jay_Intro_1_PREEMPTIVE", "Jay_Memory_2"],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCull, "neutral", "Sorry, I'm not gonna reveal any lore for my mod until EVERYTHING is finished!" ),
                    new (AmCull,"neutral","You are just gonna have to wait until then!" )
                ]
            }},
            {"Jay_Peri_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmJay, AmPeri ],
                bg = "BGRunStart",
                requiredScenes = [ "Jay_Intro_0_PREEMPTIVE", "Peri_1", "Jay_Memory_2" ],
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
                requiredScenes = ["Jay_Intro_0_PREEMPTIVE", "Goat_1"],
                dialogue = [
                    
                ]
            }},
            {"Jay_Riggs_0__PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmJay, AmRiggs ],
                bg = "BGRunStart",
                requiredScenes = [ "Jay_Intro_0_PREEMPTIVE", "Jay_Memory_2"],
                dialogue = [
                    
                ]
            }},
            {"Jay_Drake_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = ["after_crystal"],
                bg = "BGCrystalNebula",
                once = true,
                allPresent = [ AmJay, AmDrake ],
                requiredScenes = [ "Jay_Intro_0_PREEMPTIVE"],
                dialogue = [
                    
                ]
            }}
        });
    }
}