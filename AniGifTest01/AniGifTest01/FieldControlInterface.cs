using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;   // ストップウォッチ用
using System.Windows.Forms;
using System.Drawing;

namespace AniGifTest01
{
    // イメージユニットの種別など。
    public enum UnitType
    {
        UnitType_BackGroundUnit,    // 背景
        UnitType_EnemyUnit,         // ざこ敵
        UnitType_EnemyBossUnit,     // ボス的
        UnitType_ShotUnit,          // 弾丸
        UnitType_PlayerUnit,        // プレイヤー
        UnitType_EffectUnit         // 効果（死亡時など）
    }
    
    // フィールド・コントロール
    public class FieldControl
    {
        // フィールド群
        HogeFormClass hoge_form;
        private int field_width;
        private int field_height;
        Stopwatch sw;
        Int64 sw_vsync_keeptime;
        Int64 sw_vsync_ticktime;
        Int64 sw_uint_keeptime;
        Int64 sw_unit_ticktime;
        List<BaseImageUnit> unit_idx;
        PlayerUnit player;

        // プロパティ
        public int FieldWidth
        {
            get
            {
                return field_width;
            }
        }
        public int FieldHeight
        {
            get
            {
                return field_height;
            }
        }

        // メソッド群
        public FieldControl() : this(800, 480)  // デフォルトは８００ｘ４８０にしとく。
        {
        }
        public FieldControl(int w, int h)
        {
            this.field_width = w;
            this.field_height = h;
            unit_idx = new List<BaseImageUnit>();
            this.StopWatchStart();
        }

        // スタート
        public void Start()
        {
            this.hoge_form = new HogeFormClass(this,field_width,this.field_height); // フォーム生成
            this.hoge_form.HogeStartShow();          // フォーム表示
            this.UnitInit();                    // ユニット初期化
            this.StopWatchStart();      // ストップウォッチ開始
            this.MainLoop();            // メインループ開始
        }

        // ユニット初期化
        private void UnitInit()
        {
            // 背景画像ユニット登録
            this.AddImageUnit(UnitType.UnitType_BackGroundUnit, "8814368.jpg", false, 10, 10);

            // 敵ユニット登録
            this.AddImageUnit(UnitType.UnitType_EnemyBossUnit, "toy_robot-m.gif", true, 220, 20, 1.8, 43.5);
            this.AddImageUnit(UnitType.UnitType_EnemyUnit, "atom-25.gif", true, 50, 50, 1.8, 43.5);
            this.AddImageUnit(UnitType.UnitType_EnemyUnit, "atom-25.gif", true, 0, 4, 2.8, 180.5);
            
            // ダルシム登録
            player = (PlayerUnit)this.AddImageUnit(UnitType.UnitType_PlayerUnit, "s_fighter-13.gif", true, 150, 350, 1.8, 43.5);
        }

        // メインループ
        public void MainLoop()
        {
            bool bLoop = true;

            while (bLoop)
            {
                Application.DoEvents(); // イベント処理（他タスクへ処理を回す）※「using System.Windows.Forms」で使える

                if( this.StopWatchWaitCheck4Unit() )
                {
                    this.KeyProcess();          // キー処理
                    this.DoAllUnit();           // フィールド上のオブジェクトを動かす
                    this.CollisionCheck();      // 衝突判定処理
                    this.RemoveKilledUnit();    // モジュール消去処理
                    this.AddUnitProcess();      // ユニット追加判定処理
                }

                if (this.StopWatchWaitCheck4VSync())
                {
                    this.hoge_form.DrawHogeForm();
                }

                if (!this.hoge_form.Visible)
                {
                    bLoop = false;
                }
            }
        }

        // キー処理
        private void KeyProcess()
        {
            // 主人公の移動
            player.SetKeyNotice(hoge_form.eKey_Up, hoge_form.eKey_Down, hoge_form.eKey_Left, hoge_form.eKey_Right);
        }

        // フィールド上の全ユニットを「動かす」。
        private void DoAllUnit()
        {
            // フィールドに登録されている全オブジェクトに「動け」と指示。
            foreach( BaseImageUnit obj in unit_idx )
            {
                obj.DoUnit();
            }
        }

        // 当たり判定一括処理
        private void CollisionCheck()
        {
            foreach (BaseImageUnit base_obj in unit_idx)
            {
                foreach (BaseImageUnit obj in unit_idx)
                {
                    // ２つのユニットの座標計算
                    base_obj.CollisionCheck(obj);     // 衝突した事を教えてあげる
                }
            }
        }

        // フィールドから消去する。
        private void RemoveKilledUnit()
        {
            unit_idx.RemoveAll(KilledCheck);
        }

        // 死亡フラグチェック・オブジェクト排除（関数「RemoveAll」から呼び出される）
        static bool KilledCheck(BaseImageUnit obj)
        {
            return obj.eKilled;     // この条件の要素をすべて削除
        }

        // フィールドに登録されている全オブジェクトを順番に「描画」する。
        public void DrawAllUnit(Graphics g)
        {
            foreach (BaseImageUnit obj in unit_idx)
            {
                obj.DrawUnit(g);
            }
        }

