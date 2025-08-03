using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Acfeel.QInput
{
    public static class FlickHandler
    {
        private const float FlickMin = 0.03f;

        public static async UniTask UniTaskUpdate(CancellationToken token)
        {
            while (true)
            {
                if (token.IsCancellationRequested) break;

                //フリック関連
                if (QInput.ClickPressed())
                {
                    InputState.FlickTime = 0;
                    InputState.FlickStartPosition = QInput.ClickPosition();
                }
                if (QInput.Click())
                {
                    InputState.FlickEndPosition = QInput.ClickPosition();
                    InputState.FlickTime++;
                }
                if (InputState.IsFlicking)
                {
                    ResetFlick().Forget(); //1フレームだけtrueにしたいので次のフレームでは切る
                }
                if (QInput.ClickReleased())
                {
                    InputState.FlickDistance = new Vector2(
                        (InputState.FlickEndPosition.x - InputState.FlickStartPosition.x) / Screen.height,
                        (InputState.FlickEndPosition.y - InputState.FlickStartPosition.y) / Screen.height);
                    if (Math.Abs(InputState.FlickDistance.x) > FlickMin || Math.Abs(InputState.FlickDistance.y) > FlickMin)
                    {
                        InputState.IsFlicking = true;
                    }
                }
                await UniTask.DelayFrame(1, cancellationToken: token);
            }
        }

        private static async UniTask ResetFlick()
        {
            await UniTask.DelayFrame(2);
            InputState.IsFlicking = false;
        }
    }
}
