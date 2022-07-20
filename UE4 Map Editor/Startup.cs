using System;
using System.Linq;
using System.Windows.Forms;

namespace UE4MapEditor;

internal static class Startup
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        GL_EditorFramework.Framework.ShowShaderErrors = args.Contains("-shader_errors") || System.Diagnostics.Debugger.IsAttached;
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        ApplicationConfiguration.Initialize();
        Application.Run(new Editor());
    }
}