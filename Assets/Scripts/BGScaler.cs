using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent <SpriteRenderer>();
        Vector3 tempScale = transform.localScale;

        float height = sr.bounds.size.y;
        float width = sr.bounds.size.x;

        float wordHeight = Camera.main.orthographicSize * 2f;
        float wordWidth = wordHeight * Screen.width/Screen.height;

        tempScale.y = wordHeight / height;
        tempScale.x = wordWidth / width;

        transform.localScale = tempScale;
    }
}
