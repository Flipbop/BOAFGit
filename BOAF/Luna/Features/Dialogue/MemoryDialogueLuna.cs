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
                bg = "BGBlack",
                lookup = [
                    "vault",
                    $"vault_{AmLuna}"
                ],
                dialogue = [
                    new("T-972 days"),
                    new(new Wait{secs = 2}),
                    new(title: null),
                    new(new Wait{secs = 2}),
                    new (AmLuna, "Close your eyes, I have something to show you."),
                    new (AmKass, "squint", "Okay, but it better not be another frog.", true),
                    new (AmLuna, "It's not! Just stick out your paws and I'll give it to you."),
                    new (AmKass, "closed", "Alright.", true),
                    new (AmKass, "closed", "What's this? A piece of paper?", true),
                    new (AmKass, "squint", "\"We are happy to inform you that you have been accepted to Iridescent Academy.\"", true),
                    new (AmKass, "smile", "What?! That's incredible! This was always your dream!", true),
                    new (AmLuna, "Yup! I'm gonna become a real stardust mage!"),
                    new (AmKass, "When do you leave?", true),
                    new (AmLuna, "In a month."),
                    new (AmLuna, "sad", "I'll miss you. I'll visit as often as I can."),
                    new (AmKass, "Awww, that's sweet.", true),
                    new (AmLuna,"squint", "Are you sure you'll be able to protect the village with me gone?"),
                    new (AmKass, "Luna, we haven't been raided by pirates ever since we started protecting the village together. We'll be fine.", true),
                    new (AmLuna, "sad", "I know but I just worry something is gonna happen without me here to help."),
                    new (AmKass, "Nothing is gonna happen!", true),
                    new (AmKass, "Go learn how to be a stardust mage. The village will be here when you get back. I'll be here when you get back.", true),
                    new (AmLuna, "Okay, love you."),
                    new (AmKass, "smile","Love you too.", true),

                ]
            }},
            {"Luna_Memory_2", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGLunaAcademy",
                lookup = [
                    "vault", $"vault_{AmLuna}"
                ],
                requiredScenes = ["Luna_Memory_1"],
                dialogue = [
                    new("T-433 days"),
                    new(new Wait{secs = 2}),
                    new(title: null),
                    new(new Wait{secs = 2}),

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