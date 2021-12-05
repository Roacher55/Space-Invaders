using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update

   [SerializeField] GameObject enemy;
   [SerializeField] GameObject enemyShoot;
    public List<GameObject> enemies = new List<GameObject>();
    Vector3 startEnemyPosition = new Vector3(-2f, 5.5f, 0);
    public static int points;
    [SerializeField] StatisticData statisticData;
    [SerializeField] GameObject disableGrid;
    [SerializeField] GameObject activeGrid;
    [SerializeField] GameObject yourScore;
    [SerializeField] GameObject yourPlace;
    bool onlyOnce = true;
    
    void Start()
    {
        points = 0;
        SetEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        EndGame();
    }

    void SetEnemy()
    {
       float startX = startEnemyPosition.x;
       for(int j = 0; j < 2; j++)
       { 
            for (int i=0; i<5; i++)
            {
                enemies.Add(Instantiate(enemyShoot, startEnemyPosition, Quaternion.identity));
                startEnemyPosition.x += 1f;
            }
            startEnemyPosition.y -= 1f;
           startEnemyPosition.x = startX;
       }

        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < 5; i++)
            {
                enemies.Add(Instantiate(enemy, startEnemyPosition, Quaternion.identity));
                startEnemyPosition.x += 1f;
            }
            startEnemyPosition.y -= 1f;
            startEnemyPosition.x = startX;
        }
    }

    void EndGame()
    {
        if (enemies.Count == 0 && onlyOnce)
        {
            statisticData.howManyTimesplay++;
            UpdateScore();
            EndGameText();
            disableGrid.SetActive(false);
            activeGrid.SetActive(true);
            onlyOnce = false;
        }
        
    }

    void UpdateScore()
    {
        var tempPoints = points;
        int temp;
        
            for (int i = 0; i < statisticData.scores.Length; i++)
            {
                if (tempPoints > statisticData.scores[i])
                {
                    temp = statisticData.scores[i];
                    statisticData.scores[i] = tempPoints;
                    tempPoints = temp;
                    Debug.Log(i + " indeks i wynik " + statisticData.scores[i]);
                }
        }
        EditorUtility.SetDirty(statisticData);
    }

    void EndGameText()
    {
        yourScore.GetComponent<Text>().text = "Twój wynik: " + points;
        for (int i = 0; i < statisticData.scores.Length; i++)
        {
            if (points == statisticData.scores[i])
            {
                yourPlace.GetComponent<Text>().text = "Twoje miejsce : " + (i+1);
                return;
            }
            
        }
        yourPlace.GetComponent<Text>().text = "Poza top 10";
    }

   public void ClickMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}




