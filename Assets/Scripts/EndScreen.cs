using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("CarStart");
    } 
    
}
