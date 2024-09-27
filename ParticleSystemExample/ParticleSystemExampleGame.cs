﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ParticleSystemExample
{
    /// <summary>
    /// An example game demonstrating the use of particle systems
    /// </summary>
    public class ParticleSystemExampleGame : Game, IParticleEmitter
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private MouseState _previousMouseState;

        ExplosionParticleSystem _explosions;
        FireworkParticleSystem _firework;

        public Vector2 Position { get; set; }

        public Vector2 Velocity { get; set; }

        /// <summary>
        /// Constructs an instance of the game
        /// </summary>
        public ParticleSystemExampleGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Initializes the game
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            RainParticleSystem rain = new RainParticleSystem(this, new Rectangle(100, -20, 500, 10));
            Components.Add(rain);
            _explosions = new ExplosionParticleSystem(this, 20);
            Components.Add(_explosions);

            _firework = new FireworkParticleSystem(this, 20);
            Components.Add(_firework);

            PixieParticleSystem pixie = new PixieParticleSystem(this, this);
            Components.Add(pixie);


            base.Initialize();



        }

        /// <summary>
        /// Loads the game content
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// Updates the game.  Called every frame of the game loop.
        /// </summary>
        /// <param name="gameTime">The time in the game</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            MouseState currentMouse = Mouse.GetState();
            Vector2 mousePosition = new Vector2(currentMouse.X, currentMouse.Y);

            if(currentMouse.LeftButton == ButtonState.Pressed && _previousMouseState.LeftButton == ButtonState.Released)
            {
                _explosions.PlaceExplosion(mousePosition);
                
            }
            if(currentMouse.RightButton == ButtonState.Pressed && _previousMouseState.RightButton == ButtonState.Released)
            {
                _firework.PlaceFirework(mousePosition);
                
            }
            Velocity = mousePosition - Position;
            Position = mousePosition;


            _previousMouseState = currentMouse;

            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the game.  Called every frame of the game loop.
        /// </summary>
        /// <param name="gameTime">The time in the game</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
