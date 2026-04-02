using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class StoryDialogueLuna 
{
    public StoryDialogueLuna()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>(){
            
            {"Luna_Intro_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmLuna ],
                bg = "BGRunStart",
                dialogue = [
                    
                ]
            }},
            {"Luna_Post_Cicada_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "after_any" ],
                once = true,
                allPresent = [ AmLuna ],
                requiredScenes = ["Luna_Intro_0"],
                bg = "BGRunStart",
                dialogue = [
                    
                ]
            }},
            {"Luna_Intro_1_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmLuna ],
                requiredScenes = ["Luna_Intro_0", "Luna_Memory_1"],
                bg = "BGRunStart",
                dialogue = [
                    
                ]
            }},
            {"Luna_Intro_2_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                priority = true,
                allPresent = [ AmLuna ],
                requiredScenes = ["Luna_Intro_1", "Luna_Memory_2"],
                bg = "BGRunStart",
                dialogue = [
                    
                ]
            }},
            {"Luna_Dizzy_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmLuna, AmDizzy ],
                bg = "BGRunStart",
                requiredScenes = [ "Luna_Intro_0", "Luna_Memory_3" ],
                dialogue = [
                    
                ]
            }},
            {"Luna_Isaac_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                bg = "BGRunStart",
                allPresent = [AmLuna, AmIsaac],
                once = true,
                requiredScenes = ["Luna_Intro_0", "Goat_1"],
                dialogue = [
                    
                ]
            }},
            {"Luna_Riggs_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmLuna, AmRiggs ],
                bg = "BGRunStart",
                requiredScenes = [ "Luna_Intro_0", "Luna_Memory_1"],
                dialogue = [
                    
                ]
            }},
            {"Luna_Drake_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = ["after_crystal"],
                bg = "BGCrystalNebula",
                once = true,
                allPresent = [ AmLuna, AmDrake ],
                requiredScenes = [ "Luna_Post_Smiff", "Luna_Memory_2"],
                dialogue = [
                    
                ]
            }},
            {"Luna_Centi_0_PREEMPTIVE", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmLuna, AmCenti ],
                bg = "BGRunStart",
                requiredScenes = [ "Luna_Intro_0_PREEMPTIVE", "Centi_Intro_0_PREEMPTIVE"],
                dialogue = [
                    new (AmLuna, "Centi, have you noticed your special Cores are loaded with Stardust?"),
                    new (AmCenti, "squint","They are?", true),
                    new (AmLuna,  "One hundred percent."),
                    new (AmCenti,"squint","Does that... mean anything?", true),
                    new (AmLuna, "I can't use it, the Stardust is too densely packed into the core for me to do anything with it."),
                    new (AmLuna,"I just thought it was cool! It's probably where they get all their power from!"),
                    new (AmCenti, "I guess so.", true)
                ]
            }},
        });
    }
}