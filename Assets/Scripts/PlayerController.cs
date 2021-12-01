using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class PlayerController : MonoBehaviour
{
    float timerShoot =2f;
    [SerializeField] GameObject shoot;
    [SerializeField] float speed = 0.1f;
    bool right = false;
    bool left = false;

    private void Update()
    {
        Move();
        Shoot();
    }


    public void HoldRigt()
    {
        right = true;
    }

    public void ExitRight()
    {
        right = false;
    }

    public void HoldLeft()
    {
        left = true;
    }

    public void ExitLeft()
    {
        left = false;
    }

    void MoveRight()
    {
        if (transform.position.x <= 3.5f)
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
    }

     void MoveRLeft()
    {
        if(transform.position.x >= -3.5f)
          transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
    }

     void Move()
    {
        if (right)
            MoveRight();

        if (left)
            MoveRLeft();
    }

      void Shoot()
     {
        timerShoot -= Time.deltaTime;
        if(timerShoot <= 0)
        {
            Instantiate(shoot, transform.position, Quaternion.identity);
            timerShoot = 2f;
        }
     }
}
