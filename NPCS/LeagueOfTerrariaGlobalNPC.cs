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
        public bool carveDebuff;
        public override bool InstancePerEntity => true;

        public override void ResetEffects(NPC npc)
        {
            carveDebuff = false;
        }
        
        public override void DrawEffects(NPC npc, ref Color DrawColor)
        {
            if (carveDebuff)
            {
                DrawColor = new Color(254, 121, 104);
            }
        }

        public override bool StrikeNPC(NPC npc, ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            if (carveDebuff)
            {
                Main.CalculateDamageNPCsTake((int)damage, (int)(defense - defense * 0.15));
                return false;
            }
            return true;
        }
    }
}