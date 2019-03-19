using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControler : MonoBehaviour {

	public float speed;
	public Text scoreText;
	public Text winText;

	private Rigidbody rb;
	private int score;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		score = 0;
		SetScoreText ();
		winText.text = "";
	}

	// Avant tout calcul de physique. Là où va tout calcul de physique
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("PickUp"))
		{
			other.gameObject.SetActive (false);
			score = score + 1;
			SetScoreText ();
		}
	}

	void SetScoreText ()
	{
		scoreText.text = "Score : " + score.ToString ();
		if (score >= 11)
		{
			winText.text = "Gagné !";
		}
	}
}