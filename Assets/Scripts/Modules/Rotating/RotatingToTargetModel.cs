using UnityEngine;

namespace Platformer.Modules.Rotating
{
    public class RotatingToTargetModel : IRotatingModel
    {
        private readonly Transform _transform;
        private readonly Vector2 _direction;
        public RotatingToTargetModel(Transform transform, Vector2 direction)
        {
        
            _direction = direction;
            _transform = transform;
        }
        public void Rotate(Vector2 target)
        {
            var dir = target - (Vector2)_transform.position;
            var angle = Vector2.Angle(_direction, dir);
            var axis = Vector3.Cross(_direction, dir);
            _transform.rotation = Quaternion.AngleAxis(angle, axis);
        }
    }
}
