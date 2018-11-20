using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
public class Player : MonoBehaviour {

	public float jumpForce = 15f;

	public Rigidbody2D rb;
	public SpriteRenderer sr;

	public string currentColor;

	public Color colorCyan;
	public Color colorYellow;
	public Color colorMagenta;
	public Color colorPink;
	public int score;
	public Text sscore;
	void Start ()
	{
		SetRandomColor();
		score = 0;
	}
	void Update () 
	    {
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
		{
			rb.velocity = Vector2.up * jumpForce;

			Debug.Log("Score: "+score);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "ColorChanger")
		{
			SetRandomColor();
			score = score + 1;
			sscore.text = score.ToString ();
			Destroy(col.gameObject);
			return;
		}

		if (col.tag != currentColor)
		{
			Debug.Log("GAME OVER ! :( !");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	void SetRandomColor ()
	{
		int index = Random.Range(0, 4);

		switch (index)
		{
			case 0:
				currentColor = "Cyan";
				sr.color = colorCyan;
				break;
			case 1:
				currentColor = "Yellow";
				sr.color = colorYellow;
				break;
			case 2:
				currentColor = "Magenta";
				sr.color = colorMagenta;
				break;
			case 3:
				currentColor = "Pink";
				sr.color = colorPink;
				break;
		}
	}
}
