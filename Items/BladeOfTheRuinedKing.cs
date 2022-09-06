using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LeagueOfTerraria.Buffs;

namespace LeagueOfTerraria.Items
{
	public class BladeOfTheRuinedKing : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blade of the Ruined King");
			Tooltip.SetDefault("Can only be equipped in the League Inventory\n+30% melee and ranged damage\n+25% melee and ranged attack speed\n+4% life steal\nUNIQUE - MIST'S EDGE: Melee and ranged attacks deal (Melee 12% / Ranged 8%) of the target's current health bonus physical damage on-hit,\nwith a minimum of 15 and a maximum of 60 against all enemies\nUNIQUE - SIPHON: Melee and ranged attacks on-hit against enemies apply a stack, stacking up to 3 times.\nThe third stack consumes them all to slow the target by 25% for 2 seconds, while also granting you 25% bonus movement speed for the same duration (20 second cooldown)");
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
			player.GetDamage(DamageClass.Melee) += 0.3f;
            player.GetDamage(DamageClass.Ranged) += 0.3f;
			player.GetAttackSpeed(DamageClass.Melee) += 0.25f;
            player.GetAttackSpeed(DamageClass.Ranged) += 0.25f;
			player.GetModPlayer<LeagueOfTerrariaPlayer>().borkEquipped = true;
            player.GetModPlayer<LeagueOfTerrariaPlayer>().legendaryItems++;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "RecurveBow", 1);
            recipe.AddIngredient(Mod, "Pickaxe", 1);
            recipe.AddIngredient(Mod, "VampiricScepter", 1);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}