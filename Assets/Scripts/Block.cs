using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //TODO threePlusHealthSprite for regenerating Health, Some dickhead comes along and heals the blocks haha Gotta kill them quickly. 
    //TODO Create particle effect for healing

    [SerializeField] Sprite threePlusHealthSprite; 
    [SerializeField] Sprite twoHealthSprite;
    [SerializeField] Sprite oneHealthSprite; 
    [SerializeField] AudioClip destroyBlockSound;
    [SerializeField] GameObject blockVFX;
    [SerializeField] int blockHealth = 3; 


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
                blockHealth--;
                UpdateBlockSprite(); 
                DestroyBlock();
            }
        }
    }

    private void UpdateBlockSprite()
    {
        switch (blockHealth)
        {
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = twoHealthSprite; 
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = oneHealthSprite;
                break; 
        }
    }

    private void DestroyBlock()
    {
        if (blockHealth < 1)
        {
            TriggerDestroyBlockSound();
            TriggerSparklesVFX();
            RemoveBlock();
            UpdateScore();
        }
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
