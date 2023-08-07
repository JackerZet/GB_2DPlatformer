namespace PlatformerMVC
{
    public interface IUnlockable
    {
        string QuestStoryId { get; }
        void Unlock(IQuestStory story);
    }
}
