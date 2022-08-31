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
using System.Security.Cryptography.X509Certificates;
using Terraria.DataStructures;

namespace LeagueOfTerraria
{
	public class LeagueOfTerrariaPlayer : ModPlayer
	{
        //Flag for Blade of the Ruined King
        public bool borkEquipped;
        //Flag for BORK (siphon) passive cooldown
        public bool siphonCooldown;

        //Flag for Black Cleaver
		public bool canApplyBlackCleaverBuffs;
        //variable for rage stacking
        public int rageStacks;

        //Flag for IE crit calculation
        public bool perfection;

        //Flag for Serylda's slow debuff
        public bool bitterCold;
        
        //Flag for Vampiric Scepter being equipped
        public bool vampScepterEquipped;

        //Int for total life steal calculations
        public float healingAmount;

        //Flag set to false so they reset
        public override void ResetEffects()
        {
            healingAmount = 0;
            siphonCooldown = false;
            bitterCold = false;
            perfection = false;
            canApplyBlackCleaverBuffs = false;
        }

        /*will add effects later
        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            r = rageStacks * 40f;
        }
        */

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            int enemyLife;
            int enemyMaxLife;
            target.GetLifeStats(out enemyLife, out enemyMaxLife);

            if (borkEquipped)
            {
                //Calculating bonus damage for BORK passive
                int bonusDmg = (int)(enemyLife*0.12);
                if (bonusDmg < 15)
                    bonusDmg = 15;
                else if (bonusDmg > 60)
                    bonusDmg = 60;
                damage += bonusDmg;
            }

            if (canApplyBlackCleaverBuffs)
            {
                target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().IncrementCarve();
            }

            if (perfection && crit)
            {
                damage += (int)(damage*0.35);
            }
        }

        public override void ModifyHitNPCWithProj(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            int enemyLife;
            int enemyMaxLife;
            target.GetLifeStats(out enemyLife, out enemyMaxLife);

            //Calculating bonus damage for BORK passive
            if (borkEquipped)
            {
                int bonusDmg = (int)(enemyLife*0.08);
                if (bonusDmg < 15)
                    bonusDmg = 15;
                else if (bonusDmg > 60)
                    bonusDmg = 60;
                damage += bonusDmg;
            }

            if (canApplyBlackCleaverBuffs)
            {
                target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().IncrementCarve();
            }

            if (perfection && crit)
            {
                damage += (int)(damage * 0.35);
            }
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            //Checks for life steal increases
            if (vampScepterEquipped)
            {
                healingAmount += 0.03f;
            }

            if (borkEquipped)
            {
                healingAmount += 0.05f;
            }

            //Checks for item buffs
            if (borkEquipped)
            {
                if (!siphonCooldown)
                    target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().IncrementBORK();
                if (target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().borkStacks == 3)
                {
                    Player.AddBuff(ModContent.BuffType<SiphonBuff>(), 120);
                    target.AddBuff(ModContent.BuffType<SlowBuff>(), 120);
                    Player.AddBuff(ModContent.BuffType<SiphonCooldown>(), 1200);
                    target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().borkStacks = 0;
                }
            }

            if (bitterCold)
            {
                target.AddBuff(BuffID.Frostburn2, 60);
                target.AddBuff(ModContent.BuffType<SlowBuff>(), 60);
            }

            if (canApplyBlackCleaverBuffs)
            {
                if (!target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().carveDebuff)
                {
                    //resets buffer
                    target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().carveCountBuffer = 1;
                }
                else
                {
                    target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().IncrementCarve();
                }

                //Adds rage buff to player and carve debuff to enemy (1 second = 60 ticks)
                Player.AddBuff(ModContent.BuffType<RageBuff>(), 120);
                target.AddBuff(ModContent.BuffType<CarveBuff>(), 360);
                rageStacks = target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().carveCountBuffer;
            }

            //Life steal calculation
            healingAmount = (int)(damage*(healingAmount)/2);
            Player.statLife += (int)healingAmount;
            Player.HealEffect((int)healingAmount, true);
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            //Checks for life steal increases
            if (vampScepterEquipped)
            {
                healingAmount += 0.03f;
            }

            if (borkEquipped)
            {
                healingAmount += 0.05f;
            }

            //Checks for item buffs
            if (borkEquipped)
            {
                if (!siphonCooldown)
                    target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().IncrementBORK();
                if (target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().borkStacks == 3)
                {
                    Player.AddBuff(ModContent.BuffType<SiphonBuff>(), 120);
                    target.AddBuff(ModContent.BuffType<SlowBuff>(), 120);
                    Player.AddBuff(ModContent.BuffType<SiphonCooldown>(), 1200);
                    target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().borkStacks = 0;
                }
            }

            if (bitterCold)
            {
                target.AddBuff(BuffID.Frostburn2, 60);
                target.AddBuff(ModContent.BuffType<SlowBuff>(), 60);
            }

            if (canApplyBlackCleaverBuffs)
            {
                if (!target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().carveDebuff)
                {
                    target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().carveCountBuffer = 1;
                }
                else
                {
                    target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().IncrementCarve();
                }

                //Adds rage buff to player and carve debuff to enemy (1 second = 60 ticks)
                Player.AddBuff(ModContent.BuffType<RageBuff>(), 120);
                target.AddBuff(ModContent.BuffType<CarveBuff>(), 360);
                rageStacks = target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().carveCountBuffer;
            }

            //Life steal calculation
            healingAmount = (int)(damage*(healingAmount)/2);
            Player.statLife += (int)healingAmount;
            Player.HealEffect((int)healingAmount, true);
        }
    }
}