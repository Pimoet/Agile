using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public float projectileSpeed;

    public BoxCollider2D ArrowCollidder;

    //projectile target
    private GameObject player;
    private Rigidbody2D RB;

    //projectile speed
    public float force;
    public float LifeTime;

    public int HomingRange;

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = HomingRange;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    private void Start()
    {

        RB = GetComponent<Rigidbody2D>();

        if (FindClosestEnemy() != null)
        {

            player = FindClosestEnemy();

            Vector3 direction = player.transform.position - transform.position;
            RB.velocity = new Vector2(direction.x, direction.y).normalized * force;

            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            Destroy(gameObject, LifeTime);


            Vector3 vectorToTarget = FindClosestEnemy().transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = q;

            RB.AddForce(transform.right * projectileSpeed, ForceMode2D.Impulse);
        }
        else
        {
            RB.AddForce(transform.right * projectileSpeed, ForceMode2D.Impulse);
        }
    }
}
