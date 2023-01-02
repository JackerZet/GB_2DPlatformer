using Platformer.Modules.Rotating;
using Platformer.Modules.Spawner;
using Platformer.Objects.Arrow;
using UnityEngine;

namespace Platformer.Objects.MegaBow
{
    public class MegaBowController
    {
        #region Readonly's
        private readonly MegaBowConfig _config;
        private readonly MegaBowView _view;
        private readonly Transform _target;

        private readonly TimeoutSpawner _spawnable;

        private readonly IRotatingModel _rotatingModel;
        #endregion


        #region Constructors
        public MegaBowController(MegaBowView prefab, Transform target)
        {
            _config = Inputs.InputResources.Load<MegaBowConfig>(nameof(MegaBowConfig));

            _view = Object.Instantiate(prefab);
            _view.Init();
            _view.SpriteRenderer.sprite = _config.Sprite;
            _view.Transform.position = new(0, 3);

            _target = target;

            _spawnable = new TimeoutSpawner(Inputs.InputResources.Load<ArrowView>("Arrow"), _view.transform, 5, 10, 1);

            _rotatingModel = new RotatingToTargetModel(_view.Transform, _config.DirectionOfSprite);
        }
        #endregion

        #region Functionality
        public void Update()
        {
            _rotatingModel.Rotate(_target.position);
            _spawnable.Update();
        }
        #endregion
    }
}
