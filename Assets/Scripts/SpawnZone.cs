using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{

    public GameObject zone;

    float nextSpawn = 0.0f;

    const float MIN_X = -1.5f;
    const float MAX_X = 9.72f;

    const float MIN_Y = 0f;
    const float MAX_Y = 5.31f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time;
        if(t > nextSpawn)
        {
            if (nextSpawn != 0f)
            {
                Vector3 pos = new Vector3(Random.Range(MIN_X, MAX_X), Random.Range(MIN_Y, MAX_Y), 2f);
                Instantiate(zone, pos, Quaternion.identity);
            }
            nextSpawn = t + (FindObjectOfType<GameManager>().secPerBeat * 16);
        }
    }
}
