using System;
using Cysharp.Threading.Tasks;

namespace Acfeel.QuickInput
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
            InputState.ScreenPadUDown = true;
            OneFrameRaterApply(() => { InputState.ScreenPadUDown = false; }).Forget();
        }
        public static void ScreenPadDPressed()
        {
            InputState.ScreenPadD = true;
            InputState.ScreenPadDDown = true;
            OneFrameRaterApply(() => { InputState.ScreenPadDDown = false; }).Forget();
        }
        public static void ScreenPadLPressed()
        {
            InputState.ScreenPadL = true;
            InputState.ScreenPadLDown = true;
            OneFrameRaterApply(() => { InputState.ScreenPadLDown = false; }).Forget();
        }
        public static void ScreenPadRPressed()
        {
            InputState.ScreenPadR = true;
            InputState.ScreenPadRDown = true;
            OneFrameRaterApply(() => { InputState.ScreenPadRDown = false; }).Forget();
        }
        public static void ScreenPadUReleased()
        {
            InputState.ScreenPadU = false;
            InputState.ScreenPadUUp = true;
            OneFrameRaterApply(() => { InputState.ScreenPadUUp = false; }).Forget();
        }
        public static void ScreenPadDReleased()
        {
            InputState.ScreenPadD = false;
            InputState.ScreenPadDUp = true;
            OneFrameRaterApply(() => { InputState.ScreenPadDUp = false; }).Forget();
        }
        public static void ScreenPadLReleased()
        {
            InputState.ScreenPadL = false;
            InputState.ScreenPadLUp = true;
            OneFrameRaterApply(() => { InputState.ScreenPadLUp = false; }).Forget();
        }
        public static void ScreenPadRReleased()
        {
            InputState.ScreenPadR = false;
            InputState.ScreenPadRUp = true;
            OneFrameRaterApply(() => { InputState.ScreenPadRUp = false; }).Forget();
        }
    }
}
