using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    
    Rigidbody2D RB;


    public float moveSpeed = 5f;

    [HideInInspector]
    public Vector2 moveDir;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        Debug.Log(RB.velocity.sqrMagnitude);
    }

    private void FixedUpdate() 
    {
        RB.velocity += moveDir.normalized * moveSpeed * Time.fixedDeltaTime;
    }
}
