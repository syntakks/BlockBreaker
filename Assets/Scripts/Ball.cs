using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Paddle paddle1; 
    [SerializeField] private float xPush = 2f; 
    [SerializeField] private float yPush = 15f;
    [SerializeField] private int xBounceFactor = 3;
    [SerializeField] private int yBounceFactor = 3;
    [SerializeField] AudioClip[] ballSounds; 
    private Vector2 paddleToBallOffset;
    private bool hasStarted = false;
    private AudioSource audioSource;
    private Rigidbody2D rb; 

    void Start()
    {
        paddleToBallOffset = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        LockBallToPaddle();
        LaunchOnMouseClick();
    }
    
    private void LaunchOnMouseClick()
    {
        if (!hasStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation; 
                rb.velocity = new Vector2(xPush, yPush);
            }
        }
    }

    private void LockBallToPaddle()
    {
        if (!hasStarted)
        {
            Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddlePosition + paddleToBallOffset;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BounceFix(); 
        int index = Random.Range(0, ballSounds.Length);
        AudioClip ballSound = ballSounds[index];
        audioSource.PlayOneShot(ballSound); 
    }

    private void BounceFix() // Prevents ball from getting stuck on flat plane up/down or left/right
    {
        int xPush = Random.Range(0, xBounceFactor);
        int yPush = Random.Range(0, yBounceFactor);
        Vector2 bounceFix = new Vector2(xPush, yPush);
        rb.AddForce(bounceFix);
    }
}
