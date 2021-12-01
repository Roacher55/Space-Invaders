using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWhoShoot : Enemy
{

    float timerShoot;
    [SerializeField] GameObject shoot;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        timerShoot = Random.Range(4f, 7f);
    }

    // Update is called once per frame
    void  Update()
    {
        Move();
        Shoot();
        DestroyOutside();
    }

    void Shoot()
    {
        timerShoot -= Time.deltaTime;
        if (timerShoot <= 0)
        {
            GameObject temp =  Instantiate(shoot, transform.position, Quaternion.identity);
            temp.GetComponent<EnemyShoot>().losePoint = LostPoints();
            timerShoot = Random.Range(4f, 7f) - (speed * 0.5f);
        }
    }

    int LostPoints()
    {
        int lostPoints = 0;
        foreach (GameObject e in gameController.enemies)
        {
            if (e.transform.position.x - 0.1f < transform.position.x && e.transform.position.x + 0.1f > transform.position.x)
            {
                lostPoints++;
            }        
        }
        return lostPoints * 2;
    }
}
