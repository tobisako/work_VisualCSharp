using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AniGifTest01
{
    // プレイヤーユニット
    class PlayerUnit : BaseImageUnit
    {
        int mov_vol_x;      // 移動量
        int mov_vol_y;      // 移動量

        // コンストラクタ
        public PlayerUnit() { }
        public PlayerUnit(FieldControl fc)
        {
            this.ref_fc = fc;
        }

        // キー入力をプレイヤーキャラに伝えてあげる。
        public void SetKeyNotice(Boolean bUp, Boolean bDown, Boolean bLeft, Boolean bRight)
        {
            // 上下
            if (bUp)
            {
                mov_vol_y = -2;
            }
            else if (bDown)
            {
                mov_vol_y = 2;
            }
            else
            {
                mov_vol_y = 0;
            }

            // 左右
            if (bLeft)
            {
                mov_vol_x = -2;
            }
            else if (bRight)
            {
                mov_vol_x = +2;
            }
            else
            {
                mov_vol_x = 0;
            }
        }

        // ユニットアクション（仮想関数のオーバーライド）
        public override void DoUnit()
        {
            DoPlayerUnit();
            DoUnitBaseAction();
        }

        // プレイヤーキャラのユニットアクション
        private void DoPlayerUnit()
        {
            // Ｙ座標移動
            this.dPosY += mov_vol_y;
            
            // Ｘ座標移動
            this.dPosX += mov_vol_x;
            if (this.dPosX <= 0) this.dPosX = 0;
        }

        // 自分と相手に当たり判定が必要か判定する（仮想関数のオーバーライド）
        public override Boolean NeedsCollisionCheck(UnitType other_unit_type)
        {
            // 相手が「敵」だったら、当たり判定せな。
            if (other_unit_type == UnitType.UnitType_EnemyUnit)
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
            // もしかして自分死んでる？
            if (this.bKilled)
            {
                // 「俺、死んでます。」と、フィールドに連絡。
                ref_fc.NoticePlayerDead();
            }
        }
    }
}
