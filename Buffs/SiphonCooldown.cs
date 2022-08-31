using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LeagueOfTerraria.NPCS;

namespace LeagueOfTerraria.Buffs
{
	public class SiphonCooldown : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Siphon (Blade of the Ruined King)");
			Description.SetDefault("Siphon is on cooldown");
			Main.debuff[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<LeagueOfTerrariaPlayer>().siphonCooldown = true;
        }
	}
}