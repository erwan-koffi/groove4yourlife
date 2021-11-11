using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBar : MonoBehaviour
{
    RectTransform rectTransform;
    public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        Vector2 position = rectTransform.anchoredPosition;

        position.x += FindObjectOfType<GameManager>().secPerBeat * 615 * Time.deltaTime;

        if(position.x >= 200)
        {
            //DestroyImmediate(gameObject);
            position.x = FindObjectOfType<SpawnBar>().spawnPosition().x;
        }

        rectTransform.anchoredPosition = position;
    }
}
