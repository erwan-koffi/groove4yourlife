using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarLife : MonoBehaviour
{

  private ContactPoint2D[] contacts = new ContactPoint2D[10];

  void OnCollisionEnter(Collision collision) {
          currentCollision += 1;

          foreach (ContactPoint contact in collision.contacts) {
            
          }
  }

    public int currentCollision = 0;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
