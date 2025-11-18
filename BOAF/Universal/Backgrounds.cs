using System.Reflection;
using HarmonyLib;
using Nickel;


namespace Flipbop.BOAF;

public class Backgrounds
{
    public class BGJayWorkshop : BG {
        private bool explosion = false;
        private bool alarm = false;
        private bool sadness = false;
        private bool blackout = false;

        public BGJayWorkshop()
        {
            ApplyPatches();
        }
        
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
        }
    }
}