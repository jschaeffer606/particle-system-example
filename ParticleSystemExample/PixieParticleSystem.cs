﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParticleSystemExample
{
    

    public class PixieParticleSystem : ParticleSystem
    {
        IParticleEmitter _emitter;

        public PixieParticleSystem(Game game, IParticleEmitter emitter) : base(game, 2000)
        {
            _emitter = emitter;
        }

        protected override void InitializeConstants()
        {
            textureFilename = "particle";

            minNumParticles = 2;
            maxNumParticles = 5;

            blendState = BlendState.Additive;
            DrawOrder = AdditiveBlendDrawOrder;

        }

        protected override void InitializeParticle(ref Particle p, Vector2 where)
        {
            var velocity = _emitter.Velocity;

            var acceleration = Vector2.UnitY * 400;

            var scale = RandomHelper.NextFloat(0.1f, 0.5f);

            var lifetime = RandomHelper.NextFloat(0.1f, 1.0f);

            p.Initialize(where, velocity, acceleration, Color.Goldenrod, scale: scale, lifetime: lifetime);
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            AddParticles(_emitter.Position);
        }



    }
}
