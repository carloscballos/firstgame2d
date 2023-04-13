using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject gameOverMenu;
    public Renderer background;
    public GameObject column;
    public GameObject rockBig;
    public GameObject rockSmall;
    public bool gameOver = false;
    public float speed = 2;
    public bool start = false;

    private List<GameObject> columns;
    private List<GameObject> obstacles;

    // Start is called before the first frame update
    void Start()
    {
        columns = new List<GameObject> ();
        obstacles = new List<GameObject> ();

        //create map
        for (int i = 0; i < 21; i++) 
        {
            columns.Add( Instantiate(column, new Vector2(-10 + i, -3), Quaternion.identity));
        }

        // create rocks
        obstacles.Add(Instantiate(rockBig, new Vector2(14, -2), Quaternion.identity));
        obstacles.Add(Instantiate(rockSmall, new Vector2(18, -2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if (!start) 
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }

        if (!start && gameOver)
        {
            gameOverMenu.SetActive(true);            
            
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (start && !gameOver) 
        {
            menu.SetActive(false);

            background.material.mainTextureOffset = background.material.mainTextureOffset + new Vector2(0.2f, 0) * Time.deltaTime;

            //move map
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].transform.position.x <= -10)
                {
                    columns[i].transform.position = new Vector3(10, -3, 0);
                }
                columns[i].transform.position = columns[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            }

            //move obstacles
            for (int i = 0; i < obstacles.Count; i++)
            {
                if (obstacles[i].transform.position.x <= -10)
                {
                    float randomObstacules = Random.Range(11, 18);
                    obstacles[i].transform.position = new Vector3(randomObstacules, -2, 0);
                }
                obstacles[i].transform.position = obstacles[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            }
        }
    }
}
