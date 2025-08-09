using UnityEngine;
public class SpawnCar : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoint = new GameObject[2];
    [SerializeField] GameObject[] car = new GameObject[10];
    void Start()
    {
        //spawn a car
        Instantiate(car[Random.Range(0,10)], spawnPoint[Random.Range(0,2)].transform.position, Quaternion.identity);
    }
}