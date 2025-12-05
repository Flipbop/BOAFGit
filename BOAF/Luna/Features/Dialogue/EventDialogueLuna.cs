using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using static Flipbop.BOAF.CommonDefinitions;


namespace Flipbop.BOAF;

internal class EventDialogueLuna
{
    public EventDialogueLuna()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>(){
            {$"ChoiceCardRewardOfYourColorChoice_{AmLuna}", new(){
                type = NodeType.@event,
                oncePerRun = true,
                allPresent = [ AmLuna ],
                bg = "BGBootSequence",
                dialogue = [
                    new(AmLuna, "squint", "That felt weird. Too weird."),
                    new(AmCat, "Energy readings are back to normal.")
                ]
            }},
            {"ShopkeeperInfinite_Luna_Multi_0", new(){
                type = NodeType.@event,
                lookup = [ "shopBefore" ],
                bg = "BGShop",
                allPresent = [ AmLuna ],
                dialogue = [
                    new(AmLuna, "neutral", "I love your little drone!"),
                    new(AmShopkeeper, "Thanks!", true),
                    new(new Jump{key = "NewShop"})
                ]
            }},
            {"ShopkeeperInfinite_Luna_Multi_1", new(){
                type = NodeType.@event,
                lookup = [ "shopBefore" ],
                bg = "BGShop",
                allPresent = [ AmLuna ],
                dialogue = [
                    new(AmLuna, "neutral", "Hi Cleo!"),
                    new(AmShopkeeper, "Hey Luna!", true),
                    new(new Jump{key = "NewShop"})
                ]
            }},
            {$"CrystallizedFriendEvent_{AmLuna}", new(){
                type = NodeType.@event,
                oncePerRun = true,
                allPresent = [ AmLuna ],
                bg = "BGCrystalizedFriend",
                dialogue = [
                    new(new Wait{secs = 1.5}),
                    new(AmLuna, "squint", "Huh? Oh, hi everyone.")
                ]
            }},
            {$"LoseCharacterCard_{AmLuna}", new(){
                type = NodeType.@event,
                allPresent = [ AmLuna ],
                oncePerRun = true,
                bg = "BGSupernova",
                dialogue = [
                    new (new Wait {secs = 1.5}),
                    new(AmLuna,  "Doesn't feel the greatest.")
                ]
            }},
            {"CrystallizedFriendEvent", new () {
                    edit = [    
                        new (EMod.countFromStart, 1, AmLuna,  "I'm due for a good nap.")
                    ]
            }},
            {"DraculaTime", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna, "squint", "I don't like this guys vibe...")
                ]
            }},
            {"ForeignCardOffering_After", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna, "neutral", "Couldn't hurt, right?")
                ]
            }},
            {"ForeignCardOffering_Refuse", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna, "squint", "Probably a good idea.")
                ]
            }},
            {"GrandmaShop", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna, "neutral", "Cosmic brownies!")
                ]
            }},
            {"Knight_1", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna, "neutral", "Ooooh, hello little knight!")
                ]
            }},
            {"LoseCharacterCard", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna,"Doesn't feel the greatest.")
                ]
            }},
            {"LoseCharacterCard_No", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna, "nervous", "Did we plan for that?")
                ]
            }},
            {"Sasha_2_Multi_2", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna, "neutral", "Sports!")
                ]
            }},
            {"SogginsEscape_1", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna,  "Nuh-uh.")
                ]
            }},
            {"Soggins_Infinite", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna,  "...")
                ]
            }},
        });
    }
}