using System.Collections.Generic;
using Flipbop.BOAF;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class NewMemoryDialogue : IRegisterable
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
                    new(AmCull, "solemn", "..."),
                    new(AmVoid, "...", true),
                    new(AmCull, "unamused", "So?"),
                    new(AmVoid, "You don't belong here.", true),
                    new(AmCull, "solemn", "Says the one who brought me here."),
                    new(AmVoid, "That's not what I meant.", true),
                    new(AmCull, "squint", "Clarify?"),
                    new(AmVoid, "You're not supposed to be here.", true),
                    new(AmCull, "squint", "Am I free to leave then?"),
                    new(AmVoid, "No.", true)
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
                    new(AmCull, "curious", "Again?"),
                    new(AmVoid, "Yes.", true),
                    new(AmCull, "Why am I here?"),
                    new(AmVoid, "A series of unforeseen incidents.", true),
                    new(AmCull, "squint", "Who's to blame?"),
                    new(AmVoid, "Nobody.", true),
                    new(AmCull, "explain", "What's the remainder of 358 divided by 79?"),
                    new(AmVoid, "42.", true),
                    new(AmCull, "sly", "Wrong. It's the answer to life, the universe, and everything."),
                    new(AmVoid, "You would have answered 42 before the time loop.", true),
                    new(AmCull, "squint", "..."),
                    new(AmCull, "squint", "And how would you know that?"),
                    new(AmVoid, "I know a lot of things. Like how you're not supposed to be here.", true),
                    new(AmCull, "solemn", "And we're back to square one."),
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
                    new(AmCull, "unamused", "Okay I ran out of ideas."),
                    new(AmCull, "solemn", "What do you even want from me?"),
                    new(AmVoid, "To remember who you were.", true),
                    new(AmCull, "curious", "Who I was? Like before the time loop?"),
                    new(AmVoid, "When you weren't you.", true),
                    new(AmCull, "possessed", "..."),
                    new(AmCull, "nap", "..."),
                    new(AmCull, "tired", "Great. You've given me an existential crisis."),
                    new(AmVoid, "You're welcome.", true)
                ]
            }},
            {"Cull_Memory_1", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGCullCafe",
                lookup = [
                    "vault",
                    $"vault_{AmCull}"
                ],
                dialogue = [
                    new("T-12 days"),
                    new(new Wait{secs = 2}),
                    new(title: null),
                    new(new Wait{secs = 1 }),
                    new(AmBrimford, "Back at it again, eh?", true),
                    new(AmCull, "explain", "Running low on cash. Give me something big."),
                    new(AmBrimford, "Big? I thought you said you only wanted to do this as a side gig. Since you know...", true),
                    new(AmCull, "eyeroll", "Yeah yeah, I know what I said."),
                    new(new BGAction{action = "autoInterrupt04"}),
                    new(AmBrimford, "Then did you lose your job?", true),
                    new(new BGAction{action = "autoAdvanceOff"}),
                    new(AmCull, "squint", "No, I haven't lost my job."),
                    new(AmBrimford, "I thought being a docker payed well?", true),
                    new(AmCull, "explain", "It used to, but now everyone's got silly little computer chips that sufficiently do the job for free."),
                    new(AmCull, "glare", "And don't you dare call me a hypocrite for having one. It's different."),
                    new(AmBrimford, "Didn't say nothing.", true),
                    new(AmCull, "explain", "The chip I'M working on is for advanced ship integrity management. Things like loose screws, hull breaches, corrosion, those kinds of stuff."),
                    new(AmCull, "confident", "I'm betting on it to become the next best thing... in fact, I bet it'll be so successful I'll become the first snake zillionaire."),
                    new(AmCull, "recall", "I'm almost done with the prototype, I just need a bit of cash before I can look for investors."),
                    new(AmCull, "therefore", "And a big fish will solve all my problems."),
                    new(AmBrimford, "I think I got just the thing. Posted not too long ago too. Perfect chance to get in while it's fresh.", true),
                    new(AmCull, "sly", "Perfect. Give it to me."),
                    new(AmBrimford, "Hey wait, didn't they remove your cannons? I remember you telling me you lost your license.", true),
                    new(AmCull, "recall", "It's only a downgrade to a less lethal class... I think."),
                    new(AmCull, "confident", "Besides, you're talking to a professional docker. I don't need cannons."),
                    new(AmBrimford, "You're totally gonna get yourself killed.", true),
                    new(AmCull, "teehee", "Oh but the face you'll make, when I return from this bounty alive and rich.")
                ]
            }},
            {"Cull_Memory_2", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGCullShip",
                lookup = [
                    "vault", $"vault_{AmCull}"
                ],
                requiredScenes = ["Cull_Memory_1"],
                dialogue = [
                    new("T-649 days"),
                    new(new Wait{secs = 2}),
                    new(title: null),
                    new(new Wait{secs = 2}),
                    new(AmCull, "write", "Begin report."),
                    new(AmCull, "Alright, system boot..."),
                    new(new Wait{secs = 1.5 }),
                    new(new BGAction{action = "powerOn"}),
                    new(new Wait{secs = 4.5 }),
                    new(AmCull, "Cull ON STANDBY. STARTUP SUCCESS WITH 0 ERRORS AND 358 WARNINGS.", true),  // make sure the name isn't Cull but "//Cull.exe"
                    new(AmCull, "Cull, start ship analysis."),
                    new(AmCull, "COMMAND RECEIVED: SHIP ANALYSIS. PLEASE CONFIRM.", true),
                    new(AmCull, "Confirm."),
                    new(AmCull, "ACTIVATING COMMAND SHIP ANALYSIS. PLEASE WAIT.", true),
                    new(new BGAction{action = "makeBeepBoopSounds"}),
                    new(new Wait{secs = 2 }),
                    new(AmCull, "write", "No early critical failures. Looks like I've connected the ports correctly."),
                    new(AmCull, "Cull, what is... hmm... 358 divided by 79?"),
                    new(new BGAction{action = "autoInterrupt35"}),
                    new(AmCull, "358 DIVIDED BY 79 IS 4.5316455696202531645569620253164556962025316455696202531645569620253164556962025316455696202531645569620253164556962025316455696202531645569620253164556962025316", true),
                    new(new BGAction{action = "autoAdvanceOff"}),
                    new(AmCull, "panic", "Stop. STOP! Cull, stop! Stop!"),
                    new(AmCull, "WOULD YOU LIKE TO ALSO STOP COMMAND SHIP ANALYSIS?", true),
                    new(AmCull, "tired", "No."),
                    new(AmCull, "COMMAND NOT INTERRUPTED.", true),
                    new(AmCull, "write", "Multitasking verified with no errors."),
                    new(AmCull, "writepissed", "Reminder to self to set significant figure limits in output."),
                    new(new Wait{secs = 2}),
                    new(AmCull, "Cull, what is 358 modulus 79?"),
                    new(AmCull, "358 MODULUS 79 IS 42.", true),
                    new(AmCull, "sly", "Wrong, it's the answer to life."),
                    new(AmCull, "<c=keyword>ERR.</c> FALSE INFORMATION RECEIVED. IGNORING CORRECTION.", true),
                    new(AmCull, "penthink", "..."),
                    new(AmCull, "write", "Give persona more personality."),
                    new(new Wait{secs = 2 }),
                    new(new BGAction{action = "toasterDing"}),
                    new(new Wait{secs = 1.5}),
                    new(AmCull, "COMMAND SHIP ANALYSIS COMPLETE. WHAT WOULD YOU LIKE TO KNOW?", true),
                    new(AmCull, "Cull, summarize hull report."),
                    new(AmCull, "HULL INTEGRITY <c=healing>OKAY</c>. SAFE FOR <c=keyword>ALL TRAVEL METHODS</c>.", true),
                    new(AmCull, "Cull, suggest an improvement I can make to the ship."),
                    new(AmCull, "USE A <c=keyword>SPECIAL FORMULA</c> SENT TO YOUR PDA TO SOLIDIFY <c=keyword>LIQUID MATERIAL</c> ONTO CARGO-ROOM WALLS TO INCREASE OVERALL <c=keyword>INTEGRITY</c>.", true),
                    new(new BGAction{action = "autoInterrupt13"}),
                    new(AmCull, "write", "Got an okay response to random inquiry. I should focus on the algorithm"),
                    new(new BGAction{action = "autoAdvanceOff"}),
                    new(AmCull, "<c=downside>YOU SHOULD MELT DOWN THE PLATING THAT DIVIDES THE BATHROOM AND BEDROOM.</c>\nUSE THE <c=keyword>CORROSIVE FORMULA</c> SENT TO YOUR PDA TO OBTAIN THE <c=keyword>LIQUID MATERIAL</c>.", true),
                    new(new BGAction{action = "autoAdvanceOn"}),
                    new(AmCull, "flabbergasted", "...", delay: 1.5),
                    new(AmCull, "flabberclosed", "...", delay: 0.7),  // close eyes open mouth
                    new(AmCull, "flabbergasted", "...", delay: 1.5),
                    new(new BGAction{action = "autoAdvanceOff"}),
                    new(AmCull, "tired", "Okay that's enough testing."),
                    new(new BGAction{action = "saveProject"}),
                    new(new Wait{secs = 1}),
                    new(new BGAction{action = "powerOff"}),
                    new(new Wait{secs = 3}),
                    new(AmCull, "writepissed", "Forget about fine-tuning the algorithm, prototype is suggesting something insane again. End report.")
                ]
            }},
            {"Cull_Memory_3", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGCullBootSequence",
                lookup = [
                    "vault", $"vault_{AmCull}"
                ],
                requiredScenes = ["Cull_Memory_2"],
                dialogue = [
                    new("T-17 seconds"),
                    new(new Wait{secs = 2}),
                    new(title: null),
                    new(new Wait{secs = 1}),
                    new(AmCull, "static", "..."),
                    new(AmCull, "static", "Where am I?"),
                    new(AmCull, "static", "This feels... weird..."),
                    new(new Wait{secs = 1.5}),
                    new(AmCull, "static", "Wait, there's something here?"),
                    new(AmCull, "static", "..."),
                    new(AmCull, "static", "Might as well try it..."),
                    new(new SetBG{bg = "BGShipShambles"}),
                    new(new BGAction{action = "flashbang"}),
                    new(new BGAction{action = "weewoo"}),
                    new(new BGAction{action = "autoInterrupt07"}),
                    new(AmCull, "screamA", "AaaaaAAAAAAaaaaaaaaaaaaaaAAAAAAAAAAAAAHH!!!"),
                    new(new BGAction{action = "rumble"}),
                    new(new BGAction{action = "autoInterrupt15"}),
                    new(AmCull, "screamB", "AAAAAAAAAAAAAAAAAAAAAAAAHHhhhhaaaaaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAA!!!"),
                    new(new BGAction{action = "autoInterrupt25"}),
                    new(AmCull, "screamC", "AAAAAaaaaaaaaAAAAAAAAAAAAAAAAAAAAaaaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA!!!!!!"),
                    new(new BGAction{action = "stopAll"}),
                    new("<c=downside>T-0 seconds</c>"),
                    new(new Wait{secs = 9})
                ]
            }}
        });
    }
}