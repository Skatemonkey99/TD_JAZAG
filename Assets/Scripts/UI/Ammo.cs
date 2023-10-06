using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public Text ammoText;

    void Update()
    {
        ammoText.text = StatManager.Instance.ammo.ToString();
    }
}
