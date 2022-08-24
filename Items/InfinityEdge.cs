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
			DisplayName.SetDefault("Infinity Edge"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("+75% bonus melee and ranged damage\n+20% critical strike chance\nUNIQUE - PERFECTION: Gain 35% bonus critical strike damage if you have at least 60% bonus critical strike chance.");
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
			player.GetDamage(DamageClass.Melee) += 0.75f;
			player.GetCritChance(DamageClass.Melee) += 20;
            player.GetDamage(DamageClass.Ranged) += 0.75f;
            player.GetCritChance(DamageClass.Ranged) += 20;
            if (player.GetCritChance(DamageClass.Melee) >= 60 || player.GetCritChance(DamageClass.Ranged) >= 60)
			{
                player.GetModPlayer<LeagueOfTerrariaPlayer>().perfection = true;
            }
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