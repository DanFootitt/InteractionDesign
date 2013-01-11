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
    public class ClickableButton : ClickableObject
    {
        //String buttonName;
        int buttonType;

        public ClickableButton(ContentManager content, String texture, String glowTexture, Vector2 position, Player player, string buttonName, int buttonType)
            : base(content, texture, glowTexture, position, player, buttonName, buttonType)
        {
            this.buttonName = buttonName;
            this.buttonType = buttonType;
        }


        public override void onHover()
        {

        }

        public override void onLeave()
        {

        }

        public override void onLeftClick()
        {
            switch (this.buttonType)
            {

                case (int)ClickableObject.ButtonType.MOVEABLE :

                    break;

                case (int)ClickableObject.ButtonType.UNDO :

                    if (player.currentActionIndex > 0)player.currentActionIndex--;

                    break;

                case (int)ClickableObject.ButtonType.PAUSE:

                    //set pause bool to true

                    break;

                case (int)ClickableObject.ButtonType.SIMPLE:

                    if (player.actionList.ElementAt(player.currentActionIndex).Equals(buttonName.ToLower()))
                    {

                        if (!buttonName.ToLower().Contains("chest") && !buttonName.ToLower().Contains("phone"))
                        {
                            player.currentActionIndex++;
                            player.playerScore += 100;
                        }
                    }
                    
                    if (buttonName.ToLower() == "phone")
                    {
                        base.player.isShowingInfo = true;
                        base.player.loadPhone = true;
                    }

                    break;
                    
            }


        }

        public override void onHeldLeftClick()
        {
            switch (this.buttonType)
            {
                case (int)ClickableObject.ButtonType.MOVEABLE:
                    position = new Vector2(activeMouse.position.X, activeMouse.position.Y);
                    break;
                case (int)ClickableObject.ButtonType.SIMPLE:
                    if (this.buttonName.ToLower() == "chest")
                    {
                        base.player.isChestPressed = true;
                    }
                    break;
            }
        }

        public override void onLeftRelease()
        {
            switch (this.buttonType)
            {
                case (int)ClickableObject.ButtonType.SIMPLE:
                    if (this.buttonName.ToLower() == "chest")
                    {
                        System.Threading.Thread.Sleep(150);
                        base.player.isChestPressed = false;
                        if ((int)player.barpos.X > 340 && player.barpos.X < 400) player.xpos.Add("GOOD");
                        player.barpos = new Vector2(200, 318);
                        player.currentActionIndex++;
                        player.playerScore += 100;
                    }
                    break;
            }

        }

        public override void onLeftNormal()
        {

        }
    }

}

