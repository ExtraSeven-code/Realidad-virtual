using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class GameController : MonoBehaviour {

	public TextMeshProUGUI infoText;
	public TextMeshProUGUI cuantas_ganadas;
	public TextMeshProUGUI cuantas_perdidas;

    public GameObject ball;
	public Player_vasitos player;
	public Cup[] cups;
	public int gano;

	private float resetTimer = 3f;

	// Use this for initialization
	void Start () {
		infoText.text = "Seleccionar el vasito correcto!";
		cuantas_ganadas.text = "Acertado: " + PlayerPrefs.GetInt("conteo_de_ganadas", 0).ToString();
        cuantas_perdidas.text = "No Acertados: "+ PlayerPrefs.GetInt("conteo_de_perdidas", 0).ToString();


        StartCoroutine(ShuffleRoutine());
	}
	
	// Update is called once per frame
	void Update () {
		if (player.picked) {
			if (player.won) {
				infoText.text = "Tu Ganaste!";
				gano = 1;
				
			} else {
				infoText.text = "Tu Perdiste :( Volver a intentar!";
                gano = 1;
            }

			resetTimer -= Time.deltaTime;
			if (resetTimer <= 0f) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
				if (gano == 1)
				{
					PlayerPrefs.SetInt("conteo_de_ganadas", PlayerPrefs.GetInt("conteo_de_ganadas", 0) + 1);
				}
				if (gano == 0)
				{
					PlayerPrefs.SetInt("conteo_de_perdidas", PlayerPrefs.GetInt("conteo_de_perdidas", 0) + 1);
				}
			}
			

        }
	}

	private IEnumerator ShuffleRoutine () {
		yield return new WaitForSeconds (1f);

		foreach (Cup cup in cups) {
			cup.MoveUp ();
		}

		yield return new WaitForSeconds (0.5f);

		Cup targetCup = cups[Random.Range(0, cups.Length)];
		targetCup.ball = ball;
		ball.transform.position = new Vector3 (
			targetCup.transform.position.x,
			ball.transform.position.y,
			targetCup.transform.position.z
		);

		yield return new WaitForSeconds (1.0f);

		foreach (Cup cup in cups) {
			cup.MoveDown ();
		}

		yield return new WaitForSeconds (1.0f);

		for (int i = 0; i < 5; i++) {
			Cup cup1 = cups[Random.Range(0, cups.Length)];
			Cup cup2 = cup1;

			while (cup2 == cup1) {
				cup2 = cups[Random.Range(0, cups.Length)];
			}

			Vector3 cup1Position = cup1.targetPosition;

			cup1.targetPosition = cup2.targetPosition;
			cup2.targetPosition = cup1Position;

			yield return new WaitForSeconds (0.75f);
		}

		player.canPick = true;
	}
}
