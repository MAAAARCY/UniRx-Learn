using UniRx;
using UnityEngine;

public class SubjectSample : MonoBehaviour
{
    private void Start()
    {
        var subject = new Subject<int>();

        subject.OnNext(1); //not working
 
        subject.Subscribe(
            x => Debug.Log("OnNext:" + x),
            ex => Debug.LogError("OnCompleted:" + ex),
            () => Debug.Log("OnCompleted")
        );

        subject.OnNext(2);
        subject.OnNext(3);

        subject.OnCompleted();

        subject.Dispose();
    }
}
