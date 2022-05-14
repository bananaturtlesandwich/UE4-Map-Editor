using GL_EditorFramework.EditorDrawables;
using OpenTK;

namespace UE4MapEditor;

public class NamedTransformableObject : TransformableObject
{
    public NamedTransformableObject(string name, Vector3 pos, Vector3 rot, Vector3 scale) : base(pos, rot, scale) =>
        this.name = name;

    string name = "";

    public override string ToString() => name;
}

