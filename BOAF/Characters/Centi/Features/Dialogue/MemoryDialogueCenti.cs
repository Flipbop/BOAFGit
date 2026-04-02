using System.Collections.Generic;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class MemoryDialogueCenti 
{
    public MemoryDialogueCenti()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {
            {"RunWinWho_Centi_1", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmCenti],
                bg = "BGRunWin",
                lookup = [
                    $"runWin_{AmCenti}"
                ],
                dialogue = [
                    new(new Wait{secs = 3}),
                    new (AmCenti, "neutral", "This is weird. I don't like this." ),
                    new (AmVoid,"neutral","That is a natural reaction.", flipped: true),
                    new (AmCenti, "neutral", "Why am I here? I don't have a purpose being here like the others do." ),
                    new (AmVoid,"neutral","You are the strangest case.", flipped: true),
                    new (AmVoid,"neutral","You still have all of your memories, yes?", flipped: true),
                    new (AmCenti, "neutral", "I do." ),
                    new (AmVoid,"neutral","You are not alone in that. The others like you are also grieving.", flipped: true),
                    new (AmVoid,"neutral","There is only one death in your past. If you want to move on, you have to stop running from it.", flipped: true),
                ]
            }},
            {"RunWinWho_Centi_2", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmCenti],
                bg = "BGRunWinCustom",
                lookup = [
                    $"runWin_{AmCenti}"
                ],
                requiredScenes = [
                    "RunWinWho_Centi_1"
                ],
                dialogue = [
                    new(new Wait{secs = 3}),
                    new (AmCenti, "neutral", "Here once again." ),
                    new (AmVoid,"neutral","You have a goal in mind to help with your pain, do you not?", flipped: true ),
                    new (AmCenti, "neutral", "I guess that is one way to put it." ),
                    new (AmVoid,"neutral","Then find Drake. For now, I cannot help you.", flipped: true ),
                    new (new BGAction(){action = "runwinwho_reset_Centi"}),
                ]
            }},
            {"RunWinWho_Centi_3", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmCenti],
                bg = "BGRunWin",
                priority = true,
                lookup = [
                    $"runWin_{AmCenti}"
                ],
                requiredScenes = [
                    "Centi_Post_Drake", "Centi_Memory_2"
                ],
                dialogue = [
                    new(new Wait{secs = 3}),
                    new (AmVoid,"neutral","Do you feel better?", flipped: true ),
                    new (AmCenti, "sad", "I thought I would. All I feel now is hollow." ),
                    new (AmVoid,"neutral","That is expected. You are almost done.", flipped: true ),
                    new (AmCenti, "cry", "Almost? There is still more?" ),
                    new (AmVoid,"neutral","Correct. You are ready for the final stage.", flipped: true ),
                ]
            }},
            {"Centi_Memory_1", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGCentiSpace",
                lookup = [
                    "vault",
                    $"vault_{AmCenti}"
                ],
                dialogue = [
                    new("T-2456 days"),
                    new(new Wait{secs = 2}),
                    new(title: null),
                    new(new Wait{secs = 1 }),
                    new (AmCenti, "livingneutral", "Almost there..." ),
                    new (AmDrake, "C'mon, pick up the pace! The AVON Guard will be here any minute now!", true),
                    new (AmCenti, "livingneutral", "You can't rush this! Mining out an asteroid this large takes time." ),
                    new (AmDrake, "We've been here for an hour! You sure this mining rig you stole works?", true ),
                    new (AmCenti, "livingneutral", "Absolutely. This thing is top of the line!" ),
                    new (AmCenti, "livingneutral", "There! Crystallized stardust! This small clump is worth billions on the black market." ),
                    new (AmDrake, "Perfect... I'll take that and we'll be on our way!", true ),
                    new(new Wait{secs = 1 }),
                    new (AmGuard, "Stop right there criminal scum! This is restricted space!", true ),
                    new (AmCenti, "livingnervous", "They found us!" ),
                    new (AmDrake, "panic","I'm not getting caught up with them of all people! I'm out!", true ),
                    new (AmCenti, "livingnervous", "What?! Drake, we're partners!" ),
                    new (AmDrake, "panic","Sorry, but the AVON Guard are the real deal!", true ),
                    new (AmDrake, "messitupsoshedisappears","...", true ),
                    new (AmCenti, "livingnervous", "...Drake..." ),
                    new (AmGuard, "Your \"friend\" left you. No hiding now.", true ),
                    new (AmCenti, "livingneutral", "I'm not just going to give in." ),
                    new (AmGuard, "I love it when they resist. Goodbye.", true ),
                    new (new BGAction(){action = "explosion"}),
                ]
            }},
            {"Centi_Memory_2", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGCentiSpace",
                lookup = [
                    "vault", $"vault_{AmCenti}"
                ],
                requiredScenes = ["Centi_Memory_1"],
                dialogue = [
                    new("T-2450 days"),
                    new(new Wait{secs = 2}),
                    new(title: null),
                    new(new Wait{secs = 1 }),
                    new (AmDrake, "sad","Please work...", true ),
                    new(AmCenti, "gameover", "BOOTUP SEQUENCE INITIATED..."),
                    new(AmCenti, "squint", "...ow my head..."),
                    new (AmDrake, "YES!", true ),
                    new(AmCenti, "squint", "What's going on?"),
                    new (AmDrake, "neutral","I brought you back! I had to use one of your Infinity Cores to power your body, but you are alive again!", true ),
                    new(AmCenti, "cry", "I thought I died..."),
                    new (AmDrake, "sad","You... did. The AVON Guard left almost nothing behind.", true ),
                    new(AmCenti, "cry", "So I did die..."),
                    new(AmCenti, "angry", "And it's because you left me."),
                    new (AmDrake, "panic","Woah now, hold on! I brought you back!", true ),
                    new(AmCenti, "angry", "Did you?! Is that what living looks like to you?!"),
                    new(AmCenti, "angry", "I'm dead, and it's your fault!"),
                    new (AmDrake, "sad","C'mon, you don't really think that, do you?", true ),
                    new(AmCenti, "angry", "I don't EVER want to see you again!"),
                    new (AmDrake, "sad","But we are partners! What are you gonna do without me?!", true ),
                    new(AmCenti, "angry", "Settle down. Maybe start a farm. All I know right now is I want you out of my life for good."),
                    new(AmCenti, "angry", "Goodbye, Drake. I hope our paths never cross."),
                    new(AmCenti, "messitupsotheydisappear", "..."),
                ]
            }},
            {"Centi_Memory_3", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGBattleMemory",
                lookup = [
                    "vault", $"vault_{AmCenti}"
                ],
                requiredScenes = ["Centi_Memory_2"],
                dialogue = [
                    new(new Wait{secs = 2}),
                    new(AmCenti, "squint", "Something is off about this loop, I can feel it..."),
                    new (AmCull, "You would be correct.", true),
                    new (AmCenti, "squint", "What is going on, then?"),
                    new (AmCull, "It's just us. Our objective is different from usual.", true),
                    new (AmCenti,  "What do we have to do?"),
                    new (AmCull, "It's time we tackle your grief head on.", true),
                    new (AmCenti,  "squint","What? How?"),
                    new (AmCull, "It's time we tackle your grief head on.", true),
                    new (AmCull, "I can temporarily revive those that have died so they can communicate with the living.", true),
                    new (AmCenti,  "squint","So you plan on reviving me. I see. What do we have to do?"),
                    new (AmCull, "Your grief has taken physical form. We need to destroy it.", true),
                    new (AmCenti,  "Sounds... hard."),
                    new (AmCull, "I trust that you are ready?", true),
                    new (AmCenti,  "Most definitely."),
                    new (new MemoryFight()
                    {
                        cards = new List<Card>
                        {
                            new CannonColorless(),
                            new BasicShieldColorless(),
                            new DodgeColorless(),
                            new HarvestCard() {upgrade = Upgrade.A},
                            new QuickCastCard(),
                            new Lv2CoreCard() {upgrade = Upgrade.A},
                            new InfinitePotentialCard(),
                            new DemonicConverterCard() {upgrade = Upgrade.A},
                            new AgressiveDefenseCard(),
                            new DoubleShieldCard() {upgrade = Upgrade.B}
                        }, 
                        artifacts = new List<Artifact>
                        {
                            new WarpMastery(),
                            new OverclockedSiphonArtifact(),
                            new CoreCycleArtifact(),
                            new ShieldStorageArtifact(),
                            new DebrisNetArtifact(),
                        },
                        decks = new List<Deck>
                        {
                            ModEntry.Instance.CullDeck.Deck,
                            ModEntry.Instance.CentiDeck.Deck,
                        },
                        enemy = new DenialEnemy(),
                        ship = ModEntry.Instance.NeptuneShip.Configuration.Ship,
                        removeArtifacts = [new ShieldPrep()],
                        hullIncrease = 10,
                    }),

                ]
            }},
            {"Denial_Power_Up", new(){
                type = NodeType.@event,
                allPresent = [AmCenti, AmCull],
                nonePresent = [AmLuna, AmJay, /*AmEva*/],
                dialogue = [
                    new (AmCenti, "nervous", "Now how are we supposed to kill it?!" ),
                    new (AmCull,"angry","Just outlast it's barrage! That shield can't last forever!" ),
                ]
            }},
            {"Denial_Callout_Multi_0", new(){
                type = NodeType.combat,
                allPresent = [AmCenti, AmCull, AmVoid],
                nonePresent = [AmLuna, AmJay, /*AmEva*/],
                dialogue = [
                    new (AmVoid, "1S TH??S WH4t <c=part>LIVING</c> L%KS LIK3 T0 YOu?!" ),
                    new (AmCenti, "sob", "...")

                ]
            }},
            {"Denial_Callout_Multi_1", new(){
                type = NodeType.combat,
                allPresent = [AmCenti, AmCull, AmVoid],
                nonePresent = [AmLuna, AmJay, /*AmEva*/],
                dialogue = [
                    new (AmVoid, "1 <c=part>DIED</c> TH4T DA??." ),
                    new (AmCenti, "sad", "...")
                ]
            }},
            {"Denial_Callout_Multi_2", new(){
                type = NodeType.combat,
                allPresent = [AmCenti, AmCull, AmVoid],
                nonePresent = [AmLuna, AmJay, /*AmEva*/],
                dialogue = [
                    new (AmVoid, "1 4M BuT 4 <c=part>CRUDE COPY</c> Of WH??T 1 0NCE W4S." ),
                    new (AmCenti, "cry", "...")

                ]
            }},
            {"Centi_Closure", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGBattleMemory",
                lookup = [
                    "after_void"
                ],
                allPresent = [AmCenti, AmCull, AmVoid],
                nonePresent = [AmLuna, AmJay, /*AmEva*/],
                requiredScenes = ["Centi_Memory_3"],
                dialogue = [
                    new (new BGAction{action = "fight"}),  
                    new(new Wait{secs = 1}),
                    new (AmCenti, "nervous", "...is it... are we finished?"),
                    new (AmCull, "squint", "That should be it. There is no guarantee this will work for you.", true),
                    new (AmCenti, "ghost", "..."),
                    new (AmCull, "Never mind, looks like it did. I'll let you have your moment.", true),
                    new (AmCenti, "angry", "You. You are what I once was."),
                    new (AmCenti, "ghost", "...", true),
                    new (AmCenti, "cry", "Look at me now. A machine, made from scraps of metal and pieces of your body."),
                    new (AmCenti, "angry", "It's sickening. I shouldn't be here, I'm dead."),
                    new (AmCenti, "ghost", "...", true),
                    new (AmCenti, "cry", "I tried to live a normal life. Away from all of my previous life's problems. But they caught up to me."),
                    new (AmCenti, "sad", "Living any kind of life after your death is a false hope."),
                    new (AmCenti, "ghost", "...", true),
                    new (AmCenti, "angry", "Nothing from you? Do you not have anything to say?"),
                    new (AmCenti, "ghost", "...", true),
                    new (AmCenti, "cry", "You.. you can't speak."),
                    new (AmCenti, "sob", "Cull said that he can revive those that have died."),
                    new (AmCenti, "cry", "But you... you aren't fully revived, are you?"),
                    new (AmCenti, "ghost", "...", true),
                    new (AmCenti, "sad", "You.. you aren't fully dead."),
                    new (AmCenti, "sob", "If part of you isn't dead, then there is something remaining."),
                    new (AmCenti, "cry", "Something... alive in me."),
                    new (AmCenti, "ghost", "...", true),
                    new (AmCenti, "neutral", "You are gone. You have been for the last 6 years."),
                    new (AmCenti, "neutral", "But I am not. I am as alive as you once were."),
                    new (AmCenti, "neutral", "I may live inside a different body than I once did, but I am very much alive."),
                    new (AmCenti, "fade", "...", true),
                    new (AmCenti, "makethemVANISH", "...", true),
                    new (AmCenti, "sob", "..."),
                    new (AmCenti, "neutral", "I am ALIVE!"),

                    new (new EndMemoryFight())
                ]
            }},
        });
    }
}