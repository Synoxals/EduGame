using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CorrectPlatformPrefab;
    public GameObject FalsePlatformPrefab;
    public Transform Clouds;

    public int platformLayerCount;

    int plusLayerCount;

    bool PlatformUpdate;

    GameObject NextPlatformA;
    GameObject NextPlatformB;
    GameObject NextPlatformC;


    Vector3 correctSpawnPosition = new Vector3();

    Vector3 falseSpawnPositionB = new Vector3();

    Vector3 falseSpawnPositionC = new Vector3();


    int a;


    void Start()
    {
        PlatformUpdate = false;

        correctSpawnPosition.y = -3;


        falseSpawnPositionB.y = -3;


        falseSpawnPositionC.y = -3;


        plusLayerCount = platformLayerCount + 2;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlatformUpdate = true;
            if (PlatformUpdate == true)
            {
                GameObject CurrentPlatformA = NextPlatformA;
                GameObject CurrentPlatformB = NextPlatformB;
                GameObject CurrentPlatformC = NextPlatformC;
                platformLayerCount++;
                plusLayerCount++;
                Debug.Log(platformLayerCount);
            }
        }


        
        if (platformLayerCount + 1 == plusLayerCount)
        {
            correctSpawnPosition.y = correctSpawnPosition.y + 5;
            falseSpawnPositionB.y = falseSpawnPositionB.y + 5;
            falseSpawnPositionC.y = falseSpawnPositionC.y + 5;
            a = Random.Range(0, 3);

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
            NextPlatformA = Instantiate(CorrectPlatformPrefab, correctSpawnPosition, Quaternion.identity, Clouds);
            NextPlatformB = Instantiate(FalsePlatformPrefab, falseSpawnPositionB, Quaternion.identity, Clouds);
            NextPlatformC = Instantiate(FalsePlatformPrefab, falseSpawnPositionC, Quaternion.identity, Clouds);



        }
    }
}
