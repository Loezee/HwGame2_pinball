using UnityEngine;

public class PinballLauncher : MonoBehaviour
{

    SpringJoint2D mySpring;
    Rigidbody2D myBody;

    [SerializeField]
    float minDist;

    [SerializeField]
    float launchPower;

    [SerializeField]
    PinballBall ballScript;

    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mySpring = GetComponent<SpringJoint2D>();
        myBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (mySpring.distance > minDist)
            {
                mySpring.distance -= 0.1f;
            }

             if (!audioSource.isPlaying) // only start once
            {
                audioSource.Play();
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            myBody.AddForce(transform.up * launchPower);
            mySpring.distance = 20f;

            audioSource.Stop();
        }
    }
}
