using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader; 

namespace LeagueOfTerraria.Items
{
	public class SeryldasGrudge : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Serylda's Grudge");
			Tooltip.SetDefault("Can only be equipped in the League Inventory\n+22% melee and ranged damage\n+20% melee and ranged attack speed\n+30 melee and ranged armor penetration\nUNIQUE – BITTER COLD: Dealing melee or ranged damage slows enemies by 5% and inflicts frostburn for 1 second");
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
			player.GetDamage(DamageClass.Melee) += 0.22f;
			player.GetArmorPenetration(DamageClass.Melee) += 30;
            player.GetDamage(DamageClass.Ranged) += 0.22f;
            player.GetArmorPenetration(DamageClass.Ranged) += 30;
            player.GetAttackSpeed(DamageClass.Melee) += 0.2f;
            player.GetAttackSpeed(DamageClass.Ranged) += 0.2f;
            player.GetAttackSpeed(DamageClass.Magic) += 0.2f;
            player.GetAttackSpeed(DamageClass.Summon) += 0.2f;
            player.GetModPlayer<LeagueOfTerrariaPlayer>().bitterCold = true;
            player.GetModPlayer<LeagueOfTerrariaPlayer>().legendaryItems++;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "CaulfieldsWarhammer", 1);
            recipe.AddIngredient(Mod, "LastWhisper", 1);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}