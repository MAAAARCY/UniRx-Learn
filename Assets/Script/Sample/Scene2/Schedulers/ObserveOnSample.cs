using System.IO;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

public class ObserveOnSample : MonoBehaviour
{
    private void Start()
    {
        var task = Task.Run((() => File.ReadAllText(@"data.txt")));

        task.ToObservable()
            .ObserveOn(Scheduler.MainThread)
            .Subscribe(x =>
            {
                Debug.Log(x);
            });
    }
}
