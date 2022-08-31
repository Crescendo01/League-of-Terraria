using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LeagueOfTerraria.NPCS;

namespace LeagueOfTerraria.Buffs
{
	public class SlowBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slow (Serylda's Grudge)");
			Description.SetDefault("Dealing melee or ranged damage to an enemy inflicts Slow on them, which reduces their movement speed by 5%.");
		}

		public override void Update(NPC target, ref int buffIndex)
		{
			target.GetGlobalNPC<LeagueOfTerrariaGlobalNPC>().slowDebuff = true;
        }
	}
}