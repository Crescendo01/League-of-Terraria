using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Items
{
	public class CaulfieldsWarhammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Caulfield's Warhammer");
			Tooltip.SetDefault("Equipable only in the League Inventory\n+5% melee and ranged damage\n+10% melee and ranged attack speed");
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
            player.GetDamage(DamageClass.Melee) += 0.05f;
            player.GetDamage(DamageClass.Ranged) += 0.05f;
			player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
            player.GetAttackSpeed(DamageClass.Ranged) += 0.1f;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "LongSword", 2);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}