using System.Collections.Generic;
using Flipbop.BOAF;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class MemoryDialogueJay 
{
    public MemoryDialogueJay()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {
            //Remove the _PREEMPTIVE from every tag when everything is finished
            {"RunWinWho_Jay_1_PREEMPTIVE", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmJay],
                bg = "BGRunWin",
                lookup = [
                    $"runWin_{AmJay}"
                ],
                dialogue = [
                    new(new Wait{secs = 3}),
                    new (AmCull, "neutral", "Sorry, I'm not gonna reveal any lore for my mod until EVERYTHING is finished!" ),
                    new (AmCull,"neutral","You are just gonna have to wait until then!" )
                ]
            }},
            {"RunWinWho_Jay_2_PREEMPTIVE", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmJay],
                bg = "BGRunWin",
                lookup = [
                    $"runWin_{AmJay}"
                ],
                requiredScenes = [
                    "RunWinWho_Jay_1_PREEMPTIVE"
                ],
                dialogue = [
                    new(new Wait{secs = 3}),
                    new (AmCull, "neutral", "Sorry, I'm not gonna reveal any lore for my mod until EVERYTHING is finished!" ),
                    new (AmCull,"neutral","You are just gonna have to wait until then!" )
                ]
            }},
            {"RunWinWho_Jay_3_PREEMPTIVE", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmJay],
                bg = "BGRunWin",
                lookup = [
                    $"runWin_{AmJay}"
                ],
                requiredScenes = [
                    "RunWinWho_Jay_2_PREEMPTIVE"
                ],
                dialogue = [
                    new(new Wait{secs = 3}),
                    new (AmCull, "neutral", "Sorry, I'm not gonna reveal any lore for my mod until EVERYTHING is finished!" ),
                    new (AmCull,"neutral","You are just gonna have to wait until then!" )
                ]
            }},
            {"Jay_Memory_1", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGRunWin",
                lookup = [
                    "vault",
                    $"vault_{AmJay}"
                ],
                dialogue = [
                    new("T+??? days"),
                    new(new Wait{secs = 2}),
                    new(title: null),
                    new(new Wait{secs = 1 }),
                    new (AmCull, "neutral", "Sorry, I'm not gonna reveal any lore for my mod until EVERYTHING is finished!" ),
                    new (AmCull,"neutral","You are just gonna have to wait until then!" )
                ]
            }},
            {"Jay_Memory_2", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGRunWin",
                lookup = [
                    "vault", $"vault_{AmJay}"
                ],
                requiredScenes = ["Jay_Memory_1_PREEMPTIVE"],
                dialogue = [
                    new("T+??? days"),
                    new(new Wait{secs = 2}),
                    new(title: null),
                    new(new Wait{secs = 2}),
                    new (AmCull, "neutral", "Sorry, I'm not gonna reveal any lore for my mod until EVERYTHING is finished!" ),
                    new (AmCull,"neutral","You are just gonna have to wait until then!" )
                ]
            }},
            {"Jay_Memory_3", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGRunWin",
                lookup = [
                    "vault", $"vault_{AmJay}"
                ],
                requiredScenes = ["Jay_Memory_2_PREEMPTIVE"],
                dialogue = [
                    new (AmCull, "neutral", "Sorry, I'm not gonna reveal any lore for my mod until EVERYTHING is finished!" ),
                    new (AmCull,"neutral","You are just gonna have to wait until then!" )
                ]
            }}
        });
    }
}