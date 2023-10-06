using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateWithKey : MonoBehaviour
{
    public GameObject brokenCratePrefab;
    public GameObject keyPrefab;


    void OnCollisionEnter2D(Collision2D other)
    {      
        if (other.gameObject.tag == "Bullet")
        {
            FindObjectOfType<AudioManager>().Play("Crate");
            Destroy(gameObject);
            Instantiate(brokenCratePrefab, transform.position, Quaternion.identity);
            Instantiate(keyPrefab, transform.position, Quaternion.identity);           
        }
    }
}
