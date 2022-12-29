using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfTerraria.Items
{
	public class FiendishCodex : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fiendish Codex");
			Tooltip.SetDefault("Can only be equipped in the League Inventory\n+13% magic and summon damage\n+10% attack speed");
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
            player.GetDamage(DamageClass.Magic) += 0.13f;
            player.GetDamage(DamageClass.Summon) += 0.13f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
            player.GetAttackSpeed(DamageClass.Ranged) += 0.1f;
            player.GetAttackSpeed(DamageClass.Magic) += 0.1f;
            player.GetAttackSpeed(DamageClass.Summon) += 0.1f;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "AmplifyingTome", 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
		}
	}
}