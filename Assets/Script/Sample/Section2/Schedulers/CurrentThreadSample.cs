using System.Threading;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Samples.Section2.Schedulers
{
    public class CurrentThreadSample : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("Unity Main Thread ID:" + Thread.CurrentThread.ManagedThreadId);

            var subject = new Subject<Unit>();
            subject.AddTo(this);

            subject
                .ObserveOn(Scheduler.Immediate)
                .Subscribe(_ =>
                {
                    Debug.Log("Thread Id:" + Thread.CurrentThread.ManagedThreadId);
                });
            
            subject.OnNext(Unit.Default);
            subject.OnNext(Unit.Default);

            Task.Run(() => subject.OnNext(Unit.Default));

            subject.OnCompleted();
        }
    }
}
