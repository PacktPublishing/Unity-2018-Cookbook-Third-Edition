using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using System.Collections;

public class AssetBundleLoader : MonoBehaviour
{
    public string bundleFolderName = "AssetBundles";
    public string bundleName = "chapter11";
    public string resourceName = "cube";

    public string host = "http://localhost:8000";
    void Start()
    {
        // method 1: UnityWebRequest - local file
        StartCoroutine(LoadAndInstantiateFromUnityWebRequest());

        // method 2: AssetBundle.LoadFromFile
      //  LoadAndInstantiateFromAssetBundleLoadFromFile();

        // method 3: UnityWebRequest - web hosted file
        //StartCoroutine(LoadAndInstantiateFromUnityWebRequestServer());
    }

    private IEnumerator LoadAndInstantiateFromUnityWebRequest()
    {
        // (1) load asset bundle
        string uri = "file:///" + Application.dataPath;
        uri = Path.Combine(uri, bundleFolderName);
        uri = Path.Combine(uri, bundleName);

        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(uri, 0);
        yield return request.SendWebRequest();

        // (2) extract 'cube' from loaded asset bundle
        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
        GameObject cube = bundle.LoadAsset<GameObject>(resourceName);

        // (3) create scene GameObject based on 'cube'
        Instantiate(cube);
    }

    void LoadAndInstantiateFromAssetBundleLoadFromFile()
    {
        // (1) load asset bundle
        string path = Path.Combine(Application.dataPath, bundleFolderName);
        path = Path.Combine(path, bundleName);
        AssetBundle myLoadedAssetBundle = AssetBundle.LoadFromFile(path);

        if (null == myLoadedAssetBundle)
        {
            Debug.Log("Failed to load AssetBundle: " + path);
            return;
        }

        // (2) extract 'cube' from loaded asset bundle
        GameObject prefabCube = myLoadedAssetBundle.LoadAsset<GameObject>(resourceName);

        // (3) create scene GameObject based on 'cube'
        Instantiate(prefabCube);
    }

    private IEnumerator LoadAndInstantiateFromUnityWebRequestServer()
    {
        // (1) load asset bundle: e.g. from
        //      http://localhost:8000/chapter11
        string uri = Path.Combine(host, bundleName);

        Debug.Log("loading from: " + uri);

        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(uri, 0);
        yield return request.SendWebRequest();

        // (2) extract 'cube' from loaded asset bundle
        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
        GameObject cube = bundle.LoadAsset<GameObject>(resourceName);

        // (3) create scene GameObject based on 'cube'
        Instantiate(cube);
    }
}