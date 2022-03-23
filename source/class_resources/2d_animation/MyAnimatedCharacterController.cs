using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MyAnimatedCharacterController : MonoBehaviour
{
    public int score = 0;

    Rigidbody2D body;


    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 5.0f;

    public AudioSource sound;
    public AudioSource scoreIncreaseSound;
    public AudioSource scoreDecreaseSound;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        // Get the rigid body component for the player character.
        // (required to have one)
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get our axis values
        horizontal = Input.GetAxisRaw("Horizontal"); 
        vertical = Input.GetAxisRaw("Vertical"); 
    }

    void FixedUpdate()
    {

        // If player is running diagonally, we don't want them to move extra-fast.
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        if (horizontal > 0.1)
            spriteRenderer.flipX = false;
        else
            spriteRenderer.flipX = true;

        // Set player velocity
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        animator.SetFloat("HorizontalSpeed", Mathf.Abs(horizontal));
    }

    void OnTriggerEnter2D(Collider2D colliderEvent)
    {
        // Did we run into an object that will affect our score?
        ScoreScript scoreObject = colliderEvent.gameObject.GetComponent(typeof(ScoreScript))
                                  as ScoreScript;

        if (scoreObject != null)
        {
            // Yes, change the score
            score += scoreObject.points;

           
            // Destroy the object
            Destroy(colliderEvent.gameObject);
        }

        // Did we run into an object that will cause a scene change?
        SceneChangeScript sceneChangeObject = colliderEvent.gameObject.GetComponent(typeof(SceneChangeScript))
                                              as SceneChangeScript;
        if (sceneChangeObject != null) {
            // Yes, get our current scene index
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            // Load up the scene accourding to the sceneChange value
            UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneIndex + sceneChangeObject.sceneChange);
        }
    }
    void OnGUI()
    {
        // Dispaly our score
        GUIStyle guiStyle = new GUIStyle(GUI.skin.label);
        guiStyle.fontSize = 32; //modify the font height
        GUI.Label(new Rect(10, 10, 250, 50), "Score: " + score, guiStyle);
    }
}
