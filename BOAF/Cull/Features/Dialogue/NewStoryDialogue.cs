using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;

namespace Flipbop.BOAF;

internal class NewStoryDialogue : IRegisterable
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>(){
            {"Cull_Intro_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmCull ],
                bg = "BGRunStart",
                dialogue = [
                    new(AmCat, "Wakey wakey!"),
                    new(AmCull, "tired", "Hey... That's my line..."),
                    new(AmCull, "solemn", "..."),
                    new(AmCull, "squint", "This isn't my ship."),
                    new(AmCat, "squint", "Who are you?"),
                    new(AmCull, "squint", "Can't say..."),
                    new(AmCull, "But! I can make use of all this unutilized hull you got."),
                    new(AmCat, "worried", "What! We need that!"),
                    new(AmCull, "sly", "Don't worry, you won't even notice it's gone.")
                ]
            }},
            {"Cull_Intro_1", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmCull ],
                requiredScenes = ["Cull_Intro_0"],
                bg = "BGRunStart",
                dialogue = [
                    new(AmCat, "Beep beep!"),
                    new(AmCull, "tired", "I'm up..."),
                    new(AmCull, "squint", "..."),
                    new(AmCull, "curious", "What's with all this padding on the wall?"),
                    new(AmCat, "smug", "It's to stop you from destroying anything."),
                    new(AmCull, "silly", "Oh really? Is that a challenge?"),
                    new(AmCat, "worried", "What? No?"),
                    new(AmCat, "lean", "Hey! Get back here!")
                ]
            }},
            {"Cull_Intro_2", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmCull ],
                requiredScenes = ["Cull_Intro_1"],
                bg = "BGRunStart",
                dialogue = [
                    new(AmCat, "squint", "..."),
                    new(AmCull, "nap", "..."),
                    new(AmCat, "mad", "Wake up!"),
                    new(AmCull, "shocked", "AAH!"),
                    new(AmCull, "intense", "Oh hello."),
                    new(AmCat, "grumpy", "You better not touch anything."),
                    new(AmCull, "curious", "..."),
                    new(AmCat, "grumpy", "I realized there's no stopping you, no matter what I try."),
                    new(AmCat, "grumpy", "So I'm just going to tell you to not do what you usually do."),
                    new(AmCull, "But if I don't do anything, how would I know I'm doing what I usually do?"),
                    new(AmCat, "squint", "Good point..."),
                    new(AmCull, "explain", "So I'll touch something and see if that's part of my usual routine."),
                    new(AmCat, "Alright, go ahead then."),
                    new(AmCat, "squint", "..."),
                    new(AmCat, "mad", "Wait wh- HEY!")
                ]
            }},
            {"Cull_Peri_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmCull, AmPeri ],
                bg = "BGRunStart",
                requiredScenes = [ "Cull_Intro_0", "Peri_1" ],
                dialogue = [
                    new(AmPeri, "Cull? Can I ask you something?"),
                    new(AmCull, "What is it?", true),
                    new(AmPeri, "On your file, your photo ID looks nothing like you."),
                    new(AmCull, "squint", "Maybe the lighting wasn't good.", true),
                    new(AmPeri, "squint", "Your eyes are different."),
                    new(AmCull, "intense", "Maybe the lighting was different.", true),
                    new(AmPeri, "squint", "..."),
                    new(AmCull, "silly", "...", true),
                    new(AmPeri, "squint", "I guess you look similar enough...")
                ]
            }},
            {"Cull_Peri_1", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmCull, AmPeri ],
                bg = "BGRunStart",
                requiredScenes = [ "Cull_Peri_0", "RunWinWho_Cull_3" ],
                dialogue = [    
                    new(AmPeri, "Cull was it? Can I ask you something?"),
                    new(AmCull, "Go ahead.", true),
                    new(AmPeri, "squint", "I have your file here, and your picture looks different..."),
                    new(AmCull, "possessed", "So you found out.", true),
                    new(AmPeri, "What?"),
                    new(AmCull, "Hmm?", true),
                    new(AmPeri, "Say again?"),
                    new(AmCull, "explain", "I said it might be because that photo might've been sunbleached.", true),
                    new(AmPeri, "squint", "Doesn't that make the photo lighter?"),
                    new(AmCull, "Or something. Look, is this really that important?", true),
                    new(AmPeri, "squint", "..."),
                    new(AmPeri, "squint", "Just curious.")
                ]
            }},
            {"Cull_Isaac_0", new(){
                type = NodeType.@event,
                lookup = ["after_crystal"],
                bg = "BGCrystalNebula",
                allPresent = [AmCull, AmIsaac],
                once = true,
                priority = true,
                requiredScenes = ["Cull_Intro_0"],
                dialogue = [
                    new(AmIsaac, "Hey Cull."),
                    new(AmCull, "Sup?", true),
                    new(AmIsaac, "Mind if I ask something personal?"),
                    new(AmCull, "Depends.", true),
                    new(AmIsaac, "explains", "I've read in a magazine somewhere that snakes see with their tongue."),
                    new(AmIsaac, "But I haven't seen you do that throughout our journey."),
                    new(AmCull, "Ah that?", true),
                    new(AmCull, "explain", "That's because I'm mostly a robot inside.", true),
                    new(AmCull, "giggle", "See?", true),
                    new(AmCull, "Oh also I don't have a tongue.", true),
                    new(AmIsaac, "writing", "I see, so you're not actually a biological snake... how do you taste things?"),
                    new(AmCull, "explain", "I use my nose.", true),
                    new(AmIsaac, "writing", "Do you NEED to eat? Is there a charging port on you somewhere?"),
                    new(AmCull, "squint", "I think I have one on my back? I THINK I can recharge myself I guess? Never tried it.", true),
                    new(AmIsaac, "writing", "Do you have a brain or a hard disk?"),
                    new(AmCull, "intense", "Uhhhhh ummm... The latter?", true),
                    new(AmIsaac, "writing", "Did you digitalize your mind? Are you an AI?"),
                    new(AmCull, "panic", "...", true),
                    new(AmCull, "shocked", "...", true),
                    new(AmCull, "intense", "Actually, can we forget that this conversation ever happened?", true),
                    new(AmIsaac, "Okay.")
                ]
            }},
            {"Cull_Riggs_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmCull, AmRiggs ],
                bg = "BGRunStart",
                requiredScenes = [ "Cull_Intro_0"],
                dialogue = [
                    new(AmRiggs, "..."),
                    new(AmCull, "...", true),
                    new(AmRiggs, "serious", "..."),
                    new(AmCull, "...", true),
                    new(AmRiggs, "squint", "..."),
                    new(AmCull, "...", true),
                    new(AmRiggs, "squint", "Umm, can I help you?"),
                    new(AmCull, "Oh! Don't mind me, pretend I'm not here.", true),
                    new(AmRiggs, "squint", "It's a little difficult with you looking over my shoulder..."),
                    new(AmCull, "Let me observe you a bit more, then I'll be out of your fur.", true),
                    new(AmRiggs, "serious", "What is this for?"),
                    new(AmCull, "Figuring out how best to overclock the thrusters.", true),
                    new(AmRiggs, "squint", "And this helps how?"),
                    new(AmCull, "silly", "I don't know, but it's fun to look at.", true),
                    new(AmRiggs, "huh", "...")
                ]
            }},
            {"Cull_Drake_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmCull, AmDrake ],
                bg = "BGRunStart",
                requiredScenes = [ "Cull_Intro_0"],
                dialogue = [
                    new(AmDrake, "squint", "..."),
                    new(AmCull, "curious", "...", true),
                    new(AmDrake, "squint", "..."),
                    new(AmCull, "Why are you staring at me like that?", true),
                    new(AmDrake, "squint", "I'm trying to figure out how to get a jar your size."),
                    new(AmCull, "intense", "... why?", true),
                    new(AmDrake, "blush", "I heard snake rum is delicious."),
                    new(AmCull, "unamused", "You do know making something like that takes ages, right?", true),
                    new(AmDrake, "slyblush", "I can wait."),
                    new(AmCull, "squint", "Don't you dare.", true)
                ]
            }}
        });
    }
}