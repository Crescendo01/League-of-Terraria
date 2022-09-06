using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Items
{
	public class WitsEnd : ModItem
	{ 

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wit's End");
			Tooltip.SetDefault("Can only be equipped in the League Inventory\n+20% melee and ranged damage\n+40% melee and ranged attack speed\n+20 defense\nUNIQUE - FRAY: Melee and ranged attacks deal 10 bonus damage on-hit and grant you +20% bonus movement speed for 2 seconds.");
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
            player.GetDamage(DamageClass.Melee).Flat += 10;
            player.GetDamage(DamageClass.Ranged).Flat += 10;
            player.GetAttackSpeed(DamageClass.Melee) += 0.4f;
            player.GetAttackSpeed(DamageClass.Ranged) += 0.4f;
			player.statDefense += 20;
            player.GetModPlayer<LeagueOfTerrariaPlayer>().witsEndEquipped = true;
            player.GetModPlayer<LeagueOfTerrariaPlayer>().legendaryItems++;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "BlastingWand", 1);
            recipe.AddIngredient(Mod, "AmplifyingTome", 1);
            recipe.AddIngredient(Mod, "Pickaxe", 1);
            recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}