using Microsoft.Xna.Framework;
using System.Drawing;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Buffs
{
	public class LichBaneInactive : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spellblade (Lich Bane)");
			Description.SetDefault("Spellblade is on cooldown");
            Main.debuff[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<LeagueOfTerrariaPlayer>().lichBaneBuffActive = false;
            player.GetModPlayer<LeagueOfTerrariaPlayer>().lichBaneCooldown = true;
        }
	}
}