using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Items
{
	public class RecurveBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Recurve Bow");
			Tooltip.SetDefault("Can only be equipped in the League Inventory\n+25% melee and ranged attack speed\nUNIQUE – STEELTIPPED: Melee and ranged attacks deal 15 bonus damage on-hit");
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
			player.GetDamage(DamageClass.Melee).Flat += 15;
            player.GetDamage(DamageClass.Ranged).Flat += 15;
            player.GetAttackSpeed(DamageClass.Melee) += 0.25f;
            player.GetAttackSpeed(DamageClass.Ranged) += 0.25f;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "Dagger", 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
		}
	}
}