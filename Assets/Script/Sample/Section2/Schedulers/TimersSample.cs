using System;
using System.Threading;
using UniRx;
using UnityEngine;

namespace Samples.Section2.Schedulers
{
    public class TimersSample : MonoBehaviour
    {
        //private IDisposable _disposable;
        private void Start() 
        {
            //MainThread,「1秒経過直後に実行されたUpdate()」と同じタイミングで実行
            Observable.Timer(TimeSpan.FromSeconds(1), Scheduler.MainThread)
                .Subscribe(x => Debug.Log("1秒経過しました"))
                .AddTo(this);

            //未指定のためMainThread
            Observable.Timer(TimeSpan.FromSeconds(1))
                .Subscribe(x => Debug.Log("1秒経過しました"))
                .AddTo(this);

            //MainThreadEndOfFrame,「1秒経過直後のフレームレンダリング後」に実行される
            Observable.Timer(TimeSpan.FromSeconds(1), Scheduler.MainThreadEndOfFrame)
                .Subscribe(x => Debug.Log("1秒経過しました"))
                .AddTo(this);
            
            //新しく作ったスレッド上でタイマのカウントを実行する
            new Thread(() =>
            {
                //CurrentThreadを指定するとそのまま同じスレッド上で処理を実行する
                Observable.Timer(TimeSpan.FromSeconds(2), Scheduler.CurrentThread)
                    .Subscribe(x => 
                    {
                        Debug.Log("Thread Id:" + Thread.CurrentThread.ManagedThreadId);
                        Debug.Log("1秒経過しました");
                    })
                    .AddTo(this);
            }).Start();
        }
    }
}
