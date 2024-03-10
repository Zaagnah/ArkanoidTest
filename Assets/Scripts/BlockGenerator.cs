using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    public GameObject blockPrefab;         // Префаб куба
    public GameObject obstaclePrefab;      // Префаб препятствия
    public int rows = 5;                   // Количество рядов кубов
    public int columns = 10;               // Количество колонок кубов
    public float fieldWidth = 10f;         // Ширина игрового поля
    public float fieldHeight = 5f;         // Высота игрового поля
    public float minDistanceBetweenObstacles = 1f;  // Минимальное расстояние между препятствиями

    void Start()
    {
        GenerateBlocks();
        GenerateObstacles();
    }

    void GenerateBlocks()
    {
        float blockWidth = fieldWidth / columns;
        float blockHeight = fieldHeight / rows;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                float x = col * blockWidth + blockWidth / 2 - fieldWidth / 2;
                float y = row * blockHeight + blockHeight / 2 - fieldHeight / 2;

                Vector3 position = new Vector3(x, y, 0f);

                Instantiate(blockPrefab, position, Quaternion.identity);
            }
        }
    }

    void GenerateObstacles()
    {
        List<Vector3> obstaclePositions = new List<Vector3>();
        float obstacleWidth = obstaclePrefab.transform.localScale.x;
        float obstacleHeight = obstaclePrefab.transform.localScale.y;

        for (int i = 0; i < columns; i++)
        {
            float x = Random.Range(-fieldWidth / 2 + obstacleWidth / 2, fieldWidth / 2 - obstacleWidth / 2);
            float y = Random.Range(-fieldHeight / 2 + obstacleHeight / 2, fieldHeight / 2 - obstacleHeight / 2);

            Vector3 obstaclePosition = new Vector3(x, y, 0f);

            // Проверяем, чтобы препятствие не перекрывалось с другими препятствиями
            bool isValidPosition = true;
            foreach (Vector3 existingPosition in obstaclePositions)
            {
                float distance = Vector3.Distance(existingPosition, obstaclePosition);
                if (distance < minDistanceBetweenObstacles)
                {
                    isValidPosition = false;
                    break;
                }
            }

            if (isValidPosition)
            {
                obstaclePositions.Add(obstaclePosition);
                Instantiate(obstaclePrefab, obstaclePosition, Quaternion.identity);
            }
            else
            {
                i--;
            }
        }
    }
}