        // フィールドにユニットを追加する処理
        private void AddUnitProcess()
        {
            // 主人公が火を吐く？
            if (hoge_form.eKey_Space)
            {
                // ファイアー
                this.AddImageUnit(UnitType.UnitType_ShotUnit, "explosions-02.gif", true, player.ePosX, player.ePosY, 1.8, 43.5);
            }

            // 敵が弾を発射する？
            if (shot_flg)
            {
                // 敵ユニット登録
                this.AddImageUnit(UnitType.UnitType_EnemyUnit, "atom-25.gif", true, (int)shot_dPosX, (int)shot_dPosY, shot_dSpd, shot_dAng);
                shot_flg = false;
            }

            // 主人公が死亡？
            if (shibou_flg)
            {
                // 主人公死亡ユニット登録
                this.AddImageUnit(UnitType.UnitType_EffectUnit, "1387-2.gif", true, (int)player.ePosX, (int)player.ePosY, 50, 0);
                shibou_flg = false;
            }

            // ボスが被弾？
            if (boss_damage_flg)
            {
                // ボス被弾ユニット登録
                this.AddImageUnit(UnitType.UnitType_EffectUnit, "loadinfo.net.gif", true, (int)boss_dPosX, (int)boss_dPosY, 20, 0);
                boss_damage_flg = false;
            }

            // ボスが死亡？
            if (boss_shibou_flg)
            {
                // 主人公死亡ユニット登録
                this.AddImageUnit(UnitType.UnitType_EffectUnit, "1387-2.gif", true, (int)player.ePosX, (int)player.ePosY, 150, 0);
                shibou_flg = false;
            }
        }

        // 弾丸発射用プロパティ
        private double shot_dPosX;
        private double shot_dPosY;
        private double shot_dSpd;
        private double shot_dAng;
        private Boolean shot_flg = false;

        // 敵ボスが弾を発射したいと要求。
        public void UnitAddEnemyBossShoooot(double dPosX, double dPosY, double dSpd, double dAng)
        {
            shot_dPosX = dPosX;
            shot_dPosY = dPosY;
            shot_dSpd = dSpd;
            shot_dAng = dAng;
            shot_flg = true;
        }

        // 主人公死亡用プロパティ
        private Boolean shibou_flg = false;
        private Boolean boss_damage_flg = false;
        private Boolean boss_shibou_flg = false;
        private double boss_dPosX;
        private double boss_dPosY;

        // 主人公が死亡してしまったと自己申告
        public void NoticePlayerDead()
        {
            shibou_flg = true;  // 主人公死亡フラグＯＮ
        }

        // ボスが被弾したと自己申告
        public void NoticeBossDamage(double dPosX, double dPosY )
        {
            boss_dPosX = dPosX;
            boss_dPosY = dPosY;
            boss_damage_flg = true;
        }

        // ボスが死亡してしまったと自己申告
        public void NoticeBossDead()
        {
            boss_shibou_flg = true;
        }

        // ストップウォッチ・スタート
        private void StopWatchStart()
        {
            this.sw = new Stopwatch();
            this.sw.Start();
            this.sw_vsync_keeptime = this.sw_uint_keeptime = this.sw.ElapsedMilliseconds;
            this.sw_vsync_ticktime = 40;    // VSYNC
            this.sw_unit_ticktime = 30;     // UNIT ACTION
        }

        // ストップウォッチ・時間まち・時間経過チェック
        public bool StopWatchWaitCheck4Unit()
        {
            if (this.sw_uint_keeptime + this.sw_unit_ticktime < this.sw.ElapsedMilliseconds)
            {   // ティック時間を超えた希ガス
                this.sw_uint_keeptime = this.sw.ElapsedMilliseconds - (this.sw.ElapsedMilliseconds - this.sw_uint_keeptime - this.sw_unit_ticktime);
                return true;
            }
            return false;
        }

        // ストップウォッチ・時間まち（ＶＳＹＮＣ）
        public bool StopWatchWaitCheck4VSync()
        {
            if (this.sw_vsync_keeptime + this.sw_vsync_ticktime < this.sw.ElapsedMilliseconds)
            {   // ティック時間を超えた
                this.sw_vsync_keeptime = this.sw.ElapsedMilliseconds - (this.sw.ElapsedMilliseconds - this.sw_vsync_keeptime - this.sw_vsync_ticktime);
                return true;
            }
            return false;
        }

        // 現在の経過時間を取得する
        public Int64 GetNowTime()
        {
            return this.sw.ElapsedMilliseconds;
        }

        // フィールドに、イメージユニットを１つ追加する
        public BaseImageUnit AddImageUnit(UnitType ut, String str, bool b, int x, int y)
        {
            return AddImageUnit(ut, str, b, x, y, 0.0, 0.0);
        }
        public BaseImageUnit AddImageUnit(UnitType ut, String str, bool b, int x, int y, double dSpd, double dAng)
        {
            BaseImageUnit u;

            switch (ut)
            {   // ユニット種別毎のアクション処理へ分岐する。
                case UnitType.UnitType_BackGroundUnit:
                    u = (BaseImageUnit)new BackGroundUnit(this);
                    break;

                case UnitType.UnitType_EnemyBossUnit:
                    u = (BaseImageUnit)new EnemyBossUnit(this);
                    break;

                case UnitType.UnitType_EnemyUnit:
                    u = (BaseImageUnit)new EnemyUnit(this, dSpd, dAng);
                    //u.InitParam(dSpd, dAng);
                    break;

                case UnitType.UnitType_ShotUnit:
                    u = (BaseImageUnit)new ShotUnit(this);
                    break;

                case UnitType.UnitType_EffectUnit:
                    u = (BaseImageUnit)new EffectUnit(this, (int)dSpd );
                    break;

                case UnitType.UnitType_PlayerUnit:
                default:
                    u = (BaseImageUnit)new PlayerUnit(this);
                    break;
            }
            u.LoadImage(str, b, x, y);
            u.eImageUnitType = ut;
            unit_idx.Add(u);            // ユニットリストに追加。
            return u;
        }
    }
}
