using UnityEngine;
using System.Collections;


enum PlayerDirection
{
	left = -1,
	right = 1,
}

public class MainRhinoScript : MonoBehaviour
{
	private float m_fSpeed = 1;
	private bool m_bIsCollide = false;
	PlayerDirection direction = PlayerDirection.right;

	void Awake ()
	{
	}

	void Start ()
	{

	}

	void Update ()
	{
		if (m_bIsCollide) {
			m_bIsCollide = !m_bIsCollide;
			if (direction == PlayerDirection.right) {
				direction = PlayerDirection.left;	
			} else if(direction == PlayerDirection.left) {
				direction = PlayerDirection.right;		
			}
			this.transform.localScale = new Vector3(this.transform.localScale.x * -1, 
				this.transform.localScale.y, this.transform.localScale.z);
		}

		this.transform.localPosition = new Vector3 (this.transform.localPosition.x + Time.deltaTime * Direction (),
			this.transform.localPosition.y, this.transform.localPosition.z);
	}

	float Direction ()
	{
		return (float)direction;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		m_bIsCollide = !m_bIsCollide;
		Debug.Log("OnTriggerEnter2D");
	}
}
