using System;
using System.Linq;
using System.Windows.Forms;

namespace Map_Editor
{
    internal static class Startup
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            GL_EditorFramework.Framework.ShowShaderErrors = args.Contains("-shader_errors") || System.Diagnostics.Debugger.IsAttached;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Editor(args));
        }
    }
}
