using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bulletPrefab;
    public float lastShootTime = 0f;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
            audioSource.pitch = (int)Random.Range(1f, 4f);
            audioSource.Play(0);
            FindObjectOfType<GameManager>().manageMultiplier(lastShootTime, Time.fixedTime);
            lastShootTime = Time.fixedTime;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
}
