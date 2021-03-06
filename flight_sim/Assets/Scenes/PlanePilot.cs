﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePilot : MonoBehaviour {

	// Use this for initialization
	public float speed = 90.0f;

	void Start () {
		Debug.Log("plane pilot script added to "+gameObject.name);
		
	}
	
	// Update is called once per frame
	void Update () {
		/*Vector3 moveCamto = transform.position - transform.forward * 10.0f + Vector3.up * 5.0f;
		float bias = 0.96f;
		Camera.main.transform.position = Camera.main.transform.position * bias + moveCamto * (1.0f-bias);
		Camera.main.transform.LookAt(transform.position + transform.forward *30.0f);*/

		transform.position += transform.forward * Time.deltaTime * speed;

		speed -= transform.forward.y * Time.deltaTime* 50.0f;

		if(speed<35.0f)
		{
			speed = 35.0f;
		}
		transform.Rotate(Input.GetAxis("Vertical"),0.0f,-Input.GetAxis("Horizontal"));

		float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);

		if(terrainHeightWhereWeAre > transform.position.y){
			transform.position = new Vector3(transform.position.x,
											 terrainHeightWhereWeAre,
											 transform.position.z);
		}
	}
}


