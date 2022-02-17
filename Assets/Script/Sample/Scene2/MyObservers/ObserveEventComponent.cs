using System;
using UnityEngine;

namespace Samples.Section2.MyObservers
{
    class ObserveEventComponent : MonoBehaviour
    {
        [SerializeField]
        private CountDownEventProvider _countDownEventProvider;

        private PrintLogObserver<int> _printLogObserver;

        private IDisposable _disposable;

        private void Start()
        {
            _printLogObserver = new PrintLogObserver<int>();

            _disposable = _countDownEventProvider
                .CountDownObservable
                .Subscribe(_printLogObserver);
        }

        private void OnDestroy()
        {
            _disposable?.Dispose();
        }
    }
}