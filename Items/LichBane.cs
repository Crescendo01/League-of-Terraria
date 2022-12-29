using LeagueOfTerraria.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Items
{
	public class LichBane : ModItem
	{ 

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lich Bane");
			Tooltip.SetDefault("Can only be equipped in the League Inventory\n+35% magic and summon damage\n+10% attack speed\n+10% movement speed\nUNIQUE – SPELLBLADE: After hitting an attack, your next attack within 10 seconds deals 75% bonus damage on-hit\n+ 50% of all current damage bonuses (2 (begins after using the empowered attack) second cooldown).");
			
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
			player.GetDamage(DamageClass.Magic) += 0.35f;
            player.GetDamage(DamageClass.Summon) += 0.35f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
            player.GetAttackSpeed(DamageClass.Ranged) += 0.1f;
            player.GetAttackSpeed(DamageClass.Magic) += 0.1f;
            player.GetAttackSpeed(DamageClass.Summon) += 0.1f;
			player.moveSpeed += 0.1f;
            player.GetModPlayer<LeagueOfTerrariaPlayer>().lichBaneEquipped = true;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "Sheen", 1);
            recipe.AddIngredient(Mod, "AetherWisp", 1);
            recipe.AddIngredient(Mod, "FiendishCodex", 1);
            recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}