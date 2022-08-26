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
			DisplayName.SetDefault("Black Cleaver");
			Tooltip.SetDefault("Equipable only in the League Inventory\n+7% melee and ranged damage\n+30% melee and ranged attack speed\n+35 health\nUNIQUE - CARVE: Dealing damage applies Carve for 6 seconds. Carve inflicts 7% defense reduction on the enemy.\nUNIQUE - RAGE: Dealing damage gives +5% bonus movement speed for 2 seconds.");
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
			player.GetDamage(DamageClass.Melee) += 0.07f;
            player.GetDamage(DamageClass.Ranged) += 0.07f;
			player.GetAttackSpeed(DamageClass.Melee) += 0.3f;
            player.GetAttackSpeed(DamageClass.Ranged) += 0.3f;
            player.statLifeMax2 += 35;
			player.GetModPlayer<LeagueOfTerrariaPlayer>().canApplyBlackCleaverBuffs = true;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "CaulfieldsWarhammer", 1);
            recipe.AddIngredient(Mod, "Kindlegem", 1);
            recipe.AddIngredient(Mod, "LongSword", 1);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}