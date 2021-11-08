using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float beat = FindObjectOfType<GameManager>().secPerBeat;
        GameObject sprite2 = gameObject.transform.GetChild(1).gameObject;

        if (spawnTime + (8 * beat) <= Time.time)
        {
            Destroy(gameObject);
        }

        //C'est crado mais j'ai la flemme.
        if (spawnTime + beat >= Time.time)
        {
            sprite2.SetActive(false);
        }
        else if (spawnTime + 2 * beat >= Time.time)
        {
            sprite2.SetActive(true);
        }
        else if (spawnTime + 3 * beat >= Time.time)
        {
            sprite2.SetActive(false);
        }
        else if (spawnTime + 4 * beat >= Time.time && !FindObjectOfType<GameManager>().gameover)
        {
            GetComponent<AudioSource>().Play();
            sprite2.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Debug.Log("Hit Player");
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
