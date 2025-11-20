using System.Reflection;
using HarmonyLib;
using Nickel;


namespace Flipbop.BOAF;

public class Backgrounds
{
    public Backgrounds()
    {
        ApplyPatches();
    }
    private void ApplyPatches() {
        ModEntry.Instance.Harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(Dialogue), nameof(Dialogue.GetMusic)),
            postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Music_Override))
        );}

    public static void Music_Override(Dialogue __instance, ref MusicState? __result)
    {
        if (__instance.bg is BGJayWorkshop bg)
        {
            if (bg.sadness) __result = new MusicState { scene = Song.Riggs };
            if (bg.explosion) __result = new MusicState { scene = Song.Silence };
            if (bg.alarm) __result = new MusicState { scene = Song.Silence };
        }

        if (__instance.bg is BGBattleMemory)
        {
            __result = new MusicState { scene = Song.Defiance };
        }
    }

    public class BGJayWorkshop : BG {
        public  bool explosion = false;
        public bool alarm = false;
        public bool sadness = false;
        public bool blackout = false;
        
        public override void OnAction(State s, string action) {
            if (action == "explosion")
            {
                explosion = true;
                alarm = false;
            }
            if (action == "alarm") alarm = true;
            if (action == "sadness")
            {
                explosion = false;
                sadness = true;
                blackout = false;
            }
            if (action == "blackout") blackout = true;
        }

        public override void Render(G g, double t, Vec offset) {
            Draw.Sprite(ModEntry.Instance.BGJayWorkshopSprite.Sprite, 0, 0);
            BGComponents.Letterbox();

            if (explosion) Audio.Auto(FSPRO.Event.Hits_ShipExplosion);
            if (alarm)
            {
                Audio.Auto(FSPRO.Event.Scenes_CoreAlarm);
                Glow.Draw(Vec.FromAngle(250), 1000, Colors.redd);
            }
            if (blackout) Draw.Fill(Colors.black);


        }
    }
    
    public class BGBattleMemory : BG
    {
        public bool prefight = false;
        
        public override void OnAction(State s, string action) {
            
        }

        public override void Render(G g, double t, Vec offset) {
            Color color = new Color(0.0, 0.1, 0.2).gain(0.5);
            Draw.Fill(new Color?(color));
            BGComponents.NormalStars(g, t, offset);
            BGComponents.RegularNebula(g, offset, color);
        }
    }
}