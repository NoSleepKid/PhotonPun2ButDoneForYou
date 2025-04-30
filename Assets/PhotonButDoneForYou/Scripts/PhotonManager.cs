using System;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.Events;
using System.Collections.Generic;

public enum PhotonRegion
{
    DEV,         // Development Servers
    US,          // USA East (Washington)
    USW,         // USA West (San Jose)
    CAE,         // Canada East (Montreal)
    SA,          // South America (São Paulo)
    EU,          // Europe (Amsterdam)
    UK,          // United Kingdom (London)
    ASIA,        // Asia (Singapore)
    JP,          // Japan (Tokyo)
    AU,          // Australia (Sydney)
    KR,          // South Korea (Seoul)
    IN,          // India (Chennai)
    ZA,          // South Africa (Johannesburg)
    CN,          // China (Shanghai) - Requires special setup
    RU,          // Russia (Moscow)
    AE           // UAE (Dubai)
}

[RequireComponent(typeof(PhotonView))]
public class PhotonManager : MonoBehaviourPunCallbacks
{
    public static PhotonManager instance;

    [Header("Tags And Locations")]
    public string playerVisualLocation; // Must be inside the "Resources" folder in your assets
    public string vrRigHeadTag; // Tag for your head
    public string vrRigLeftHandTag; // Tag for your left hand
    public string vrRigRightHandTag; // Tag for your right hand

    [Header("Events And Settings")]
    public bool connectOnStart = true;
    public UnityEvent<string> onPlayerJoin;
    public UnityEvent<string> onBannedPlayerTriedJoin;
    public UnityEvent<string> onPlayerLeft;
    public UnityEvent<string> onYouJoined;
    public List<Player> bannedPlayers;
    public PhotonRegion region = PhotonRegion.US;
    

    private string sceneSpecificLobbyName;
    private GameObject tempPlayerVisual;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        bannedPlayers?.Clear();

        // Set region to USA
        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = region.ToString();

        if (connectOnStart)
        {
            ConnectToPhoton();
            Debug.Log("Joining room");
        }
    }

    public void ConnectToPhoton()
    {

        // Ensure region is set to the selected.
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnJoinedRoom();

        // Automatically join the scene-specific lobby
        sceneSpecificLobbyName = $"Scene_{UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex}";
        PhotonNetwork.JoinLobby(new TypedLobby(sceneSpecificLobbyName, LobbyType.Default));
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedRoom();

        // Once in the lobby, attempt matchmaking
        JoinRoomWithMostPlayers();
    }

    private void JoinRoomWithMostPlayers()
    {
        base.OnJoinedRoom();

        // Try to join a room with the highest number of players
        PhotonNetwork.JoinRandomRoom(null, 0, MatchmakingMode.FillRoom, TypedLobby.Default, null, null);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinedRoom();

        // Create a new room if no suitable room is found
        string newRoomName = $"Room_{sceneSpecificLobbyName}_{System.Guid.NewGuid()}";
        RoomOptions options = new RoomOptions
        {
            MaxPlayers = 10 // Adjust as needed
        };
        PhotonNetwork.CreateRoom(newRoomName, options);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        onYouJoined?.Invoke($"Joined Room: {PhotonNetwork.CurrentRoom.Name}");
        tempPlayerVisual = PhotonNetwork.Instantiate(playerVisualLocation, Vector3.zero, Quaternion.identity);
        Debug.Log("Joined room");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnJoinedRoom();
        foreach (Player player in bannedPlayers)
        {
            if (newPlayer == player)
            {
                KickPlayer(player);
                return;
            }
        }
        onPlayerJoin?.Invoke(newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnJoinedRoom();

        onPlayerLeft?.Invoke(otherPlayer.NickName);
    }

    public void SetUsername(string newUsername)
    {
        PhotonNetwork.NickName = newUsername;
    }

    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
    }

    public void DestroyPlayerVisual()
    {
        tempPlayerVisual = null;
        Destroy(tempPlayerVisual);
    }

    public void SpawnPlayerVisual()
    {
        if (tempPlayerVisual != null) { tempPlayerVisual = PhotonNetwork.Instantiate(playerVisualLocation, Vector3.zero, Quaternion.identity); } else { Debug.LogWarning("Can not spawn player visual when your player visual is already spawned!"); }
    }

    public void KickPlayer(Player player)
    {
        this.GetComponent<PhotonView>().RPC("KickPlayerRPC", player);
    }

    [PunRPC]
    public void KickPlayerRPC()
    {
        DestroyPlayerVisual();
        Disconnect();
        Debug.Log("You have been kicked from this lobby.");
        ConnectToPhoton();
    }

    public void BanPlayer(Player player)
    {
        KickPlayer(player);
        bannedPlayers.Add(player);
    }

    private void OnDestroy()
    {
        DestroyPlayerVisual();
        Disconnect();
    }

}
