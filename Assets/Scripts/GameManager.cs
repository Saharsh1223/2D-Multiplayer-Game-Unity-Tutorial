using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class GameManager : MonoBehaviour
{
	public GameObject playerPrefab;
	[Space]
	public GameObject contentObject;
	public GameObject messagePrefab;
	public TMP_InputField messageInput;
	public PhotonView pv;
	[Space]
	public TMP_Text pingText;

	private void Start()
	{
		PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(Random.Range(-5, 5), 0, 0), Quaternion.identity);
		Debug.Log("Instantiated Player!");
	}
	
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			pv.RPC("SendAndGetMessage", RpcTarget.All, messageInput.text);
		}

        pingText.text = "PING: " + PhotonNetwork.GetPing();
    }
	
	[PunRPC]
	private void SendAndGetMessage(string message, PhotonMessageInfo info)
	{
		string sender = info.Sender.NickName;

		GameObject messageObj = Instantiate(messagePrefab, contentObject.transform);
		messageObj.GetComponent<MessageObject>().msgText.text = sender + ": " + message;
	}
}
