using UnityEditor;
using UnityEditor.iOS;

#if ENABLE_IOS_APP_SLICING
public class BuildAppSlicingResources
{
    [InitializeOnLoadMethod]
    static void SetupResourcesBuild()
    {
        UnityEditor.iOS.BuildPipeline.collectResources += CollectResources;
    }

    static UnityEditor.iOS.Resource[] CollectResources()
    {
        var iPadRequirement = new iOSDeviceRequirement();
        iPadRequirement.values.Add("idiom", "ipad");

        return new Resource[]
        {
       // simple sliced resource
       new Resource("variants/myassets").BindVariant("AssetBundles/iOS/variants/myassets.hd", "hd")
                        .BindVariant("AssetBundles/iOS/variants/myassets.sd", "sd"),
 
       // sliced ODR resource
       new Resource("variants/odrassets").BindVariant("AssetBundles/iOS/variants/odrassets.hd", "hd")
                        .BindVariant("AssetBundles/iOS/variants/odrassets.sd", "sd")
                        .AddOnDemandResourceTags("variants/odrassets"),
 
       // custom device requirements
       new Resource("variants/odrassets2").BindVariant("AssetBundles/iOS/variants/odrassets2.hd", iPadRequirement)
                        .BindVariant("AssetBundles/iOS/variants/odrassets2.sd", new iOSDeviceRequirement())
                        .AddOnDemandResourceTags("variants/odrassets2")
        };
    }
}
#endif