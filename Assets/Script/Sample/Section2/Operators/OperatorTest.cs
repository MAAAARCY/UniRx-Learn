using UniRx;
using UnityEngine;

namespace Samples.Section2.Operators
{
    public class OperatorTest : MonoBehaviour
    {
        void Start() 
        { 
            var subject = new Subject<int>();

            //そのままSubscribe
            subject.Subscribe(x => Debug.Log("raw:" + x));

            //0以下を除去してSubscribe
            //Whereを間に挟むことで、条件を満たすメッセージのみを通過させることが出来る
            subject
                .Where(x => x > 0)
                .Subscribe(x => Debug.Log("filter:" + x));

            subject.OnNext(1);
            subject.OnNext(-1);
            subject.OnNext(3);
            subject.OnNext(0);

            subject.OnCompleted();
            subject.Dispose();

        }
    }
}
