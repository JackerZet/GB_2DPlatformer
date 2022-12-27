using System.Collections.Generic;
using System;
using UnityEngine;

namespace Platformer.Animations
{
    public enum Track
    {
        Run,
        Jump,
        Idle
    }
    [CreateAssetMenu(fileName = "SpriteAnimations", menuName = "Configs/Sprite animations", order = 1)]
    public class SpriteAnimations : ScriptableObject
    {
        [Serializable]
        public class SpritesSequence
        {
            public Track Track;
            public List<Sprite> Sprites = new();
        }
        public List<SpritesSequence> Sequences = new();
    }
}
