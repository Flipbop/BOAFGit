using System.Collections.Generic;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class MemoryDialogueLuna 
{
    public MemoryDialogueLuna()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {
            {"RunWinWho_Luna_1", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmLuna],
                bg = "BGRunWin",
                lookup = [
                    $"runWin_{AmLuna}"
                ],
                dialogue = [
                    
                ]
            }},
            {"RunWinWho_Luna_2", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmLuna],
                bg = "BGRunWinCustom",
                lookup = [
                    $"runWin_{AmLuna}"
                ],
                requiredScenes = [
                    "RunWinWho_Luna_1"
                ],
                dialogue = [
                    
                ]
            }},
            {"RunWinWho_Luna_3", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmLuna],
                bg = "BGRunWin",
                priority = true,
                lookup = [
                    $"runWin_{AmLuna}"
                ],
                requiredScenes = [
                    "Luna_Post_Smiff", "Luna_Memory_2"
                ],
                dialogue = [
                    
                ]
            }},
            {"Luna_Memory_1", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGLunaWorkshop",
                lookup = [
                    "vault",
                    $"vault_{AmLuna}"
                ],
                dialogue = [
                    
                ]
            }},
            {"Luna_Memory_2", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGLunaWorkshop",
                lookup = [
                    "vault", $"vault_{AmLuna}"
                ],
                requiredScenes = ["Luna_Memory_1"],
                dialogue = [
                    

                ]
            }},
            {"Luna_Memory_3", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGBattleMemory",
                lookup = [
                    "vault", $"vault_{AmLuna}"
                ],
                requiredScenes = ["Luna_Memory_2"],
                dialogue = [
                    
                ]
            }},
            
            {"Luna_Closure", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGBattleMemory",
                lookup = [
                    "after_void"
                ],
                allPresent = [AmLuna, AmCull, AmVoid],
                nonePresent = [/*AmJay, AmCenti, AmEva*/],
                requiredScenes = ["Luna_Memory_3"],
                dialogue = [
                    
                ]
            }},
        });
    }
}