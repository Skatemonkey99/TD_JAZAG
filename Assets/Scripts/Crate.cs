using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public GameObject brokenCratePrefab;
    public GameObject ammoPrefab;
    public GameObject medkitPrefab;
    public float spawnProbability = 0.5f;
    

    void OnCollisionEnter2D(Collision2D other)
    {
        float randomValue = Random.value;  // this generates a random number between 0 and 1 inclusively
        
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Instantiate(brokenCratePrefab, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Crate");

            if (randomValue > spawnProbability)  // 50% chance to do nothing (so if number is between 0.5 and 1)
            {
                return;
            }
            else if (randomValue < spawnProbability / 2) // 25% chance of ammo spawning (so if number is between 0 and 0.25)
            {
                Instantiate(ammoPrefab, transform.position, Quaternion.identity);
            }
            else if (randomValue > spawnProbability / 2) // 25% chance of medkit spawning (so if number is between 0.25 and 0.5)
            {
                Instantiate(medkitPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
