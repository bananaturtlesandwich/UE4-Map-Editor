using GL_EditorFramework;
using GL_EditorFramework.EditorDrawables;
using GL_EditorFramework.GL_Core;
using GL_EditorFramework.Interfaces;
using OpenTK;

namespace UE4MapEditor;

//Basically just an empty object
public class Function : SingleObject
{
    public Function(string name) : base(Vector3.Zero) => this.name = "Function: " + name;
    string name = "";
    public override string ToString() => name;
    public override void Draw(GL_ControlModern control, Pass pass) { }
    public override void Draw(GL_ControlModern control, Pass pass, EditorSceneBase editorScene) { }
    public override bool TrySetupObjectUIControl(EditorSceneBase scene, ObjectUIControl objectUIControl) => Selected;
}
