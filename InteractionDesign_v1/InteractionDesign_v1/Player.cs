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
        public bool loadPhone = false;
        public Vector2 barpos;
        //public Dictionary<String, bool> completedActions;
        public int currentActionIndex;
        public List<String> actionList;
        public List<String> instructionList;
        public int playerScore;
        public TimeSpan timeTaken;
        public bool isGameCompleted;
        public bool welcome;
        public bool isHardMode;
        public bool modeSelect;


        public Player(){
            playerScore = 0;
            isChestPressed = false;
            isShowingInfo = true;
            welcome = false;
            xpos = new List<string>();
            currentActionIndex = 0;
            isGameCompleted = false;
            modeSelect = true;
            isHardMode = false;
            
            actionList = new List<string>();
            actionList.Add("phone");
            actionList.Add("shoulder");
            actionList.Add("mouth");
            actionList.Add("mouth");
            actionList.Add("nose");
            actionList.Add("chest");
            actionList.Add("chest");
            actionList.Add("chest");
            actionList.Add("chest");
            actionList.Add("chest");
            actionList.Add("chest");
            actionList.Add("chest");
            actionList.Add("chest");
            actionList.Add("chest");
            actionList.Add("chest");
            actionList.Add("chest");
            actionList.Add("chest");
            actionList.Add("chest");
            actionList.Add("chest"); 
            actionList.Add("chest");

            instructionList = new List<string>();
            instructionList.Add("Use the phone to call an ambulance\nDial 999");
            instructionList.Add("shake the victims shoudler \nto see if they are conscious");
            instructionList.Add("Put your hand over the victims mouth\nto see if they are breathing");
            instructionList.Add("Tilt the victims head back to open the airways");
            instructionList.Add("Pinch the victims nose");
            instructionList.Add("Push Down two inches on the victims chest\n15 times");
            instructionList.Add("Push Down two inches on the victims chest\n14 times");
            instructionList.Add("Push Down two inches on the victims chest\n13 times");
            instructionList.Add("Push Down two inches on the victims chest\n12 times");
            instructionList.Add("Push Down two inches on the victims chest\n11 times");
            instructionList.Add("Push Down two inches on the victims chest\n10 times");
            instructionList.Add("Push Down two inches on the victims chest\n9 times");
            instructionList.Add("Push Down two inches on the victims chest\n8 times");
            instructionList.Add("Push Down two inches on the victims chest\n7 times");
            instructionList.Add("Push Down two inches on the victims chest\n6 times");
            instructionList.Add("Push Down two inches on the victims chest\n5 times");
            instructionList.Add("Push Down two inches on the victims chest\n4 times");
            instructionList.Add("Push Down two inches on the victims chest\n3 times");
            instructionList.Add("Push Down two inches on the victims chest\n2 times");
            instructionList.Add("Push Down two inches on the victims chest\n1 more time");

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
