using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader; 

namespace LeagueOfTerraria.Items
{
	public class InfinityEdge : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infinity Edge");
			Tooltip.SetDefault("Can only be equipped in the League Inventory\n+13% melee and ranged damage\n+10% melee and ranged critical strike chance\nUNIQUE - PERFECTION: Gain 35% bonus critical strike damage if you have at least 30% bonus critical strike chance");
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
			player.GetDamage(DamageClass.Melee) += 0.13f;
			player.GetCritChance(DamageClass.Melee) += 10;
            player.GetDamage(DamageClass.Ranged) += 0.13f;
            player.GetCritChance(DamageClass.Ranged) += 10;
            if (player.GetCritChance(DamageClass.Melee) >= 30 || player.GetCritChance(DamageClass.Ranged) >= 30)
			{
                player.GetModPlayer<LeagueOfTerrariaPlayer>().perfection = true;
            }
            player.GetModPlayer<LeagueOfTerrariaPlayer>().legendaryItems++;
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