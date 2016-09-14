using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace gamen_enum
{
    public enum gamen
    {
        GAMEN_00_LOGIN = 0,     // ログイン画面
        GAMEN_01,               // 画面その１
        GAMEN_02,               // 画面その２
        GAMEN_SPECIAL,          // スペシャル画面
        GAMEN_LAST              // ラスト認識用
    };
}

namespace MobaTes
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
            Application.Run(new Form1());
        }
    }
}
