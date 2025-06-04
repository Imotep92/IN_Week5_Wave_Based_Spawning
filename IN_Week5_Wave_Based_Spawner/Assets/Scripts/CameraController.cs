using UnityEngine;

public class CameraController : MonoBehaviour
{

    private bool _cursorLocked;

    [SerializeField] float mouseSensitivity = 300f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()  
    {
        //cursor set to lock and invisible upon game starting
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _cursorLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        //mouse sensitivity for camera in game
        float mouseXInput = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseSensitivity * Time.deltaTime * mouseXInput);

        //press E to show cursor
        if (Input.GetKeyDown(KeyCode.E))
        {
            Hide_ShowMouseCursor();
        }
    }

    //hide and unhide method for cursor in game
    public void Hide_ShowMouseCursor()
    {
        if (!_cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            _cursorLocked = true;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            _cursorLocked = false;
            Cursor.visible = true;
        }
    }

    
}
