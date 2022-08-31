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
			Description.SetDefault("Dealing melee or ranged damage to an enemy applies a stack of Carve for 6 seconds, stacking up to 6 times. Each stack inflicts 5% defense reduction, up to 30% at 6 stacks.");
		}

		public override void Update(NPC target, ref int buffIndex)
		{
			target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().carveCount =  target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().carveCountBuffer;
			target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().carveDebuff = true;
        }
	}
}