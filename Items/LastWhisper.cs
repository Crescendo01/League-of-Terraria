using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader; 

namespace LeagueOfTerraria.Items
{
	public class LastWhisper : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Last Whisper");
			Tooltip.SetDefault("Can only be equipped in the League Inventory\n+20% melee and ranged damage\n+18 melee and ranged armor penetration");
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
			player.GetDamage(DamageClass.Melee) += 0.20f;
			player.GetArmorPenetration(DamageClass.Melee) += 18;
            player.GetDamage(DamageClass.Ranged) += 0.20f;
            player.GetArmorPenetration(DamageClass.Ranged) += 18;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "LongSword", 2);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}