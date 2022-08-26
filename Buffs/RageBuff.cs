using Microsoft.Xna.Framework;
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
			Description.SetDefault("+5% movement speed");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.moveSpeed += 0.05f;
        }
	}
}