using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Move : MonoBehaviour {

	public float moveSpeed = 10;
	GameObject cam;
	public GameObject enemy;

	public ArrayList list;
	// Use this for initialization
	void Start () {
		cam = Camera.main.gameObject;

		var dof = m_Profile.vignette.settings;
		dof.intensity = 0;
		m_Profile.vignette.settings = dof;
	}

	public PostProcessingProfile m_Profile;

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z) * Time.deltaTime * moveSpeed);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (new Vector3(-cam.transform.right.x, 0, -cam.transform.right.z) * Time.deltaTime * moveSpeed);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (new Vector3(-cam.transform.forward.x, 0, -cam.transform.forward.z) * Time.deltaTime * moveSpeed);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (new Vector3(cam.transform.right.x, 0, cam.transform.right.z) * Time.deltaTime * moveSpeed);
		}
		enemy.GetComponent<Enemy> ().isSeen = enemy.GetComponent<Renderer> ().isVisible;

		if (Input.GetKey (KeyCode.V)) {

			var dof = m_Profile.vignette.settings;
			dof.intensity += .0001f;
			m_Profile.vignette.settings = dof;
		}
	}

	void OnApplicationQuit() {
		var dof = m_Profile.vignette.settings;
		dof.intensity = 0;
		m_Profile.vignette.settings = dof;
	}

	bool IsGrounded() {
		RaycastHit hit;
		if (Physics.Raycast(new Ray(transform.position, -Vector3.up, 1.1), out hit)) {
			return hit.collider.tag == "Floor";
		}

	}

}
