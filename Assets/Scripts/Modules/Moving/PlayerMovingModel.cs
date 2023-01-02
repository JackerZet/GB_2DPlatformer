using UnityEngine;

namespace Platformer.Modules.Moving
{
    public class PlayerMovingModel: IMovingModel
    {
        private readonly Vector3 _leftScale = new(-1, 1, 1);
        private readonly Vector3 _rightScale = new(1, 1, 1);

        private readonly Transform _transform;
        private readonly float _speed;

        public PlayerMovingModel(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }
        public void MoveTowards(float xAxis)
        {
            _transform.position += Vector3.right * (Time.deltaTime * _speed * (xAxis < 0 ? -1 : 1));

            _transform.localScale = (xAxis < 0 ? _leftScale : _rightScale);
        }
             
    }
}
