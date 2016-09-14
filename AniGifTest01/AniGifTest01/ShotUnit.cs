using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AniGifTest01
{
    // 「弾」クラス
    class ShotUnit : BaseImageUnit
    {

        // コンストラクタ
        public ShotUnit() { }
        public ShotUnit(FieldControl fc)
        {
            this.ref_fc = fc;
        }

        // ユニットを動かす（仮想関数のオーバーライド）
        public override void DoUnit()
        {
            DoShotUnit();
            DoUnitBaseAction();
        }

        // 弾ユニットを動かす
        private void DoShotUnit()
        {   // 背景ユニットの移動処理
            this.dPosY -= 10;

            if (this.dPosY < 10)
            {
                this.bKilled = true;     // 死亡
            }
        }

        // 自分と相手に当たり判定が必要か判定する（仮想関数のオーバーライド）
        public override Boolean NeedsCollisionCheck(UnitType other_unit_type)
        {
            // 相手が「敵」だったら、当たり判定せな。
            if (other_unit_type == UnitType.UnitType_EnemyUnit ||
                other_unit_type == UnitType.UnitType_EnemyBossUnit )
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
   
    }
}
