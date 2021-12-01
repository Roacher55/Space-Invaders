using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPoints : MonoBehaviour
{
    // Start is called before the first frame update
    Text text;
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Points: " + GameController.points + "!";
    }
}
