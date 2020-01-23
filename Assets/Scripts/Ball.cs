using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Paddle paddle1; 
    [SerializeField] private float xPush = 2f; 
    [SerializeField] private float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds; 
    private Vector2 paddleToBallOffset;
    private bool hasStarted = false;
    private AudioSource audioSource; 
    void Start()
    {
        paddleToBallOffset = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>(); 
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
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation; 
                GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
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
        int index = Random.Range(0, ballSounds.Length);
        AudioClip ballSound = ballSounds[index];
        audioSource.PlayOneShot(ballSound); 
    }
}
