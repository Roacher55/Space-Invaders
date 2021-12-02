using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    static bool direction = true;
    float xRight = 3f;
    float xLeft = -3f;
    protected static float speed =1f;
    float additionalSpeed = 0.1f;   
    float timer = 5f;
    static float timerMinus =5f;
    protected GameController gameController;
    float errorMargin = 0.3f;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        speed = 1f;
    }

    // Update is called once per frame
   void Update()
    {
        Move();
        DestroyOutside();
        // Debug.Log(speed);
    }

    protected void Move()
    {

        MoveLeftRight();
        MoveDown();

    }

    void MoveLeftRight()
    {
        if (direction)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(xRight, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(xLeft, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }

        if (transform.position.x == xRight)
        {
            direction = false;
            
        }
        else if (transform.position.x == xLeft)
        {
            direction = true;
        }
    }

    void MoveDown()
    {
       
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
            timer = timerMinus;
            InSameLine();
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerShoot")
        {
            Destroy(collision.gameObject);
            GameController.points++;
            gameController.enemies.Remove(gameObject);
            Destroy(gameObject);

            FasterEnemies();
        }

        if (collision.tag == "Player")
        {

            LostPoints();
            gameController.enemies.Remove(gameObject);
            Destroy(gameObject);

            FasterEnemies();
        }
    }

    void LostPoints()
    {
        int lostPoints = 0;
        foreach (GameObject e in gameController.enemies)
        {
            if (e.transform.position.x - errorMargin < transform.position.x && e.transform.position.x + errorMargin > transform.position.x)
            {
                lostPoints++;
            }

        }
        lostPoints = lostPoints * 2;
        GameController.points = GameController.points - lostPoints;
        if (GameController.points < 0)
        {
            GameController.points = 0;
        }
    }

    protected void DestroyOutside()
    {
        if(transform.position.y <= -8f)
        {
            gameController.enemies.Remove(gameObject);
            Destroy(gameObject);

        }
    }

    void InSameLine()
    {
        foreach (var x in gameController.enemies)
        {
            if (x.transform.position.x + errorMargin > transform.position.x && x.transform.position.x - errorMargin < transform.position.x)
            {
                transform.position = new Vector3(x.transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }

    void FasterEnemies()
    {
        speed = speed + additionalSpeed;
        timerMinus -= additionalSpeed;
    }
}
