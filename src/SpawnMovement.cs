using UnityEngine;
public class SpawnMovement : MonoBehaviour
{
    [SerializeField] float speed;
    private float temp;
    bool worldStop = false;
    void Update()
    {
        //pause
        if (!worldStop && Time.timeScale == 0)
        {
            temp = speed;
            speed = 0;
            worldStop = true;
        }
        else if (worldStop && Time.timeScale == 1)
        {
            speed = temp;
            worldStop = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (speed != 0)
            {
                temp = speed;
                speed = 0;
                worldStop = true;
            }
            else
            {
                speed = temp;
                worldStop = false;
            }
        }
        //destroy
        if (transform.position.z < -60)
        {
            Destroy(gameObject);
        }
        //move
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
    }
}