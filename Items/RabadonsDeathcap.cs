using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Items
{
	public class RabadonsDeathcap : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rabadon's Deathcap");
			Tooltip.SetDefault("Equipable only in the League Inventory\n+25% magic and summon damage\nUNIQUE - MAGICAL OPUS: Increase your magic and summon damage by 35%.");
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
			player.GetDamage(DamageClass.Magic) += 0.25f;
            player.GetDamage(DamageClass.Magic) += 0.35f;
            player.GetDamage(DamageClass.Summon) += 0.25f;
            player.GetDamage(DamageClass.Summon) += 0.35f;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "NeedlesslyLargeRod", 2);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}