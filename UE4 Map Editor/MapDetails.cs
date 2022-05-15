using UAssetAPI;

namespace UE4MapEditor;

public struct MapDetails
{
    public UAsset Map;
    public string filepath;
    public List<(int, int)> Objects;
}
