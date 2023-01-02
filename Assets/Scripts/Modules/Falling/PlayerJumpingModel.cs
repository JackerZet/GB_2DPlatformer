using UnityEngine;

namespace Platformer.Modules.Falling
{
    public class PlayerJumpingModel : IJumpingModel
    {
        private const float _g = -10f;

        private readonly Transform _transform;
        private readonly float _groundLevel;
        private readonly float _jumpSpeed;

        private Vector2 _velocity;
        public Vector2 Velocity => _velocity;

        public PlayerJumpingModel(Transform transform, float jumpSpeed, float groundLevel)
        {
            _transform = transform;
            _jumpSpeed = jumpSpeed;
            _groundLevel = groundLevel;
        }

        public void Fall()
        {
            _velocity.y += _g * Time.deltaTime;
            _transform.position += Vector3.up * (Time.deltaTime * _velocity.y);
        }

        public bool IsGrounded()
        {
            return _transform.position.y < _groundLevel && _velocity.y <= 0;
        }

        public void Jump(bool doJump)
        {
            if(doJump && _velocity.y == 0)
            {
                _velocity.y = _jumpSpeed;
            }
            else if (_velocity.y < 0)
            {
                _velocity.y = 0;
                _transform.position = new(_transform.position.x, _groundLevel);
            }
        }
    }
}
