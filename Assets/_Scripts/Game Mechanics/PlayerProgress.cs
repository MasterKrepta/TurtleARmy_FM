﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{

	[SerializeField] private int _levelupThreshold = 5;

	private static PlayerProgress _instance;
	
	public  static PlayerProgress Instance
	{
		get
		{
			return _instance;
		}
	}

	public PlayerProgress()
	{
		_instance = this;
	}
	private  Minion _playerData;

	public  Minion PlayerData
	{
		get { return _playerData; }
		set 
		{ 
			_playerData = value; 
			//TODO notify game of level up (event)
		}
	}

	[SerializeField]private int _creditBalance;

	
	public int CreditBalance
	{
		get { return _creditBalance; }
		set
		{
			_creditBalance = value;
			//TODO notify game (event)
		}
	}

	[SerializeField]private int _experiance;

	public int Experiance
	{
		get { return _experiance; }
		set 
		{ 
			_experiance = value;
			
			//TODO notify game (event)
		}
	}
	public void EarnXP(int xpToGain)
	{
		Experiance += xpToGain;
		if (CanLevelUp())
		{
			LevelUp();
			//TODO call the event to do this. 
		}
	}

	private void LevelUp()
	{
		
		
		
		//Adjust experiance to prevent rollover loss
		//2: Show three options
		LevelUpMenu.Instance.ActivateLevelUpMenu();
		//3: upgrade option chosen
		//4: resume gameplay
		
	}

	private bool CanLevelUp()
	{
		if (Experiance > _levelupThreshold)
		{
			return true;
		}
		return false;
	}

	public  void GiveCredits(int creditsToGive)
	{
		CreditBalance += creditsToGive;
	}

	public  void SpendCredits(int creditsToSpend)
	{
		if (CanSpend(creditsToSpend))
		{
			CreditBalance -= creditsToSpend;
		}
		else
		{
			Debug.Log($"Can not afford {creditsToSpend}");
		}
		
	}

	
	public bool CanSpend(int amountToSpend)
	{
		if (amountToSpend > CreditBalance)
		{
			return true;
		}
		return false;
	}
}
