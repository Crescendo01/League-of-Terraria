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
			DisplayName.SetDefault("Void Staff");
			Tooltip.SetDefault("Equipable only in the League Inventory\n+10% magic and summon damage\n+10 magic and summon armor penetration");
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
			player.GetArmorPenetration(DamageClass.Magic) += 10;
            player.GetDamage(DamageClass.Summon) += 0.1f;
            player.GetArmorPenetration(DamageClass.Summon) += 10;
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