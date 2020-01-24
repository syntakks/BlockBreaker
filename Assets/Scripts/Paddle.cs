using UnityEngine; 

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidth = 16f;
    [SerializeField] private float minPaddleX = 1f;
    [SerializeField] private float maxPaddleX = 15f;
    private bool autoPlay = false;
    private Ball ball; 

    private void Start()
    {
        autoPlay = FindObjectOfType<GameStatus>().autoPlay;
        ball = FindObjectOfType<Ball>(); 
    }

    // Update is called once per frame
    void Update()
    {
        CheckPaddleMove(); 
    }

    private void CheckPaddleMove()
    {
        //Debug.Log("Mouse X Position: " + Input.mousePosition.x / Screen.width * screenWidth);
        float mousePositionX = GetXPosition(); 
        transform.position = new Vector2(Mathf.Clamp(mousePositionX, minPaddleX, maxPaddleX), transform.position.y);
    }

    private float GetXPosition()
    {
        if (autoPlay)
        {
            return ball.transform.position.x; 
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidth;
        }
    }
}
