using System.Collections;
using UniRx;
using UnityEngine;

namespace Samples.Section3.ReactiveProperty
{
    public class ReactivePropertyTimerSample : MonoBehaviour
    {
        [SerializeField] private IntReactiveProperty _current = new IntReactiveProperty(60);

        public IReadOnlyReactiveProperty<int> CurrentTime => _current;

        private void Start()
        {
            StartCoroutine(CountDownCoroutine());
            _current.AddTo(this);
        }

        private IEnumerator CountDownCoroutine()
        {
            while (_current.Value > 0)
            {
                _current.Value--;
                Debug.Log(_current.Value);
                yield return new WaitForSeconds(1);
            }
        }
    }
}

