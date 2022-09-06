using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LeagueOfTerraria.Buffs;

namespace LeagueOfTerraria.Items
{
	public class KrakenSlayer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Kraken Slayer");
			Tooltip.SetDefault("Can only be equipped in the League Inventory\n+35% melee and ranged damage\n+25% melee and ranged attack speed\n+20% melee and ranged critical strike chance\nUNIQUE - BRING IT DOWN: Melee and ranged attacks grant a stack for 3 seconds, up to 2 stacks.\nAt 2 stacks, the next melee or ranged attack consumes all stacks to deal 30 (+40% melee/ranged damage) bonus damage on-hit.\nMYTHIC PASSIVE: Empowers each of your other Legendary items with 10% bonus attack speed.");
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
			player.GetDamage(DamageClass.Melee) += 0.35f;
            player.GetDamage(DamageClass.Ranged) += 0.35f;
			player.GetAttackSpeed(DamageClass.Melee) += 0.25f;
            player.GetAttackSpeed(DamageClass.Ranged) += 0.25f;
            player.GetCritChance(DamageClass.Melee) += 0.2f;
            player.GetCritChance(DamageClass.Ranged) += 0.2f;
			player.GetModPlayer<LeagueOfTerrariaPlayer>().krakenSlayerEquipped = true;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "Noonquiver", 1);
            recipe.AddIngredient(Mod, "CloakOfAgility", 1);
            recipe.AddIngredient(Mod, "Pickaxe", 1);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}