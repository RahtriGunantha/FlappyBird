using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnner : MonoBehaviour
{
    public GameObject pipeSpawn;
    public float spawnTime;
    public float yMin, yMax;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PipeSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PipeSpawn()
    {
        yield return new WaitForSeconds(spawnTime);
      //  Instantiate(pipeSpawn, transform.position, transform.rotation);
        Instantiate(pipeSpawn, transform.position + Vector3.up * Random.Range(yMin, yMax), Quaternion.identity); // sama saja seperti transform.rotation
        StartCoroutine(PipeSpawn());
    }
   
}
