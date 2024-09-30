using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] TMP_Text livesText;
	[SerializeField] TMP_Text scoreText;

	int lives = 3;
	int score;

	public static GameManager instance;

	[SerializeField] AudioClip failSound;
	[SerializeField] GameObject gameOverScreen;

	void Start()
	{
		instance = this;
	}

	public void AddScore(int value = 1)
	{
		score += value;
		scoreText.text = score.ToString();
	}

	public void Damage(int value = 1)
	{
		lives-=value;
		if (lives <= 0) GameOver();
		livesText.text = lives + " lives";
		Audio.Play(failSound);
	}

	void GameOver()
	{
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
		livesText.gameObject.SetActive(false);
		scoreText.gameObject.SetActive(false);
    }

    public void OnClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}