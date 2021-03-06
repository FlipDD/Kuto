﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunCollider : MonoBehaviour {

	private float stunDuration;

	void Awake () 
	{
		stunDuration = PlayerHandler.playerHandler.GetComponent<PlayerHandler>().stunDuration;
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("EnemyRanged")) 
		{
			EnemyRangedHandler enemy = col.GetComponent<EnemyRangedHandler>();
			enemy.KnockBack(1000000);
			if (enemy.GetHealthSystem().GetHealthPercent() < 0.25) enemy.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
			if (enemy.switched == false) StartCoroutine(enemy.SwapState(stunDuration));
		}  
		if (col.CompareTag("Enemy"))
		{
			EnemyHandler enemy = col.GetComponent<EnemyHandler>();  
			enemy.KnockBack(1000000);
			if (enemy.GetHealthSystem().GetHealthPercent() < 0.25) enemy.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
			if (enemy.switched == false) StartCoroutine(enemy.SwapState(stunDuration));
		}
		if (col.CompareTag("EnemySlower"))
		{
			EnemySlowerHandler enemy = col.GetComponent<EnemySlowerHandler>();  
 			enemy.KnockBack(1000000);
			if (enemy.GetHealthSystem().GetHealthPercent() < 0.25) enemy.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
			if (enemy.switched == false) StartCoroutine(enemy.SwapState(stunDuration));			
		}
	}
}

