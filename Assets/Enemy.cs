using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	public GameObject player;
	NavMeshAgent agent;
	public bool isSeen = false;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isSeen) {
			agent.destination = transform.position;
		} else {
			agent.destination = player.transform.position;
		}
	}

	void OnCollisionEnter(Collision col) {
		GameObject player = col.collider.gameObject;
		if (player.name == "Player") {
			Rigidbody r = player.GetComponent<Rigidbody> ();
			r.constraints = RigidbodyConstraints.None;
			r.AddTorque (Camera.main.transform.eulerAngles*100, ForceMode.Impulse);
		}
	}
}
