using LeagueOfTerraria.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Items
{
	public class Sheen : ModItem
	{ 

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sheen");
			Tooltip.SetDefault("Can only be equipped in the League Inventory\nUNIQUE - SPELLBLADE: After hitting an attack, your next attack within 10 seconds deals 50% bonus damage on-hit (3 (begins after using the empowered attack) second cooldown)");
			
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
            base.UpdateAccessory(player, hideVisual);
            player.GetModPlayer<LeagueOfTerrariaPlayer>().sheenEquipped = true;
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