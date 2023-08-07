using System.Collections.Generic;

namespace PlatformerMVC
{
    public class QuestDistributorController
    {
        private PlayerController _player;
        private List<IQuestStory> _questStoriesList;

        private List<IUnlockable> _unlockables;


        public QuestDistributorController(PlayerController player, List<IQuestStory> questStoryList, List<IUnlockable> unlockables)
        {
            _player = player;
            _questStoriesList = new List<IQuestStory>();
            _questStoriesList = questStoryList;
            _unlockables = unlockables;
 
            Subscribe();
        }

        private void Subscribe()
        {
            for (int i = 0; i < _questStoriesList.Count; i++)
            {
                for(int j = 0; j< _unlockables.Count; j++)
                {
                    if (_unlockables[j].QuestStoryId == _questStoriesList[i].QuestStoryId)
                    {
                        _questStoriesList[i].QuestStoryCompleted += _unlockables[j].Unlock;
                    }
                }            
            }
        }
    }
}
