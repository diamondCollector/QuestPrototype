using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    [SerializeField] List<Quest> quests;
    string questSummary;
    [SerializeField] TextMeshProUGUI questsSummaryText;


    public void AddQuest(Quest quest)
    {
        quests.Add(quest);
    }

    public List<Quest> GetActiveQuests()
    {
        return quests;
    }

    public void UpdateQuestSummary()
    {
        questSummary = "Quests: \n";
        for (int i = 0; i < quests.Count; i++)
        {
            questSummary += i + 1 + ". " + quests[i].name + ".\n" + "Status: " + quests[i].status + "\n" + "\n";
        }

        questsSummaryText.text = questSummary;
    }
}
