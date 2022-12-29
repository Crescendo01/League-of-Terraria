using LeagueOfTerraria.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Items
{
	public class AetherWisp : ModItem
	{ 

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aether Wisp");
			Tooltip.SetDefault("Can only be equipped in the League Inventory\n+10% magic and summon damage\nUNIQUE - GLIDE: Gain 5% bonus movement speed.");
			
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
			player.GetDamage(DamageClass.Magic) += 0.1f;
            player.GetDamage(DamageClass.Summon) += 0.1f;
			player.moveSpeed += 0.1f;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "AmplifyingTome", 1);
            recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}