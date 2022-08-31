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
using ReLogic.Graphics;
using Microsoft.Xna.Framework.Graphics;

namespace LeagueOfTerraria
{
	public class LeagueOfTerrariaUIElement : UIElement
	{
        public override void Draw(SpriteBatch spriteBatch)
        {
            //draws a string on a sprite
            spriteBatch.DrawString((ReLogic.Graphics.DynamicSpriteFont)FontAssets.MouseText, "League Inventory", new Vector2(Main.screenWidth * 0.64f + 4, Main.screenHeight * 0.88f - 26), Color.White);
        }
    }
}