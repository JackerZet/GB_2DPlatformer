using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Game
{
    public class Application
    {    
        #region Fields
        private LevelData _levelData;
        private Sprite _wallSprite;
        #endregion

        private readonly Vector2 startPosition = new(-1.5F, -1.5F);

        #region Constructors
        public Application(LevelData data)
        {
            _levelData = data;

            InstantiateAll();
        }
        public Application(LevelData data, Sprite wallSprite)
        {
            _levelData = data;
            _wallSprite = wallSprite;
            InstantiateAll();
            InstantiateMap();
        }
        #endregion

        #region Functionality
        private void InstantiateAll()
        {
            _levelData.camera = Camera.main;
            _levelData.player = Object.Instantiate(Inputs.InputResources.Load<SpriteRenderer>("Knight"));
        }

        private void InstantiateMap()
        {
            for (int i = 0; i < 4; i++)
            {
                var wall = new GameObject().AddComponent<SpriteRenderer>();
                wall.name = "Wall";
                wall.transform.position = new Vector2(startPosition.x + i, startPosition.y);
                wall.sprite = _wallSprite;
            }
        }
        #endregion
    }
}
