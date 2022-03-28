﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace UE4_Map_Editor
{
    static class Startup
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            GL_EditorFramework.Framework.ShowShaderErrors = args.Contains("-shader_errors") || Debugger.IsAttached;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Editor());
        }
    }
}
