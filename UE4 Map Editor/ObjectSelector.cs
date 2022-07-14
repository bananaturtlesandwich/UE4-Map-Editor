using UAssetAPI;

namespace UE4MapEditor
{
    class SelectorButton : Button
    {
        public SelectorButton(NormalExport Export) => export = Export;
        public NormalExport export;
    }

    public partial class ObjectSelector : Form
    {
        SelectorButton[] buttons;
        public ObjectSelector(List<NormalExport> exports)
        {
            InitializeComponent();
            buttons = new SelectorButton[exports.Count];
            for (int i = 0; i < exports.Count; i++)
            {
                buttons[i] = new SelectorButton(exports[i])
                {
                    Text = exports[i].ObjectName.Value.Value,
                    Parent = ButtonList,
                    Width = ButtonList.Width,
                    AutoSize = true,
                    CausesValidation = true
                };
                buttons[i].Click += AddActor;
            }
        }

        void AddActor(object? sender, EventArgs e)
        {
            if (sender is SelectorButton button)
            {
                //Get a list of dependents and add in a way that works
                List<NormalExport> dependents = new() { button.export };
            }
            Close();
        }
    }
}
