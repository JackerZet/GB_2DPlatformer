using Platformer.Modules.Falling;
using Platformer.Modules.Rotating;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Objects.Arrow
{
    public class ArrowController
    {
        #region Readonly's
        private readonly ArrowView _view;

        private readonly IRotatingModel _rotatingModel;
        private readonly IFallingModel _fallingModel;

        private readonly float _radius = 0.3f;
        private readonly float _groundLevel = 0;
        #endregion

        #region Fields

        #endregion

        #region Constructors
        public ArrowController(ArrowView prefab, Vector2 startPosition)
        {
            _view = Object.Instantiate(prefab);
            _view.Init();
            _view.IsVisible = false;
            _view.Transform.position = startPosition;

            _rotatingModel = new ReboundModel(_view.Transform, _groundLevel, _radius, Vector2.up);
            _fallingModel = (IFallingModel)_rotatingModel;
        }
        #endregion

        #region Functionality
        public void Update()
        {
            if (_fallingModel.IsGrounded())
            {
                _rotatingModel.Rotate(new(_fallingModel.Velocity.x, -_fallingModel.Velocity.y));
                _view.Transform.position = new(_view.Transform.position.x, _groundLevel + _radius);
            }
            else
            {
                _fallingModel.Fall();
            }
        }
        public void Throw(Vector3 position, Vector3 velocity)
        {
            _view.Transform.position = position;
            _rotatingModel.Rotate(velocity);
            _view.IsVisible = true;
        }
        #endregion
    }   
}
