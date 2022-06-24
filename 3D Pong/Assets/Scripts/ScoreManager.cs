using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    #region Singleton
    public static ScoreManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    [SerializeField] private GoalWall[] goalWall;
    [SerializeField] private Text player1ScoreText, player2ScoreText, player3ScoreText, player4ScoreText;

    [SerializeField] private int maxScore;

    [Header("Game Over")]
    [SerializeField] private Text winnerTxt;
    [SerializeField] private GameObject gameOverPanel;

    private int playerCount;

    private int player1Score, player2Score, player3Score, player4Score;

    private void Start()
    {
        playerCount = 4;
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
        player3ScoreText.text = player3Score.ToString();
        player4ScoreText.text = player4Score.ToString();

        //Jika salah satu Player sudah kebobolan 15 kali
        if (player1Score == maxScore)
        {
            goalWall[0].renderer.material = goalWall[0].material;
            goalWall[0].paddle.SetActive(false);
            goalWall[0].goalWallController.playerDead = true;

            playerCount--;
            player1Score = 0;
            player1ScoreText.gameObject.SetActive(false);
        }
        if (player2Score == maxScore)
        {
            goalWall[1].renderer.material = goalWall[1].material;
            goalWall[1].paddle.SetActive(false);
            goalWall[1].goalWallController.playerDead = true;

            playerCount--;
            player2Score = 0;
            player2ScoreText.gameObject.SetActive(false);
        }
        if (player3Score == maxScore)
        {
            goalWall[2].renderer.material = goalWall[2].material;
            goalWall[2].paddle.SetActive(false);
            goalWall[2].goalWallController.playerDead = true;

            playerCount--;
            player3Score = 0;
            player3ScoreText.gameObject.SetActive(false);
        }
        if (player4Score == maxScore)
        {
            goalWall[3].renderer.material = goalWall[3].material;
            goalWall[3].paddle.SetActive(false);
            goalWall[3].goalWallController.playerDead = true;

            playerCount--;
            player4Score = 0;
            player4ScoreText.gameObject.SetActive(false);
        }

        //Jika pemain tinggal 1 maka dia adalah pemenangnya
        if (playerCount == 1)
        {
            gameOverPanel.SetActive(true);
            string winnersName = GameObject.FindGameObjectWithTag("Player").name;
            winnerTxt.text = winnersName + " is Win";
        }

    }

    public void AddScore(PlayerNumber playerNum)
    {
        switch (playerNum)
        {
            case PlayerNumber.player1:
                player1Score++;
                break;

            case PlayerNumber.player2:
                player2Score++;
                break;

            case PlayerNumber.player3:
                player3Score++;
                break;

            case PlayerNumber.player4:
                player4Score++;
                break;

            default:
                break;
        }
    }

    [System.Serializable]
    public class GoalWall
    {
        public string name;
        public Renderer renderer;
        public Material material;

        public GameObject paddle;
        public GoalWallController goalWallController;
    }
}

public enum PlayerNumber
{
    player1, 
    player2, 
    player3, 
    player4
}

