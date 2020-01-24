using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip destroyBlockSound;
    [SerializeField] GameObject blockVFX; 

    private void Awake()
    {
        if (tag == "Breakable")
        {
            FindObjectOfType<LevelManager>().AddBlock(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            if (tag == "Breakable")
            {
                DestroyBlock();
            }
        }
    }

    private void DestroyBlock()
    {
        TriggerDestroyBlockSound();
        TriggerSparklesVFX();
        RemoveBlock();
        UpdateScore();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkleParticle = Instantiate(blockVFX, transform.position, Quaternion.identity);
        Destroy(sparkleParticle, 1f);
    }

    private void TriggerDestroyBlockSound()
    {
        AudioSource.PlayClipAtPoint(destroyBlockSound, Camera.main.transform.position);
    }

    private void RemoveBlock()
    {
        Destroy(gameObject);
        FindObjectOfType<LevelManager>().RemoveBlock(gameObject);
    }

    private void UpdateScore()
    {
        FindObjectOfType<GameStatus>().AddToScore();
    }
}
