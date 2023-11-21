using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    private YandexApi yandexAPi;

    public Text playerText;
    public Text aiText;

    public Paddle playerPaddle;
    public Paddle aiPaddle;

    public GameObject menu;
    public GameObject game;
    public GameObject lose;
    public GameObject win;
    public GameObject cont;


    private int playerScore;
    private int aiScore;

    private void Start()
    {
        YandexApi.Init(() =>
        {
            YandexApi.GetPlayer(() =>
            {
                Mute();
                YandexApi.ShowFullscreenAdv(() =>
                { Unmute(); }, (string error) =>
                { Unmute(); });
                var a = YandexApi.DeviceInfo();
                Debug.Log(a);
                var playerInfo = YandexApi.GetPlayerInfo();
                Debug.Log(JsonUtility.ToJson(playerInfo));
            }, (error) => Debug.Log(error));
        }, (error) => Debug.Log(error));
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        menu.SetActive(true);
        game.SetActive(false);
    }

    public void Mute()
    {
        AudioListener.volume = 0f;
    }

    public void Unmute()
    {
        AudioListener.volume = 0.5f;
    }

    public void Continue()
    {
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayerScores()
    {
        playerScore++;
        this.playerText.text = playerScore.ToString();
        ReserRound();

        if (playerScore == 10)
        {
         //   Mute();
         //   YandexApi.ShowFullscreenAdv(() =>
          //  { Unmute(); }, (string error) =>
          //  { Unmute(); });
            cont.SetActive(false);
            Time.timeScale = 0f;
            game.SetActive(false);
            win.SetActive(true);
        }
    }

    public void AiScore()
    {
        aiScore++;
        this.aiText.text = aiScore.ToString();

        RestartAi();

        if (aiScore == 10)
        {
           // Mute();
          //  YandexApi.ShowFullscreenAdv(
           //     () => { Unmute(); },
             //   (string error) => { Unmute(); });
            cont.SetActive(false);
            Time.timeScale = 0f;
            game.SetActive(false);
            lose.SetActive(true);
        }
    }

    private void ReserRound()
    {
        this.playerPaddle.ResetPosition();
        this.aiPaddle.ResetPosition();
        this.ball.ResetBall();
    }

    private void RestartAi()
    {
        cont.SetActive(true);
        game.SetActive(false);
        menu.SetActive(false);
        Time.timeScale = 0f;
        this.playerPaddle.ResetPosition();
        this.aiPaddle.ResetPosition();
        this.ball.ResetBall();
    }
}
