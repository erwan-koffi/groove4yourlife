using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBar : MonoBehaviour
{
    float nextSpawn = 0.0f;
    public GameObject bar;
    List<GameObject> bars = new List<GameObject>();
    bool first = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;
        if (time > nextSpawn && bars.Count < 9)
        {
            if (!first)
            {
                nextSpawn = time + FindObjectOfType<GameManager>().secPerBeat;
                bars.Add(Instantiate(bar, spawnPosition(), Quaternion.identity));
            }
            else
            {
                first = false;
            }
        }
    }

    public Vector2 spawnPosition()
    {
        return new Vector2(-1200f, 118.7f);
    }
}
