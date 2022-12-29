using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LeagueOfTerraria.Buffs;

namespace LeagueOfTerraria.Items
{
	public class SpearOfShojin : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spear Of Shojin");
			Tooltip.SetDefault("Can only be equipped in the League Inventory\n+40% melee and ranged damage\n+20% melee and ranged attack speed\n+30 health\nUNIQUE - DRAGONFORCE: Gain (+8% melee / +6% ranged) attack speed based on your bonus damage\nUNIQUE - EXIGENCY: Gain up to 15% bonus movement speed based on missing health, capped at 67% missing health");
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
			player.GetDamage(DamageClass.Melee) += 0.4f;
            player.GetDamage(DamageClass.Ranged) += 0.4f;
			player.GetAttackSpeed(DamageClass.Melee) += 0.20f;
            player.GetAttackSpeed(DamageClass.Ranged) += 0.20f;
			player.statLifeMax2 += 30;
			//Bonus attack speed calculation
			player.GetAttackSpeed(DamageClass.Melee) += 0.08f + (int)(player.GetDamage(DamageClass.Melee).Flat * 0.08);
			player.GetAttackSpeed(DamageClass.Ranged) += 0.06f + (int)(player.GetDamage(DamageClass.Melee).Flat * 0.08);
            player.GetModPlayer<LeagueOfTerrariaPlayer>().legendaryItems++;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "CaulfieldsWarhammer", 1);
            recipe.AddIngredient(Mod, "BFSword", 1);
            recipe.AddIngredient(Mod, "Kindlegem", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}