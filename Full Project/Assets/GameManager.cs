using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CorrectPlatformPrefab;
    public GameObject FalsePlatformPrefab;
    public Transform Clouds;

    public int platformLayerCount;

    int a;


    void Start()
    {
        Vector3 correctSpawnPosition = new Vector3();
        correctSpawnPosition.y = -1;

        Vector3 falseSpawnPositionB = new Vector3();
        falseSpawnPositionB.y = -1;

        Vector3 falseSpawnPositionC = new Vector3();
        falseSpawnPositionC.y = -1;


        for (int i = 0; i < platformLayerCount; i++)
        {
            correctSpawnPosition.y = correctSpawnPosition.y + 5;
            falseSpawnPositionB.y = falseSpawnPositionB.y + 5;
            falseSpawnPositionC.y = falseSpawnPositionC.y + 5;
            a = Random.Range(0, 2);

            if (a == 0)
            {
                correctSpawnPosition.x = 1.75f;
                falseSpawnPositionB.x = 3.5f;
                falseSpawnPositionC.x = 5.25f;
            }
            else if (a == 1)
            {
                correctSpawnPosition.x = 3.5f;
                falseSpawnPositionB.x = 1.75f;
                falseSpawnPositionC.x = 5.25f;
            }
            else if (a == 2)
            {
                correctSpawnPosition.x = 5.25f;
                falseSpawnPositionB.x = 1.75f;
                falseSpawnPositionC.x = 3.5f;
            }
            GameObject NextPlatformA = Instantiate(CorrectPlatformPrefab, correctSpawnPosition, Quaternion.identity, Clouds);
            GameObject NextPlatformB = Instantiate(FalsePlatformPrefab, falseSpawnPositionB, Quaternion.identity, Clouds);
            GameObject NextPlatformC = Instantiate(FalsePlatformPrefab, falseSpawnPositionC, Quaternion.identity, Clouds);


        }
    }
}
