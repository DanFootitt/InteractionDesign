using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace InteractionDesign_v1
{
    public class Player
    {
        public List<String> actions;
        public bool isChestPressed, isShowingInfo;
        public List<String> info;

        public Player(){
            actions = new List<String>();
            isChestPressed = false;
            isShowingInfo = false;
            info = new List<string>();
            info.Add("Ring an Ambulance!");
        }

        //overide update to draw chest thing and record information

        public void update(GameTime gameTime) { 
            
            if (this.isChestPressed)
            {
                //update the moving bar
                
            }
        
        }
    }
}
