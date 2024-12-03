# PhotonPun2ButDoneForYou  

**The VR multiplayer package for Photon Pun 2. Pre-configured so you can focus on your game.**  

---

## **How to Set Up**  

### 1. Install the Package  
- Download the `.unitypackage` file and import it into your Unity project.  

### 2. Install Photon Pun 2  
- Add **Photon Pun 2 Free** via the Unity Package Manager or Asset Store.  

### 3. Set Up Your Photon App  
- Go to the Photon Dashboard and create a new app:  
  - **Type:** Multiplayer  
  - **Photon SDK:** PUN  
- Copy your App ID.  

### 4. Connect to Photon  
- In Unity, go to **Window > Photon Unity Networking > Pun Wizard**.  
- Paste your App ID into the wizard to connect.  

---

## **Customizing Your VR Rig**  

### 1. Assign Tags  
- Add tags to your VR rig's **head**, **left hand**, and **right hand**.  

### 2. Use PhotonManager  
- Drag the **PhotonManager prefab** into your scene.  
- Configure:  
  - VR rig tags (head, hands).  
  - Auto-connect to the lobby (optional).  
  - Region settings for v1.1+.  

---

## **Player Prefab**  

1. Open the **Player Visual Prefab** in `Assets/Resources/PhotonButDoneForYou`.  
2. Customize as needed:  
   - Adjust rotation offsets.  
   - Replace the default player model.  

**Tip:**  
If your rig doesn’t sync correctly, enable `Sync Rig Using RPC` in the prefab settings.  

---

## **New Features in v1.1**  

- **KickPlayer(Player player):** Remove a player from the room.  
- **BanPlayer(Player player):** Kick and block a player from rejoining.  

---

## **Known Issues**  

- Username text might clip through VR headsets. Adjust the **Text Vertical Offset** in the Player Visual Prefab.  
- If objects you have added in your Player Visual Prefab do NOT sync position, rotation, Or even scale, Please try using the `SyncRigUsingRPC` setting on the Player Visual Prefab to counteract this behaviour.

---

## **PhotonManager API**  

1. **`ConnectToPhoton()`**  v1.0
   Connects to Photon servers.  

2. **`SetUsername(string username)`**  v1.0
   Sets the player's username.  

3. **`Disconnect()`**  v1.0
   Disconnects from Photon.  

4. **`DestroyPlayerVisual()`**  v1.0
   Removes the local player’s visual representation.  

5. **`SpawnPlayerVisual()`**  v1.0
   Spawns the player’s visual in the scene.  

6. **`KickPlayer(Player player)`**  v1.1
   Removes a player from the room.  

7. **`BanPlayer(Player player)`**  v1.1
   Bans a player from rejoining the room.  

---

## **FAQ**  

1. **Can regions communicate with each other?**  
   - No, regions are isolated.  

2. **Can I use this for non-VR multiplayer?**  
   - Yes, but it’s optimized for VR rigs.  

---

Now you're ready to create your multiplayer VR experience with PhotonPun2ButDoneForYou. Enjoy!
