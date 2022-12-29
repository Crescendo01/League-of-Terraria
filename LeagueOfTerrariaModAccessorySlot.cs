using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace LeagueOfTerraria
{
    //These slots are out of order lmao. Actual order of slots is commented (order starts from top left of 3x2 rectangle and counts up going left to right, top to bottom)
    //This is the first one tho
    public class LeagueOfTerrariaModAccessorySlot : ModAccessorySlot
    {
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override string FunctionalBackgroundTexture => "Terraria/Images/Inventory_Back12";
        public override string FunctionalTexture => "Terraria/Images/Inventory_Back12";
        public override Vector2? CustomLocation => new Vector2(Main.screenWidth * 0.64f, Main.screenHeight * 0.88f);
        
        public static string[] items = { "Amplifying Tome", "B.F. Sword", "Black Cleaver", "Blasting Wand", "Blighting Jewel", "Cloak of Agility", "Infinity Edge", "Long Sword", "Needlessly Large Rod", "Pickaxe", "Rabadon's Deathcap", "Void Staff", "Ruby Crystal", "Kindlegem", "Serylda's Grudge", "Last Whisper", "Dagger", "Recurve Bow", "Vampiric Scepter", "Blade of the Ruined King", "Nashor's Tooth", "Wit's End", "Null Magic Mantle", "Hearthbound Axe", "Kraken Slayer", "Noonquiver", "Sheen", "Lich Bane", "Aether Wisp", "Fiendish Codex", "Spear Of Shojin" };
        //Checks if the player is trying to equip a league item, returning true if they are
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            foreach (string s in items)
            {
                if (checkItem.Name == s)
                {
                    return true;
                }
            }
            return false;
        }
    }

    //This is the sixth one
    public class LeagueOfTerrariaModAccessorySlotTwo : ModAccessorySlot
    {
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override string FunctionalBackgroundTexture => "Terraria/Images/Inventory_Back12";
        public override string FunctionalTexture => "Terraria/Images/Inventory_Back12";
        public override Vector2? CustomLocation => new Vector2(Main.screenWidth * 0.64f + 98, Main.screenHeight * 0.88f + 49);

        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            foreach (string s in LeagueOfTerrariaModAccessorySlot.items)
            {
                if (checkItem.Name == s)
                {
                    return true;
                }
            }
            return false;
        }
    }

    //This is the fifth one
    public class LeagueOfTerrariaModAccessorySlotThree : ModAccessorySlot
    {
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override string FunctionalBackgroundTexture => "Terraria/Images/Inventory_Back12";
        public override string FunctionalTexture => "Terraria/Images/Inventory_Back12";
        public override Vector2? CustomLocation => new Vector2(Main.screenWidth * 0.64f + 49, Main.screenHeight * 0.88f + 49);

        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            foreach (string s in LeagueOfTerrariaModAccessorySlot.items)
            {
                if (checkItem.Name == s)
                {
                    return true;
                }
            }
            return false;
        }
    }

    //This is the third one
    public class LeagueOfTerrariaModAccessorySlotFour : ModAccessorySlot
    {
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override string FunctionalBackgroundTexture => "Terraria/Images/Inventory_Back12";
        public override string FunctionalTexture => "Terraria/Images/Inventory_Back12";
        public override Vector2? CustomLocation => new Vector2(Main.screenWidth * 0.64f + 98, Main.screenHeight * 0.88f);

        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            foreach (string s in LeagueOfTerrariaModAccessorySlot.items)
            {
                if (checkItem.Name == s)
                {
                    return true;
                }
            }
            return false;
        }
    }

    //This is the second one
    public class LeagueOfTerrariaModAccessorySlotFive : ModAccessorySlot
    {
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override string FunctionalBackgroundTexture => "Terraria/Images/Inventory_Back12";
        public override string FunctionalTexture => "Terraria/Images/Inventory_Back12";
        public override Vector2? CustomLocation => new Vector2(Main.screenWidth * 0.64f + 49, Main.screenHeight * 0.88f);

        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            foreach (string s in LeagueOfTerrariaModAccessorySlot.items)
            {
                if (checkItem.Name == s)
                {
                    return true;
                }
            }
            return false;
        }
    }
    
    //This is the fourth one
    public class LeagueOfTerrariaModAccessorySlotSix : ModAccessorySlot
    {
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override string FunctionalBackgroundTexture => "Terraria/Images/Inventory_Back12";
        public override string FunctionalTexture => "Terraria/Images/Inventory_Back12";
        public override Vector2? CustomLocation => new Vector2(Main.screenWidth * 0.64f, Main.screenHeight * 0.88f + 49);

        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            foreach (string s in LeagueOfTerrariaModAccessorySlot.items)
            {
                if (checkItem.Name == s)
                {
                    return true;
                }
            }
            return false;
        }
    }
}