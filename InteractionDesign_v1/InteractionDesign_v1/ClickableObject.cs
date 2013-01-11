using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;
using System.Threading;

namespace GameStateManagement
{
    
    public enum objState
    {
        NORMAL,
        CLICKED,
        RELEASED,
        DRAGGING

    }

    public class ClickableObject
    {



        public enum ButtonType
        {
            SIMPLE,
            UNDO,
            MOVEABLE,
            MULTIPLE,
            PAUSE
        }

        Texture2D texture;
        Texture2D glowTexture;
        public Player player;

        public Rectangle rectangle
        {
            get;
            protected set;
        }

        public Vector2 position
        {
            get;
            protected set;
        }

        public objState leftState
        {
            get;
            protected set;
        }

        public Mouse activeMouse
        {
            get;
            protected set;
        }

        public String buttonName
        {
            get;
            protected set;
        }



        // Constructors

        public ClickableObject(ContentManager content, String text, String glowText, Vector2 pos, Player player, String buttonName, int buttonType) 
        {
            leftState = objState.NORMAL;
            texture = content.Load<Texture2D>(text);
            glowTexture = content.Load<Texture2D>(glowText);
            this.position = pos;
            this.player = player;
            this.buttonName = buttonName;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);
        }


        public ClickableObject(ContentManager content, String text, Vector2 pos, String buttonName)
        {
            leftState = objState.NORMAL;
            texture = content.Load<Texture2D>(text);
            this.position = pos;
            this.buttonName = buttonName;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);
        }

        //virtual functions

        public virtual void onLeftClick() { }
        public virtual void onHeldLeftClick() { }
        public virtual void onLeftRelease() { }
        public virtual void onLeftNormal() { }
        public virtual void onHover() { }
        public virtual void onLeave() { }

        
        // Update

        public void Update(GameTime gameTime, Mouse mouse) 
        {
            bool intersect = mouse.rectangle.Intersects(this.rectangle);

            if (intersect || (activeMouse != null && leftState != objState.NORMAL))
            {
                activeMouse = mouse;

                if (intersect || activeMouse != null && leftState != objState.NORMAL)
                {
                    onHover();
                }

                if (activeMouse.leftClick && (leftState == objState.NORMAL || leftState == objState.RELEASED))
                {
                    leftState = objState.CLICKED;
                    onLeftClick();
                }

                else if (activeMouse.leftClick && leftState == objState.CLICKED)
                {
                    onHeldLeftClick();
                    rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
                }

                else if (activeMouse.leftRelease && leftState == objState.CLICKED)
                {
                    leftState = objState.RELEASED;
                    onLeftRelease();
                }

                else if (activeMouse.leftClick && leftState == objState.RELEASED)
                {
                    leftState = objState.NORMAL;
                    onLeave();
                }

                else
                {

                    if (activeMouse != null)
                    {
                        activeMouse = null;
                        leftState = objState.NORMAL;
                    }
                }
            }

        }


        // Draw

        public void Draw(SpriteBatch spriteBatch) 
        {

            spriteBatch.Begin();

            if (this.GetType() == typeof(PhoneButton) ){
                spriteBatch.Draw(texture, position, Color.White);
            } 
            else {
                if (player.currentActionIndex < player.actionList.Count)
                {
                    if (player.actionList.ElementAt(player.currentActionIndex).Equals(buttonName.ToLower()))
                    {
                        spriteBatch.Draw(glowTexture, position, Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(texture, position, Color.White);
                    }
                }
            }

            spriteBatch.End();
        }


    }
}
