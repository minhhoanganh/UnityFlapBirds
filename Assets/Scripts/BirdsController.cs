using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsController : MonoBehaviour
{
    public float bounceForce;

    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flyClip, pingClip, DeadClip;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        BirdsMoveMent();
    }

    void BirdsMoveMent()
    {
        myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
        audioSource.PlayOneShot(flyClip);


        float angel = 0;
        if (myBody.velocity.y > 0)
        {
            angel = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
        else if (myBody.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (myBody.velocity.y < 0)
        {
            angel = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }
}
