using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    public GameObject SceneManager; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ball")
        {
            // Need to trigger the player lost. 
            Debug.Log("YOU LOSE!");
            SceneManager.GetComponent<SceneLoader>().LoadGameOverScene(); 
        }
    }
}
