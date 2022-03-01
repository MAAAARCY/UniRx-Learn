using UniRx;
using UnityEngine;

namespace Samples.Section2.Observables
{
    public class AddToSample : MonoBehaviour
    {
        private void Start()
        {
            Observable.IntervalFrame(30)
                .Subscribe(_ => Debug.Log("Do!"))
                .AddTo(this);
        }
    }
}
