using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Items
{
	public class BlightingJewel : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blighting Jewel");
			Tooltip.SetDefault("Can only be equipped in the League Inventory\n+3% magic and summon damage\n+3 magic and summon armor penetration");
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
            player.GetDamage(DamageClass.Magic) += 0.03f;
			player.GetArmorPenetration(DamageClass.Magic) += 3;
            player.GetDamage(DamageClass.Summon) += 0.03f;
            player.GetArmorPenetration(DamageClass.Summon) += 3;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "AmplifyingTome", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}