using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using static Flipbop.BOAF.CommonDefinitions;


namespace Flipbop.BOAF;

internal class CardDialogueLuna
{
    public CardDialogueLuna()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {
            {
                "CATsummonedLunaCard_Multi_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [AmCat],
                    lookup = ["summonLuna"],
                    oncePerCombatTags = ["summonLunaTag"],
                    dialogue =
                    [
                        new(AmCat, "I feel more in-tune with the ship.")
                    ]
                }
            },
            {
                "CATsummonedLunaCard_Multi_1", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [AmCat, AmLuna],
                    lookup = ["summonLuna"],
                    oncePerCombatTags = ["summonLunaTag"],
                    dialogue =
                    [
                        new(AmCat, "My turn to screw with the ship's layout."),
                        new(AmLuna,  "Have fun!")
                    ]
                }
            },
        });
    }
}