using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombiesKilled : MonoBehaviour
{
    public Text killsText;

    void Update()
    {
        killsText.text = StatManager.Instance.zombiesKilled.ToString();
    }
}
