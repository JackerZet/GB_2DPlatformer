using Platformer.Animations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Game
{
    public class Starter : MonoBehaviour
    {        
        [SerializeField] private float speed = 0.5f;
        [SerializeField] private Sprite wallSprite;

        private LevelData _levelData = new();

        private SpriteAnimator _spriteAnimator;
        private SpriteAnimations _animations;
       
        private void Awake()
        {           
            _animations = Inputs.InputResources.Load<SpriteAnimations>(nameof(SpriteAnimations));
            _spriteAnimator = new SpriteAnimator(_animations);

            new Application(_levelData, wallSprite);

            _spriteAnimator.StartAnimation(_levelData.player, Track.Idle, true, speed);
        }
        private void Update()
        {
            _spriteAnimator.Update();
        }
        private void FixedUpdate()
        {

        }
        private void OnDestroy()
        {
            _spriteAnimator.Dispose();       
        }
    }
}
