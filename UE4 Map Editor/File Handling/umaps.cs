using System;
using System.Collections.Generic;
using UAssetAPI;
using UAssetAPI.PropertyTypes;

public class umaps
{
    public static Dictionary<int, int> LoadUmap(string map, string UEVersion)
    {
        Dictionary<int, int> objects = new Dictionary<int, int>();
        UEVersion = UEVersion.Replace("4.", "VER_UE4_");
        UE4Version version = UE4Version.UNKNOWN;
        foreach (var ver in Enum.GetValues(typeof(UE4Version)))
            if (ver.ToString().Equals(UEVersion)) version = (UE4Version)ver;

        UAsset Map = new UAsset(@map, version);

        for (int i = 0; i < Map.Exports.Count; i++)
            foreach (NormalExport export in Map.Exports)
                foreach (PropertyData property in export.Data)
                    if (property is ObjectPropertyData TransformIndex)
                        if (Map.Exports[int.Parse(TransformIndex.Value.ToString())] is NormalExport transform &&
                        transform.Data[0].Name.Equals(FName.FromString("RelativeLocation(0)")))
                            objects.Add(i, int.Parse(TransformIndex.Value.ToString()));
        return objects;
    }
}
