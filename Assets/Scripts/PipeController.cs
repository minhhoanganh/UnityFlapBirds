using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PipeMoveMent();
    }

    void PipeMoveMent()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;

        transform.position = temp;
    }
}
