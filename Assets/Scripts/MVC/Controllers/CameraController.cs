using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class CameraController : IUpdateable
    {
        private LevelObjectView _player;
        private Transform _playerTransform;
        private Transform _cameraTransform;

        private float _damping = 2f;
        private float _cameraSpeed = 10f;

        private float X;
        private float Y;

        private Vector3 _destination;

        float offsetValue = 2f;
        private float _offsetX;
        private float _xAxisInput;

        private float _threshold;

        public CameraController(Transform camera, LevelObjectView player)
        {
            _player = player;
            _playerTransform = player._transform;
            _cameraTransform = camera;
            _threshold = 0.2f;

        }

        public void Update()
        {
            _xAxisInput = Input.GetAxis("Horizontal");
          
            X = _playerTransform.position.x;
            Y = _playerTransform.position.y;

            _offsetX = SetOffset(_xAxisInput);
           
            _destination = new Vector3(X + _offsetX, Y, _cameraTransform.position.z);

            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, _destination, _damping * Time.deltaTime);
        }

        private float SetOffset(float axis)
        {
            if (axis > _threshold)
            {
                return offsetValue;
            }
            else if (axis < -_threshold)
            {
                return -offsetValue;
            }
            return 0;
        }
    }
}
