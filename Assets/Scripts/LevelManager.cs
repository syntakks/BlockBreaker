using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private List<GameObject> blocks = new List<GameObject>();

    public void AddBlock(GameObject block)
    {
        if (!blocks.Contains(block))
        {
            blocks.Add(block); 
        }
    }

    public void RemoveBlock(GameObject block)
    {
        if (blocks.Contains(block))
        {
            blocks.Remove(block); 
            if (IsLevelWin())
            {
                FindObjectOfType<SceneLoader>().LoadNextScene(); 
            }
        }
    }

    private bool IsLevelWin()
    {
        return blocks.Count == 0; 
    }
}
