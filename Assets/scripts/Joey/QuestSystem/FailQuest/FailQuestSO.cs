using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FailQuestSO : ScriptableObject
{
    public abstract void OnFail(QuestSO data);
}