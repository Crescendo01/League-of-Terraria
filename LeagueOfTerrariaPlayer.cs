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
using rail;

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

        //Flag for hearthbound axe being equipped
        public bool hearthboundEquipped;

        //Flag for IE crit calculation
        public bool perfection;

        //Flag for kraken slayer being equipped
        public bool krakenSlayerEquipped;
        //flag for max kraken stacks
        public bool maxKrakenStacks;

        //Flags for lich bane
        public bool lichBaneEquipped;
        public bool lichBaneBuffActive;
        public bool lichBaneCooldown;

        //Flag for Nashor's Tooth ap calculation
        public bool nashorsEquipped;

        //Flag for Serylda's slow debuff
        public bool bitterCold;

        //Flags for sheen being equipped and its buffs
        public bool sheenEquipped;
        public bool sheenBuffActive;
        public bool sheenCooldown;

        //Flag for Vampiric Scepter being equipped
        public bool vampScepterEquipped;

        //Flag for Wit's End being equipped
        public bool witsEndEquipped;

        //Int for total life steal calculations
        public float healingAmount;

        //Int for the amount of legendary items (used for the mythic passive calculations)
        public int legendaryItems;

        //Flags set to false so they reset
        public override void ResetEffects()
        {
            legendaryItems = 0;
            healingAmount = 0;
            borkEquipped = false;
            siphonCooldown = false;
            bitterCold = false;
            krakenSlayerEquipped = false;
            lichBaneEquipped = false;
            lichBaneBuffActive = false;
            lichBaneCooldown = false;
            maxKrakenStacks = false;
            hearthboundEquipped = false;
            nashorsEquipped = false;
            perfection = false;
            sheenBuffActive = false;
            sheenCooldown = false;
            sheenEquipped = false;
            witsEndEquipped = false;
            canApplyBlackCleaverBuffs = false;
        }

        /*will add effects later
        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            r = rageStacks * 40f;
        }
        */

        public override void PostUpdate()
        {
            if (krakenSlayerEquipped)
            {
                Player.GetAttackSpeed(DamageClass.Melee) += legendaryItems * 0.1f;
                Player.GetAttackSpeed(DamageClass.Ranged) += legendaryItems * 0.1f;
            }
        }

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

            if (lichBaneBuffActive && lichBaneCooldown == false)
            {
                damage += (int)(damage * 0.75) + (int)(Player.GetDamage(DamageClass.Generic).Flat * 0.5);
            }

            if (maxKrakenStacks)
            {
                damage += 30 + (int)(Player.GetDamage(DamageClass.Melee).Flat * 0.4);
                Player.ClearBuff(ModContent.BuffType<BringItDown>());
            }

            if (nashorsEquipped)
            {
                damage += 15 + (int)(Player.GetDamage(DamageClass.Magic).Flat * 0.2);
                damage += 15 + (int)(Player.GetDamage(DamageClass.Summon).Flat * 0.2);
            }

            if (perfection && crit)
            {
                damage += (int)(damage*0.35);
            }

            if (sheenBuffActive && sheenCooldown == false)
            {
                damage += (int)(damage * 0.5);
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

            if (lichBaneBuffActive && lichBaneCooldown == false)
            {
                damage += (int)(damage * 0.75) + (int)(Player.GetDamage(DamageClass.Generic).Flat * 0.5);
            }

            if (nashorsEquipped)
            {
                damage += 15 + (int)(Player.GetDamage(DamageClass.Magic).Flat * 0.2);
                damage += 15 + (int)(Player.GetDamage(DamageClass.Summon).Flat * 0.2);
            }

            if (maxKrakenStacks)
            {
                damage += 30 + (int)(Player.GetDamage(DamageClass.Melee).Flat * 0.4);
                Player.ClearBuff(ModContent.BuffType<BringItDown>());
            }

            if (perfection && crit)
            {
                damage += (int)(damage * 0.35);
            }

            if (sheenBuffActive && sheenCooldown == false)
            {
                damage += (int)(damage * 0.5);
            }
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            //Checks flags for life steal increases
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

            if (krakenSlayerEquipped)
            {
                target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().IncrementKraken();
                if (target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().krakenStacks == 3)
                {
                    Player.AddBuff(ModContent.BuffType<BringItDown>(), 180);
                    target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().krakenStacks = 0;
                }
            }

            if (lichBaneEquipped && !lichBaneBuffActive && !lichBaneCooldown)
            {
                Player.AddBuff(ModContent.BuffType<LichBaneActive>(), 600);
            }

            if (lichBaneBuffActive && lichBaneCooldown == false)
            {
                lichBaneBuffActive = false;
                Player.ClearBuff(ModContent.BuffType<LichBaneActive>());
                Player.AddBuff(ModContent.BuffType<LichBaneInactive>(), 180);
            }

            if (hearthboundEquipped)
            {
                Player.AddBuff(ModContent.BuffType<NimbleBuffMelee>(), 120);
            }

            if (sheenEquipped && !sheenBuffActive && !sheenCooldown)
            {
                Player.AddBuff(ModContent.BuffType<SheenActive>(), 600);
            }

            if (sheenBuffActive && sheenCooldown == false)
            {
                sheenBuffActive = false;
                Player.ClearBuff(ModContent.BuffType<SheenActive>());
                Player.AddBuff(ModContent.BuffType<SheenInactive>(), 180);
            }

            if (witsEndEquipped)
            {
                Player.AddBuff(ModContent.BuffType<FrayBuff>(), 120);
            }

            //Life steal calculation
            if (healingAmount > 0)
            {
                healingAmount = (int)(damage*(healingAmount)/2);
                Player.statLife += (int)healingAmount;
                Player.HealEffect((int)healingAmount, true);
            }
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

            if (krakenSlayerEquipped)
            {
                target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().IncrementKraken();
                if (target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().krakenStacks == 3)
                {
                    Player.AddBuff(ModContent.BuffType<BringItDown>(), 180);
                    target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().krakenStacks = 0;
                }
            }

            if (lichBaneEquipped && !lichBaneBuffActive && !lichBaneCooldown)
            {
                Player.AddBuff(ModContent.BuffType<LichBaneActive>(), 600);
            }

            if (lichBaneBuffActive && lichBaneCooldown == false)
            {
                lichBaneBuffActive = false;
                Player.ClearBuff(ModContent.BuffType<LichBaneActive>());
                Player.AddBuff(ModContent.BuffType<LichBaneInactive>(), 180);
            }

            if (hearthboundEquipped)
            {
                Player.AddBuff(ModContent.BuffType<NimbleBuffRanged>(), 120);
            }

            if (sheenEquipped && !sheenBuffActive && !sheenCooldown)
            {
                Player.AddBuff(ModContent.BuffType<SheenActive>(), 600);
            }

            if (sheenBuffActive && sheenCooldown == false)
            {
                sheenBuffActive = false;
                Player.ClearBuff(ModContent.BuffType<SheenActive>());
                Player.AddBuff(ModContent.BuffType<SheenInactive>(), 180);
            }

            if (witsEndEquipped)
            {
                Player.AddBuff(ModContent.BuffType<FrayBuff>(), 120);
            }

            //Life steal calculation
            if (healingAmount > 0)
            {
                healingAmount = (int)(damage*(healingAmount)/2);
                Player.statLife += (int)healingAmount;
                Player.HealEffect((int)healingAmount, true);
            }
        }
    }
}