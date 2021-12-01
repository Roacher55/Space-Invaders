using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boost : MonoBehaviour
{
    [SerializeField] GameObject clickBoost;
    [SerializeField] GameObject timerBoost;
    PlayerController playerController;
    float timer = 40f;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    void Timer() 
    {   
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }

        timerBoost.GetComponent<Text>().text= timer.ToString("F2"); ;

        if(timer <= 0f)
        {
             clickBoost.SetActive(true);
             timerBoost.SetActive(false);
        }
    }

    public void ClickBoost()
    {
        clickBoost.SetActive(false);
        timerBoost.SetActive(true);
        timer = 40f;
        playerController.timerForNitro = 5f;
    }
}
