using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject player;
    [SerializeField] private Block simpleBlock;
    [SerializeField] private Block redBlock;
    [SerializeField] private Block yellowBlock;
    [SerializeField] private Block greenBlock;
    [SerializeField] private Bonus bonus;
    [SerializeField] private Text scoreUI;
    [SerializeField] private Text gameOver;
    public List<Block> allBlocks = new List<Block>();
    private IEnumerator spawnBonus;
    private int score = 0;
    public static int remainsBlock = 0;
    public static event Action RestartGame;
    public static Game currentGame;
    public static bool play = false;
    public int test;


    void Start()
    {
        if (currentGame == null)
            currentGame = this;

        allBlocks.AddRange(FindObjectsOfType<Block>());
        remainsBlock = allBlocks.Count;
        Time.timeScale = 1f;    
        spawnBonus = SpawnBonus();
        StartCoroutine(spawnBonus);
        play = false;
        gameOver.gameObject.SetActive(false);
    }

    void Update()
    {
        if (ball.transform.position.y < -5.5f)
        {
            player.transform.position = new Vector2(0.0f, -4.0f);
            play = false;
            RestartGame();
        }

        if (remainsBlock<= 0)
        {
            GameOver();
        }
    }

    public static void ChangeBlock(Vector2 position, string nameBlock)
    {
        switch (nameBlock)
        {
            case "RedBlock":
                currentGame.Create(position, currentGame.redBlock);
                break;
            case "YellowBlock":
                currentGame.Create(position, currentGame.yellowBlock);
                break;
            case "GreenBlock":
                currentGame.Create(position, currentGame.greenBlock);
                break;
            case "SimpleBlock":
                currentGame.Create(position, currentGame.simpleBlock);
                break;
        }
    }

    public static void ChangeScore(int getScore)
    {
        currentGame.score += getScore;
        currentGame.scoreUI.text = currentGame.score.ToString();
    }

    private IEnumerator SpawnBonus()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            var randomX = UnityEngine.Random.Range(-2.5f, 2.5f);
            var position = new Vector2(randomX, 5.5f);
            Create(position, bonus);
        }       
    }

    public void Create(Vector2 position, Block block)
    {
        Instantiate(block, position, Quaternion.identity);
    }

    public void Create(Vector2 position, Bonus bonus)
    {
        Instantiate(bonus, position, Quaternion.identity);
    }

    public void Restart()
    {
        play = false;
        StopCoroutine(spawnBonus);
        allBlocks.Clear();
        SceneManager.LoadScene(0);       
    } 

    public void GameOver()
    {
        play = false;
        StopCoroutine(spawnBonus);
        allBlocks.Clear();
        Time.timeScale = 0.001f;
        gameOver.gameObject.SetActive(true);

    }
}
