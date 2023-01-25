using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject CorrectPlatformPrefab;
    public GameObject FalsePlatformPrefab;
    public Transform Clouds;

    [Header("Misc")]
    public int platformLayerCount;

    int plusLayerCount;

    int a;

    GameObject NextPlatformA;
    GameObject NextPlatformB;
    GameObject NextPlatformC;

    GameObject CurrentPlatformA;
    GameObject CurrentPlatformB;
    GameObject CurrentPlatformC;

    [Header("First Platforms")]
    public GameObject FirstPlatformA;
    public GameObject FirstPlatformB;
    public GameObject FirstPlatformC;

    GameObject LastPlatformA;
    GameObject LastPlatformB;
    GameObject LastPlatformC;

    Vector3 correctSpawnPosition = new Vector3();
    Vector3 falseSpawnPositionB = new Vector3();
    Vector3 falseSpawnPositionC = new Vector3();

    void Start()
    {
        correctSpawnPosition.y = -3;
        falseSpawnPositionB.y = -3;
        falseSpawnPositionC.y = -3;
        plusLayerCount = platformLayerCount + 1;

        CurrentPlatformA = FirstPlatformA;
        CurrentPlatformB = FirstPlatformB;
        CurrentPlatformB = FirstPlatformC;
    }


    private void Update()
    {     
        if (platformLayerCount < plusLayerCount)
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
            // Creates a layer of new clouds.
            NextPlatformA = Instantiate(CorrectPlatformPrefab, correctSpawnPosition, Quaternion.identity, Clouds);
            NextPlatformB = Instantiate(FalsePlatformPrefab, falseSpawnPositionB, Quaternion.identity, Clouds);
            NextPlatformC = Instantiate(FalsePlatformPrefab, falseSpawnPositionC, Quaternion.identity, Clouds);
            Debug.Log("New Clouds Created");
            platformLayerCount++;
            Debug.Log("PlatLayerCount increased to: " + platformLayerCount);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(waiter());
        }
    }
    IEnumerator waiter()
    {

        plusLayerCount++;
        Debug.Log("PlusLayerCount increased to: " + plusLayerCount);
        
        LastPlatformA = CurrentPlatformA;
        LastPlatformB = CurrentPlatformB;
        LastPlatformC = CurrentPlatformC;

        yield return new WaitForSeconds(3);
        
        CurrentPlatformA = NextPlatformA;
        CurrentPlatformB = NextPlatformB;
        CurrentPlatformC = NextPlatformC;

        Destroy(LastPlatformA);
        Destroy(LastPlatformB);
        Destroy(LastPlatformC);
    }
}
