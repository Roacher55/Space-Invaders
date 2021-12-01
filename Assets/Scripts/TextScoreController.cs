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

    public void UpdateList()
    {
        for (int i = 0; i < 10; i++)
        {
            textScores[i].text = i + 1 + ". Wynik - " + statisticData.scores[i] + " !";
        }
        disableGrid.SetActive(false);
        activeGrid.SetActive(true);
    }
}
