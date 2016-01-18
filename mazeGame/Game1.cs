using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Threading;

namespace mazeGame
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Maze m;
        bool playControl = false;
        CharacterController character;
        public Game1()
        {
            m = new Maze();
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = m.mazeSize * m.cellSize;
            graphics.PreferredBackBufferHeight = m.mazeSize * m.cellSize;   
            graphics.ApplyChanges();
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
                MazeBuilder.createMaze(m.cells[0, 0], m);
                character = new CharacterController(m.cells[0, 0]);
                playControl = true;
            }
            character.moveCharacter(Keyboard.GetState(),gameTime);
            
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
