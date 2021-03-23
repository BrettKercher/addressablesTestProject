using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

public class Manager : MonoBehaviour {

    public AssetLabelReference RemoteNumberLabel;
    public AssetLabelReference LocalNumberLabel;

    private List<IResourceLocation> _remoteNumbers;
    private List<IResourceLocation> _localNumbers;

    private void Start() {
        Addressables.LoadResourceLocationsAsync(LocalNumberLabel.labelString).Completed += LocalLocationLoaded;
        Addressables.LoadResourceLocationsAsync(RemoteNumberLabel.labelString).Completed += RemoteLocationLoaded;
    }

    private void RemoteLocationLoaded(AsyncOperationHandle<IList<IResourceLocation>> obj) {
        _localNumbers = new List<IResourceLocation>(obj.Result);
        StartCoroutine(SpawnRemoteNumbers(3, _localNumbers));
    }

    private void LocalLocationLoaded(AsyncOperationHandle<IList<IResourceLocation>> obj) {
        _remoteNumbers = new List<IResourceLocation>(obj.Result);
        StartCoroutine(SpawnRemoteNumbers(0, _remoteNumbers));
    }

    private IEnumerator SpawnRemoteNumbers(int yOffset, IEnumerable<IResourceLocation> numbers) {
        yield return new WaitForSeconds(1f);
        var xOffset = -4.0f;

        foreach (var num in numbers) {
            var spawnPosition = new Vector3(xOffset, yOffset, 0);
            Addressables.InstantiateAsync(num, spawnPosition, Quaternion.identity);
            xOffset += 2.5f;
            yield return new WaitForSeconds(1f);
        }
    }
}