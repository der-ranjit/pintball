using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    public float zoomSpeed = 10.0f;
    public float minZoom = 5.0f;
    public float maxZoom = 50.0f;

    private float currentZoom = 10.0f;
    private Vector3 lastMousePosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentZoom = Camera.main.fieldOfView;
        // lock z rotation
        // transform.eulerAngles = new Vector3(45, 45, 0);
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseInput();
        // lock z rotation to 0
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }

    void HandleMouseInput()
    {
        // Rotate camera based on mouse movement
        if (Input.GetMouseButton(1)) // Right mouse button
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            float rotationX = -delta.y;
            float rotationY = delta.x;

            transform.eulerAngles += new Vector3(rotationX, rotationY, 0);
        }
        lastMousePosition = Input.mousePosition;
    }
}