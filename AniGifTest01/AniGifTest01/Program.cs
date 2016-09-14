using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AniGifTest01
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //            Application.Run(new Form1());

            //HogeFormClass obj = new HogeFormClass();
            //obj.HogeStart();

            FieldControl fc = new FieldControl();
            fc.Start();
        }
    }
}
