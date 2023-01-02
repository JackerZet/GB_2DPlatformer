using Platformer.Modules.Falling;
using UnityEngine;

namespace Platformer.Modules.Rotating
{
    public class ReboundModel : IRotatingModel, IFallingModel
    {
        private const float _g = -10f;
        
        private readonly Transform _transform;
        private readonly Vector2 _direction;
        private readonly float _groundLevel;
        private readonly float _radius;

        private Vector2 _velocity;
        public Vector2 Velocity => _velocity;
        public ReboundModel(Transform transform, float groundLevel, float radius, Vector2 direction)
        {
            _direction = direction;
            _transform = transform;
            _groundLevel = groundLevel;
            _radius = radius;
        }
        public void Rotate(Vector2 velocity)
        {
            _velocity = velocity;
            var angle = Vector2.Angle(_direction, _velocity);
            var axis = Vector3.Cross(_direction, _velocity);
            _transform.rotation = Quaternion.AngleAxis(angle, axis);
        }

        public void Fall()
        {
            Rotate((Vector3)Velocity + _g * Time.deltaTime * Vector3.up);
            _transform.position += (Vector3)_velocity * Time.deltaTime;
        }

        public bool IsGrounded()
        {
            return _transform.position.y < _groundLevel + _radius && _velocity.y <= 0;
        }

    }
}
