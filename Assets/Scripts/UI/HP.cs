using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Text hpText;

    void Update()
    {
        hpText.text = StatManager.Instance.hp.ToString();
    }
}
