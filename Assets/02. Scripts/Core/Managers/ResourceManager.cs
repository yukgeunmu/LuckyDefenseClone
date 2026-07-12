using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


namespace LuckyDefense.Core.Manager
{
    public class ResourceManager
    {
        private readonly Dictionary<object, AsyncOperationHandle> _assetCache = new Dictionary<object, AsyncOperationHandle>();


        public async UniTask<T> LoadAsync<T>(AssetReference assetRef) where T : UnityEngine.Object
        {
            object key = assetRef.RuntimeKey;

            if (_assetCache.TryGetValue(key, out AsyncOperationHandle cachedHandle))
            {
                if (cachedHandle.Status != AsyncOperationStatus.Failed)
                {
                    var typedHandle = cachedHandle.Convert<T>();
                    await typedHandle;

                    if (typedHandle.Status == AsyncOperationStatus.Succeeded)
                        return typedHandle.Result;

                    _assetCache.Remove(key);

                    return null;
                }

                _assetCache.Remove(key);

            }

            AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(assetRef);

            _assetCache[key] = handle;

            await handle;

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                _assetCache.Remove(key);

                Debug.LogError($"[ResourceManager] 에셋 로드 실패. Key: {key}");

                return null;
            }

            return handle.Result;
        }

        public void Unload(AssetReference assetRef)
        {
            if (assetRef == null || !assetRef.RuntimeKeyIsValid()) return;

            object key = assetRef.RuntimeKey;

            if (_assetCache.TryGetValue(key, out AsyncOperationHandle handle))
            {
                Addressables.Release(handle);
                _assetCache.Remove(key);
            }
        }

        public void Clear()
        {
            foreach (var handle in _assetCache.Values)
            {
                if (handle.IsValid())
                {
                    Addressables.Release(handle);
                }
            }
            _assetCache.Clear();
        }

    }

}
