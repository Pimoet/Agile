using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class TempMovement : MonoBehaviour
{
    
    Rigidbody2D RB;

    [SerializeField]
    private PlayerData _PlayerData;


    [HideInInspector]
    public Vector2 moveDir;

    void Start()
    {
        //_PlayerData.MovementSpeed 
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
        RB.velocity += moveDir.normalized * _PlayerData.MovementSpeed * Time.fixedDeltaTime;
    }
}
