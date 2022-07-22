using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UE4MapEditor;
internal static class Startup
{
    [DllImport("Shcore.dll")]
    static extern int SetProcessDpiAwareness(int PROCESS_DPI_AWARENESS);

    enum DpiAwareness
    {
        None = 0,
        SystemAware = 1,
        PerMonitorAware = 2
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        GL_EditorFramework.Framework.ShowShaderErrors = args.Contains("-shader_errors") || System.Diagnostics.Debugger.IsAttached;
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        SetProcessDpiAwareness((int)DpiAwareness.PerMonitorAware);
        Application.Run(new Editor());
    }
}