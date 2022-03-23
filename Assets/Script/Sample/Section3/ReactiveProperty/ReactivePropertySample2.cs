using UniRx;
using UnityEngine;

namespace Samples.Section3.ReactiveProperty
{
    public class ReactivePropertySample2 : MonoBehaviour
    {
        private void Start()
        {
            var health = new ReactiveProperty<int>(100);

            Debug.Log("現在の値:" + health.Value);

            health.Subscribe(
                x => Debug.Log("通知された値:" + x)
                //() => Debug.Log("OnCompleted")
            );

            health.Value = 100;

            health.SetValueAndForceNotify(100); //値が変わらなくても強制的にOnNextする

            Debug.Log("現在の値:" + health.Value);

            health.Dispose();
        }
    }
}
