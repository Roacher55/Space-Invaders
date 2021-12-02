using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScoreController : MonoBehaviour
{
    [SerializeField] List<Text> textScores;
    [SerializeField] StatisticData statisticData;
    [SerializeField] GameObject disableGrid;
    [SerializeField] GameObject activeGrid;
    [SerializeField] GameObject howManyTimesPlay;

    public void UpdateList()
    {
        for (int i = 0; i < statisticData.scores.Length; i++)
        {
            textScores[i].text = i + 1 + ". Wynik - " + statisticData.scores[i] + " !";
        }
        howManyTimesPlay.GetComponent<Text>().text = "Liczba gier: " + statisticData.howManyTimesplay;
        disableGrid.SetActive(false);
        activeGrid.SetActive(true);
    }
}
