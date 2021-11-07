using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public bool destroyed;
    public float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        destroyed = false;
        destroyTime = 0f;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.name.StartsWith("Enemy") || hitInfo.name == "BulletWall")
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if(enemy != null)
            {
                GetComponent<AudioSource>().Play();
                enemy.TakeDamage(FindObjectOfType<GameManager>().multiplier);
            }
            ParticleSystem particle = GetComponent<ParticleSystem>();
            particle.Emit(100);
            particle.Play();
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().Sleep();
            GetComponent<Renderer>().enabled = false;
            destroyTime = Time.time;
            destroyed = true;
            rb.velocity = Vector2.zero;
        }
    }

    private void Update()
    {
        if(destroyed)
        {
            if (destroyTime + (FindObjectOfType<GameManager>().secPerBeat / 2) <= Time.time)
            {
                Destroy(gameObject);
            }
        }
    }
}
