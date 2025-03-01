using UnityEngine;

public class AbsturzVerhinderungsAnstupsNippesController : MonoBehaviour
{
    public float flipperStrength = 1000.0f;
    public float flipperRotationAngle = 45.0f;
    public KeyCode activationKey = KeyCode.Space;

    private Vector3 initialPosition;
    private Quaternion activeRotation;
    private bool isActive = false;
    private Transform anchor;

    void Start()
    {
        // Find the child game object named "Anchor"
        anchor = transform.Find("Anchor");
        if (anchor == null)
        {
            Debug.LogError("Anchor child game object not found.");
            return;
        }

        // Store the initial rotation of the flipper
        initialPosition = transform.position;
        // Calculate the active rotation of the flipper
        activeRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, flipperRotationAngle));
    }

    void Update()
    {
        // Check if the activation key is pressed
        if (Input.GetKeyDown(activationKey))
        {
            isActive = true;
            RotateAroundAnchor(activeRotation);
        }
        else if (Input.GetKeyUp(activationKey))
        {
            isActive = false;
            transform.position = initialPosition;
        }
    }

    void RotateAroundAnchor(Quaternion targetRotation)
    {
        // Rotate around the anchor point
        Vector3 anchorPosition = anchor.position;
        transform.RotateAround(anchorPosition, Vector3.up, -(targetRotation.eulerAngles.z - transform.rotation.eulerAngles.z));
    }
}