using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerData playerData;

    [Range(0f, 1f)]
    [SerializeField] private float cameraAngle;

    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject gunSprite;
    private bool gunFlipped = false;

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
        gun.transform.LookAt(mousePos, Vector3.forward);
        gun.transform.rotation = new Quaternion(gun.transform.rotation.x, gun.transform.rotation.y, 0, 0);
        gun.transform.Rotate(0, 0, -90);
        if(!gunFlipped && gun.transform.rotation.y < 0.7f || gunFlipped && gun.transform.rotation.y > 0.7f)
        {
            Debug.Log("GunFlipped");
            gunFlipped = !gunFlipped;
            gunSprite.transform.Rotate(180, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if(horizontal != 0 || vertical != 0)
        {
            dir = new Vector2(horizontal, vertical * cameraAngle) * playerData.MovementSpeed * playerData.MovementSpeedModifier;
            rb.velocity = dir;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
        
        
    }
}

