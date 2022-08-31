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
	public class LeagueOfTerrariaUIState : UIState
	{
        //instantiate ui element which contains text
        public LeagueOfTerrariaUIElement textElement;

        //appends text to the inventory uistate
        public override void OnInitialize()
        {
            textElement = new LeagueOfTerrariaUIElement();
            Append(textElement);
        }
    }
}