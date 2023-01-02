using Platformer.Animations;
using Platformer.Objects.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Game
{
    public sealed class Starter : MonoBehaviour
    {               
        [SerializeField] private Sprite wallSprite;

        private readonly LevelData _levelData = new();

        private SpriteAnimator _spriteAnimator;
        private SpriteAnimationsConfig _animations;
       
        private void Awake()
        {           
            _animations = Inputs.InputResources.Load<SpriteAnimationsConfig>("SpriteAnimations");
            _spriteAnimator = new SpriteAnimator(_animations);

            new Application(_levelData, _spriteAnimator, wallSprite);

        }
        private void Update()
        {
            _levelData.player.Update();
            _levelData.megaBow.Update();
            _spriteAnimator.Update();
        }
        //private void FixedUpdate()
        //{

        //}
        private void OnDestroy()
        {
            _spriteAnimator.Dispose();       
        }
    }
}
