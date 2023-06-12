using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class Lobby : MonoBehaviourPunCallbacks
{
	[Header("References")]
	public TMP_InputField createRoomInput;
	public TMP_InputField joinRoomInput;
	[Space]
	public TMP_InputField usernameInput;

	[Header("Settings")]
	public int maxPlayers;
	
	private void Start()
	{
		if (PlayerPrefs.GetString("usernameSet") == "true")
		{
            usernameInput.text = PlayerPrefs.GetString("username");
        }
		
		PhotonNetwork.JoinLobby();
		Debug.Log("Joined Lobby!");
	}
	
	public void SetUsername()
	{
		PhotonNetwork.NickName = usernameInput.text;
		PlayerPrefs.SetString("username", usernameInput.text);
		PlayerPrefs.SetString("usernameSet", "true");
	}
	
	public void CreateRoom()
	{
		if (string.IsNullOrWhiteSpace(createRoomInput.text))
		{
			Debug.Log("Cannot create room due to create input field having whitespaces or being null");
			return;
		}

		RoomOptions roomOptions = new RoomOptions();
		roomOptions.MaxPlayers = maxPlayers;

		PhotonNetwork.CreateRoom(createRoomInput.text, roomOptions);
	}
	
	public void JoinRoom()
	{
		if (string.IsNullOrWhiteSpace(joinRoomInput.text))
		{
			Debug.Log("Cannot join room due to join input field having whitespaces or being null");
			return;
		}

		PhotonNetwork.JoinRoom(joinRoomInput.text);
	}

	public override void OnJoinedRoom()
	{
		Debug.Log("Joined Room!");
		PhotonNetwork.LoadLevel("Game");
	}
}
