using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LocalAddressablesManager : MonoBehaviour
{
    [SerializeField] private AssetReference[] _references;
    
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SpawnNumbers(0, _references));
    }
    
    private IEnumerator SpawnNumbers(int yOffset, AssetReference[] numbers) {
        yield return new WaitForSeconds(1f);
        var xOffset = -4.0f;

        foreach (var num in numbers) {
            var spawnPosition = new Vector3(xOffset, yOffset, 0);
            num.InstantiateAsync(spawnPosition, Quaternion.identity);
            xOffset += 2.5f;
            yield return new WaitForSeconds(1f);
        }
    }
}
