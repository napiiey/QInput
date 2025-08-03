using System;
using Cysharp.Threading.Tasks;

namespace Acfeel.QInput
{
    public static class ScreenPadHandler
    {
        private static async UniTask OneFrameRaterApply(Action act)
        {
            await UniTask.DelayFrame(2);
            act.Invoke();
        }

        public static void ScreenPadUPressed()
        {
            InputState.ScreenPadU = true;
            InputState.ScreenPadUPressed = true;
            OneFrameRaterApply(() => { InputState.ScreenPadUPressed = false; }).Forget();
        }
        public static void ScreenPadDPressed()
        {
            InputState.ScreenPadD = true;
            InputState.ScreenPadDPressed = true;
            OneFrameRaterApply(() => { InputState.ScreenPadDPressed = false; }).Forget();
        }
        public static void ScreenPadLPressed()
        {
            InputState.ScreenPadL = true;
            InputState.ScreenPadLPressed = true;
            OneFrameRaterApply(() => { InputState.ScreenPadLPressed = false; }).Forget();
        }
        public static void ScreenPadRPressed()
        {
            InputState.ScreenPadR = true;
            InputState.ScreenPadRPressed = true;
            OneFrameRaterApply(() => { InputState.ScreenPadRPressed = false; }).Forget();
        }
        public static void ScreenPadUReleased()
        {
            InputState.ScreenPadU = false;
            InputState.ScreenPadUReleased = true;
            OneFrameRaterApply(() => { InputState.ScreenPadUReleased = false; }).Forget();
        }
        public static void ScreenPadDReleased()
        {
            InputState.ScreenPadD = false;
            InputState.ScreenPadDReleased = true;
            OneFrameRaterApply(() => { InputState.ScreenPadDReleased = false; }).Forget();
        }
        public static void ScreenPadLReleased()
        {
            InputState.ScreenPadL = false;
            InputState.ScreenPadLReleased = true;
            OneFrameRaterApply(() => { InputState.ScreenPadLReleased = false; }).Forget();
        }
        public static void ScreenPadRReleased()
        {
            InputState.ScreenPadR = false;
            InputState.ScreenPadRReleased = true;
            OneFrameRaterApply(() => { InputState.ScreenPadRReleased = false; }).Forget();
        }
    }
}
