using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    float speed = 5f;
   
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 11f, transform.position.z), speed * Time.deltaTime);
        if (transform.position.y >= 11f)
            Destroy(gameObject);
    }
}
