using OpenTK;
using UAssetAPI;

namespace UE4MapEditor;

class Actor
{
    public int ExportIndex;
    public int TransformIndex;
    public string Name = "Actor";
    public Actor(int exportIndex, int transformIndex, string name, UAsset Map)
    {
        ExportIndex = exportIndex;
        TransformIndex = transformIndex;
        Name = name;
        if (Map.Exports[TransformIndex] is NormalExport transform)
        {
            //get the transforms using this
        }
    }
    Vector3 Location;
    Vector3 Rotation;
    Vector3 Scale;
}
