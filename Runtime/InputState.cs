using UnityEngine;

namespace Acfeel.QInput
{
    public static class InputState
    {
        // Repeat/Click count state
        public static int ClickCt;
        public static int RepeatCt;

        // ScreenPad state
        public static bool ScreenPadU;
        public static bool ScreenPadD;
        public static bool ScreenPadL;
        public static bool ScreenPadR;
        public static bool ScreenPadUPressed;
        public static bool ScreenPadDPressed;
        public static bool ScreenPadLPressed;
        public static bool ScreenPadRPressed;
        public static bool ScreenPadUReleased;
        public static bool ScreenPadDReleased;
        public static bool ScreenPadLReleased;
        public static bool ScreenPadRReleased;

        // Pinch state
        public static float BasePinchDistance;
        public static bool IsPinching;

        // Flick state
        public static bool IsFlicking;
        public static Vector2 FlickStartPosition;
        public static Vector2 FlickEndPosition;
        public static Vector2 FlickDistance;
        public static int FlickTime;

        // Direction state
        public static Vector2 Direction;
    }
}
