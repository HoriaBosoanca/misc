using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReloadTimer : MonoBehaviour
{
    public float timeLeft;
    void Update()
    {
        timeLeft = Mathf.Round(timeLeft * 10) / 10;
        if(timeLeft <= 0)
        {
            GetComponent<TextMeshProUGUI>().text = "";
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = timeLeft.ToString() + "s"; //gets rounded to 1st decimal place
        }
    }
}
