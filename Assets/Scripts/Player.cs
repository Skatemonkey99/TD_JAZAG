using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public float bulletSpeed = 10f;
    private SpriteRenderer spriteRenderer;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Animator animator;
    public bool isWalking = false;
    public bool canShoot = true;


    void Update()
    {
        GetMovement();
        GetFireInput();
        GetAnimations();
    }

    void GetMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    void GetFireInput()
    {
        if (StatManager.Instance.ammo == 0)
        {
            canShoot = false;
        }
        else if (StatManager.Instance.ammo >= 1)
        {
            canShoot = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (canShoot == true)
            {
                StatManager.Instance.Shoot();
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Vector2 shootingDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - bullet.transform.position).normalized;
                FindObjectOfType<AudioManager>().Play("Shoot");
            }
        }
    }

    void GetAnimations()
    {
        animator.SetBool("isWalking", isWalking);

        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)))
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ammo")
        {
            Destroy(other.gameObject);
            StatManager.Instance.GetAmmo();
            FindObjectOfType<AudioManager>().Play("Ammo");
        }

        if (other.gameObject.tag == "Medkit")
        {
            if (StatManager.Instance.hp < StatManager.Instance.startingHP)
            {
                Destroy(other.gameObject);
                StatManager.Instance.IncreaseHealth();
                FindObjectOfType<AudioManager>().Play("Medkit");
            }
        }

        if (other.gameObject.tag == "Key")
        {
            Destroy(other.gameObject);
            StatManager.Instance.hasKey = true;
            FindObjectOfType<AudioManager>().Play("Key");
        }       
    }



}
