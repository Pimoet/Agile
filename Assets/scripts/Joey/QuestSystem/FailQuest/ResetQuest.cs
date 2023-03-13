using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quests/FailConditions/Reset")]
public class ResetQuest : FailQuestSO
{
    public override void OnFail(QuestSO data)
    {
        //reset the quest and perhaps the game or go to a lose screen
        data.OnStartQuest();
    }
}
