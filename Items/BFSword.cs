using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Items
{
	public class BFSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("B.F. Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("+15% melee and ranged damage");
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
            player.GetDamage(DamageClass.Melee) += 0.15f;
            player.GetDamage(DamageClass.Ranged) += 0.15f;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}