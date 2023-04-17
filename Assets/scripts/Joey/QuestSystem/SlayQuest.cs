using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName ="QuestInfo/Quests/KillQuest")]
public class SlayQuest : QuestSO
{
    public List<EnemyData> EnemyTypes;
    public int Count;
    public int CurrentCount;

    public override void OnStartQuest()
    {
        Damage.onEnemyKill += CheckQuest;
        CurrentCount = 0;
        Gui = GameObject.Find("GUI");
        UIReference = Instantiate(UIPrefab,Gui.transform);
    }

    public override void OnEndQuest()
    {
        Damage.onEnemyKill -= CheckQuest;
        Destroy(UIReference);
        UIReference = null;
    }

    public override void UpdateUI()
    {
        UIReference.GetComponent<TextMeshPro>().text = $"{CurrentCount} / {Count}";

    }
    public void CheckQuest(EnemyData data) // call on enemy kill
    {
        Debug.Log("enemy killed");
        foreach(var enemyType in EnemyTypes)
        {
            if (data == enemyType)
            {
                CurrentCount++;
                UpdateUI();
            }
            
        }
        if (CurrentCount >= Count)
        {
            CompleteQuest();
        }

    }

    
}
