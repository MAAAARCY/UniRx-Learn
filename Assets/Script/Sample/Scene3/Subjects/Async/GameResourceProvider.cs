using System;
using System.Collections;
using UniRx;
using UnityEngine;

namespace Samples.Section3.Subjects.async
{
    public class GameResourceProvider : MonoBehaviour
    {
        private readonly AsyncSubject<Texture> _playerTextureAsyncSubject = new AsyncSubject<Texture>(); //プレイヤーのテクスチャ情報を扱うAsyncSubject

        public IObservable<Texture> PlayerTextureAsync => _playerTextureAsyncSubject; //プレイヤのテクスチャ情報

        private void Start()
        {
            StartCoroutine(LoadTexture()); //起動時にテクスチャをロードする
        }

        private IEnumerator LoadTexture()
        {
            var resource = Resources.LoadAsync<Texture>("Textures/player"); //プレイヤーのテクスチャを非同期で読み込み

            yield return resource;

            _playerTextureAsyncSubject.OnNext(resource.asset as Texture);
            _playerTextureAsyncSubject.OnCompleted();
        }
    }
}
