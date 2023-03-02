using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dash : Abillity
{
    public float dashVelocity;

    public override void Activate(GameObject parent)
    {
        Debug.Log("DASH");
        Movement movement = parent.GetComponent<Movement>();
        Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();

        rb.velocity = movement.moveDir.normalized * dashVelocity;
        Debug.Log(rb.velocity.sqrMagnitude);
    }

}
