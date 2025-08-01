﻿using System;
using UnityEngine;

[Serializable]
public class TankManager
{
	public Color m_PlayerColor;
	public Transform m_SpawnPoint;

	[HideInInspector] public int m_PlayerNumber;
	[HideInInspector] public string m_ColoredPlayerText;
	[HideInInspector] public GameObject m_Instance;
	[HideInInspector] public int m_Wins;
	[HideInInspector] public int m_Losses;

	private TankMovement m_Movement;
	private TankShooting m_Shooting;
	private GameObject m_CanvasGameObject;

	public void Setup()
	{
		m_Movement = m_Instance.GetComponent<TankMovement>();
		m_Shooting = m_Instance.GetComponent<TankShooting>();
		m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;

		m_Movement.m_PlayerNumber = m_PlayerNumber;
		m_Shooting.m_PlayerNumber = m_PlayerNumber;

		m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">PLAYER " + m_PlayerNumber + "</color>";

		MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>();

		for (int i = 0; i < renderers.Length; i++)
		{
			renderers[i].material.color = m_PlayerColor;
		}
	}

	public void DisableControl()
	{
		if (m_Movement != null) m_Movement.enabled = false;
		if (m_Shooting != null) m_Shooting.enabled = false;
		if (m_CanvasGameObject != null) m_CanvasGameObject.SetActive(false);
	}

	public void EnableControl()
	{
		if (m_Movement != null) m_Movement.enabled = true;
		if (m_Shooting != null) m_Shooting.enabled = true;
		if (m_CanvasGameObject != null) m_CanvasGameObject.SetActive(true);
	}

	public void Reset()
	{
		if (m_Instance != null)
		{
			m_Instance.transform.position = m_SpawnPoint.position;
			m_Instance.transform.rotation = m_SpawnPoint.rotation;

			m_Instance.SetActive(false);
			m_Instance.SetActive(true);
		}
	}
}
