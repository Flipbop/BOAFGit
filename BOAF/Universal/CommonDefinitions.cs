namespace Flipbop.BOAF;

/// <summary>
/// For if a dialogue needs to be registered AFTER mods have been loaded
/// </summary>
internal interface IDialogueRegisterable
{
    static abstract void LateRegister();
}

static class CommonDefinitions
{
    internal static ModEntry Instance => ModEntry.Instance;

    internal static string AmCull => Instance.CullDeck.UniqueName;
    internal static Deck AmCullDeck => Instance.CullDeck.Deck;
    internal static Status MissingCull => ModEntry.Instance.CullCharacter.MissingStatus.Status;
    
    internal static string AmJay => Instance.JayDeck.UniqueName; 
    internal static Deck AmJayDeck => Instance.JayDeck.Deck;
    internal static Status MissingJay => ModEntry.Instance.JayCharacter.MissingStatus.Status;
    /*internal static string AmLuna => Instance.LunaDeck.UniqueName;
    internal static Deck AmLunaDeck => Instance.LunaDeck.Deck;
    internal static Status MissingLuna => ModEntry.Instance.LunaCharacter.MissingStatus.Status;
    internal static string AmCenti => Instance.CentiDeck.UniqueName;
    internal static Deck AmCentiDeck => Instance.CentiDeck.Deck;
    internal static Status MissingCenti => ModEntry.Instance.CentiCharacter.MissingStatus.Status;
    internal static string AmEva => Instance.EvaDeck.UniqueName;
    internal static Deck AmEvaDeck => Instance.EvaDeck.Deck;
    internal static Status MissingEva => ModEntry.Instance.EvaCharacter.MissingStatus.Status;
    */
    internal const string AmUnknown = "johndoe";
    internal const string AmCat = "comp";
    internal static string AmDizzy => Deck.dizzy.Key();
    internal static string AmPeri => Deck.peri.Key();
    internal static string AmRiggs => Deck.riggs.Key();
    internal static string AmDrake => Deck.eunice.Key();
    internal static string AmIsaac => Deck.goat.Key();
    internal static string AmBooks => Deck.shard.Key();
    internal static string AmMax => Deck.hacker.Key();
    internal const string AmVoid = "void";
    internal const string AmShopkeeper = "nerd";
    internal const string AmBrimford = "walrus";
    internal const string AmDuncan = "skunk";
    internal const string AmJumbo = "miner";
    internal const string AmSmiff = "batboy";


    internal static string AmValv = Instance.ValvCharacter.CharacterType;

}