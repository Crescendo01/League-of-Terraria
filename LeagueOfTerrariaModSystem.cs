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
	public class LeagueOfTerrariaModSystem : ModSystem
	{
        //creating instance of LOTuistate
        internal LeagueOfTerrariaUIState LeagueOfTerrariaState;
        private UserInterface LeagueOfTerrariaInterface;

        //Adding the custom LOTui layer into the game
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            layers.Add(new LegacyGameInterfaceLayer("Cool Mod: Something UI", DrawLeagueOfTerrariaUI, InterfaceScaleType.UI));
        }

        private bool DrawLeagueOfTerrariaUI()
        {
            if (Main.playerInventory)
            {
                LeagueOfTerrariaInterface.Draw(Main.spriteBatch, new GameTime());
            }
            return true;
        }

        //attaches custom LOTuistate to the interface
        public override void Load()
        {
            LeagueOfTerrariaState = new LeagueOfTerrariaUIState();
            LeagueOfTerrariaState.Activate();
            LeagueOfTerrariaInterface = new UserInterface();
            LeagueOfTerrariaInterface.SetState(LeagueOfTerrariaState);
        }
    }

}