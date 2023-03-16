using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float shootingCooldown;
    private float shootingTime;
    private bool shot;

    private Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        shootingTime = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.point);
        }
    }
}
