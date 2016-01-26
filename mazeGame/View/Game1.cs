using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Threading;
using mazeGame.Control;
using mazeGame.View;
namespace mazeGame
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        Maze m;
        public static bool playControl = false;
  
        CharacterController character;
        MonsterController monster;
       
        public Game1()
        {
            m = new Maze();
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = m.mazeSize * m.cellSize +200;
            graphics.PreferredBackBufferHeight = m.mazeSize * m.cellSize ;   
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
                DroppingController.putDroppings(m);
                character = new CharacterController(m.cells[0, 0]);
                monster = new MonsterController(m.cells[m.mazeSize - 1, 0]);
                
                playControl = true;
            }
            //MazeBuilder.createMazeOneByOne(m);
            monster.moveMonster(character, gameTime,m);
            character.moveCharacter(Keyboard.GetState(), gameTime,monster,m);
            DroppingController.updateDroppings(m,gameTime);
            BulletController.getInstance().Update(character,gameTime);
            Debug.WriteLine(GameController.score);
            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(157,158,0));
            spriteBatch.Begin();
            m.drawMaze(spriteBatch, this);
            GameController.drawStatus(spriteBatch,this,m,gameTime);
            //spriteBatch.DrawString(Content.Load<SpriteFont>("font"), "Score: " + GameController.score, new Vector2(20,m.mazeSize * m.cellSize+ 20), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
