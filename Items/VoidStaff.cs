using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Items
{
	public class VoidStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void Staff"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("+50% bonus magic and summon damage\n+20 bonus magic and summon armor penetration");
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
            player.GetDamage(DamageClass.Magic) += 0.5f;
			player.GetArmorPenetration(DamageClass.Magic) += 20;
            player.GetDamage(DamageClass.Summon) += 0.5f;
            player.GetArmorPenetration(DamageClass.Summon) += 20;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "BlightingJewel", 1);
            recipe.AddIngredient(Mod, "BlastingWand", 1);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}