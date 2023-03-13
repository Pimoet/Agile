using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SucceedQuestSO : ScriptableObject
{
    public abstract void OnSucceed(QuestSO data);
}
