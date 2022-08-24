using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Items
{
	public class RabadonsDeathcap : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rabadon's Deathcap"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("+100% bonus magic and summon damage\nUNIQUE - MAGICAL OPUS: Increase your magic and summon damage by 35%.");
		}

		public override void SetDefaults()
		{
			Item.accessory = true;
			Item.width = 40;
			Item.height = 40;
			Item.value = 10000;
			Item.rare = 5;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			base.UpdateAccessory(player, hideVisual);
			player.GetDamage(DamageClass.Magic) += 1;
            player.GetDamage(DamageClass.Magic) += 0.35f;
            player.GetDamage(DamageClass.Summon) += 1;
            player.GetDamage(DamageClass.Summon) += 0.35f;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "NeedlesslyLargeRod", 2);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}