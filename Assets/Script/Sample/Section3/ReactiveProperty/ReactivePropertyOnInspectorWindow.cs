using UniRx;
using UnityEngine;

namespace Samples.Section3.ReactiveProperty
{
    public class ReactivePropertyOnInspectorWindow : MonoBehaviour
    {
        public ReactiveProperty<int> A;

        public IntReactiveProperty B;
    }
}