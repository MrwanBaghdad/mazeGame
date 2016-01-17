using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace mazeGame
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Maze m;
        bool playControl = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

    
        protected override void Initialize()
        {
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }   

        
        protected override void UnloadContent()
        { 
        }

      
        protected override void Update(GameTime gameTime)
        {
            //exit if escape is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) { Exit(); }
            if (Keyboard.GetState().IsKeyDown(Keys.Enter)) { playControl = false; } 
            if (!playControl)
            {
                m = new Maze();
                MazeBuilder.createMaze(m.cells[0,0], m);
                playControl = true;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            m.drawMaze(spriteBatch, this);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
