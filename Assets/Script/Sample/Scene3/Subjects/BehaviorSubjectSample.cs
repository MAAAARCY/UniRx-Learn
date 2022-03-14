using UniRx;
using UnityEngine;

namespace Samples.Section3.Subjects
{
    public class BehaviorSubjectSample : MonoBehaviour
    {
        private void Start()
        {
            var behaviorSubject = new BehaviorSubject<int>(0);

            behaviorSubject.OnNext(1);

            behaviorSubject.Subscribe(
                x => Debug.Log("OnNext:" + x),
                ex => Debug.LogError("OnError:" + ex),
                () => Debug.Log("OnCompleted")
            );

            behaviorSubject.OnNext(2);

            Debug.Log("Last Value:" + behaviorSubject.Value);

            behaviorSubject.OnNext(3);
            behaviorSubject.OnCompleted();

            behaviorSubject.Dispose();
        }
    }
}
