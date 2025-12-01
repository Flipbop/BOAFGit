using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class StoryDialogueLuna 
{
    public StoryDialogueLuna()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>(){
            
            {"Luna_Intro_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmLuna ],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCat, "Alright everyone, let's get going!", flipped: true),
                    new(AmLuna, "squint", "This doesn't look familiar. What's going on?"),
                    new(AmCat, "Oh, you are new here. Hello! We're trapped in a time loop!", flipped: true),
                    new(AmLuna, "nervous", "A what?!"),
                    new(AmCat, "A time loop! You don't happen to have your memories do you?", flipped: true),
                    new(AmLuna, "squint", "I do, but I don't see how that is relevant."),
                    new(AmCat, "squint", "Oh. That's interesting.", flipped: true),
                ]
            }},
            {"Luna_Post_Cicada", new(){
                type = NodeType.@event,
                lookup = [ "after_any" ],
                once = true,
                allPresent = [ AmLuna ],
                requiredScenes = ["Luna_Intro_0"],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCat, "squint","Just how much do you remember? No gaps in your memory?", flipped: true),
                    new(AmLuna, "No, I remember everything just fine."),
                    new(AmCat, "squint","Strange. Usually people that show up on this ship are missing key memories.", flipped: true),
                    new(AmCat, "squint","But not you. There must be some reason you are here now.", flipped: true),
                    new(AmLuna, "squint", "I can still be of use."),
                ]
            }},
            {"Luna_Intro_1", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmLuna ],
                requiredScenes = ["Luna_Intro_0", "Luna_Memory_1"],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCat, "squint", "Judging by the fact that space travel has not been revolutionized recently, it didn't work out?", flipped: true ),
                    new (AmLuna,"nervous","You could say that." ),
                    new (AmCat, "neutral", "That \"bat dude\" she mentioned, I think I know who that is.", flipped: true ),
                    new (AmLuna,"neutral","Really? I need to talk to him!" ),
                    new (AmCat, "neutral", "No guarantee we see him, but we can try!", flipped: true ),
                ]
            }},
            {"Luna_Pre_Smiff", new(){
                type = NodeType.@event,
                lookup = [ "before_batboy" ],
                once = true,
                priority = true,
                allPresent = [ AmLuna ],
                requiredScenes = ["Luna_Intro_1", "Luna_Memory_1"],
                dialogue = [
                    new (AmLuna, "squint", "Did you ever sell a piece of a weird ship to some bird girl?" ),
                    new (AmSmiff,"neutral","Yeah, why?", flipped: true),
                    new (AmLuna, "angry", "The part was faulty." ),
                    new (AmSmiff,"neutral","Not my problem, that was months ago.", flipped: true ),
                    new (AmLuna, "angry", "I'm about to make it your problem." ),
                ]
            }},
            {"Luna_Post_Smiff", new(){
                type = NodeType.@event,
                lookup = [ "after_batboy" ],
                once = true,
                allPresent = [ AmLuna ],
                requiredScenes = ["Luna_Pre_Smiff"],
                dialogue = [
                    new (AmCat, "worried","Are you ok?", flipped: true),
                    new(AmLuna, "As much as I can be."),
                    new(AmCat, "worried","What was that about, anyways?", flipped: true),
                    new(AmLuna, "gameover","..."),
                    new(AmLuna, "sad", "I'll tell you after the loop."),
                    new (new SetMemoryLevel(){chararcter = ModEntry.Instance.LunaDeck.Deck, level = 2})
                ]
            }},
            {"Luna_Intro_2", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                priority = true,
                allPresent = [ AmLuna ],
                requiredScenes = ["Luna_Intro_1", "Luna_Memory_2"],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCat, "worried", "Oh, I'm so sorry. That can't have been easy to go through.", flipped: true ),
                    new (AmLuna,"sad","It's... alright." ),
                    new (AmLuna,"sob","There is nothing you could say that I haven't already told myself." ),
                    new (AmCat, "worried", "Don't talk like that! We're all here for you, you are our friend.", flipped: true ),
                    new (AmLuna,"tear","Thanks. It means a lot." ),
                ]
            }},
            {"Luna_Dizzy_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmLuna, AmDizzy ],
                bg = "BGRunStart",
                requiredScenes = [ "Luna_Intro_0", "Luna_Memory_3" ],
                dialogue = [
                    new (AmDizzy, "Do you remember what kind of part your sister bought off Smiff?", true),
                    new (AmLuna, "squint", "Yeah, it was some sort of crystal like thing. I don't remember exactly. It was destroyed in the blast."),
                    new (AmDizzy, "crystal", "Like this?", true), 
                    new (AmLuna, "nervous", "Where did you get that?!"),
                    new (AmDizzy, "crystal", "These things are everywhere. They last between each loop, so everytime we turn the big crystal to dust some more get scattered about.", true),
                    new (AmDizzy, "crystal", "They have some weird time-warping properties, if my tests are to be believed.", true), 
                    new (AmLuna, "squint", "I guess that would make for some fast engines..."),
                ]
            }},
            {"Luna_Isaac_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                bg = "BGRunStart",
                allPresent = [AmLuna, AmIsaac],
                once = true,
                requiredScenes = ["Luna_Intro_0", "Goat_1"],
                dialogue = [
                    new (AmIsaac, "Hey Luna, I was wondering what you are doing to manipulate the ships we pilot.", true),
                    new (AmLuna, "It's quite simple really! I use microscopic nanomachines to deconstruct and reconstruct the ship in a few seconds."),
                    new (AmIsaac, "Nanomachines? I thought those didn't exist yet.", true),
                    new (AmLuna, "I just recently developed them myself. They are still in the prototype phase, not to be released to the public."),
                    new (AmLuna, "They can be quite dangerous in the wrong hands!"),
                    new (AmIsaac, "panic","They can?!", true)
                ]
            }},
            {"Luna_Riggs_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmLuna, AmRiggs ],
                bg = "BGRunStart",
                requiredScenes = [ "Luna_Intro_0", "Luna_Memory_1"],
                dialogue = [
                    new (AmRiggs, "What were you working on with your sister?", true),
                    new (AmLuna, "It was a prototype lightspeed engine. Small enough to fit on a single-person craft."),
                    new (AmRiggs, "Whoa! That's so cool! Why did you stop?", true),
                    new (AmLuna, "nervous", "It... uh... didn't work."),
                    new (AmRiggs, "Awww, that sucks. I would have loved to pilot a ship with it.", true)
                ]
            }},
            {"Luna_Drake_0", new(){
                type = NodeType.@event,
                lookup = ["after_crystal"],
                bg = "BGCrystalNebula",
                once = true,
                allPresent = [ AmLuna, AmDrake ],
                requiredScenes = [ "Luna_Post_Smiff", "Luna_Memory_2"],
                dialogue = [
                    new (AmDrake, "squint","What kinda beef you got with Smiff?", true),
                    new (AmLuna, "angry", "He is the reason my sister is dead."),
                    new (AmDrake, "squint","Really? THAT guy? He's harmless. How would he even do that?", true),
                    new (AmLuna, "angry", "He sold her a faulty part that ended up causing a critical failure in an engine, causing an explosion that killed her."),
                    new (AmDrake, "nervous", "Oh.", true)
                ]
            }}
        });
    }
}