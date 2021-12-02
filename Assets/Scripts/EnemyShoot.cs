using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 2.5f;
    public int losePoint = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -8f, transform.position.z), speed * Time.deltaTime);
        if (transform.position.y <= -8f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameController.points = GameController.points - losePoint;
            if(GameController.points<0)
            {
                GameController.points = 0;
            }
            Destroy(gameObject);
            
        }
    }
}
