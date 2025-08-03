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
        public static bool ScreenPadUUp;
        public static bool ScreenPadDUp;
        public static bool ScreenPadLUp;
        public static bool ScreenPadRUp;
        public static bool ScreenPadUDown;
        public static bool ScreenPadDDown;
        public static bool ScreenPadLDown;
        public static bool ScreenPadRDown;

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
