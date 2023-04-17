using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestSO : ScriptableObject
{
    public string QuestName;

    [TextArea(4,4)]
    public string Description;

    public float Reward; // money for now, can be changed to items or create a list of things that could be rewards.
    public QuestTypes QuestType;
    public bool RestartOnDeath;

    public bool HasFollowUpQuest;

    public QuestSO FollowUpQuest;


    public SucceedQuestSO Success;
    public FailQuestSO Failure;

    public GameObject UIPrefab;
    public GameObject UIReference;
    protected GameObject Gui;


    public enum QuestTypes
    {
        Fetch,
        Travel,
        Interact,
        Slay,
        Time,
        Misc
    }


    public void CompleteQuest()
    {
        if(Success != null)
        Success.OnSucceed(this);
    }
    public void FailQuest()
    {
        if(Failure != null)
        Failure.OnFail(this);
    }

    public abstract void UpdateUI();

    public abstract void OnStartQuest();
    public abstract void OnEndQuest();
}
