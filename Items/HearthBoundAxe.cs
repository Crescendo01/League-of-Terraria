using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Items
{
	public class HearthboundAxe : ModItem
	{ 

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hearthbound Axe");
			Tooltip.SetDefault("Can only be equipped in the League Inventory\n+7% melee and ranged damage\n");
        }

		public override void SetDefaults()
		{
			Item.accessory = true;
			Item.width = 40;
			Item.height = 40;
			Item.value = 10000;
			Item.rare = 5;
		}

        //Tells the game it is a league item so it can only go in the league inventory
        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            return modded;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
		{
            
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "Dagger", 1);
            recipe.AddIngredient(Mod, "LongSword", 1);
            recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}