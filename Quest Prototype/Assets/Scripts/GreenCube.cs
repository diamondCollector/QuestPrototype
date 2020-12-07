using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCube : QuestGiver
{
    string questName;
    // Start is called before the first frame update
    void Start()
    {
        questName = "Go to Green Cube";
    }

    protected override void OnTriggerEnter(Collider other)
    {
        QuestManager questManager = other.GetComponent<QuestManager>();
        if (questManager != null)
        {
            List<Quest> playerActiveQuests = questManager.GetActiveQuests();

            foreach (Quest quest in playerActiveQuests)
            {
                if (quest.name == questName && quest.isStarted)
                {
                    UpdateQuest(quest);
                    questManager.UpdateQuestSummary();
                    Debug.Log("Return to Red Cube");

                }
            }            
        }
        
    }
}
