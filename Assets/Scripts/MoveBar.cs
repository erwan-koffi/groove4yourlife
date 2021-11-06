using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < -13) {
            transform.Translate(23, 0, 0);
        }
        else {
            transform.Translate(Time.deltaTime*-4, 0, 0);
        }
    }
}
