using Microsoft.Xna.Framework;
using System.Drawing;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Buffs
{
	public class RageBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rage (Black Cleaver)");
			Description.SetDefault("Dealing melee or ranged damage to an enemy grants 3% bonus movement speed per stack of Carve on them for 2 seconds, up to 18.");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.moveSpeed += 0.03f * player.GetModPlayer<LeagueOfTerrariaPlayer>().rageStacks;
        }
	}
}