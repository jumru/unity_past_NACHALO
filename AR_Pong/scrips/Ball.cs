using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	private Rigidbody _rigidbody;

	public Transform ball;
	public Transform _plane;
	public float startBallSpeed = 0.5f;
	
	
	public GameObject playerScoreText;
	public GameObject computerScoreText;
	private int playerScore;
	private int computerScore;

    private void Awake()
    {
		_rigidbody = GetComponent<Rigidbody>();
		

	}
    void Start()
	{
		Reset(0);
	}

	void Update()
	{

		if (playerScore < 10 && computerScore < 10)
		{
			if (playerScoreText && computerScoreText != null)
			{
				playerScoreText.GetComponent<TextMesh>().text = playerScore.ToString();
				computerScoreText.GetComponent<TextMesh>().text = computerScore.ToString();
			}
		}
		else
		{
			Result();
		}
		
		
	}
	public void _Start()
    {
		_rigidbody.WakeUp();
		Vector3 direction = new Vector3(1.5f, Random.Range(1.75f, -1.75f),0);
		if (Random.Range(0, 2) == 1) direction.x *= -1;
		_rigidbody.AddForce(direction * startBallSpeed, ForceMode.Impulse);
	}

	public void Reset(float x)
	{
		_rigidbody.Sleep();
		ball.position = _plane.position;
		if (x > 0) playerScore++; else if (x < 0) computerScore++;

		if (playerScore > 9 || computerScore > 9 && x==0)
		{
			playerScore = 0;
			computerScore = 0;
		}
	}

	public void Result()
    {
		if (playerScore > computerScore)
        {
			playerScoreText.GetComponent<TextMesh>().text = "W";
			computerScoreText.GetComponent<TextMesh>().text = "L";
		}
        else
        {
			playerScoreText.GetComponent<TextMesh>().text = "L";
			computerScoreText.GetComponent<TextMesh>().text = "W";
		}
		
	}

}
