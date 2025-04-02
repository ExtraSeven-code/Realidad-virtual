using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;


public class GameController_ping : MonoBehaviour 
{
	public TextMeshProUGUI score;
    public TextMeshProUGUI score_menu;
    public Player_ping player;
	public Ball ball;
	public TextMesh scoreText;
	public GameObject menu_gameover;

	private float gameOverTimer = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool isGameOver = ball.transform.position.z < player.transform.position.z;

		if (isGameOver == false) {
			scoreText.text = "Score: " + ball.score;
            score.text = "Score: " + ball.score;
        } else {
			scoreText.text = "Game over!\nYour final score: " + ball.score;
			menu_gameover.SetActive(true);
            score_menu.text = "Game over!\nYour final score: " + ball.score;

		}
	}
	public void reinicio()
	{
		Debug.Log("se reinicio");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void menu()
    {
        Debug.Log("se fue al inicio");
        SceneManager.LoadScene("Menu_Inicio");
    }
}
