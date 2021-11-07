using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarLife : MonoBehaviour
{

    private List<GameObject> contacts = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.StartsWith("Enemy") && !contacts.Contains(collision.gameObject))
        {
            contacts.Add(collision.gameObject);
            FindObjectOfType<GameManager>().decreaseHealth();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.StartsWith("Enemy") && contacts.Contains(collision.gameObject))
        {
            contacts.Remove(collision.gameObject);
            FindObjectOfType<GameManager>().increaseHealth();
        }
    }
}
