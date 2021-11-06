using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMovement : MonoBehaviour
{
    float nextSpawn = 0.0f;
    public GameObject bar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;
        if(time > nextSpawn)
        {
            nextSpawn = time + FindObjectOfType<GameManager>().secPerBeat;
            Vector2 spawnPosition = new Vector2(-1225f, 118.7f);
            Instantiate(bar, spawnPosition, Quaternion.identity);
        }
    }
}
