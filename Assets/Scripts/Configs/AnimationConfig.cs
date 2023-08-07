using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public enum Track
    {
        Idle = 0,
        Run = 1,
        Jump = 2,
        Blink = 3,
        Open = 4,
    }

    [CreateAssetMenu(fileName = "SpriteAnimCfg", menuName = "Configs / Animation", order = 1)]
    public class AnimationConfig : ScriptableObject
    {
        [Serializable]
        public class SpriteSequence
        {
            public Track Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }

        public List<SpriteSequence> Sequences = new List<SpriteSequence>();
    }
}
