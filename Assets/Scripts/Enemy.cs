using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    const int MAX_HEALTH = 10;

    public float maxSpeed = 5f;
    public int health = 10;
    public float speed = 1.001f;
    float scale = 0.9f;

    Rigidbody2D body;

    Vector3 direction;
    bool stopped;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
        direction = Vector3.left;
        stopped = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool toStop = collision.name == "Right";

        if (collision.name == "Right")
        {
            audioSource.Play(0);
        }

        if (collision.name.StartsWith("Enemy"))
        {
            BoxCollider2D collider = GetComponents<BoxCollider2D>()[1];
            if (collider.IsTouching(collision))
            {
                Enemy enemy = collision.GetComponent<Enemy>();
                toStop = enemy.stopped;
                if (enemy.stopped)
                {
                    toStop = true;
                } else
                {
                    direction = Vector3.left / 2;
                }
            }
        }

        if (toStop)
        {
                direction = Vector3.zero;
                stopped = true;
        }

        if (collision.name == "Beam")
        {
            Die();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.StartsWith("Enemy"))
        {
            direction = Vector3.left;
        }
    }

    private void FixedUpdate() {
      transform.Translate(direction * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        float newScale = (health * scale / MAX_HEALTH) + 0.02f;
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
