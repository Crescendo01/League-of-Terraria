using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using LeagueOfTerraria.Buffs;
using System.Security.Cryptography.X509Certificates;
using LeagueOfTerraria.Items;

namespace LeagueOfTerraria.NPCS
{
	public class LeagueOfTerrariaGlobalNPC : GlobalNPC
	{
        //variable for BORK (siphon) stacks
        public int borkStacks;

        //Flag for Black Cleaver's debuff
        public bool carveDebuff;
        //variables for carve stacks
        public int carveCount;
        public int carveCountBuffer;

        //variable for kraken stacks
        public int krakenStacks = 1;

        //Flag for Serylda's Slow Debuff
        public bool slowDebuff;

        public override bool InstancePerEntity => true;

        //Resets the debuff
        public override void ResetEffects(NPC npc)
        {
            //black cleaver resets
            slowDebuff = false;
            carveDebuff = false;
            carveCount = 0;
        }
        
        //Gives player visual when enemy is affected by carve
        public override void DrawEffects(NPC npc, ref Color DrawColor)
        {
            if (carveDebuff)
            {
                //DrawColor = new Color(254, 121, 104);
                DrawColor = new Color(255, carveCount * 40, 0);
            
            }

            /* make dust for this and carve
            if (slowDebuff)
            {
                DrawColor = new Color(0, 0, 255);
            }
            */
        }

        public void IncrementBORK()
        {
            if (borkStacks < 3)
                borkStacks++;
        }

        public void IncrementCarve()
        {
            if (carveCountBuffer < 6)
                carveCountBuffer++;
        }

        public void IncrementKraken()
        {
            if (krakenStacks < 3)
                krakenStacks++;
        }

        public override void PostAI(NPC npc)
        {
            if (slowDebuff)
            { 
                npc.velocity.X *= 0.95f;
                npc.velocity.Y *= 0.95f;
            }
        }

        //carve debuff calculation
        public override bool StrikeNPC(NPC npc, ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            if (carveDebuff)
            {
                damage = damage - (defense - defense * 0.05 * carveCount) * 0.5;
                return false;
            }
            return true;
        }
    }
}