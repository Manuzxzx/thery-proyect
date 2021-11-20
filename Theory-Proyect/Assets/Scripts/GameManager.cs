using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject[] Enemys;
    private int[] spawnPosx;
    private int spawnPosz;
    private int spawnRange = 5;
    private int spawnPosxInt;
    private int spawnIndex;
    public int score { get ; set ; } //ENCAPSULATION
    public bool gameOver { get; set; }//ENCAPSULATION
    [SerializeField]
    private Text gameOverT; //ENCAPSULATION
    [SerializeField]
    private Button restartB; //ENCAPSULATION
    [SerializeField]
    private TMP_Text ScoreText; //ENCAPSULATION 
    // Start is called before the first frame update
    void Start()
    {     
        InvokeRepeating("SpawnEnemy", 4, 1);       
    }

    // Update is called once per frame
    void Update()
    {
        ScoreTextManager();
        GameOver();
    }
    private Vector3 GenerateRandomPosition() // ABSTRACTION
    {
        spawnPosx = new int[2];
        spawnPosx[0] = -spawnRange;
        spawnPosx[1] = spawnRange;
        spawnPosz = Random.Range(spawnRange, -spawnRange);
        if (spawnPosz == spawnRange || spawnPosz == -spawnRange)
        {
            spawnPosxInt = Random.Range(spawnRange, -spawnRange);
        }
        else
        {
            spawnPosxInt = spawnPosx[Random.Range(0, 2)];
        }
        Vector3 randomPos = new Vector3(spawnPosxInt, 1.1f, spawnPosz);
        return randomPos;
        
    }
    private void SpawnEnemy()
    {
        spawnIndex = Random.Range(0, 2);
        Instantiate(Enemys[spawnIndex], GenerateRandomPosition(), Enemys[spawnIndex].transform.rotation);
        if (gameOver)
        {
            CancelInvoke();
            
        }
    }
    private void GameOver() // ABSTRACTION
    {
        if (gameOver)
        {
            gameOverT.gameObject.SetActive(true);
            restartB.gameObject.SetActive(true);
        }
    }
    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ScoreTextManager()
    {
        ScoreText.text = "score: " + score;
    }
}
