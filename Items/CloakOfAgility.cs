using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Items
{
	public class CloakOfAgility : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cloak of Agility");
			Tooltip.SetDefault("Can only be equipped in the League Inventory\n+7% critical strike chance");
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
            player.GetCritChance(DamageClass.Melee) += 7;
            player.GetCritChance(DamageClass.Ranged) += 7;
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