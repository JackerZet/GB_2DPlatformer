using Platformer.Objects.Arrow;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Modules.Spawner
{
    public class TimeoutSpawner
    {
        private readonly ArrowView _prefab;

        private readonly List<ArrowController> _arrows = new();
        private readonly Transform _transformToSpawn;

        private readonly float _startSpeed;
        private int _currentIndex;

        private readonly Enumerator _enumerator;
        public TimeoutSpawner(ArrowView prefab, Transform transform, int quantity, float startSpeed, float delay)
        {
            if (prefab == null) 
                throw new System.ArgumentNullException();
            
            _prefab = prefab;
            _transformToSpawn = transform;
            _enumerator = new Enumerator(delay);
            _startSpeed = startSpeed;

            for(int i =0; i < quantity; i++)           
                _arrows.Add(new ArrowController(_prefab, _transformToSpawn.position));
            
        }
        public void Update()
        {
            if (_enumerator.CanDo)
            {
                
                _arrows[_currentIndex].Throw(_transformToSpawn.position, _transformToSpawn.right * _startSpeed);
                _currentIndex++;
                if (_currentIndex >= _arrows.Count) _currentIndex = 0;
            }
            _arrows.ForEach(a => a.Update());
        }
    }
    public class Enumerator
    {
        public float CountDownTime { get; set; }
        public float CurentTime { get; private set; }
        public bool CanDo
        {
            get
            {
                CurentTime -= Time.deltaTime;

                if (CurentTime > 0)
                    return false;

                ResetEnumerator();
                return true;
            }
        }
        public Enumerator(float countDownTime)
        {
            CountDownTime = countDownTime;
            ResetEnumerator();
        }
        public void ResetEnumerator()
        {
            CurentTime = CountDownTime;
        }
    }
}
