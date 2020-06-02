using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

public class Manager : MonoBehaviour {
    public AssetReference localNumber;
    public AssetLabelReference NumberLabel;
    private List<IResourceLocation> _remoteNumbers;

    // Start is called before the first frame update
    void Start() {
        DisplayNumber();
        Addressables.LoadResourceLocationsAsync(NumberLabel.labelString).Completed += LocationLoaded;
    }

    private void DisplayNumber() {
        // local prefab:
        localNumber.InstantiateAsync(Vector3.zero, Quaternion.identity);
    }

    private void LocationLoaded(AsyncOperationHandle<IList<IResourceLocation>> obj) {
        _remoteNumbers = new List<IResourceLocation>(obj.Result);
        StartCoroutine(SpawnRemoteNumbers());
    }

    private IEnumerator SpawnRemoteNumbers() {
        yield return new WaitForSeconds(1f);
        var xOffset = -4.0f;

        foreach (var num in _remoteNumbers) {
            var spawnPosition = new Vector3(xOffset, 3, 0);
            Addressables.InstantiateAsync(num, spawnPosition, Quaternion.identity);
            xOffset += 2.5f;
            yield return new WaitForSeconds(1f);
        }
    }
}