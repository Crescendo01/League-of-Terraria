using Microsoft.Xna.Framework;
using System.Drawing;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Buffs
{
	public class SheenInactive : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spellblade (Sheen)");
			Description.SetDefault("Spellblade is on cooldown");
            Main.debuff[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<LeagueOfTerrariaPlayer>().sheenBuffActive = false;
            player.GetModPlayer<LeagueOfTerrariaPlayer>().sheenCooldown = true;
        }
	}
}