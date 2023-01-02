using Platformer.Animations;
using Platformer.Modules.Falling;
using Platformer.Modules.Moving;
using UnityEngine;

namespace Platformer.Objects.Player
{
    public class PlayerController
    {
        #region Readonly's
        private readonly PlayerConfig _config;       
        private readonly PlayerView _view;
        private readonly SpriteAnimator _spriteAnimator;

        private readonly IMovingModel _movingModel;
        private readonly IJumpingModel _jumpingModel;
        #endregion

        #region Consts
        private const float _movingThreshold = 0.1f;
        private const float _flyThreshold = 1f;
        #endregion

        #region Fields
        private bool _doJump;
        private float _xAxisInput;
        #endregion
        
        public Transform Transform => _view.Transform;
        public PlayerController(PlayerView prefab, SpriteAnimator spriteAnimator)
        {
            _config = Inputs.InputResources.Load<PlayerConfig>(nameof(PlayerConfig));
            
            _view = Object.Instantiate(prefab);
            _view.Init();

            _movingModel = new PlayerMovingModel(_view.transform, _config.MovingSpeed);
            _jumpingModel = new PlayerJumpingModel(_view.transform, _config.JumpSpeed, 0f);

            _spriteAnimator = spriteAnimator;
        }
        public void Update()
        {
            _doJump = Input.GetAxis("Jump") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");

            var canMove = Mathf.Abs(_xAxisInput) > _movingThreshold;

            if (canMove) _movingModel.MoveTowards(_xAxisInput);

            if (_jumpingModel.IsGrounded())
            {            
                _spriteAnimator.StartAnimation(_view.SpriteRenderer, canMove ? Track.Run : Track.Idle, true, _config.AnimationSpeed);

                _jumpingModel.Jump(_doJump);
            }
            else
            {    
                if (Mathf.Abs(_jumpingModel.Velocity.y) > _flyThreshold)
                    _spriteAnimator.StartAnimation(_view.SpriteRenderer, Track.JumpStaying, true, _config.AnimationSpeed);

                _jumpingModel.Fall();              
            }
        }      
    }
}

