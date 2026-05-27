using System.Collections.Generic;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class MemoryDialogueJay 
{
    public MemoryDialogueJay()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {
            {"RunWinWho_Jay_1", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmJay],
                bg = "BGRunWin",
                lookup = [
                    $"runWin_{AmJay}"
                ],
                dialogue = [
                    new(new Wait{secs = 3}),
                    new (AmJay, "neutral", "Are you the reason I'm here?" ),
                    new (AmVoid,"neutral","In a way.", flipped: true),
                    new (AmJay, "neutral", "But why? According to CAT, almost everyone else is missing their memories." ),
                    new (AmVoid,"neutral","I need you to be whole again.", flipped: true),
                    new (AmJay, "squint", "Whole? In what sense?" ),
                    new (AmVoid,"neutral","You may remember your past, but that does not mean you have not pushed it deep down.", flipped: true),
                    new (AmVoid,"neutral","I need you to remember her.", flipped: true),
                ]
            }},
            {"RunWinWho_Jay_2", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmJay],
                bg = "BGRunWin",
                priority = true,
                lookup = [
                    $"runWin_{AmJay}"
                ],
                requiredScenes = [
                    "RunWinWho_Jay_1"
                ],
                dialogue = [
                    new(new Wait{secs = 3}),
                    new (AmJay, "neutral", "Now what?" ),
                    new (AmVoid,"neutral","That is only part of the whole story. You still have more to tell.", flipped: true ),
                    new (AmJay, "cry", "But reliving these moments hurts." ),
                    new (AmVoid,"neutral","I know, but you must persevere. For her.", flipped: true ),
                ]
            }},
            {"RunWinWho_Jay_3", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmJay],
                bg = "BGRunWinCustom",
                lookup = [
                    $"runWin_{AmJay}"
                ],
                requiredScenes = [
                    "Jay_Post_Smiff" ,"RunWinWho_Jay_2"
                ],
                dialogue = [
                    new(new Wait{secs = 3}),
                    new (AmJay, "neutral", "Back here again. What for?" ),
                    new (AmVoid,"neutral","I am not sure. You know who you are searching for, yes?", flipped: true ),
                    new (AmJay, "neutral", "The person Valv bought the part from. CAT says his name is Smiff." ),
                    new (AmVoid,"neutral","That is correct. As of now, there is nothing I can do for you here.", flipped: true ),
                    new (new BGAction(){action = "runwinwho_reset_Jay"}),
                ]
            }},
            {"Jay_Memory_1", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGJayWorkshop",
                lookup = [
                    "vault",
                    $"vault_{AmJay}"
                ],
                dialogue = [
                    new("T-106 days"),
                    new(new Wait{secs = 2}),
                    new(title: null),
                    new(new Wait{secs = 1 }),
                    new (AmValv, "neutral", "Who's calling you?", flipped: true ),
                    new (AmJay,"neutral","Let me check." ),
                    new(new Wait{secs = 1 }),
                    new (AmDizzy, "neutral", "Hello!", flipped: true  ),
                    new (AmJay,"neutral","Dizzy! Long time no talk. " ),
                    new (AmValv, "neutral", "Hi Dizzy! How have you been?", flipped: true ),
                    new (AmDizzy, "neutral", "Pretty good! Got a new contract on a mysterious ship. I get to do loads of groundbreaking research here!", flipped: true  ),
                    new (AmJay,"neutral","That's great! What are you researching?" ),
                    new (AmDizzy, "neutral", "That's what I am calling about, actually. I know you and your sister have been trying to design a new lightspeed engine, and I think I have just the thing to help you out. For the sake of research, of course.", flipped: true  ),
                    new (AmJay,"neutral","Oh? What is it, exactly?" ),
                    new (AmDizzy, "neutral", "I can't say, I'm under an NDA.", flipped: true  ),
                    new (AmDizzy, "neutral", "But I *can* just so happen to lose the part you need in space nearby for a pirate to pick up. You'll have to buy it off of them though.", flipped: true  ),
                    new (AmDizzy, "neutral", "It's a small piece of a crystal. Very volatile, be careful not to damage it.", flipped: true  ),
                    new (AmValv,"squint","What if the pirate damages it?" ),
                    new (AmDizzy, "neutral", "Better hope they don't.", flipped: true  ),
                    new (AmDizzy, "failtoloadimageplease", "*click*", flipped: true  ),
                    new (AmJay,"neutral","You think you can handle that, Valv?" ),
                    new (AmValv, "neutral", "Shouldn't be too hard to get that part. I'll head out now.", flipped: true ),

                ]
            }},
            {"Jay_Memory_2", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGJayWorkshop",
                lookup = [
                    "vault",
                    $"vault_{AmJay}"
                ],
                requiredScenes = ["Jay_Memory_1"],
                dialogue = [
                    new("T-98 days"),
                    new(new Wait{secs = 2}),
                    new(title: null),
                    new(new Wait{secs = 1 }),
                    new (AmValv, "neutral", "What's up, bro!", flipped: true ),
                    new (AmJay,"neutral","Valv, you're back! Did you get the part I needed?" ),
                    new (AmValv, "neutral", "Yup! Bought it off of some bat dude. Drove a hard bargain, saying he stole it from some weird ship.", flipped: true  ),
                    new (AmJay,"neutral","Excellent! With this, I think I'll be able to finish my prototype engine within the next week or so." ),
                    new (AmValv, "neutral", "We're gonna be so rich!", flipped: true  ),
                    new (AmJay,"squint","That's not the point." ),
                    new (AmValv, "angry", "Yeah, I know, revolutionizing space travel yada yada yada.", flipped: true  ),
                    new (AmValv, "neutral", "The money is still a huge bonus.", flipped: true  ),
                    new (AmJay,"neutral","Oh of course." ),
                ]
            }},
            {"Jay_Memory_3", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGJayWorkshop",
                lookup = [
                    "vault", $"vault_{AmJay}"
                ],
                requiredScenes = ["Jay_Memory_2"],
                dialogue = [
                    new("T-94 days"),
                    new(new Wait{secs = 2}),
                    new(title: null),
                    new(new Wait{secs = 2}),
                    new (AmJay, "neutral", "Screw that plate in and then we should be finished." ),
                    new (AmValv,"neutral","Alright! I think that's done! Ready to test it?", flipped: true  ),
                    new (AmJay, "neutral", "Of course." ),
                    new(new Wait{secs = 2}),
                    new (AmJay, "neutral", "Engine is stable. Temperatures are normal." ),
                    new (AmValv,"neutral","That's good, right? That sounds good.", flipped: true  ),
                    new (AmJay, "neutral", "It's very good. If this holds, then it's finally finished!" ),
                    new (new BGAction(){action = "alarm"}),
                    new(new Wait{secs = 1}),
                    new (AmJay, "nervous", "Uh oh. The part we got seems unable to hold!" ),
                    new (AmValv,"angry","We were so close!", flipped: true  ),
                    new (AmJay, "nervous", "Shutting down power!" ),
                    new(new Wait{secs = 1}),
                    new (AmValv,"nervous","What's wrong? Why isn't it stopping?!", flipped: true  ),
                    new (AmJay, "nervous", "It's not letting me!" ),
                    new (AmJay, "nervous", "GET DOWN!" ),
                    new (new BGAction(){action = "explosion"}),
                    new (new Shake{amount = 25}),
                    new (new BGAction{action = "blackout"}),
                    new(new Wait{secs = 5}),
                    new (new BGAction(){action = "sadness"}),
                    new (AmJay, "damaged", "Valv! Where are you?!" ),
                    new (new Wait{secs = 2}),
                    new (AmJay, "damaged", "Oh god..." ),
                    new (AmValv,"dead","...", flipped: true  ),
                    new (AmJay, "damaged", "Valv! Wake up! VALV!" ),
                    new (AmValv,"dead","...", flipped: true  ),
                    new (AmJay, "damaged", "Don't do this to me! C'mon, wake up!" ),
                    new (AmValv,"dead","...", flipped: true  ),
                    new (AmJay, "damaged", "No! No..." ),
                    new (AmJay, "damagedcry", "..." ),
                    new (AmJay, "damagedcry", "This is my fault..." ),
                    new (AmJay, "damagedcry", "If I-I just... paid more attention..." ),
                    new (AmJay, "damagedcry", "..." ),
                    new (AmJay, "damagedcry", "How will I ever forgive myself..." ),

                ]
            }},
            {"Jay_Memory_Fight", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGBattleMemory",
                lookup = [
                    "vault", $"vault_{AmJay}"
                ],
                requiredScenes = ["Jay_Memory_3"],
                dialogue = [
                    new("END THE PAIN"),
                    new(new Wait{secs = 2}),
                    new(title: null),
                    new (AmCull,"neutral","Wake up.", flipped: true ),
                    new (AmJay, "squint", "Huh? Oh, another loop already?" ),
                    new (AmCull,"neutral","Not exactly. It's time to face the source of your problem.", flipped: true ),
                    new (AmJay, "squint", "What problem?" ),
                    new (AmCull,"neutral","Your grief.", flipped: true ),
                    new (AmJay, "squint", "How, exactly?" ),
                    new (AmCull,"neutral","My connection with Death allows me to temporarily resurrect those that are gone.", flipped: true  ),
                    new (AmCull,"neutral","You will be able to make peace with your past.", flipped: true  ),
                    new (AmJay, "nervous","Are you saying I will get to see Valv again?" ),
                    new (AmCull,"neutral","Yes, if only for a moment. It is a difficult process though. We will have to fight the personification of your grief.", flipped: true ),
                    new (AmJay, "squint", "In a metaphorical sense?" ),
                    new (AmCull,"neutral","In a literal sense. Are you ready?", flipped: true ),
                    new (AmJay, "squint", "I... guess." ),
                    new (AmCull,"neutral","I am going to need a more definite answer.", flipped: true ),
                    new (AmJay, "neutral", "Yes. I am ready. Do what you must." ),
                    new (AmCull,"neutral","Then prepare yourself. This will be no easy battle.", flipped: true ),
                    new (new MemoryFight()
                    {
                        cards = new List<Card>
                        {
                            new CannonColorless(),
                            new DodgeColorless(),
                            new BasicShieldColorless(),
                            new HarvestCard() {upgrade = Upgrade.A},
                            new QuickCastCard(),
                            new ReorganizeCard(){upgrade = Upgrade.A},
                            new SensoryShotCard(){upgrade = Upgrade.A},
                            new AmplifierCard(),
                            new BareMinimumCard(),
                            new ShootingGalleryCard(){upgrade = Upgrade.B}
                        }, 
                        artifacts = new List<Artifact>
                        {
                            new EnhancedFocusArtifact(),
                            new CodeInspectionArtifact(),
                            new EnhancedSensorsArtifact(),
                            new WarpMastery(),
                            new IonConverter()
                        },
                        decks = new List<Deck>
                        {
                            ModEntry.Instance.CullDeck.Deck,
                            ModEntry.Instance.JayDeck.Deck,
                        },
                        enemy = new AngerEnemy(),
                        ship = ModEntry.Instance.VulcanShip.Configuration.Ship,
                        removeArtifacts = [new ShieldPrep()],
                        hullIncrease = 10,
                    }),
                ]
            }},
            {"Anger_Power_Up", new(){
                type = NodeType.@event,
                allPresent = [AmJay, AmCull],
                nonePresent = [AmLuna, AmCenti,/* AmEva*/],
                dialogue = [
                    new (AmJay, "nervous", "Did it just power up?!" ),
                    new (AmCull,"angry","I told you this would be no easy battle! Stand your ground!" ),
                ]
            }},
            {"Anger_Callout_Multi_0", new(){
                type = NodeType.combat,
                allPresent = [AmJay, AmCull, AmVoid],
                nonePresent = [AmLuna, AmCenti,/* AmEva*/],
                dialogue = [
                    new (AmVoid, "1'M AB0UT TO MA??KE IT\n<c=part>YOUR PROBLEM.</c>" ),
                    new (AmJay, "sob", "...")

                ]
            }},
            {"Anger_Callout_Multi_1", new(){
                type = NodeType.combat,
                allPresent = [AmJay, AmCull, AmVoid],
                nonePresent = [AmLuna, AmCenti, /*AmEva*/],
                dialogue = [
                    new (AmVoid, "THAT'S N??0T <c=part>THE POINT.</c>" ),
                    new (AmJay, "sad", "...")
                ]
            }},
            {"Anger_Callout_Multi_2", new(){
                type = NodeType.combat,
                allPresent = [AmJay, AmCull, AmVoid],
                nonePresent = [AmLuna, AmCenti,/* AmEva*/],
                dialogue = [
                    new (AmVoid, "Y0U TH1NK YO??U C4N <c=part>HANDLE THAT?</c>" ),
                    new (AmJay, "tear", "...")

                ]
            }},
            {"Jay_Closure", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGBattleMemory",
                lookup = [
                    "after_void"
                ],
                allPresent = [AmJay, AmCull, AmVoid],
                nonePresent = [AmLuna, AmCenti,/* AmEva*/],
                requiredScenes = ["Jay_Memory_3"],
                dialogue = [
                    new (new BGAction{action = "fight"}),  
                    new(new Wait{secs = 1}),
                    new (AmJay,"nervous","Did we do it? Is it over?" ),
                    new (AmCull, "neutral", "Looks like it.", flipped: true  ),
                    new (AmJay,"nervous","Then what now?" ),
                    new (AmValv, "ghost", "Jay?", flipped: true  ),
                    new (AmJay,"nervous","Valv?!" ),
                    new (AmCull, "neutral", "I'll leave you two alone.", flipped: true  ),
                    new (AmJay, "sad", "Valv... I am so sorry..." ),
                    new (AmValv, "ghostmad", "Don't. Don't talk like that.", flipped: true  ),
                    new (AmJay,"sob","If I had just paid closer attention, maybe you would still be alive." ),
                    new (AmValv, "ghostsad", "No one could have known what would have happened.", flipped: true  ),
                    new (AmJay,"sad","I could have! You aren't here because of me!" ),
                    new (AmValv, "ghostmad", "Not even you could have known! This was never your fault, Jay.", flipped: true  ),
                    new (AmJay,"sob","But you are still gone." ),
                    new (AmValv, "ghostsad", "I've never held you at fault for that. It was an accident, nothing more.", flipped: true  ),
                    new (AmJay,"sad","I've held myself at fault ever since." ),
                    new (AmValv, "ghostmad", "And you have got to stop!", flipped: true  ),
                    new (AmValv, "ghostsad", "I may no longer be with you, but you are still my brother. I still love you.", flipped: true  ),
                    new (AmJay,"tear","You do?" ),
                    new (AmValv, "ghostsad", "Of course.", flipped: true  ),
                    new (AmJay,"tear","I- I am sorry. For everything." ),
                    new (AmValv, "ghostsad", "It's okay. I forgive you.", flipped: true  ),
                    new (AmValv, "fade", "...", flipped: true  ),
                    new (AmValv, "fade", "Looks like my time is running out.", flipped: true  ),
                    new (AmJay,"tear","Goodbye, Valv. I'll miss you." ),
                    new (AmValv, "fade", "Goodbye, Jay.", flipped: true  ),
                    new (AmValv, "purposefully_misspelled_name_to_make_her_disappear", "...", flipped: true  ),
                    new (AmJay,"sob","...I'll miss you." ),

                    new (new EndMemoryFight())
                ]
            }},
        });
    }
}