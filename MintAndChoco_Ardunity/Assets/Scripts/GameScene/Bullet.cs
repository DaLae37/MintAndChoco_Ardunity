using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 5000.0f;
    public const int damage = 25;
    float livedTime = 0.0f;

    Rigidbody ri;
    Transform playerTransform;

    void Awake()
    {
        ri = GetComponent<Rigidbody>();
        playerTransform = GameObject.Find("cat").GetComponent<Transform>();
    }

    void Start()
    {
        ri.AddForce(playerTransform.forward * speed);
    }
    void Update()
    {
        livedTime += Time.deltaTime;
        if (livedTime >= 2.0f)
            gameObject.SetActive(false);
        if (!gameObject.activeSelf)
            ri.velocity = Vector3.zero;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Invincible")
        {
            gameObject.SetActive(false);
        }
    }
}
