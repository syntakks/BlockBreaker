using UnityEngine; 

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidth = 16f;
    [SerializeField] private float minPaddleX = 1f;
    [SerializeField] private float maxPaddleX = 15f;

    // Update is called once per frame
    void Update()
    {
        CheckPaddleMove(); 
    }

    private void CheckPaddleMove()
    {
        //Debug.Log("Mouse X Position: " + Input.mousePosition.x / Screen.width * screenWidth);
        float mousePositionX = Input.mousePosition.x / Screen.width * screenWidth;
        transform.position = new Vector2(Mathf.Clamp(mousePositionX, minPaddleX, maxPaddleX), transform.position.y);
    }
}
