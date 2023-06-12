using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Connect : MonoBehaviourPunCallbacks
{
	private void Start()
	{
		PhotonNetwork.ConnectUsingSettings();
		Debug.Log("Connecting...");
	}

	public override void OnConnectedToMaster()
	{
		Debug.Log("Connected!");
        SceneManager.LoadScene("Lobby");
    }
}
