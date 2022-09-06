using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Items
{
	public class NashorsTooth : ModItem
	{ 

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nashor's Tooth");
			Tooltip.SetDefault("Can only be equipped in the League Inventory\n+40% magic and summon damage\n+50% magic and summon attack speed\nUNIQUE - ICATHIAN BITE: Magic and summon weapons deal 15 (+20% AP) bonus magic and summon damage on-hit.");
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
            player.GetDamage(DamageClass.Magic) += 0.4f;
            player.GetDamage(DamageClass.Summon) += 0.4f;
            player.GetAttackSpeed(DamageClass.Magic) += 0.5f;
            player.GetAttackSpeed(DamageClass.Summon) += 0.5f;
            player.GetModPlayer<LeagueOfTerrariaPlayer>().nashorsEquipped = true;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "BlastingWand", 1);
            recipe.AddIngredient(Mod, "AmplifyingTome", 1);
            recipe.AddIngredient(Mod, "RecurveBow", 1);
            recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}