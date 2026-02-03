using System.Collections.Generic;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class MemoryDialogueCenti 
{
    public MemoryDialogueCenti()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {
            {"RunWinWho_Centi_1", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmCenti],
                bg = "BGRunWin",
                lookup = [
                    $"runWin_{AmCenti}"
                ],
                dialogue = [
                    
                ]
            }},
            {"RunWinWho_Centi_2", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmCenti],
                bg = "BGRunWinCustom",
                lookup = [
                    $"runWin_{AmCenti}"
                ],
                requiredScenes = [
                    "RunWinWho_Centi_1"
                ],
                dialogue = [
                    
                ]
            }},
            {"RunWinWho_Centi_3", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmCenti],
                bg = "BGRunWin",
                priority = true,
                lookup = [
                    $"runWin_{AmCenti}"
                ],
                requiredScenes = [
                    "Centi_Post_Smiff", "Centi_Memory_2"
                ],
                dialogue = [
                    
                ]
            }},
            {"Centi_Memory_1", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGCentiWorkshop",
                lookup = [
                    "vault",
                    $"vault_{AmCenti}"
                ],
                dialogue = [
                    
                ]
            }},
            {"Centi_Memory_2", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGCentiWorkshop",
                lookup = [
                    "vault", $"vault_{AmCenti}"
                ],
                requiredScenes = ["Centi_Memory_1"],
                dialogue = [
                   

                ]
            }},
            {"Centi_Memory_3", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGBattleMemory",
                lookup = [
                    "vault", $"vault_{AmCenti}"
                ],
                requiredScenes = ["Centi_Memory_2"],
                dialogue = [
                    
                ]
            }},
            {"Anger_Power_Up", new(){
                type = NodeType.@event,
                allPresent = [AmCenti, AmCull],
                nonePresent = [AmLuna, /*AmCenti, AmEva*/],
                dialogue = [
                    new (AmCenti, "nervous", "Did it just power up?!" ),
                    new (AmCull,"angry","I told you this would be no easy battle! Stand your ground!" ),
                ]
            }},
            {"Anger_Callout_Multi_0", new(){
                type = NodeType.combat,
                allPresent = [AmCenti, AmCull, AmVoid],
                nonePresent = [AmLuna, /*AmCenti, AmEva*/],
                dialogue = [
                    new (AmVoid, "1'M AB0UT TO MA??KE IT\n<c=part>YOUR PROBLEM.</c>" ),
                    new (AmCenti, "sob", "...")

                ]
            }},
            {"Anger_Callout_Multi_1", new(){
                type = NodeType.combat,
                allPresent = [AmCenti, AmCull, AmVoid],
                nonePresent = [AmLuna, /*AmCenti, AmEva*/],
                dialogue = [
                    new (AmVoid, "THAT'S N??0T <c=part>THE POINT.</c>" ),
                    new (AmCenti, "sad", "...")
                ]
            }},
            {"Anger_Callout_Multi_2", new(){
                type = NodeType.combat,
                allPresent = [AmCenti, AmCull, AmVoid],
                nonePresent = [AmLuna, /*AmCenti, AmEva*/],
                dialogue = [
                    new (AmVoid, "1S TH??AT IT? AM 1 <c=part>\"WHOLE\"</c> N0W?" ),
                    new (AmCenti, "tear", "...")

                ]
            }},
            {"Centi_Closure", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGBattleMemory",
                lookup = [
                    "after_void"
                ],
                allPresent = [AmCenti, AmCull, AmVoid],
                nonePresent = [AmLuna, /*AmCenti, AmEva*/],
                requiredScenes = ["Centi_Memory_3"],
                dialogue = [
                    
                ]
            }},
        });
    }
}