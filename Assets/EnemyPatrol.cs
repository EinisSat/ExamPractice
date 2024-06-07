using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
	// Start is called before the first frame update
	public Transform pointA;
	public Transform pointB;

	private Transform current;
	private Transform target;
	Vector3 position1;
	Vector3 position2;
	public float speed = 1f;
	float sinTime;
	private void Start()
	{
		current = pointA;
		target = pointB;
		transform.position = current.position;
		//position1 = pointA.transform.localPosition;
		//position2 = pointB.transform.localPosition;
		//StartCoroutine(moveToA());
	}
	// Update is called once per frame
	void Update()
	{
		//float step = speed * Time.deltaTime;
		//enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, pointA.transform.position, step);
		if (transform.position != target.position)
		{
			sinTime += Time.deltaTime * speed;
			sinTime = Mathf.Clamp(sinTime, 0f, Mathf.PI);
			float t = evaluate(sinTime);
			transform.position = Vector3.Lerp(current.position, target.position, t);
		}

		swap();
	}

	private void swap()
	{
		if(transform.position != target.position) {
			return;
		}

		Transform t = current;
		current = target;
		target = t;
		sinTime = 0;
	}
	public float evaluate(float x)
	{
		return 0.5f * Mathf.Sin(x - Mathf.PI / 2f) + 0.5f;
	}
 //   IEnumerator moveToA()
 //   {
	//	float step = speed * Time.deltaTime;
	//	enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, pointA.transform.position, step);
 //       yield return new WaitForSeconds(0.01f);
	//	if (enemy.transform.position == pointA.transform.position)
	//	{
	//		yield return new WaitForSeconds(2);
	//		StartCoroutine(moveToB());
	//	}
	//}
	//IEnumerator moveToB()
	//{
	//	float step = speed * Time.deltaTime;
	//	enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, pointB.transform.position, step);
 //       if(enemy.transform.position == pointB.transform.position)
 //       {
	//		yield return new WaitForSeconds(2);
 //           StartCoroutine(moveToA());
	//	}
	//}
}
