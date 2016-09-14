using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace hogedef
{
    public enum gamen
    {
        GAMEN_UNKNOWN = 0,
        GAMEN_01,
        GAMEN_02,
        GAMEN_03,
        GAMEN_04,
        GAMEN_05,
        GAMEN_LAST
    };
}

namespace GameSen3
{
    public static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
