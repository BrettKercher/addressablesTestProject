using UnityEditor;
using UnityEditor.AddressableAssets.Build;
using UnityEngine;

public class CloudBuildAddressables : MonoBehaviour
{
    [MenuItem("UCB/BuildAddressables")]
    private static void BuildAddressables()
    {
        BuildScript.buildCompleted += OnBuildComplete;
        UnityEditor.AddressableAssets.Settings.AddressableAssetSettings.BuildPlayerContent();
    }

    private static void OnBuildComplete(object result)
    {
        Debug.Log("Addressables Build Complete! The following files were created:");

        var filePaths = ((AddressableAssetBuildResult)result).FileRegistry.GetFilePaths();
        foreach (var path in filePaths)
        {
            Debug.Log(path);
        }

        BuildScript.buildCompleted -= OnBuildComplete;
    }
}
