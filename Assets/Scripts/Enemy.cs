using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Enemy : MonoBehaviour
{
    const int MAX_HEALTH = 10;

    public float maxSpeed = 5f;
    public int health = 10;
    public float speed = 1.001f;
    public int pause = 8;
    public float pauseTime = 0f;
    bool ignoreRight = false;
    bool hasTouchedRight = false;
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
    void Update() {

      if(hasTouchedRight && pauseTime + 2 * FindObjectOfType<GameManager>().secPerBeat <= Time.time) {
        transform.GetChild(1).GetComponent<Light2D>().enabled = true;
      }

      if(hasTouchedRight && pauseTime + 4 * FindObjectOfType<GameManager>().secPerBeat <= Time.time) {
        transform.GetChild(1).GetComponent<Light2D>().enabled = false;
      }

      if(hasTouchedRight && pauseTime + 5 * FindObjectOfType<GameManager>().secPerBeat <= Time.time) {
        transform.GetChild(1).GetComponent<Light2D>().enabled = true;
      }

      if(hasTouchedRight && pauseTime + 6 * FindObjectOfType<GameManager>().secPerBeat <= Time.time) {
        transform.GetChild(1).GetComponent<Light2D>().enabled = false;
      }

      if(hasTouchedRight && pauseTime + 6.5 * FindObjectOfType<GameManager>().secPerBeat <= Time.time) {
        transform.GetChild(1).GetComponent<Light2D>().enabled = true;
      }

      if(hasTouchedRight && pauseTime + 7 * FindObjectOfType<GameManager>().secPerBeat <= Time.time) {
        transform.GetChild(1).GetComponent<Light2D>().enabled = false;
      }

      if(hasTouchedRight && pauseTime + 7.5 * FindObjectOfType<GameManager>().secPerBeat <= Time.time) {
        transform.GetChild(1).GetComponent<Light2D>().enabled = false;
      }

      if(hasTouchedRight && pauseTime + pause * FindObjectOfType<GameManager>().secPerBeat <= Time.time) {
        stopped = false;
        ignoreRight = true;
        direction = Vector3.left;
        transform.GetChild(1).GetComponent<Light2D>().enabled = true;
      }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool toStop = collision.name == "Right";

        if (collision.name == "Right" && !ignoreRight)
        {
            pauseTime = Time.time;
            hasTouchedRight = true;
            audioSource.Play(0);
            transform.GetChild(1).GetComponent<Light2D>().enabled = true;
        }

        if (collision.name == "Left" || collision.name == "Player")
        {
          FindObjectOfType<GameManager>().GameOver();
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
        float newScale = (health * scale / MAX_HEALTH);
        if (health <= 0)
        {
            Die();
        } else
        {
            gameObject.transform.localScale = new Vector3(Mathf.Max(newScale, 0.2f), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
    }

    void Die()
    {
        FindObjectOfType<GameManager>().incrementScore();
        Destroy(gameObject);
    }
}
