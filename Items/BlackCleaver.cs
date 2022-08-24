using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LeagueOfTerraria.Buffs;

namespace LeagueOfTerraria.Items
{
	public class BlackCleaver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Black Cleaver"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("+30% bonus melee and ranged damage\n+100 health\nUNIQUE - CARVE: Dealing damage applies Carve for 3 seconds. Carve inflicts 15% defense reduction on the enemy.\nUNIQUE - RAGE: Dealing damage gives +18% bonus movement speed for 2 seconds.");
		}

		public override void SetDefaults()
		{
			Item.accessory = true;
			Item.width = 40;
			Item.height = 40;
			Item.value = 10000;
			Item.rare = 5;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			base.UpdateAccessory(player, hideVisual);
			player.GetDamage(DamageClass.Melee) += 0.3f;
            player.GetDamage(DamageClass.Ranged) += 0.3f;
			player.statLifeMax2 += 100;
			player.GetModPlayer<LeagueOfTerrariaPlayer>().canApplyBlackCleaverBuffs = true;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "CloakOfAgility", 1);
            recipe.AddIngredient(Mod, "Pickaxe", 1);
            recipe.AddIngredient(Mod, "BFSword", 1);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}