using UniRx;
using UnityEngine;

namespace Samples.Section3.Subjects.async
{
    public class PlayerTextureChanger : MonoBehaviour
    {
        [SerializeField] private GameResourceProvider _gameResourceProvider;

        private void Start()
        {
            _gameResourceProvider.PlayerTextureAsync
                .Subscribe(SetMyTexture)
                .AddTo(this);
        }

        private void SetMyTexture(Texture newTexture)
        {
            var r = GetComponent<Renderer>();
            r.sharedMaterial.mainTexture = newTexture;
        }
    }
}
