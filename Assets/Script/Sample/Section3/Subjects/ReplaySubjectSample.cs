using UniRx;
using UnityEngine;

namespace Samples.Section3.Subjects
{
    public class ReplaySubjectSample : MonoBehaviour
    {
        private void Start()
        {
            //過去3メッセージまでキャッシュする
            var subject = new ReplaySubject<int>(bufferSize: 3);

            for (int i = 0; i < 10; i++)
            {
                subject.OnNext(i);
            }

            //OnCompletedメッセージもキャッシュされる
            subject.OnCompleted();

            //OnErrorのキャッシュ
            //subject.OnError(new Exception("Error!"));

            subject.Subscribe(
                x => Debug.Log("OnNext:" + x),
                ex => Debug.LogError("OnNext:" + ex),
                () => Debug.Log("OnCompleted")
            );

            subject.Dispose();
        }
    }
}
