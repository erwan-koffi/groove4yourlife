using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    const int MAX_HEALTH = 10;

    public float maxSpeed = 5f;
    public int health = 10;

    float scale = 0.9f;

    Rigidbody2D body;

    // Start is called before the first frame update
    void Start() {
      body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {}

    private void FixedUpdate() {
      transform.Translate(Vector3.left * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        float newScale = health * scale / MAX_HEALTH;
        if (health <= 0)
        {
            Die();
        } else
        {
            gameObject.transform.localScale = new Vector3(newScale, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
