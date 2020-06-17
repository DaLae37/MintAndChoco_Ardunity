using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -50, 0);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 1.8)
        {
            gameObject.SetActive(false);
        }
    }
}
