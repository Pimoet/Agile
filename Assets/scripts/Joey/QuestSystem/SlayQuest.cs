using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quests/KillQuest")]
public class SlayQuest : QuestSO
{
    public string EnemyName; //replace with Enemy ScriptableObject or logic for the name
    public int Count;
    public int CurrentCount;

    //Event from player called OnEnemyKill PlayerCombat.OnEnemyKill += CheckQuest

    public override void CompleteQuest()
    {
        Debug.Log("you've completed the slaying quest");
        //give player reward, remove quest from list and unsubscrible from events
    }

    public override void FailQuest()
    {
        // depends on each quest, might make specific SO's for completing and failing quests
    }

    public void CheckQuest(string name) // call on enemy kill
    {
        if(name == EnemyName)
        {
            CurrentCount++;
        }
        if(CurrentCount >= Count)
        {
            CompleteQuest();
        }
    }

    private void OnDisable()
    {
        //unsubscribe from events
    }
}
