using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    const float SPAWN_X = 16f;
    const float BASE_Y = -5.5f;

    public GameObject enemy;
    public float spawnRate = 2f;

    float nextSpawn = 0.0f;
    public Vector2 spawnPosition;


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
      if (Time.time > nextSpawn) {
        nextSpawn = Time.time + FindObjectOfType<GameManager>().secPerBeat;
        float y = BASE_Y + (int) Random.Range(0f, 10f);
        spawnPosition = new Vector2(SPAWN_X, y);
        Instantiate(enemy, spawnPosition, Quaternion.identity);
      }
    }
}
