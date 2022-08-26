using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using LeagueOfTerraria.Buffs;

namespace LeagueOfTerraria.NPCS
{
	public class LeagueOfTerrariaGlobalNPC : GlobalNPC
	{
        //Flag for Black Cleaver's debuff
        public bool carveDebuff;
        public override bool InstancePerEntity => true;

        //Resets the debuff
        public override void ResetEffects(NPC npc)
        {
            carveDebuff = false;
        }
        
        //Gives player visual when enemy is affected by carve
        public override void DrawEffects(NPC npc, ref Color DrawColor)
        {
            if (carveDebuff)
            {
                DrawColor = new Color(254, 121, 104);
            }
        }

        //carve debuff calculation
        public override bool StrikeNPC(NPC npc, ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            if (carveDebuff)
            {
                Main.CalculateDamageNPCsTake((int)damage, (int)(defense - defense * 0.07));
                return false;
            }
            return true;
        }
    }
}