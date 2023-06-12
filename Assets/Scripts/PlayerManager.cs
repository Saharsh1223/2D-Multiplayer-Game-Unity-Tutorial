using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerManager : MonoBehaviour
{
	public PhotonView view;
	public TMP_Text usernameText;
	[Space]
	public PlayerMovement playerMovement;
	public Camera camera;
	public AudioListener audioListener;

	private void Update()
	{
		if (view.IsMine)
		{
			usernameText.text = PhotonNetwork.NickName;

			playerMovement.enabled = true;
			audioListener.enabled = true;
			camera.enabled = true;
		}
		else
		{
            usernameText.text = view.Owner.NickName;

            playerMovement.enabled = false;
			audioListener.enabled = false;
			camera.enabled = false;
		}
	}
}
