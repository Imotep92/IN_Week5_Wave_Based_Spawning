using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // This region declares the Players: Speed; RigidBody; Start/Respawn Position; no. of Lives; Mouse input
    #region  Player Variables

    // Declared "Player" variables: Speed; RigidBody; Start/Respawn Position; no. of Lives
    public float speed = 5.0f;
    private Rigidbody playerRb;
    private GameObject focalPoint; //Link to Camera/Mouse input, see <CamerController.cs>
    private Vector3 startPosition;
    public int lives = 3;
    public int maxLives;

    public bool isDead = false;

    #endregion Player Variables


    // This region declares Forcefield powerup: "Has Forcefield" bool; Forcefield indicator; Forcefield strength; 
    #region Forcefield

    // Declared "Forcefield" variables: bool; Strength; Indicator;
    public bool hasForceField;

    private float forceFieldStrength = 100f;

    public GameObject forceFieldIndicator;

    #endregion Forcefield

    // This region declares Rocket powerup: "Has Rocket" bool; Rocket indicator; 

    #region Rocket

    public bool hasRocket;
    public GameObject RocketIndicator;
    public GameObject bullet;

    public Vector3 spawnOffset;

    #endregion Rocket


    public GameObject game_Over_Panel;
    public GameObject pause_Panel;
    public bool GameIsPaused = false;
    public int score;
    public TMP_Text scoreText;
    public TMP_Text livesText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f;
        playerRb = GetComponent<Rigidbody>();  //get player's rigidbody
        focalPoint = GameObject.Find("Focal_Point"); //get player's camera movent
        maxLives = lives; //player lives upon game start/restart
    }

    // Update is called once per frame
    void Update()
    {
        
        #region Player Movement and lives

        float verticalInput = Input.GetAxisRaw("Vertical"); //player moves forward/back
        float horizontalInput = Input.GetAxisRaw("Horizontal"); //player moves left/right

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized; /*player moves along 'horizontal' and 'vertical(forward)' axis only, 
        no up/down movement, speed normalized on diagonals */

        focalPoint.transform.position = transform.position;  //Player's movedirection is affected by camera/mouse input

        playerRb.AddForce((focalPoint.transform.forward * moveDirection.y + focalPoint.transform.right * moveDirection.x) * speed); //final player movement equation

        if (transform.position.y < -3)  //Player respawn location upon death, current velocity reverted to zero, take one life from lives pool
        {
            transform.position = startPosition;
            playerRb.linearVelocity = Vector3.zero;
            lives--;
        }

        if (lives <= 0 && !isDead)  //Game over scenario
        {
            isDead = true; // isDead set to true
            game_Over_Panel.SetActive(true);  //shows gameOver panel
            Time.timeScale = 0f; // freeze game
            Debug.Log("GameOver");
            Destroy(gameObject); //destroys player 
        }

        #endregion Player Movement and lives

        scoreText.text = "Score: " + score;

        livesText.text = "Lives: " + lives;

       /* if (!GameIsPaused)
        {
            pause_Panel.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }*/
    

        #region Forcefield indicator

        //Active forcefield indicator movement tied to player position
        forceFieldIndicator.SetActive(hasForceField);
        forceFieldIndicator.transform.position = transform.position + new Vector3(0, 0.6f, 0);
        forceFieldIndicator.transform.Rotate(Vector3.up * Time.deltaTime);

        #endregion Forcefield indicator


        //shooting bullets/rocket

        if (Input.GetKeyDown(KeyCode.Space) && hasRocket)
        {
            Destroy(Instantiate(bullet, transform.position + spawnOffset, Quaternion.LookRotation(transform.forward)), 7);
        }


        #region Rocket indicator

        RocketIndicator.SetActive(hasRocket);
        RocketIndicator.transform.position = transform.position + new Vector3(0, 1f, 0);
        RocketIndicator.transform.Rotate(Vector3.up * Time.deltaTime);

        #endregion Rocket indicator

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ForceField"))
        {
            hasForceField = true;
            StartCoroutine(ForceFieldCountdownRoutine());
            Destroy(other.gameObject);
            //Debug.Log("has Forcefield");
        }

        if (other.CompareTag("Rocket"))
        {
            hasRocket = true;
            StartCoroutine(RocketCountdownRoutine());
            Destroy(other.gameObject);
            //Debug.Log("has Rocket");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasForceField)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

            Debug.Log("This player has collided with " + collision.gameObject.name + "with Force Field set to" + hasForceField);
            enemyRb.AddForce(awayFromPlayer * forceFieldStrength, ForceMode.Impulse);
        }
    }

    IEnumerator ForceFieldCountdownRoutine()
    {
        yield return new WaitForSeconds(8);
        hasForceField = false;
    }

    IEnumerator RocketCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasRocket = false;
    }
    
     /*EXAMPLE*/


}
