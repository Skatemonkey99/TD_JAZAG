using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public Image image;

    void Update()
    {
        if (StatManager.Instance.hasKey == true)
        {
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
        }
    }
}
