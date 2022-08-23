using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace jeff.Items
{
	public class Dagger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dagger"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("+12% attack speed");
		}

		public override void SetDefaults()
		{
			Item.damage = 7;
			Item.DamageType = DamageClass.Melee;
			Item.width = 6;
			Item.height = 20;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = 3;
			Item.knockBack = 2;
			Item.value = 10000;
			Item.value = 10000;
			Item.rare = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useTurn = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup(RecipeGroupID.IronBar, 7);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			//Recipe recipe2 = CreateRecipe();
            //recipe.AddIngredient(ItemID.TungstenBar, 7);
            //recipe.AddTile(TileID.Anvils);
            //recipe.Register();
        }
	}
}