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
			DisplayName.SetDefault("Carve (Black Cleaver)"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Description.SetDefault("-15% defense reduction");
		}

		public override void Update(NPC target, ref int buffIndex)
		{
			target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().carveDebuff = true;
        }
	}
}