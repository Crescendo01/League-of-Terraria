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
			DisplayName.SetDefault("Rage (Black Cleaver)"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Description.SetDefault("+18% movement speed");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.moveSpeed += 0.18f;
        }
	}
}