using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TopoDroidTranslator
{
    public static class GlobalContext
    {
        static MainForm mainWindow;

        static string applicationTitle = "TopoDroid Symbol Translator";

        public static MainForm MainWindow { get => mainWindow; set => mainWindow = value; }
        public static string ApplicationTitle { get => applicationTitle; set => applicationTitle = value; }
    }
}
