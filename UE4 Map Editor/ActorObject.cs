using GL_EditorFramework.EditorDrawables;
using OpenTK;

namespace UE4MapEditor;

public class ActorObject : TransformableObject
{
    public ActorObject((int, int) indexes, string name, Vector3 pos, Vector3 rot, Vector3 scale) : base(pos, rot, scale)
    {
        this.indexes = indexes;
        this.name = name;
    }

    //the first integer is the index of the object while the second is the index of the rootcomponent
    public (int, int) indexes;

    string name = "";

    public override string ToString() => name;
}

