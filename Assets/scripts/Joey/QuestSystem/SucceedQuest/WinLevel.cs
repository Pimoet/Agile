using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="QuestInfo/SuccessConditions/Win")]
public class WinLevel : SucceedQuestSO
{
    public override void OnSucceed(QuestSO data)
    {
        Debug.Log($"you have cleared the quest '{data.QuestName}' and thus have cleared the game! :D");
        // clear game code
    }
}
