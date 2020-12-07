using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    QuestManager subscribedPlayer;
    [SerializeField] Quest[] questsToGive;

    protected virtual void StartQuest(Quest quest)
    {
        quest.onStart();
    }

    protected virtual void UpdateQuest(Quest quest)
    {
        quest.onUpdated();
    }

    protected virtual void FinishQuest(Quest quest)
    {
        quest.OnFinished();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        QuestManager questManager = other.GetComponent<QuestManager>();
        if (questManager != null)
        {
            subscribedPlayer = questManager;
            List<Quest> playerActiveQuests = questManager.GetActiveQuests();
            for (int i = 0; i < questsToGive.Length; i++)
            {
                if (!playerActiveQuests.Contains(questsToGive[i]))
                {
                    questManager.AddQuest(questsToGive[i]);
                    StartQuest(questsToGive[i]);
                    questManager.UpdateQuestSummary();
                } 
                else
                {
                    string questName = questsToGive[i].name;
                    foreach (Quest quest in playerActiveQuests)
                    {
                        if (quest.name == questName && quest.isStarted && !quest.isUpdated)
                        {
                            Debug.Log("Before you return complete the quest(" + questName + ") first!");
                        } 
                        else if (quest.name == questName && quest.isUpdated)
                        {
                            FinishQuest(quest);
                            questManager.UpdateQuestSummary();
                        }
                    }
                }
            }
        }
    }
}
