using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class StalactiteSpawner : MonoBehaviour
{
	private const int NUM_ESTALACS = 4;
	public List<GameObject> estalacPrefabs = new List<GameObject>(NUM_ESTALACS);
	private List<GameObject> tempEstalacPrefabs = new List<GameObject>(NUM_ESTALACS);
	public List<Transform> estalacTransforms = new List<GameObject>(NUM_ESTALACS);

	public float distanciaGeracaoX = 5.1f;
	public float distanciaGeracaoY = 5.1f;

	private Transform player;
	private Transform transf;
	private bool destroyed = true;
	private Animator anim;
	

	//public ShakeCamera shake;

	// Start is called before the first frame update
	void Start()
	{
		createEstalacs();

		player = GameObject.FindWithTag("Player").transform;
		transf = GetComponent<Transform>();
		anim = GetComponent<Animator>();
		//ShakeCamera shake = gameObject.GetComponent<ShakeCamera>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Distance(transf.position.x, player.position.x) < distanciaGeracaoX && Distance(transf.position.y, player.position.y) < distanciaGeracaoY && destroyed)
		{
			anim.SetTrigger("Cai");

			///tremedeira
			//shake.TriggerShake();

			for (int i = 0; i < NUM_ESTALACS; i++)
			{
				tempEstalacPrefabs[i] = Instantiate(estalacPrefabs[i], estalacTransforms[i].position, estalacTransforms[i].rotation) as GameObject;
				tempEstalacPrefabs[i].transform.parent = transf;

			}


			destroyed = false;
		}

	}
	private float Distance(float x, float y)
	{
		return Math.Abs(x - y);
	}

	private void createEstalacs()
	{
		for (int i = 0; i < NUM_ESTALACS; i++)
		{
			estalacPrefabs.Add(new GameObject());
			tempEstalacPrefabs.Add(new GameObject());
			estalacTransforms.Add(new Transform());

		}
	}
}
