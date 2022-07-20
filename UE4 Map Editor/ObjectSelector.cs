using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UAssetAPI;

namespace UE4MapEditor
{
    public partial class ObjectSelector : Form
    {
        (Button, Export)[] buttons;
        public ObjectSelector(List<Export> exports)
        {
            InitializeComponent();
            buttons = new (Button, Export)[exports.Count];
            for (int i = 0; i < exports.Count; i++)
            {
                buttons[i] = (
                    new Button()
                    {
                        Text = exports[i].ObjectName.Value.Value,
                        Parent = ButtonList,
                        Width = ButtonList.Width,
                        AutoSize = true,
                        CausesValidation = true
                    }, exports[i]
                );
                buttons[i].Item1.Click += AddActor;
            }
        }

        void AddActor(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                //Get a list of dependents and add in a way that works
            }
            Close();
        }
    }
}
