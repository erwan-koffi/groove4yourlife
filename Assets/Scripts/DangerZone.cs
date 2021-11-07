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
        GameObject sprite = gameObject.transform.GetChild(0).gameObject;

        if (spawnTime + (12 * beat) <= Time.time)
        {
            Destroy(gameObject);
        }

        //C'est crado mais j'ai la flemme.
        if (spawnTime + beat >= Time.time)
        {
            sprite.SetActive(false);
        }
        else if (spawnTime + 2 * beat >= Time.time)
        {
            sprite.SetActive(true);
        }
        else if (spawnTime + 3 * beat >= Time.time)
        {
            sprite.SetActive(false);
        }
        else if (spawnTime + 4 * beat >= Time.time)
        {
            sprite.SetActive(true);
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