using Microsoft.Xna.Framework;
using System.Drawing;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Buffs
{
	public class LichBaneActive : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spellblade (Lich Bane)");
			Description.SetDefault("Your next attack will deal 50% bonus damage.");
            Main.debuff[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<LeagueOfTerrariaPlayer>().lichBaneBuffActive = true;
        }
	}
}