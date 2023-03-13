using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProximityEventHandler : MonoBehaviour
{
    [SerializeField] private ProximityEvent action;
    [SerializeField] private string tag;
    [SerializeField] private List<GameObject> additionalTargets;

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.CompareTag(tag))
        {
            if(additionalTargets.Count > 0)
            {
                action.Activate(this.gameObject, hit.gameObject, additionalTargets);
            }
            else
            {
                action.Activate(this.gameObject, hit.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D hit)
    {
        if (hit.gameObject.CompareTag(tag))
        {
            if (additionalTargets.Count > 0)
            {
                action.Deactivate(this.gameObject, hit.gameObject, additionalTargets);
            }
            else
            {
                action.Deactivate(this.gameObject, hit.gameObject);
            }
        }
    }
}
