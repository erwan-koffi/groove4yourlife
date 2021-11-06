using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarLife : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameManager>().decreaseHealth();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        FindObjectOfType<GameManager>().increaseHealth();
    }
}
