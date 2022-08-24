using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using LeagueOfTerraria.NPCS;
using LeagueOfTerraria.Buffs;

namespace LeagueOfTerraria
{
	public class LeagueOfTerrariaPlayer : ModPlayer
	{
        //Flag for Black Cleaver
		public bool canApplyBlackCleaverBuffs;

        //Flag for IE
        public bool perfection;
        
        //Flag set to false so they reset
        public override void ResetEffects()
        {
            perfection = false;
            canApplyBlackCleaverBuffs = false;
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (perfection && crit)
            {
                damage += (int)(damage*0.35);
            }
        }

        public override void ModifyHitNPCWithProj(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (perfection && crit)
            {
                damage += (int)(damage * 0.35);
            }
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (canApplyBlackCleaverBuffs)
            {
                //Adds rage buff and makes it 2 seconds long (1 second = 60 ticks)
                Player.AddBuff(ModContent.BuffType<RageBuff>(), 120);
                target.AddBuff(ModContent.BuffType<CarveBuff>(), 180);
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (canApplyBlackCleaverBuffs)
            {
                //Adds rage buff and makes it 2 seconds long (1 second = 60 ticks)
                Player.AddBuff(ModContent.BuffType<RageBuff>(), 120);
                target.AddBuff(ModContent.BuffType<CarveBuff>(), 180);
                
            }
        }
    }
}