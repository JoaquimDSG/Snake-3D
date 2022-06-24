using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManzana : MonoBehaviour
{
    public GameObject Manzana;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-11, 11), 0.5f, Random.Range(-11, 11));

        Instantiate(Manzana, randomSpawnPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
  
    }
}
