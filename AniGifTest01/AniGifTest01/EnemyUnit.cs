using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AniGifTest01
{
    class EnemyUnit : BaseImageUnit
    {
        // プロパティ
        private double dSpeed;										// 推進速度
        private double dAngle;										// 進行角度(0～359.999くらいまで)
        public double dUnitSpeed
        {
            set
            {
                dSpeed = value;
            }
            get
            {
                return dSpeed;
            }
        }

        public double dUnitAngle
        {
            set
            {
                dAngle = value;
            }
            get
            {
                return dAngle;
            }
        }

        // コンストラクタ
        public EnemyUnit() { }
        public EnemyUnit(FieldControl fc, double dSpd, double dAgl)
        {
            this.ref_fc = fc;
            dSpeed = dSpd;
            dAngle = dAgl;
        }

        // 初期化関数
        private void InitParam(double dSpd, double dAgl)
        {
            dSpeed = dSpd;
            dAngle = dAgl;
        }

        // ユニットアクション（仮想関数のオーバーライド）
        public override void DoUnit()
        {
            DoEnemyUnit();
            DoUnitBaseAction();
        }

        // 敵ユニット・アクション
        private void DoEnemyUnit()
        {   // 敵ユニットの移動処理
            this.MoveUnitFromAngle();
            bool bReflection = this.JudgeReflection(this.ref_fc.FieldWidth, this.ref_fc.FieldHeight);
            if (bReflection)
            {
                // 反射した時に音とか出したかったらココ。
            }
        }

        // 自分と相手に当たり判定が必要か判定する（仮想関数のオーバーライド）
        public override Boolean NeedsCollisionCheck(UnitType other_unit_type)
        {
            // 相手が「弾」だったら当たり判定せな。
            if (other_unit_type == UnitType.UnitType_ShotUnit)
            {
                return true;    // 当たり判定が必要。
            }
            return false;       // 必要なし。
        }

        // 当たり判定前に呼び出される関数
        public override void BeforeCollisionCheck()
        {
        }

        // 当たり判定後に呼び出される関数
        public override void AfterCollisionCheck()
        {
        }

        // ユニット移動計算（角度）
        void MoveUnitFromAngle()
        {	// 移動速度(dSpeed)と角度(dAngle)を計算して、ユニットを移動する
            double movementX = (this.dSpeed * Math.Cos(this.dAngle * Math.PI / 180.0));
            double movementY = (this.dSpeed * Math.Sin(this.dAngle * Math.PI / 180.0));
            this.dPosX += movementX;
            this.dPosY += movementY;
        }

        // 反射判定
        private bool JudgeReflection(double width, double height)
        {	// 反射をジャッジし、必要に応じて
            bool bJudge = false;

            // 反射判定（Ｙ軸）
            if (this.dPosY >= (height - this.bmp.Height))	// 反射判定（下→上）
            {	// Ｙ軸下（1～179）
                if (this.dAngle < 180.0)	// 画面下へ向かっているか？
                {	// 反射角度を変更（下から上へ）
                    this.dAngle = 360.0 - this.dAngle;
                    bJudge = true;
                }
            }
            else if (this.dPosY <= 1.0)	// 反射判定（上→下）
            {	// Ｙ軸上（181～359）
                if (this.dAngle >= 180.0)
                {	// 反射角度を変更（上から下へ）
                    this.dAngle = 360.0 - this.dAngle;
                    bJudge = true;
                }
            }
            // 反射判定（Ｘ軸）
            else if (this.dPosX >= (width - this.bmp.Width))	// 反射判定（右→左）
            {	// Ｘ軸右（271～359, 1～89）
                if (this.dAngle > 270.0 || this.dAngle < 90.0)
                {
                    this.dAngle = 180.0 - this.dAngle;
                    if (this.dAngle < 0.0) this.dAngle = 360.0 + this.dAngle;	// マイナス化させない対策
                    bJudge = true;
                }
            }
            else if (this.dPosX <= 1.0)		// 反射判定（左→右）
            {	// Ｘ軸左（90～270）
                if (this.dAngle > 90.0 && this.dAngle < 270.0)
                {
                    this.dAngle = 180.0 - this.dAngle;
                    if (this.dAngle < 0.0) this.dAngle = 360.0 + this.dAngle;	// マイナス化させない対策
                    bJudge = true;
                }
            }
            return bJudge;
        }

    }
}
