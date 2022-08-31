using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Buffs
{
	public class SiphonBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Siphon");
			Description.SetDefault("+25% movement speed for 2 seconds");
		}

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 0.25f;
        }
    }
}