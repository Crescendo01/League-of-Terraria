using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LeagueOfTerraria.NPCS;

namespace LeagueOfTerraria.Buffs
{
	public class BringItDown : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bring It Down (Kraken Slayer)");
			Description.SetDefault("Your next melee or ranged attack will deal 30 (+40% melee/ranged damage) bonus damage on-hit.");
		}

        public override void Update(Player player, ref int buffIndex)
        {
			player.GetModPlayer<LeagueOfTerrariaPlayer>().maxKrakenStacks = true;
        }
    }
}