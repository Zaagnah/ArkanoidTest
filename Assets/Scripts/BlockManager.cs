using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField]    
    List<GameObject> blockList = new List<GameObject>();

   

    public void DeleteBlock(Block block)
    {
        blockList.Remove(block.gameObject);
        if(blockList.Count == 0)
        {
            Debug.Log("no blocks");
            FindObjectOfType<GameManager>().WinPanel();
        }
    }
    
    

}
