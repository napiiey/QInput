using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Acfeel.QInput
{
    public static class StartupInitializer {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void InitializeBeforeSceneLoad()
        {
            var initializer = new GameObject("Initializer", typeof(Initializer));
            Object.DontDestroyOnLoad(initializer);
        }
    }

    public class Initializer : SingletonMonoBehaviour<Initializer> {
        private CancellationTokenSource QInputUpdateCts;
        private CancellationTokenSource QInputSlowUpdateCts;
        void Start() {
            QInputUpdateCts = new CancellationTokenSource();
            QInputSlowUpdateCts = new CancellationTokenSource();
            InputLoop.RunFlickUpdate(QInputUpdateCts.Token).Forget();
            InputLoop.RunSlowUpdate(QInputSlowUpdateCts.Token).Forget();
            System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("en-us");
        }
        void OnApplicationQuit() {
            QInputUpdateCts.Cancel();
            QInputUpdateCts.Dispose();
            QInputSlowUpdateCts.Cancel();
            QInputSlowUpdateCts.Dispose();
        }
    }
}
