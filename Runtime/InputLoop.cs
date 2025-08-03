using System.Threading;
using Cysharp.Threading.Tasks;

namespace Acfeel.QuickInput
{
    public static class InputLoop
    {
        private const int RepeatStartConst = 5; //リピートがはじまるまでの時間を入力
        private const int RepeatDurationConst = 1; //リピートの間隔を入力
        public static int RepeatStart => RepeatStartConst;
        public static int RepeatDuration => RepeatDurationConst;

        public static async UniTask RunFlickUpdate(CancellationToken token)
        {
            await FlickHandler.UniTaskUpdate(token);
        }

        public static async UniTask RunSlowUpdate(CancellationToken token)
        {
            //約2フレーム
            while (true)
            {
                if (token.IsCancellationRequested) break;
                InputState.ClickCt++;
                InputState.RepeatCt++;
                await UniTask.Delay(62, cancellationToken: token);
            }
        }
    }
}
