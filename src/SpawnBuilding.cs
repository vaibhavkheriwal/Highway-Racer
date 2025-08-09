using UnityEngine;
public class SpawnBuilding : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoint = new GameObject[8];
    [SerializeField] GameObject[] building = new GameObject[10];
    void Start()
    {
        Instantiate(building[Random.Range(0, 10)], spawnPoint[0].transform.position, spawnPoint[0].transform.rotation);
        Instantiate(building[Random.Range(0, 10)], spawnPoint[1].transform.position, spawnPoint[1].transform.rotation);
        Instantiate(building[Random.Range(0, 10)], spawnPoint[2].transform.position, spawnPoint[2].transform.rotation);
        Instantiate(building[Random.Range(0, 10)], spawnPoint[3].transform.position, spawnPoint[3].transform.rotation);
        Instantiate(building[Random.Range(0, 10)], spawnPoint[4].transform.position, spawnPoint[4].transform.rotation);
        Instantiate(building[Random.Range(0, 10)], spawnPoint[5].transform.position, spawnPoint[5].transform.rotation);
        Instantiate(building[Random.Range(0, 10)], spawnPoint[6].transform.position, spawnPoint[6].transform.rotation);
        Instantiate(building[Random.Range(0, 10)], spawnPoint[7].transform.position, spawnPoint[7].transform.rotation);
    }
}