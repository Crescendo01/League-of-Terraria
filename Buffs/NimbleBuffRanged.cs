using Microsoft.Xna.Framework;
using System.Drawing;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Buffs
{
	public class NimbleBuffRanged : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nimble (Hearthbound Axe)");
			Description.SetDefault("Ranged attacks grant 10% bonus movement speed for 2 seconds.");
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.moveSpeed += 0.1f;
        }
	}
}