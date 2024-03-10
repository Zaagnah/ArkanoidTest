using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField]
    private GameObject blockPrefab;
    [SerializeField]
    private GameObject obstaclePrefab;
    [SerializeField]
    private int numberOfBlocks = 10;
    [SerializeField]
    private int numberOfObstacles = 5;
    [SerializeField]
    private float minX = -5f;
    [SerializeField]
    private float maxX = 5f;
    [SerializeField]
    private float minY = -3f;
    [SerializeField]
    private float maxY = 3f;

    private List<GameObject> blockList = new List<GameObject>();
    private List<GameObject> obstacleList = new List<GameObject>();

    void Start()
    {
        GenerateBlocksAndObstacles();
    }

    void GenerateBlocksAndObstacles()
    {
        GenerateBlocks();
        GenerateObstacles();

        // Проверяем столкновения и удаляем пересекающиеся объекты после генерации
        CheckAndRemoveOverlappingObjects(blockList);
        CheckAndRemoveOverlappingObjects(obstacleList);
        Debug.Log(blockList.Count);
        // После генерации проверяем, если блоков нет, открываем панель победы
        if (blockList.Count == 0)
        {
            Debug.Log("no blocks");
            FindObjectOfType<GameManager>().WinPanel();
        }
    }

    void GenerateBlocks()
    {
        for (int i = 0; i < numberOfBlocks; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            CreateBlock(randomPosition);
        }
    }

    void GenerateObstacles()
    {
        for (int i = 0; i < numberOfObstacles; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            CreateObstacle(randomPosition);
        }
    }

    void CreateBlock(Vector3 position)
    {
        GameObject block = Instantiate(blockPrefab, position, Quaternion.identity);
        blockList.Add(block);
    }

    void CreateObstacle(Vector3 position)
    {
        GameObject obstacle = Instantiate(obstaclePrefab, position, Quaternion.identity);
        obstacleList.Add(obstacle);
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        return new Vector3(x, y, 0f);
    }

    void CheckAndRemoveOverlappingObjects(List<GameObject> objectList)
    {
        List<GameObject> overlappingObjects = new List<GameObject>();

        foreach (GameObject obj in objectList)
        {
            Collider2D hitCollider = Physics2D.OverlapCircle(obj.transform.position, 0.1f);

            if (hitCollider != null && hitCollider.gameObject != obj)
            {
                overlappingObjects.Add(obj);
            }
        }

        foreach (GameObject overlappingObject in overlappingObjects)
        {
            objectList.Remove(overlappingObject);
            Destroy(overlappingObject);
        }
    }
    public void DeleteBlock(Block block)
    {
        blockList.Remove(block.gameObject);
        if (blockList.Count == 0)
        {
            Debug.Log("no blocks");
            FindObjectOfType<GameManager>().WinPanel();
        }
    }
}
