using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace jeff.Items
{
	public class RecurveBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Recurve Bow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("+25% Attack Speed \n UNIQUE – STEELTIPPED: Basic attacks deal 15 bonus ranged damage on-hit.");
		}

		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 5;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = 1;
			Item.useAmmo = AmmoID.Arrow;
			Item.shootSpeed = 7;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "Dagger", 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}