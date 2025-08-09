using System.Collections;
using UnityEngine;
public class PlayerCarMovement : MonoBehaviour
{
    //this script is for player side movement and collision detection
    Collider car;
    void Start()
    {
        car = GetComponent<Collider>();
        StartCoroutine(Wait());
    }
    [SerializeField] float sideSpeed = 15;
    void Update()
    {
        //player car controller
        if (Input.GetKey(KeyCode.A) && transform.position.x > -5)
        {
            Left();
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < 5)
        {
            Right();
        }
    }
    public void Left()
    {
        transform.position = new Vector3(transform.position.x + -sideSpeed * Time.deltaTime, 0.01f, transform.position.z);
    }
    public void Right()
    {
        transform.position = new Vector3(transform.position.x + sideSpeed * Time.deltaTime, 0.01f, transform.position.z);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        car.enabled = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //player die
        Destroy(gameObject);
    }
}