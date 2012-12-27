using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GameStateManagement
{
    public class Player
    {
        public List<String> actions;
        public bool isChestPressed, isShowingInfo;
        public List<String> info;
        public List<String> xpos;
        bool isMovingLeft = true;
        public Vector2 barpos;

        public Player(){
            actions = new List<String>();
            isChestPressed = false;
            isShowingInfo = false;
            info = new List<string>();
            xpos = new List<string>();
            //info.Add("Phone");
            info.Add("Shoulder");
            info.Add("Mouth");
            info.Add("Nose");
            info.Add("Chest");
            barpos = new Vector2(200, 318);
        }

        //overide update to draw chest thing and record information

        public void update(GameTime gameTime) { 
            
            if (this.isChestPressed)
            {

                if (isMovingLeft)
                {
                    barpos.X += 6.0f;
                }

                if (!isMovingLeft)
                {
                    barpos.X -= 6.0f;
                }

                if (barpos.X <= 200)
                {
                    isMovingLeft = true;
                    Console.Write(barpos.X);
                }

                if (barpos.X >= 200 + 356)
                {
                    isMovingLeft = false;
                    Console.Write(barpos.X);
                }
                
            }
        
        }
    }
}
