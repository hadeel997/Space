using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AstroidsSpawner : MonoBehaviour
{
    [Header("size of the spawner area")]
    public Vector3 Spawnersize;

    [Header(" Rate of of spawn")]
    public float Spawnerrate;

    [Header(" Model of Spwan")]
    [SerializeField] private GameObject astroidmodel;
    private float spawnTimer = 0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, Spawnersize);
    }
    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
        spawnTimer += Time.deltaTime;  
        if (spawnTimer > Spawnerrate)
        {
            Debug.Log("Spawning");
            spawnTimer = 0;
            SpawnAstroid();

        }
    }
    private void SpawnAstroid()
    {
        Vector3 spawnpoint= transform.position + new Vector3(UnityEngine.Random.Range(-Spawnersize.x/ 2, Spawnersize.x/2),UnityEngine.Random.Range(-Spawnersize.y / 2, Spawnersize.y/2),UnityEngine.Random.Range(-Spawnersize.z/ 2, Spawnersize.z/2));

        GameObject astroid = Instantiate(astroidmodel, spawnpoint, transform.rotation);
    }
}
