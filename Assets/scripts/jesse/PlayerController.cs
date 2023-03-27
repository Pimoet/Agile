using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerData playerData;

    [Range(0f, 1f)]
    [SerializeField] private float cameraAngle;

    private Rigidbody2D rb;

    [HideInInspector]
    public Vector2 dir;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.LookAt(mousePos, Vector3.forward);
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        dir = new Vector2(horizontal, vertical).normalized;
        rb.velocity = new Vector2(horizontal, vertical * cameraAngle) * playerData.MovementSpeed * playerData.MovementSpeedModifier;
        
    }
}

