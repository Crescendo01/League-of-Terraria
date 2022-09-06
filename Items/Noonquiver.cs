using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Items
{
	public class Noonquiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Noonquiver");
			Tooltip.SetDefault("Can only be equipped in the League Inventory\n+20% melee and ranged damage\n+15% melee and ranged attack speed\nUNIQUE - PRECISION: Melee and ranged attacks deal 20 bonus damage on-hit.");
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
            player.GetDamage(DamageClass.Melee) += 0.2f;
            player.GetDamage(DamageClass.Ranged) += 0.2f;
            player.GetDamage(DamageClass.Melee).Flat += 20;
            player.GetDamage(DamageClass.Ranged).Flat += 20;
            player.GetAttackSpeed(DamageClass.Melee) += 0.15f;
            player.GetAttackSpeed(DamageClass.Ranged) += 0.15f;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "LongSword", 2);
            recipe.AddIngredient(Mod, "Dagger", 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
		}
	}
}