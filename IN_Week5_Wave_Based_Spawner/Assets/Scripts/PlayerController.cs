using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody playerRb;

    public GameObject focalPoint;

    //playerRespawn and player lower boundary y axis

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal_Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        focalPoint.transform.position = transform.position;
        
        playerRb.AddForce((focalPoint.transform.forward * moveDirection.y + focalPoint.transform.right * moveDirection.x) * speed);

        
    }
}
