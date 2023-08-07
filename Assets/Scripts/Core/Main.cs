using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private DestroyableObjectsView _playerView;
        [SerializeField] private QuestView _questView;
        [SerializeField] private UIView _UIView;
        [SerializeField] private PopupView _popupView;

        [SerializeField] private GeneratorLevelView _generatorLevelView;

        [Header("Environment")]
        [SerializeField] private GameObject[] _background;
        [SerializeField] private LevelObjectView[] _waterViews;
        [SerializeField] private LevelObjectView[] _liftViews;

        [Header("Enemies")] 
        [SerializeField] private CannonView[] _cannonViews;
        [SerializeField] private DestroyableObjectsView[] _groundEnemyViews;
        [SerializeField] private EnemyPatrolView[] _flyingEnemyViews;

        [Header("Locked Items")]
        [SerializeField] private LockedItemView[] _chestViews;
        [SerializeField] private LockedItemView[] _doorViews;

        [Header("Quest Items")]
        [SerializeField] private QuestObjectView[] _coinViews;
        [SerializeField] private QuestObjectView[] _buttonViews;

        private List<IUpdateable> _updateableControllers;
        private List<IFixedUpdateable> _fixedUpdateableControllers;
        private List<IUnlockable> _unlockables;

        private void Awake()
        {
            _updateableControllers = new List<IUpdateable>();
            _fixedUpdateableControllers = new List<IFixedUpdateable>();
            _unlockables = new List<IUnlockable>();

            var cameraController = new CameraController(Camera.main.transform, _playerView);
            var playerController = new PlayerController(_playerView);
            var questConfiguratorController = new QuestConfiguratorController(_questView, _playerView);
            var backgroundController = new BackgroundController(_background, Camera.main);
            var liftController = new LiftController(_liftViews);

            _UIView.Player = playerController;
            _popupView.Player = playerController;
            //var generatorLevelController = new GeneratorLevelController(_generatorLevelView);
            //generatorLevelController.Start();

            _playerView.LevelCompleted += _UIView.WinScreen;
            _playerView.LevelCompleted += OnLevelCompletion;
            playerController.ResetAfterDeath += backgroundController.OnReset;

            _updateableControllers.Add(cameraController);
            _fixedUpdateableControllers.Add(playerController);
            _updateableControllers.Add(backgroundController);
            _updateableControllers.Add(liftController);

            for (int i = 0; i < _waterViews.Length; i++)
                _updateableControllers.Add(new WaterController(_waterViews[i]));
            
            for (int i = 0; i < _cannonViews.Length; i++)
                _updateableControllers.Add(new CannonController(_cannonViews[i], _playerView._transform));
           
            for (int i = 0; i < _groundEnemyViews.Length; i++)
                _updateableControllers.Add(new GroundEnemyController(_groundEnemyViews[i], _playerView._transform));
            
            for (int i = 0; i < _flyingEnemyViews.Length; i++)
                _updateableControllers.Add(new FlyingEnemyController(_flyingEnemyViews[i], _playerView._transform));
            
            for (int i = 0; i < _chestViews.Length; i++)
                _updateableControllers.Add(new ChestController(_chestViews[i]));
            
            for (int i = 0; i < _coinViews.Length; i++)
                _updateableControllers.Add(new CoinController(_coinViews[i]));
            

            for (int i = 0; i < _chestViews.Length; i++)
                _unlockables.Add(new ChestController(_chestViews[i]));
            
            for (int i = 0; i < _doorViews.Length; i++)
                _unlockables.Add(new DoorController(_doorViews[i]));

            var questDistributorController = new QuestDistributorController(playerController, questConfiguratorController.QuestStoryList,_unlockables);
        }

        private void Update()
        {
            for(int i = 0; i < _updateableControllers.Count; i++)
            {
                _updateableControllers[i].Update();
            }
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < _fixedUpdateableControllers.Count; i++)
            {
                _fixedUpdateableControllers[i].FixedUpdate();
            }
        }

        private void OnLevelCompletion(LevelObjectView obj)
        {
            Time.timeScale = 0;
        }
    }
}
