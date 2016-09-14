using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AniGifTest01
{
    class EnemyBossUnit : BaseImageUnit
    {
        int mov_vol_x;
        Random cRandom;

        // コンストラクタ
        public EnemyBossUnit() { }
        public EnemyBossUnit(FieldControl fc)
        {
            this.ref_fc = fc;
            mov_vol_x = 2;
            hp = 50;
            cRandom = new System.Random();
        }

        // ユニットアクション（仮想関数のオーバーライド）
        public override void DoUnit()
        {
            DoEnemyBossUnit();
            Shoooot();
            DoUnitBaseAction();
        }

        // 敵ユニット・アクション
        private void DoEnemyBossUnit()
        {
            // 乱数で移動のアクセントを
            if (cRandom.Next(100) < 2)
            {
                mov_vol_x *= -1;    // 反転
            }

            // 移動処理
            this.dPosX += mov_vol_x;
            if (this.dPosX >= 500)
            {
                mov_vol_x = -2;
            }
            if (this.dPosX <= 100)
            {
                mov_vol_x = 2;
            }
        }

        // 雑魚キャラを射出。フィールドに依頼する。
        private void Shoooot()
        {
            int iRandMax = 100;
            // ボスのダメージ状態で、弾の発生確率を変動。
            if (this.hp < 20)
            {
                iRandMax = 10;
            }

            // 乱数で発生をチェック
            if (cRandom.Next(iRandMax) < 5)
            {
                // 乱数で弾速を算出
                double dSpd = cRandom.Next(500);
                dSpd /= 100;
                dSpd += 1.0;    // 最低速度

                // 移動方向と乱数で発射角度を算出
                double dAng;
                if (mov_vol_x > 0)
                {   // 右に進んでいる
                    dAng = cRandom.Next(90);
                }
                else
                {   // 左に進んでいる
                    dAng = cRandom.Next(90);
                    dAng += 90;
                }

                // フィールドに「弾」オブジェクト生成を依頼する。
                this.ref_fc.UnitAddEnemyBossShoooot(this.dPosX, this.dPosY, dSpd, dAng);
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

        private int before_hp;

        // 当たり判定前に呼び出される関数
        public override void BeforeCollisionCheck()
        {
            before_hp = this.hp;
        }

        // 当たり判定後に呼び出される関数
        public override void AfterCollisionCheck()
        {
            // 死んでる？
            if (this.bKilled)
            {
                ref_fc.NoticeBossDead();
            }

            // ダメージを受けた？
            if (this.hp < before_hp)
            {
                ref_fc.NoticeBossDamage(this.ePosX, this.ePosY);
            }
        }
    }
}
