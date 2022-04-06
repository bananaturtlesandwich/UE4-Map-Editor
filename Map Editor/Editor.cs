using System.Windows.Forms;

namespace Map_Editor
{
    public partial class Editor : Form
    {
        private string[] arguments;
        public Editor(string[] args)
        {
            InitializeComponent();
            arguments = args;
        }

        private void OnLoad(object sender, System.EventArgs e)
        {
            if (arguments.Length > 0) MessageBox.Show(arguments[0]);
        }
    }
}
