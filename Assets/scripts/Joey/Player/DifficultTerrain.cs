using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ProximityEvents/DifficultTerrain")]
public class DifficultTerrain : ProximityEvent
{
    [Range(0f, 1f)]
    public float SpeedReduction;
    public override void Activate(GameObject self, GameObject target)
    {
        target.GetComponent<PlayerController>().playerData.MovementSpeedModifier -= SpeedReduction;
    }

    public override void Deactivate(GameObject self, GameObject target)
    {
        target.GetComponent<PlayerController>().playerData.MovementSpeedModifier += SpeedReduction;
    }
}
