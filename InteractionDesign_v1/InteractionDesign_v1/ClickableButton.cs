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
    class ClickableButton : ClickableObject
    {
        String buttonName;
        int buttonType;

        public ClickableButton(ContentManager content, String texture, Vector2 position, Player player, string buttonName, int buttonType)
            : base(content, texture, position, player, buttonName, buttonType)
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

                    base.player.actions.Add(this.buttonName);
                    break;

                case (int)ClickableObject.ButtonType.UNDO :

                    if (base.player.actions.Count > 0)
                    {
                        if (base.player.actions[base.player.actions.Count - 1] == "Mouth")
                        {
                            //move sqaure back to starting position
                        }

                        base.player.actions.RemoveAt(base.player.actions.Count - 1);
                    }

                    break;

                case (int)ClickableObject.ButtonType.SIMPLE:

                    base.player.actions.Add(this.buttonName);

                    if (buttonName.ToLower() == "phone")
                    {
                        base.player.isShowingInfo = true;
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
                        base.player.isChestPressed = false;
                        //record chest pressess and xpos of moving bar
                        // reset xpos of moving bar
                    }
                    break;
            }

        }

        public override void onLeftNormal()
        {

        }
    }

}

