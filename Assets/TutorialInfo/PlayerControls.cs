using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // start position
    private Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    void Awake()
    {
        // save position of first spwamn o
        startPosition = transform.position;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            // reset position
            transform.position = startPosition;
            // reset velocity
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            // reset forces on rigidbody
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        // apply velocity to object when using wasd or arrow keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // apply force to rigidbody
        GetComponent<Rigidbody>().AddForce(new Vector3(horizontal, 0, vertical));
    }
}
