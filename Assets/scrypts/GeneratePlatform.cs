using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatform : MonoBehaviour
{
    [SerializeField]private GameObject[] _prefabPlatform;
    // Start is called before the first frame update
    private void Start()
    {
        List<GameObject> generetedPlatform = new List<GameObject>();
        Vector3 spawnPosition = new Vector3();
        for(int i = 0; i < 6; i++)
        {
            spawnPosition.x = Random.Range(-2f,2f);
            spawnPosition.y += Random.Range(2f, 2f+1.2f);


            Instantiate(_prefabPlatform[0], spawnPosition, Quaternion.identity);
        }

    }
}
