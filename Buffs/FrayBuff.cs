using Microsoft.Xna.Framework;
using System.Drawing;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Buffs
{
	public class FrayBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fray (Wit's End)");
			Description.SetDefault("Melee and ranged attacks grant you +20% bonus movement speed.");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.moveSpeed += 0.2f;
        }
	}
}