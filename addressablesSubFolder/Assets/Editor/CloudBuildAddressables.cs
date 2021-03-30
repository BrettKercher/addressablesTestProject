using UnityEditor;
using UnityEditor.AddressableAssets.Build;
using UnityEngine;

public class CloudBuildAddressables : MonoBehaviour
{
    [MenuItem("UCB/BuildAddressables")]
    private static void BuildAddressables()
    {
        BuildScript.buildCompleted += OnBuildComplete;
        UnityEditor.AddressableAssets.Settings.AddressableAssetSettings.CleanPlayerContent();
        UnityEditor.AddressableAssets.Settings.AddressableAssetSettings.BuildPlayerContent();
    }
    
    [MenuItem("UCB/CleanAddressables")]
    private static void CleanAddressables()
    {
        UnityEditor.AddressableAssets.Settings.AddressableAssetSettings.CleanPlayerContent();
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

// AddressableAssetBuildResult.FileRegistry.GetFilePaths();