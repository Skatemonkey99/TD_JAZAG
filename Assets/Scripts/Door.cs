using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public BoxCollider2D triggerCollider;
    public SpriteRenderer closedSprite;
    public SpriteRenderer openedSprite;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (StatManager.Instance.hasKey == true)
            {
                FindObjectOfType<AudioManager>().Play("Gate");
                boxCollider.enabled = false;
                triggerCollider.enabled = false;
                closedSprite.enabled = false;
                openedSprite.enabled = true;
                StatManager.Instance.hasKey = false;
            }
        }
    }

   /* void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            openedSprite.enabled = false;
            boxCollider.enabled = true;
            closedSprite.enabled = true;                           
        }
    }*/


}
