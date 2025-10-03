using UnityEngine;

public class PinballCamera : MonoBehaviour
{

     [SerializeField]
    Transform ballTransform;
    [SerializeField]
    float smoothVal;
    Vector3 velocity = Vector3.zero;

    Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 target = ballTransform.position;
        target.z = -2;
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothVal);
    }
}
