using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBar : MonoBehaviour
{
    const float SPAWN_X = 10;
    const float BASE_Y = 5f;

    public GameObject bar;
    public float spawnRate = 0.5f;

    float nextSpawn = 0.0f;
    Vector2 spawnPosition;


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
      if (Time.time > nextSpawn && GameObject.FindGameObjectsWithTag("MovingBar").Length < 5) {
        nextSpawn = Time.time + spawnRate;
        float y = BASE_Y;
        spawnPosition = new Vector2(SPAWN_X, y);
        Instantiate(bar, spawnPosition, Quaternion.identity);
      }
    }
}
