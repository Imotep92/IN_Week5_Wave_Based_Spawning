using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] float mouseSensitivity = 300f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseXInput = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.up * mouseSensitivity * Time.deltaTime * mouseXInput);
    }
}
