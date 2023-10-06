using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFacingDirection : MonoBehaviour
{
    void Update()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the character to the mouse position
        Vector3 aimDirection = mousePosition - transform.position;

        // Calculate the angle (in degrees) from the character to the mouse
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        // Rotate the character to face the mouse direction
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
