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
                    new(AmLuna, "squint", "Nope. Don't like that."),
                    new(AmCat, "Energy readings are back to normal.")
                ]
            }},
            {"ShopkeeperInfinite_Luna_Multi_0", new(){
                type = NodeType.@event,
                lookup = [ "shopBefore" ],
                bg = "BGShop",
                allPresent = [ AmLuna ],
                dialogue = [
                    new(AmLuna, "neutral", "Cool ship!"),
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
                    new(AmLuna, "neutral", "Where do you get all the parts for repairs?"),
                    new(AmShopkeeper, "That's classified.", true),
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
                    new(AmCull, "squint", "Again? Alright...")
                ]
            }},
            {$"LoseCharacterCard_{AmLuna}", new(){
                type = NodeType.@event,
                allPresent = [ AmLuna ],
                oncePerRun = true,
                bg = "BGSupernova",
                dialogue = [
                    new(AmCull,  "At least the ship is ok.")
                ]
            }},
            {"CrystallizedFriendEvent", new () {
                    edit = [    
                        new (EMod.countFromStart, 1, AmLuna,  "If I'm going, make sure the ship stays intact.")
                    ]
            }},
            {"DraculaTime", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna, "squint", "I don't recall meeting any Draculas before.")
                ]
            }},
            {"ForeignCardOffering_After", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna, "neutral", "I don't see why not.")
                ]
            }},
            {"ForeignCardOffering_Refuse", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna, "squint", "Maybe best if we don't.")
                ]
            }},
            {"GrandmaShop", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna, "neutral", "Do you have any peanuts?")
                ]
            }},
            {"Knight_1", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna, "neutral", "What an interesting ship. Sure isn't my design.")
                ]
            }},
            {"LoseCharacterCard", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna,"Better than hull damage.")
                ]
            }},
            {"LoseCharacterCard_No", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna, "angry", "Not a fan of the hull getting damaged so severely.")
                ]
            }},
            {"Sasha_2_Multi_2", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna, "neutral", "I'm up for a game.")
                ]
            }},
            {"SogginsEscape_1", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna, "angry", "Not on my watch.")
                ]
            }},
            {"Soggins_Infinite", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmLuna, "squint", "This frog annoys me.")
                ]
            }},
        });
    }
}