using UnityEngine;

public class PinballBall : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D myBody; 

    AudioSource myAudioSource;

    [SerializeField]
    AudioClip bumperClip, wallClip, pipeClip, fanClip;

    Vector2 lastVel;

    [SerializeField]
    PinballManager myManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    //calls when a collision first occurs
    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "bumper":
                myAudioSource.PlayOneShot(bumperClip);
                myManager.AddScore();
                break;
            case "wall":
                myAudioSource.PlayOneShot(wallClip);
                break;
            case "pipe":
                myAudioSource.PlayOneShot(pipeClip);
                break;
            case "fan":
                myAudioSource.PlayOneShot(fanClip);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("direction"))
        {
            //myManager.AddScore();
            //Vector2 dirVec = new Vector2(collision.gameObject.transform.up.x, collision.gameObject.transform.up.y);
            myBody.linearVelocity += (Vector2)collision.gameObject.transform.up * 100;
        }
    }

}
