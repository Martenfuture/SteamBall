using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallController : MonoBehaviour
{

	public float speed;
	public float jumpHeight;
	public GameObject camera;


	private Rigidbody rb;
	
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0) * new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);

		if (Input.GetKeyDown("space"))
		{
			Vector3 jump = new Vector3(0.0f, jumpHeight, 0.0f);
			rb.AddForce(jump);
		}


	}
}