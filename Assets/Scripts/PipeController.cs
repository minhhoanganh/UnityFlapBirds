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
        if(BirdsController.instance.flag != null)
        {
            if(BirdsController.instance.flag == 1)
            {
                Destroy(GetComponent<PipeController>());
            }
        }
        PipeMoveMent();
    }

    void PipeMoveMent()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;

        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
