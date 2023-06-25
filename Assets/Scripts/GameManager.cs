using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class GameManager : MonoBehaviour
{
	public GameObject playerPrefab;

	private void Start()
	{
		PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(Random.Range(-5, 5), 0, 0), Quaternion.identity);
		Debug.Log("Instantiated Player!");
	}
}