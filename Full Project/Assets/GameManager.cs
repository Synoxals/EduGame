using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject PlatformA;
    public GameObject PlatformB;
    public GameObject PlatformC;
    public Transform Clouds;

    [Header("Misc")]
    public int platformLayerCount;

    int plusLayerCount;

    int a;

    int i;

    int counter;

    GameObject NextPlatformA;
    GameObject NextPlatformB;
    GameObject NextPlatformC;

    public GameObject[] cloudArray;

    Vector3 correctSpawnPosition = new Vector3();
    Vector3 falseSpawnPositionB = new Vector3();
    Vector3 falseSpawnPositionC = new Vector3();

    void Start()
    {
        correctSpawnPosition.y = -3;
        falseSpawnPositionB.y = -3;
        falseSpawnPositionC.y = -3;
        plusLayerCount = platformLayerCount + 1;

        i = 0;

        counter = 0;
    }


    private void Update()
    {     
        if (platformLayerCount < plusLayerCount)
        {
            correctSpawnPosition.y = correctSpawnPosition.y + 10;
            falseSpawnPositionB.y = falseSpawnPositionB.y + 10;
            falseSpawnPositionC.y = falseSpawnPositionC.y + 10;
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
            NextPlatformA = Instantiate(PlatformA, correctSpawnPosition, Quaternion.identity, Clouds);
            i++;
            cloudArray[i] = NextPlatformA;
            NextPlatformB = Instantiate(PlatformB, falseSpawnPositionB, Quaternion.identity, Clouds);
            i++;
            cloudArray[i] = NextPlatformB;
            NextPlatformC = Instantiate(PlatformC, falseSpawnPositionC, Quaternion.identity, Clouds);
            i++;
            if (i <= 6)
            {
                counter = counter + 3;
            }

            cloudArray[i] = NextPlatformC;
            Debug.Log("New Clouds Created");
            platformLayerCount++;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(waiter());
        }
    }
    IEnumerator waiter()
    {
        plusLayerCount++;
        
        yield return new WaitForSeconds(1.5f);

        if (counter == 6)
        {
            Destroy(cloudArray[i - 2 - counter]);
            Destroy(cloudArray[i - 1 - counter]);
            Destroy(cloudArray[i - counter]);
        }
    }
}
