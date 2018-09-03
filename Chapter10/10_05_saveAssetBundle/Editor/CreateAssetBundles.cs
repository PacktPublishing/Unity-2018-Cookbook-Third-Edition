using UnityEditor;

public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles/Mac")]
    static void BuildAllAssetBundlesMac()
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneOSX);
    }

    [MenuItem("Assets/Build AssetBundles/Windows")]
    static void BuildAllAssetBundlesWindows()
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}