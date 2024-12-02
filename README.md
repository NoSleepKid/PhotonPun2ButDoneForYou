# PhotonPun2ButDoneForYou 🎮🚀  
**The ultimate VR multiplayer package for Photon Pun 2, pre-programmed for your convenience.**  
Forget hours of tinkering; we've done the work so you can just plug, play, and crush it in VR.  
*(Disclaimer: Steve from accounting may still break it.)*  

---

## **How to Set Up (a.k.a., The Fun Part)**  

### 1. Install the Magic 🎩  
- Download the latest `.unitypackage` file and install it.  
  ![Installation Instructions](https://github.com/user-attachments/assets/fe394525-2b71-44c9-aa80-31c26ddf54a0)  
  *(Yes, it’s as easy as it looks—you're welcome.)*  

### 2. Photon Pun 2: The Power Source ⚡  
- Install **Photon Pun 2 Free** via Unity Package Manager or the Asset Store.  
  ![Photon Pun 2 on Asset Store](https://github.com/user-attachments/assets/a76565f8-95a4-45f7-a0cc-09e8709bb8f7)  
  *(No Pun, no fun. Seriously.)*  

### 3. Set Up Your Photon App 🌐  
- Go to the Photon Pun 2 Dashboard and create a new app:  
  - **Settings:** Multiplayer Game  
  - **Photon SDK:** PUN  
- Grab that shiny App ID like it’s a rare Pokémon.  

### 4. Wizardry 🧙‍♂️  
- In Unity, go to **Window > Photon Unity Networking > Pun Wizard**.  
- Click **Setup Project**, paste in your App ID, and boom—you’re connected!  
  ![Pun Wizard Setup](https://github.com/user-attachments/assets/88ed507d-75cb-4558-9d3f-f0212ef628f3)  
  *(Magic? More like logic. But still, pat yourself on the back.)*  

---

## **Customizing Your VR Rig 🕶️✋**  

### 1. Tag All the Things  
- Set your VR rig's **left hand**, **right hand**, and **head objects** to your desired tags.  

### 2. Photon Manager Is Your New Best Friend  
- Drag the **Photon Manager prefab** from `Assets/PhotonButDoneForYou` into your scene.  
- Update these settings:  
  - **VR Rig Left, Right Hand, and Head Tags** to match your tags.  
    ![Tag Variables](https://github.com/user-attachments/assets/31343e0b-25b6-4e77-9733-554eb20e969c)  
  - Want to connect to a lobby on start? Flip that toggle like a pro.  
    ![Lobby Connect on Start](https://github.com/user-attachments/assets/283e7b1d-0973-4016-a784-9688f627b75e)
  - And select your region.
  - ![image](https://github.com/user-attachments/assets/78d1cbc8-dea9-4a78-9226-14a01b2f6846)


### 3. Callback Central 📞  
- Assign callbacks for when players join or leave.  
  *(Yes, even Steve. Sigh.)*  

---

## **The Player Prefab Zone 🧍‍♂️🔧**  

1. Navigate to `Assets/Resources/PhotonButDoneForYou`.  
2. Open the **Player Visual Prefab** and get customizing:  
   - Adjust rotation offsets.  
   - Swap out the player model. Make it a dragon, robot, or even a dancing banana. Go wild.  

**Pro Tip:**  
If your player model acts like a diva and won’t sync across platforms, enable:  
`Sync Rig Using RPC`.  
![Sync Rig Using RPC](https://github.com/user-attachments/assets/04003c1b-473f-44b4-9329-db31316e2182)  

---

## **Final Adjustments 🛠️**  

- Is your username clipping through your VR headset?  
  Fix it by tweaking the **Text Vertical Offset** in the Player Visual Prefab.  
  ![Text Vertical Offset](https://github.com/user-attachments/assets/1a9252e7-7b72-440b-bb86-6ce21c5d56e2)  

---

## **You're Done! 🎉**  
Congratulations, VR Master!  
You’ve set up Photon-powered multiplayer like a legend. Time to dominate the virtual world.  

---

## **EZ API & Tips (PhotonManager Edition)** 📚💡  

### **Meet the Singleton:**  
The **PhotonManager** class has a singleton called `instance`—because we know you love shortcuts.  

### **The Handy Functions:**  
1. **`ConnectToPhoton()` 1.0+**  
   - Easy-peasy function to connect to a lobby.  

2. **`SetUsername(string username)` 1.0+**  
   - Sets your username. *(Be nice, no weird names.)*  

3. **`Disconnect()` 1.0+**  
   - Logs you out of the lobby. (Don’t rage quit. It’s not cool.)  

4. **`DestroyPlayerVisual()` 1.0+**  
   - Poof! Makes your player visual disappear. Perfect for when you want to be stealthy or just invisible.  

5. **`SpawnPlayerVisual()` 1.0+**  
   - Brings your player visual back. (Because, obviously, you’re the star of the show.)  

---

Now go forth, conquer VR multiplayer, and remember: Steve from accounting is still probably gonna break something. 😉
