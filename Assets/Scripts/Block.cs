using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    
    [SerializeField] AudioClip destroyBlockSound;

    private void Awake()
    {
        FindObjectOfType<LevelManager>().AddBlock(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            // Ball Hit
            //Debug.Log("Ball Hit!"); 
            Destroy(gameObject, 1f);
            FindObjectOfType<LevelManager>().RemoveBlock(gameObject); 
            AudioSource.PlayClipAtPoint(destroyBlockSound, Camera.main.transform.position); 
        }
    }
}
