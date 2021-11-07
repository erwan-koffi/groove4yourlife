using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bulletPrefab;
    public float lastShootTime = 0f;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public int laserDuration = 8;
    float laserStart;

    // Start is called before the first frame update
    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
            //audioSource.pitch = (int)Random.Range(1f, 3f);
            int clip = (int)Random.Range(0f, 4f);
            audioSource.clip = audioClips[clip];
            audioSource.Play(0);
            FindObjectOfType<GameManager>().manageMultiplier(lastShootTime, Time.fixedTime);
            lastShootTime = Time.fixedTime;
        }
        if(laserStart + FindObjectOfType<GameManager>().secPerBeat * laserDuration <= Time.time)
        {
            LaserEnd();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }

    public void Laser()
    {
        laserStart = Time.time;
        transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
    }

    public void LaserEnd()
    {
        transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
    }
}
