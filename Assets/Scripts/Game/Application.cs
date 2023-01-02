using Platformer.Animations;
using Platformer.Objects.MegaBow;
using Platformer.Objects.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Game
{
    public sealed  class Application
    {
        #region
        private const int quantityHorisontalWalls = 15;
        #endregion

        #region Fields
        private readonly LevelData _levelData;
        private readonly Sprite _wallSprite;
        private readonly SpriteAnimator _spriteAnimator;

        private readonly Vector2 startPosition = new(-(quantityHorisontalWalls/2), -1F);
        #endregion

        #region Constructors
        public Application(LevelData data)
        {
            _levelData = data;

            InstantiateAll();
        }
        public Application(LevelData data, SpriteAnimator spriteAnimator, Sprite wallSprite)
        {
            _levelData = data;
            _spriteAnimator = spriteAnimator;
            _wallSprite = wallSprite;

            InstantiateAll();
            InstantiateMap();
        }
        #endregion

        #region Functionality
        private void InstantiateAll()
        {
            _levelData.camera = Camera.main;
            _levelData.player = new PlayerController(Inputs.InputResources.Load<PlayerView>("Knight"), _spriteAnimator);
            _levelData.megaBow = new MegaBowController(Inputs.InputResources.Load<MegaBowView>("MegaBow"), _levelData.player.Transform);
        }

        private void InstantiateMap()
        {
            var root = new GameObject($"[Walls]").transform;
            for (int i = 0; i < quantityHorisontalWalls; i++)
            {
                var wall = new GameObject().AddComponent<SpriteRenderer>();
                wall.transform.SetParent(root);
                wall.name = "Wall";
                wall.transform.position = new Vector2(startPosition.x + i, startPosition.y);
                wall.sprite = _wallSprite;
            }
        }
        #endregion
    }
}
