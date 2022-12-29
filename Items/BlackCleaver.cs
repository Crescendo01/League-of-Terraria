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
			Tooltip.SetDefault("Can only be equipped in the League Inventory\n+25% melee and ranged damage\n+30% attack speed\n+35 health\nUNIQUE - CARVE: Dealing melee or ranged damage to an enemy applies a stack of Carve for 6 seconds, stacking up to 6 times. Each stack inflicts 5% armor reduction, up to 30% at 6 stacks.\nUNIQUE - RAGE: Dealing melee or ranged damage to an enemy grants +3% bonus movement speed per stack of Carve on them for 2 seconds, up to 18%.");
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
			player.GetDamage(DamageClass.Melee) += 0.25f;
            player.GetDamage(DamageClass.Ranged) += 0.25f;
			player.GetAttackSpeed(DamageClass.Melee) += 0.3f;
            player.GetAttackSpeed(DamageClass.Ranged) += 0.3f;
            player.GetAttackSpeed(DamageClass.Magic) += 0.3f;
            player.GetAttackSpeed(DamageClass.Summon) += 0.3f;
            player.statLifeMax2 += 35;
			player.GetModPlayer<LeagueOfTerrariaPlayer>().canApplyBlackCleaverBuffs = true;
            player.GetModPlayer<LeagueOfTerrariaPlayer>().legendaryItems++;
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