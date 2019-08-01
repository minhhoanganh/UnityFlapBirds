using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsController : MonoBehaviour
{
    public static BirdsController instance;
    public float bounceForce;

    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flyClip, pingClip, DeadClip;

    private bool isAlive;
    private bool didFlap;
    private GameObject spawner;

    public float flag = 0;
    public int score;

    private void Awake()
    {
        isAlive = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spawner = GameObject.Find("Spawner Pipe");
        MakeInstance();
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void FixedUpdate()
    {
        BirdsMoveMent();
    }

    void BirdsMoveMent()
    {
        if(isAlive)
        {
            if(didFlap)
            {
                didFlap = false;
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
                audioSource.PlayOneShot(flyClip);
            }
        }
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

    public void FlapButton()
    {
        didFlap = true;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "PipeHolder")
        {
            score++;
            if(MainController.instance != null)
            {
                MainController.instance.SetScore(score);
            }
            audioSource.PlayOneShot(pingClip);
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground")
        {
            flag = 1;
            if(isAlive)
            {
                isAlive = false;
                Destroy(spawner);
                audioSource.PlayOneShot(DeadClip);
                anim.SetTrigger("Died");
                if(MainController.instance != null)
                {
                    MainController.instance.BirdsDiedShowPanel(score);
                }
            }
        }
    }
}
