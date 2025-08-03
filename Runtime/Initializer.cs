using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Acfeel.QuickInput
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
        private CancellationTokenSource quickInputUpdateCts;
        private CancellationTokenSource quickInputSlowUpdateCts;
        void Start() {
            quickInputUpdateCts = new CancellationTokenSource();
            quickInputSlowUpdateCts = new CancellationTokenSource();
            InputLoop.RunFlickUpdate(quickInputUpdateCts.Token).Forget();
            InputLoop.RunSlowUpdate(quickInputSlowUpdateCts.Token).Forget();
            System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("en-us");
        }
        void OnApplicationQuit() {
            quickInputUpdateCts.Cancel();
            quickInputUpdateCts.Dispose();
            quickInputSlowUpdateCts.Cancel();
            quickInputSlowUpdateCts.Dispose();
        }
    }
}
