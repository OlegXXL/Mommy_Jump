using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject springPrefab;
    private int scrinAmountOlatform = 26;

    void Start()
    {                
        var SpawnerPosition = new Vector3();

        for (int i = 0; i < scrinAmountOlatform; i++)
        {
            SpawnerPosition.x = Random.Range(-1.7f, 1.7f);
            SpawnerPosition.y += 0.8f;
            SpawnerPosition.z = 0;

            if(i % 23 == 0 && i != 0)
            {
                springPrefab.tag = "PTND";

                Instantiate(springPrefab, SpawnerPosition, Quaternion.identity);
            }
            else
            {
                if (i % 3 == 0)
                {
                    platformPrefab.tag = "PTND";                  
                }
                else
                {
                    platformPrefab.tag = "PlatformTag";
                }

                Instantiate(platformPrefab, SpawnerPosition, Quaternion.identity);
            }
            
            
        }
    }
}
