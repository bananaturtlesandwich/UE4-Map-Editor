using GL_EditorFramework.EditorDrawables;
using OpenTK;

namespace UE4MapEditor;

public class NamedTransformableObject : TransformableObject
{
    public NamedTransformableObject((int, int) indexes, string name, Vector3 pos, Vector3 rot, Vector3 scale) : base(pos, rot, scale)
    {
        this.indexes = indexes;
        this.name = name;
    }
    public (int, int) indexes;

    string name = "";

    public override string ToString() => name;
}

