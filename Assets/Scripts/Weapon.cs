using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bulletPrefab;
    public float lastShootTime = 0f;
    public AudioSource audioSource;
    public AudioSource normalMusic;
    public AudioSource bonusMusic;
    public AudioClip[] audioClips;
    public int laserDuration = 8;
    float laserStart;
    bool firingLaser = false;

    // Start is called before the first frame update
    void Start() {
        audioSource = GetComponent<AudioSource>();
        AudioSource[] audio = FindObjectOfType<GameManager>().GetComponents<AudioSource>();
        normalMusic = audio[0];
        bonusMusic = audio[1];
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1") && !firingLaser) {
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
            firingLaser = false;
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
        firingLaser = true;
        normalMusic.mute = true;
        bonusMusic.mute = false;
        transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        FindObjectOfType<ShakeBehavior>().TriggerShake(FindObjectOfType<GameManager>().secPerBeat * laserDuration);
    }

    public void LaserEnd()
    {
        normalMusic.mute = false;
        bonusMusic.mute = true;
        transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
    }
}
