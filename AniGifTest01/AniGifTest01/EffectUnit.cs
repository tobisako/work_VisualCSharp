using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AniGifTest01
{
    class EffectUnit : BaseImageUnit
    {
        int effect_life;
        int max_life;

        // コンストラクタ
        public EffectUnit() { }
        public EffectUnit(FieldControl fc, int mlife )
        {
            this.ref_fc = fc;
            effect_life = 0;
            max_life = mlife;
        }

        // ユニットアクション（仮想関数のオーバーライド）
        public override void DoUnit()
        {
            effect_life++;
            if (effect_life > max_life)
            {
                this.bKilled = true;       // 燃え尽きた。
            }
            DoUnitBaseAction();
        }

        // 自分と相手に当たり判定が必要か判定する（仮想関数のオーバーライド）
        public override Boolean NeedsCollisionCheck(UnitType other_unit_type)
        {
            return false;       // 「背景」は誰とも衝突しない。
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
