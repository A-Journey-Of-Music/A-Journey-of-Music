using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AGameOfMusic
{
    public class AnimationManager
    {
        private readonly List<Animation> _animations;

        public AnimationManager()
        {
            _animations = new List<Animation>();
        }

        public void AddAnimation(Animation animation)
        {
            _animations.Add(animation);
        }

        public void ToggleAnimation(string name)
        {
            var animation = _animations.Find(anim => anim.Name.Equals(name));
            animation.ToggleAnimation();
        }

        public void Update()
        {
            foreach (var animation in _animations)
            {
                animation.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch, string name, Vector2 position)
        {
            var animation = _animations.Find(anim => anim.Name.Equals(name));
            animation.Draw(position);
        }
    }
}
