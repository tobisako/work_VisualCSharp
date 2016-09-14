using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;


namespace AniGifTest01
{
    abstract public class BaseImageUnit
    {
        // フィールド
        protected UnitType unit_type;       // ユニット種別
        protected int hp;                             // ヒットポイント
        protected Boolean bKilled = false;  // 死亡フラグ
        protected FieldControl ref_fc;      // フィールドコントロールＩＦ(参照)
        protected Bitmap bmp;
        protected double dPosX;										// 座標Ｘ
        protected double dPosY;										// 座標Ｙ
        protected int width;            // 横幅
        protected int height;           // 縦幅
        bool bIsAnime;          // アニメＧＩＦですフラグ
        FrameDimension fd;      // アニメＧＩＦ用
        PropertyItem pitem;     // アニメＧＩＦ用
        int frame_count;        // アニメＧＩＦ用
        Int64 keeptime;									// 時間保存用
        Int64 nowtime;									// 現在時間
        Int64 ticktime;									// ティック時間管理値(33msecとか)
        const int PropertyTagFrameDelay = 0x5100;   // アニメＧＩＦ用

        // プロパティ
        public int ePosX
        {
            get
            {
                return (int)dPosX;
            }
        }
        public int ePosY
        {
            get
            {
                return (int)dPosY;
            }
        }
        public int eWidth
        {
            get
            {
                return (int)width;
            }
        }
        public int eHeight
        {
            get
            {
                return (int)height;
            }
        }
        public UnitType eImageUnitType
        {
            set
            {
                unit_type = value;
            }
            get
            {
                return unit_type;
            }
        }
        public Boolean eKilled
        {
            get
            {
                return bKilled;
            }
        }

        // コンストラクタ
        public BaseImageUnit() { }
        public BaseImageUnit(FieldControl fc)
        {
            this.ref_fc = fc;
            hp = 1;
        }

        // ＧＩＦアニメのパラパラ間隔(msec)を取得
        private int GetWaitTimeFromProperty( int no )
        {	// GIFアニメの各コマの待機時間は、プロパティ４バイト毎に格納されている。
	        return this.pitem.Value[no*4] + (this.pitem.Value[no*4+1] << 8) +
			        (this.pitem.Value[no*4+2] << 16) + (this.pitem.Value[no*4+3] << 24);
        }

        // イメージデータをロード
        public void LoadImage(String str, bool b, int x, int y)
        {
            this.bIsAnime = b;

            if (this.bIsAnime)
            {   // アニメGIFとして処理する（例外処理いれんとダメやで。）
                this.bmp = new Bitmap(str);
                this.width = this.bmp.Width;
                this.height = this.bmp.Height;
                this.fd = new FrameDimension(this.bmp.FrameDimensionsList[0]);
                this.frame_count = 0;
                this.pitem = this.bmp.GetPropertyItem(PropertyTagFrameDelay);
                this.ticktime = this.GetWaitTimeFromProperty(this.frame_count) * 10;
            }
            else
            {   // 静止画として処理する
                this.bmp = new Bitmap(str);
                this.width = this.bmp.Width;
                this.height = this.bmp.Height;
            }
            this.dPosX = (double)x;
            this.dPosY = (double)y;
        }

        // ユニット描画
        public void DrawUnit(Graphics g)
        {
            RectangleF SrcRect, DstRect;

            SrcRect = new RectangleF( 0, 0, this.bmp.Width, this.bmp.Height );
            DstRect = new RectangleF( (float)this.dPosX, (float)this.dPosY, this.bmp.Width, this.bmp.Height );
            g.DrawImage(this.bmp, DstRect, SrcRect, GraphicsUnit.Pixel);
        }

        // ユニットを動かす
        public abstract void DoUnit();  // 純粋仮想関数

        // 自分と相手に当たり判定が必要か判定する
        public abstract Boolean NeedsCollisionCheck(UnitType other_unit_type);  // 純粋仮想関数

        // 当たり判定前に子オブジェクトを呼び出す関数
        public abstract void BeforeCollisionCheck();    // 純粋仮想関数

        // 当たり判定後に子オブジェクトを呼び出す関数
        public abstract void AfterCollisionCheck();     // 純粋仮想関数

        // ユニット衝突判定処理
        public void CollisionCheck(BaseImageUnit obj)
        {
            // 判定前に子オブジェクトを呼び出す。
            BeforeCollisionCheck();

            // 当たり判定が必要な相手なのか？
            if (NeedsCollisionCheck(obj.eImageUnitType))
            {   // 当たり判定を実行する
                if (CollisionJudge(obj))
                {
                    this.hp--;                  // ヒットポイント・マイナス。
                    if (this.hp <= 0)
                    {
                        this.bKilled = true;    // 自分が死亡。
                    }
                }
            }

            // 判定後に子オブジェクトを呼び出す。
            AfterCollisionCheck();
        }

        // ユニット座標計算による衝突検知
        public Boolean CollisionJudge(BaseImageUnit obj)
        {
            int ax0 = this.ePosX;
            int ax1 = this.ePosX + this.eWidth;
            int ay0 = this.ePosY;
            int ay1 = this.ePosY + this.eHeight;
            int bx0 = obj.ePosX;
            int bx1 = obj.ePosX + obj.eWidth;
            int by0 = obj.ePosY;
            int by1 = obj.ePosY + obj.eHeight;

            if( ax0 <= bx1 &&
                ay0 <= by1 &&
                ax1 >= bx0 &&
                ay1 >= by0 )
            {
                return true;    // 衝突した
            }
            return false;       // 衝突してない。
        }

        // ユニット衝突通知（当たり判定後）
        public void CollisionNotice()
        {
            int a = 0;
            a++;
        }

        // ユニットの基本アクション
        protected void DoUnitBaseAction()
        {
            this.nowtime = this.ref_fc.GetNowTime();

            if (this.bIsAnime)	// GIFアニメ更新チェック
            {	// アニメGIFの時の処理
                if (this.keeptime + this.ticktime < this.nowtime)
                {	// ティック時間を超えた
                    this.keeptime = this.nowtime - (this.nowtime - this.keeptime - this.ticktime);
                    this.frame_count++;
                    if (this.frame_count >= this.bmp.GetFrameCount(this.fd)) this.frame_count = 0;
                    this.ChangeFrame();
                    this.ticktime = this.GetWaitTimeFromProperty(this.frame_count) * 10;
                }
            }
        }

        private void ChangeFrame()
        {   // ＧＩＦアニメのフレームを変更する
            this.bmp.SelectActiveFrame(this.fd, this.frame_count);
        }

    }
}
