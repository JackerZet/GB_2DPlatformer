using System.Collections.Generic;
using System;
using UnityEngine;

namespace Platformer.Animations
{
    public enum Track
    {
        Run,
        JumpStart,
        JumpStaying,
        Idle
    }
    [CreateAssetMenu(fileName = "SpriteAnimations", menuName = "Configs/Sprite animations", order = 0)]
    public sealed class SpriteAnimationsConfig : ScriptableObject
    {
        [Serializable]
        public class SpritesSequence
        {
            public Track Track;
            public List<Sprite> Sprites = new();
        }
        [field: SerializeField] public List<SpritesSequence> Sequences { get; private set; } = new();
    }
}
