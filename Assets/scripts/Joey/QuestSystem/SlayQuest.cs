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

    public override void OnStartQuest()
    {
        CurrentCount = 0;
        //Update UI and stuff
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

    
}
