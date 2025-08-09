using UnityEngine;
public class EnvironmentManager : MonoBehaviour
{
    [SerializeField] float gameSpeed = 1;
    bool worldStop = false;
    void Update()
    {
        //pause environment
        if (!worldStop && Time.timeScale == 0)
        {
            gameSpeed = 0;
            worldStop = true;
        }
        else if (worldStop && Time.timeScale == 1)
        {
            gameSpeed = 1;
            worldStop = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (gameSpeed == 0)
            {
                gameSpeed = 1;
                worldStop = false;
            }
            else
            {
                gameSpeed = 0;
                worldStop = true;
            }
        }
        //spawn environment
        if (transform.position == new Vector3(0, 0, 0))
        {
            Instantiate(gameObject, new Vector3(0, 0, 60 - gameSpeed), Quaternion.identity);
        }
        //destroy environment
        if (transform.position.z == -60)
        {
            Destroy(gameObject);
        }
        transform.position = new Vector3(0, 0, transform.position.z - gameSpeed);
    }
}