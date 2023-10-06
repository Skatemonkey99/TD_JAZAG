using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public GameObject player;
    public GameObject zombieDeadPrefab;
    Vector2 direction = new Vector2();
    public float speed = 1f;
    public bool playerInVicinity = false;

    public SpriteRenderer spriteRenderer;
    public Collider2D boxCollider;

    void Start()
    {
        DisableComponents();
    }

    void Update()
    {
        FacePlayer();
    }

    void LateUpdate()
    {
        FollowPlayer();      
    }

    void FollowPlayer()
    {
        if (playerInVicinity == true)
        {
            direction = player.transform.position - transform.position;
            Vector3 velocity = direction.normalized * speed * Time.deltaTime;
            transform.position += velocity;
        }
    }

    void FacePlayer()
    {           
        Vector3 faceDirection = player.transform.position - transform.position;      
        float angle = Mathf.Atan2(faceDirection.y, faceDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void EnableComponents()
    {
        spriteRenderer.enabled = true;
        boxCollider.enabled = true;
    }

    void DisableComponents()
    {
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
    }
   
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            StatManager.Instance.ZombieKilled();
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(zombieDeadPrefab, transform.position, Quaternion.identity);
        }

        if (other.gameObject.name == "Player")
        {
            StatManager.Instance.DecreaseHealth();
            FindObjectOfType<AudioManager>().Play("Hit");
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerInVicinity = true;
            EnableComponents();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerInVicinity = false;
            DisableComponents();
        }
    }

}
