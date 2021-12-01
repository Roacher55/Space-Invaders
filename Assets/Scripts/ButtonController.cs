using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject disableGrid;
    [SerializeField] GameObject activeGrid;
    public void  ClickStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void MenuGrid()
    {
        disableGrid.SetActive(false);
        activeGrid.SetActive(true);
    }
}
