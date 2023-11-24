using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    public int maxScore = 5; // Maximum score to win the game

    public Text playerScoreText; // UI Text for player score
    public Text computerScoreText; // UI Text for computer score
    public Text winText; // UI Text to display winner

    private int playerScore = 0; // Player score
    private int computerScore = 0; // Computer score

    public Transform ball; // Reference to the ball GameObject
    private Vector3 ballStartPosition; // Initial position of the ball

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ballStartPosition = ball.position;
        UpdateUI();
        HideWinText(); // Hide win text at the start
        StartGame();
    }
    private void UpdateUI()
    {
        playerScoreText.text = "Player: " + playerScore.ToString();
        computerScoreText.text = "Computer: " + computerScore.ToString();
    }

    private void HideWinText()
    {
        winText.gameObject.SetActive(false);
    }

    private void StartGame()
    {
        ResetBall();
    }
  public void HandlePlayerScored()
{
    playerScore++;
    UpdateUI();
    CheckGameEnd();
    ResetBall(); // Reset the ball when player scores
}

public void HandleComputerScored()
{
    computerScore++;
    UpdateUI();
    CheckGameEnd();
    ResetBall(); // Reset the ball when computer scores
}
private void ResetBall()
{
    ball.position = ballStartPosition;
    ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    Invoke("LaunchBall", 1f); // Delay before launching the ball again
}
private void LaunchBall()
{
    ball.GetComponent<Ball>().LaunchBall();
}

 private void CheckGameEnd()
    {
        if (playerScore >= maxScore || computerScore >= maxScore)
        {
            if (playerScore >= maxScore)
            {
                winText.text = "Player Wins!";
            }
            else if (computerScore >= maxScore)
            {
                winText.text = "Computer Wins!";
            }
               winText.gameObject.SetActive(true);
        RestartGame();
    }
}
    private void RestartGame()
{
    // Reset scores
    playerScore = 0;
    computerScore = 0;

    // Update score text
    UpdateUI();

    // Hide game-over text
    winText.gameObject.SetActive(false);

    // Reset the ball and start a new game
    ResetBall();
} 
}