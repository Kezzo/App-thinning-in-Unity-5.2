using System;
using System.Collections;
using UnityEngine;
using UnityEngine.iOS;

public class LoadResources : MonoBehaviour {

	private void LoadResourcesOnDemand()
    {
        StartCoroutine(LoadAsset("asset.data", OnResourceLoaded));
    }

    private IEnumerator LoadAsset(string resourceName, Action<AssetBundle> onResourceLoadedCallback)
    {
        // Create the request
        OnDemandResourcesRequest request = OnDemandResources.PreloadAsync(new string[] { "resource_tag"});

        // Wait until request is completed
        yield return request;

        // Check for errors
        if (request.error != null)
            throw new Exception("ODR request failed: " + request.error);

        // Get path to the resource and use it. Note that at the moment the only API
        // that can load ODR or sliced resources is AssetBundle.CreateFromFile()
        string path = "res://" + resourceName;

        AssetBundle bundle = AssetBundle.CreateFromFile(path);

        onResourceLoadedCallback(bundle);

        // Call Dispose() when resource is no longer needed. This will release a pin on ODR resource.
        request.Dispose();
    }

    private void OnResourceLoaded(AssetBundle loadedAssetBundle)
    {
        // use loaded asset bundle.
    }
}
