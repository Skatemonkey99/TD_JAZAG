using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePlayed : MonoBehaviour
{
    public Text timeText;

    void Update()
    {
        timeText.text = StatManager.Instance.timePlayed.ToString("0");
    }
}
