# PhotonPun2ButDoneForYou 🎮🚀  
**The ultimate VR multiplayer package for Photon Pun 2, pre-programmed for your convenience.**  
Forget hours of tinkering; we've done the work so you can just plug, play, and crush it in VR.  

---

## **How to Set Up (a.k.a., The Fun Part)**  

### 1. Install the Magic 🎩  
- Download the latest `.unitypackage` file and install it.  
  ![Installation Instructions](https://github.com/user-attachments/assets/fe394525-2b71-44c9-aa80-31c26ddf54a0)  
  *(It's literally a right-click away—you're welcome.)*  

### 2. Photon Pun 2: The Power Source ⚡  
- Make sure you’ve installed **Photon Pun 2 Free** via the Unity Package Manager or Asset Store.  
  ![Photon Pun 2 on Asset Store](https://github.com/user-attachments/assets/a76565f8-95a4-45f7-a0cc-09e8709bb8f7)  
  *(No Pun, no fun. Get it?)*  

### 3. Set Up Your Photon App 🌐  
- Head over to the Photon Pun 2 Dashboard and create a new app:  
  - **Settings:** Multiplayer Game  
  - **Photon SDK:** PUN  
- Copy your App ID like your life depends on it (because it kinda does).  

### 4. Wizardry 🧙‍♂️  
- In Unity, go to **Window > Photon Unity Networking > Pun Wizard**.  
- Hit **Setup Project**, paste in your App ID, and voilà—you’re connected!  
  ![Pun Wizard Setup](https://github.com/user-attachments/assets/88ed507d-75cb-4558-9d3f-f0212ef628f3)  
  *(Look at you, being all tech-savvy.)*  

---

## **Customizing Your VR Rig 🕶️✋**  

### 1. Tag All the Things  
- Set your VR rig's left hand, right hand, and head objects to your desired tags.  

### 2. Photon Manager Is Your New Best Friend  
- Drag the Photon Manager prefab from `Assets/PhotonButDoneForYou` into your scene.  
- Update these settings:  
  - **VR Rig Left, Right Hand, and Head Tags** to match the ones you just set.  
    ![Tag Variables](https://github.com/user-attachments/assets/31343e0b-25b6-4e77-9733-554eb20e969c)  
  - Want to connect to a lobby on start? Toggle that setting too!  
    ![Lobby Connect on Start](https://github.com/user-attachments/assets/283e7b1d-0973-4016-a784-9688f627b75e)  

### 3. Callback Central 📞  
- Assign callbacks for when players join or leave the room. (Yes, even Steve from accounting.)  

---

## **The Player Prefab Zone 🧍‍♂️🔧**  

1. Go to `Assets/Resources/PhotonButDoneForYou`.  
2. Open the **Player Visual Prefab** and let the tweaking begin!  
   - Adjust rotation offsets.  
   - Replace the player model with something cooler if you feel like it.  
   *(A robot? A dragon? A pizza slice? You do you.)*  

**Pro Tip:**  
If your player model refuses to sync across platforms (it’s probably stubborn), turn on:  
`Sync Rig Using RPC`.  
![Sync Rig Using RPC](https://github.com/user-attachments/assets/04003c1b-473f-44b4-9329-db31316e2182)  

---

## **Final Adjustments 🛠️**  

- Got a username clipping through your VR headset? Yeah, that's annoying.  
  Fix it by tweaking the **Text Vertical Offset** in the Player Visual Prefab.  
  ![Text Vertical Offset](https://github.com/user-attachments/assets/1a9252e7-7b72-440b-bb86-6ce21c5d56e2)  

---

## **You're Done! 🎉**  
Congratulations, VR Master! You’ve just set up a Photon-powered multiplayer game without breaking a sweat. Go ahead, pat yourself on the back. Now get out there and show the world what VR multiplayer fun looks like.  

*(Disclaimer: If anything breaks, it’s probably because of Steve.)*
