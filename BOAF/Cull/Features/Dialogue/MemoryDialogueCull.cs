using System.Collections.Generic;
using Flipbop.BOAF;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class MemoryDialogueCull : IRegisterable
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {
            {"RunWinWho_Cull_1", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmCull],
                bg = "BGRunWin",
                lookup = [
                    $"runWin_{AmCull}"
                ],
                dialogue = [
                    new(new Wait{secs = 3}),
                    new (AmCull, "neutral", "Sorry, I'm not gonna reveal any lore for my mod until EVERYTHING is finished!" ),
                    new (AmCull,"neutral","You are just gonna have to wait until then!" )
                ]
            }},
            {"RunWinWho_Cull_2", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmCull],
                bg = "BGRunWin",
                lookup = [
                    $"runWin_{AmCull}"
                ],
                requiredScenes = [
                    "RunWinWho_Cull_1"
                ],
                dialogue = [
                    new(new Wait{secs = 3}),
                    new (AmCull, "neutral", "Sorry, I'm not gonna reveal any lore for my mod until EVERYTHING is finished!" ),
                    new (AmCull,"neutral","You are just gonna have to wait until then!" )
                ]
            }},
            {"RunWinWho_Cull_3", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmCull],
                bg = "BGRunWin",
                lookup = [
                    $"runWin_{AmCull}"
                ],
                requiredScenes = [
                    "RunWinWho_Cull_2"
                ],
                dialogue = [
                    new(new Wait{secs = 3}),
                    new (AmCull, "neutral", "Sorry, I'm not gonna reveal any lore for my mod until EVERYTHING is finished!" ),
                    new (AmCull,"neutral","You are just gonna have to wait until then!" )
                ]
            }},
            {"Cull_Memory_1", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGRunWin",
                lookup = [
                    "vault",
                    $"vault_{AmCull}"
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
            {"Cull_Memory_2", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGRunWin",
                lookup = [
                    "vault", $"vault_{AmCull}"
                ],
                requiredScenes = ["Cull_Memory_1"],
                dialogue = [
                    new("T+??? days"),
                    new(new Wait{secs = 2}),
                    new(title: null),
                    new(new Wait{secs = 2}),
                    new (AmCull, "neutral", "Sorry, I'm not gonna reveal any lore for my mod until EVERYTHING is finished!" ),
                    new (AmCull,"neutral","You are just gonna have to wait until then!" )
                ]
            }},
            {"Cull_Memory_3", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGRunWin",
                lookup = [
                    "vault", $"vault_{AmCull}"
                ],
                requiredScenes = ["Cull_Memory_2"],
                dialogue = [
                    new (AmCull, "neutral", "Sorry, I'm not gonna reveal any lore for my mod until EVERYTHING is finished!" ),
                    new (AmCull,"neutral","You are just gonna have to wait until then!" )
                ]
            }}
        });
    }
}