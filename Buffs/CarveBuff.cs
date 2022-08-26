using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LeagueOfTerraria.NPCS;

namespace LeagueOfTerraria.Buffs
{
	public class CarveBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Carve (Black Cleaver)");
			Description.SetDefault("-7% defense reduction");
		}

		public override void Update(NPC target, ref int buffIndex)
		{
			target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().carveDebuff = true;
        }
	}
}