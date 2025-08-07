using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;

namespace Flipbop.BOAF;

internal class NewEventDialogue : IRegisterable
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>(){
            {$"ChoiceCardRewardOfYourColorChoice_{AmCull}", new(){
                type = NodeType.@event,
                oncePerRun = true,
                allPresent = [ AmCull ],
                bg = "BGBootSequence",
                dialogue = [
                    new(AmCull, "squint", "Ow... I felt that in my bones."),
                    new(AmCat, "Energy readings are back to normal.")
                ]
            }},
            {"ShopkeeperInfinite_Cull_Multi_0", new(){
                type = NodeType.@event,
                lookup = [ "shopBefore" ],
                bg = "BGShop",
                allPresent = [ AmCull ],
                dialogue = [
                    new(AmShopkeeper, "Howdy", true),
                    new(AmCull, "squint", "Have we met before?"),
                    new(new Jump{key = "NewShop"})
                ]
            }},
            {"ShopkeeperInfinite_Cull_Multi_1", new(){
                type = NodeType.@event,
                lookup = [ "shopBefore" ],
                bg = "BGShop",
                allPresent = [ AmCull ],
                dialogue = [
                    new(AmShopkeeper, "Back again, are we?", true),
                    new(AmCull, "explain", "Yeah, need more material to experiment with."),
                    new(new Jump{key = "NewShop"})
                ]
            }},
            {"ShopkeeperInfinite_Cull_Multi_2", new(){
                type = NodeType.@event,
                lookup = [ "shopBefore" ],
                bg = "BGShop",
                allPresent = [ AmCull ],
                dialogue = [
                    new(AmShopkeeper, "Hey.", true),
                    new(AmCull, "sly", "Hey."),
                    new(new Jump{key = "NewShop"})
                ]
            }},
            {$"CrystallizedFriendEvent_{AmCull}", new(){
                type = NodeType.@event,
                oncePerRun = true,
                allPresent = [ AmCull ],
                bg = "BGCrystalizedFriend",
                dialogue = [
                    new(new Wait{secs = 1.5}),
                    new(AmCull, "sly", "Hey.")
                ]
            }},
            {$"LoseCharacterCard_{AmCull}", new(){
                type = NodeType.@event,
                allPresent = [ AmCull ],
                oncePerRun = true,
                bg = "BGSupernova",
                dialogue = [
                    new(AmCull, "shocked", "My research!")
                ]
            }},
            {"DraculaTime", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "squint", "No, I don't recall any Dracula in my friends list...")
                ]
            }},
            {"AbandonedShipyard_Repaired", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "I helped!")
                ]
            }},
            {"EphemeralCardGift", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "screamB", "AAAAAAAAAAaaaaaaaagh!")
                ]
            }},
            {"ForeignCardOffering_After", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "curious", "What's this?")
                ]
            }},
            {"ForeignCardOffering_Refuse", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "squint", "Get out of my head.")
                ]
            }},
            {"Freeze_1", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "curious", "I wonder what it tastes like?")
                ]
            }},
            {"GrandmaShop", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "salavating", "Kitten.")
                ]
            }},
            {"Knight_1", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "intense", "Such glory!")
                ]
            }},
            {"LoseCharacterCard", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "Abort? Abort!")
                ]
            }},
            {"LoseCharacterCard_No", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "explain", "That wasn't so bad.")
                ]
            }},
            {"Sasha_2_Multi_2", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "sad", "Can't play sports...")
                ]
            }},
            {"SogginsEscape_1", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "knife", "...")
                ]
            }},
            {"Soggins_Infinite", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "tired", "Do we really have to help him?")
                ]
            }},
        });
    }
}