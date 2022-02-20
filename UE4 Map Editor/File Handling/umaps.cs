using GL_EditorFramework.EditorDrawables;
using System;
using System.Collections.Generic;
using UAssetAPI;
using UAssetAPI.PropertyTypes;

namespace UE4_Map_Editor.File_Handling
{
    internal partial class umaps
    {
        public static List<TransformableObject> LoadUmap(string map, string UEVersion)
        {
            List<TransformableObject> objects = new List<TransformableObject>();
            UEVersion = UEVersion.Replace("4.", "VER_UE4_");
            UE4Version version = UE4Version.UNKNOWN;
            foreach (var ver in Enum.GetValues(typeof(UE4Version)))
                if (ver.ToString() == UEVersion) version = (UE4Version)ver;

            UAsset Map = new UAsset(@map, version);

            foreach (NormalExport export in Map.Exports)
                foreach (var property in export.Data)
                    if (property.Name == FName.FromString("RootComponent")&&property is ObjectPropertyData transformindex)
                        if(Map.Exports[int.Parse(transformindex.Value.ToString())] is NormalExport transform)
                            foreach(var prop in transform.Data)
        }
    }
}
