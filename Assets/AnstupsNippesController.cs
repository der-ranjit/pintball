using UnityEngine;

public class AnstupsNippesController : MonoBehaviour
{
    private Vector3 originalPosition;
    public float moveBackwardsDistance = 0.0002f;
    public float returnForce = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Store the original position of the nippes
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // When Space is pressed the nippes should start moving backwards relative to its z rotation.
        // When space is released, the nippes should jump back to its original position with force.
        if (Input.GetKey(KeyCode.Space))
        {
            // Move the nippes backwards
            transform.position -= transform.forward * moveBackwardsDistance;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            // Move the nippes back to its original position with force
            Vector3 direction = (originalPosition - transform.position).normalized;
            GetComponent<Rigidbody>().AddForce(direction * returnForce, ForceMode.Impulse);
        } 
    }
}