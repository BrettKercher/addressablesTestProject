using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;

public class NonAddressableManager : MonoBehaviour {

    [SerializeField] private GameObject[] _numbers;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SpawnNumbers(0, _numbers));
    }
    
    private IEnumerator SpawnNumbers(int yOffset, GameObject[] numbers) {
        yield return new WaitForSeconds(1f);
        var xOffset = -4.0f;

        foreach (var num in numbers) {
            var spawnPosition = new Vector3(xOffset, yOffset, 0);
            GameObject.Instantiate(num, spawnPosition, Quaternion.identity);
            xOffset += 2.5f;
            yield return new WaitForSeconds(1f);
        }
    }

}
