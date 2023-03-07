using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestSO : ScriptableObject
{
    public string Name;

    [TextArea(4,4)]
    public string Description;

    public float Reward; // money for now, can be changed to items or create a list of things that could be rewards.
    public QuestTypes QuestType;

    public bool HasFollowUpQuest;

    public QuestSO FollowUpQuest;


    public enum QuestTypes
    {
        Fetch,
        Travel,
        Interact,
        Slay,
        Time,
        Misc
    }


    public abstract void CompleteQuest();
    public abstract void FailQuest();
}
