using UAssetAPI;

namespace UE4MapEditor
{
    public partial class ObjectSelector : Form
    {
        public ObjectSelector(List<NormalExport> exports)
        {
            InitializeComponent();
            foreach (NormalExport export in exports)

        }
    }
}
