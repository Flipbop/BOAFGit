using System.Collections.Generic;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class MemoryDialogueCenti 
{
    public MemoryDialogueCenti()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {
            {"RunWinWho_Jay_1", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmJay],
                bg = "BGRunWin",
                lookup = [
                    $"runWin_{AmJay}"
                ],
                dialogue = [
                    
                ]
            }},
            {"RunWinWho_Jay_2", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmJay],
                bg = "BGRunWinCustom",
                lookup = [
                    $"runWin_{AmJay}"
                ],
                requiredScenes = [
                    "RunWinWho_Jay_1"
                ],
                dialogue = [
                    
                ]
            }},
            {"RunWinWho_Jay_3", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmJay],
                bg = "BGRunWin",
                priority = true,
                lookup = [
                    $"runWin_{AmJay}"
                ],
                requiredScenes = [
                    "Jay_Post_Smiff", "Jay_Memory_2"
                ],
                dialogue = [
                    
                ]
            }},
            {"Jay_Memory_1", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGJayWorkshop",
                lookup = [
                    "vault",
                    $"vault_{AmJay}"
                ],
                dialogue = [
                    
                ]
            }},
            {"Jay_Memory_2", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGJayWorkshop",
                lookup = [
                    "vault", $"vault_{AmJay}"
                ],
                requiredScenes = ["Jay_Memory_1"],
                dialogue = [
                   

                ]
            }},
            {"Jay_Memory_3", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGBattleMemory",
                lookup = [
                    "vault", $"vault_{AmJay}"
                ],
                requiredScenes = ["Jay_Memory_2"],
                dialogue = [
                    
                ]
            }},
            {"Anger_Power_Up", new(){
                type = NodeType.@event,
                allPresent = [AmJay, AmCull],
                nonePresent = [AmLuna, /*AmCenti, AmEva*/],
                dialogue = [
                    new (AmJay, "nervous", "Did it just power up?!" ),
                    new (AmCull,"angry","I told you this would be no easy battle! Stand your ground!" ),
                ]
            }},
            {"Anger_Callout_Multi_0", new(){
                type = NodeType.combat,
                allPresent = [AmJay, AmCull, AmVoid],
                nonePresent = [AmLuna, /*AmCenti, AmEva*/],
                dialogue = [
                    new (AmVoid, "1'M AB0UT TO MA??KE IT\n<c=part>YOUR PROBLEM.</c>" ),
                    new (AmJay, "sob", "...")

                ]
            }},
            {"Anger_Callout_Multi_1", new(){
                type = NodeType.combat,
                allPresent = [AmJay, AmCull, AmVoid],
                nonePresent = [AmLuna, /*AmCenti, AmEva*/],
                dialogue = [
                    new (AmVoid, "THAT'S N??0T <c=part>THE POINT.</c>" ),
                    new (AmJay, "sad", "...")
                ]
            }},
            {"Anger_Callout_Multi_2", new(){
                type = NodeType.combat,
                allPresent = [AmJay, AmCull, AmVoid],
                nonePresent = [AmLuna, /*AmCenti, AmEva*/],
                dialogue = [
                    new (AmVoid, "1S TH??AT IT? AM 1 <c=part>\"WHOLE\"</c> N0W?" ),
                    new (AmJay, "tear", "...")

                ]
            }},
            {"Jay_Closure", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGBattleMemory",
                lookup = [
                    "after_void"
                ],
                allPresent = [AmJay, AmCull, AmVoid],
                nonePresent = [AmLuna, /*AmCenti, AmEva*/],
                requiredScenes = ["Jay_Memory_3"],
                dialogue = [
                    
                ]
            }},
        });
    }
}