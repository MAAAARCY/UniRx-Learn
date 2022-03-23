using UniRx;
using UnityEngine;

namespace Samples.Section3.ReactiveProperty
{
    public class ReactivePropertySample3 : MonoBehaviour
    {
        private void Start()
        {
            var health = new ReactiveProperty<int>(100);

            Debug.Log("現在の値:" + health.Value);

            health
                .SkipLatestValueOnSubscribe() //Subscribe直後のOnNextメッセージを無視する
                .Subscribe(
                x => Debug.Log("通知された値:" + x)
                //() => Debug.Log("OnCompleted")
            );

            health.Dispose();
        }
    }
}
