using UnityEditor;
using UnityEditor.iOS;

#if ENABLE_IOS_ON_DEMAND_RESOURCES
public class BuildODRExample
{
    [InitializeOnLoadMethod]
    static void SetupResourcesBuild()
    {
        UnityEditor.iOS.BuildPipeline.collectResources += CollectResources;
    }

    static UnityEditor.iOS.Resource[] CollectResources()
    {
        return new Resource[]
        {
           new Resource("iOS", "AssetBundles/iOS/iOS").AddOnDemandResourceTags("iOS"),
           new Resource("cube.unity3d", "AssetBundles/iOS/cube.unity3d").AddOnDemandResourceTags("cube.unity3d"),
           new Resource("resource", "path/to/resource.file").AddOnDemandResourceTags("resource_tag"),
        };
    }
}
#endif
