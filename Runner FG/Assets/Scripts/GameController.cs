using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject line;
    public GameObject player;
    public float respawnTime = 1f;
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;
    public GameObject CurrentPlayer;
    public GameObject gameOverObject;
    public GameObject startGameObject;
    public Animator anim;
    public Animator anim2;
    public bool gameOver = false;
    public bool gameStartCheck = false;
    public bool feverMode = false;
    public bool gunMode = false;
    public GameObject feverObject;

    public float generalSpeed = 0;
    public int gameDifficulty = 0;
    public float timeForwardSec;

    private void Awake()
    {
        II = this;
        III = this;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            startGameObject.SetActive(false);
            gameStartCheck = true;
            
        }
        if (gameOver == true)
        {
            //End animation
            gameOverObject.SetActive(true);
            anim.Play("GameOver");
            Invoke(nameof(GameOver), 1.5f);
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if(feverMode == true)
        {
            FeverMode();
            StartCoroutine(KillFever());
        }
        if(gunMode == true)
        {
            //Magic
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        anim2.Play("SwipeToStart");
        StartCoroutine(SpawnerTime());
    }
    
    void Spawn()
    {
        if (gameStartCheck)
        {
            Instantiate(line, spawnPoint1.transform.position, Quaternion.identity);
            Instantiate(line, spawnPoint2.transform.position, Quaternion.identity);
            Instantiate(line, spawnPoint3.transform.position, Quaternion.identity);
        }
    }
    IEnumerator SpawnerTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            Spawn();
        }
    }

    void GameOver()
    {
        gameStartCheck = false;
    }

    void FeverMode()
    {

    }
    IEnumerator KillFever()
    {
        yield return new WaitForSeconds(5);
        feverObject.SetActive(false);
        feverMode = false;
    }
    public static GameController III;

    public static GameController II;
    public static GameController I
    {
        get
        {
            if (II == null)
            {
                II = GameObject.Find("GameController").GetComponent<GameController>();
            }
            return II;
        }
    }
}
