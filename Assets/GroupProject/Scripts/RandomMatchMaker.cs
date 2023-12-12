using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RandomMatchMaker : MonoBehaviourPunCallbacks
{
    public GameObject PhotonObject;

    // using PhotonUsersettings
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();    
    }

    public override void OnConnectedToMaster()
    {
        //Every player will join in the same room becuase we only have one room - up to 8 players

        PhotonNetwork.JoinRandomRoom();
    }
    //called when joining the room
    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {   //this will be called when joining room failed
        //The first player will be failed
        //We are creating a room for the first player
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 8;
        //setting the name of the room null as we only have one room
        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    //called when joining a room
    public override void OnJoinedRoom()
    {
        //Instantiate a character
        PhotonNetwork.Instantiate(
            PhotonObject.name,
            new Vector3(0,1f,0f), Quaternion.identity,0
            );

        //GameObject mainCamera = GameObject.FindWithTag("MainCamera");
        //mainCamera.GetComponent<Eathen.ThirdPersonCamera>().enabled = true;
    }

   
}
