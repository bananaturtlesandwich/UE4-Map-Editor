using GL_EditorFramework;
using GL_EditorFramework.EditorDrawables;
using OpenTK;

namespace UE4MapEditor;

class Actor : SingleObject
{
    public Actor(Vector3 pos) : base(pos) { }

    string name = "Actor";
    public override string ToString() => name;

    public override bool TrySetupObjectUIControl(EditorSceneBase scene, ObjectUIControl properties)
    {
        if (!Selected) return false;
        properties.AddObjectUIContainer(new PropertyProvider(this, scene), "Transform");
        properties.AddObjectUIContainer(new ActorProperties(this, scene), "Actor Properties");
        return true;
    }

    public class ActorProperties : IObjectUIContainer
    {
        string text = "";
        string longText = "";
        float number = 0;
        SingleObject obj;
        EditorSceneBase scene;

        public ActorProperties(SingleObject obj, EditorSceneBase scene)
        {
            this.obj = obj;
            this.scene = scene;
        }

        public void DoUI(IObjectUIControl control)
        {
            text = control.TextInput(text, "TextInput");
            longText = control.FullWidthTextInput(longText, "Long Text Input");
            number = control.NumberInput(number, "Number Input");
            control.Link("Just some Link");
            control.DoubleButton("Add", "Remove");
            control.TripleButton("Add", "Remove", "Insert");
            control.QuadripleButton("+", "-", "*", "/");

            control.Spacing(30);
            control.PlainText("Some Text");
        }

        public void OnValueChanged() => scene.Refresh();

        public void OnValueSet() { }

        public void UpdateProperties() { }

        public void OnValueChangeStart() { }
    }
}
