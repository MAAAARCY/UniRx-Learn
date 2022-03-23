using UniRx;
using UnityEngine;

namespace Samples.Section3.ReactiveProperty
{
    public class ReactivePropertySample : MonoBehaviour
    {
        private void Start()
        {
            var health = new ReactiveProperty<int>(100);

            Debug.Log("現在の値:" + health.Value);

            health.Subscribe(
                x => Debug.Log("通知された値:" + x), 
                () => Debug.Log("OnCompleted"));

            health.Value = 50;

            Debug.Log("現在の値:" + health.Value);

            health.Dispose();
        }
    }
}
