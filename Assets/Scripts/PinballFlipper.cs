using UnityEngine;

public class PinballFlipper : MonoBehaviour
{

    [SerializeField]
    KeyCode flipKey; 

    [SerializeField]
    Rigidbody2D myBody; 

    [SerializeField]
    float flipPower; 


    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(flipKey))
        {
            //add force to the flipper in the upwards direction
            myBody.AddForce(transform.up * flipPower);

            if (!audioSource.isPlaying) // only start once
            {
                audioSource.Play();
            }
        }

        if (Input.GetKeyUp(flipKey))
        {
            audioSource.Stop();
        }
    }
}
