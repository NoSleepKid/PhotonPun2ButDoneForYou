using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class PhotonPlayer : MonoBehaviourPunCallbacks
{
    [Header("References")]
    public Transform head;
    public Transform rightHand;
    public Transform leftHand;
    public TextMeshProUGUI nameText;

    [Header("Settings")]
    [Tooltip("This setting replaces the transform view and syncs the position/rotation manually using RPCs.")]
    public bool syncRigUsingRPC = true;

    [Header("Offsets")]
    [Tooltip("Offset applied to the head rotation.")]
    public Vector3 headRotationOffset = new Vector3(-90, 0, 0);

    [Tooltip("Offset applied to the left hand rotation.")]
    public Vector3 leftHandRotationOffset = new Vector3(90, 0, -180);

    [Tooltip("Offset applied to the right hand rotation.")]
    public Vector3 rightHandRotationOffset = new Vector3(90, 0, -180);

    [Tooltip("Vertical offset for the name text position relative to the head.")]
    public float nameTextVerticalOffset = 0.5f;

    private PhotonView view;
    private bool hideVisual = true;

    private void Start()
    {
        view = GetComponent<PhotonView>();

        InvokeRepeating(nameof(UpdateName), 0f, 15f);

        if (PhotonNetwork.InRoom)
        {
            UpdateName();
        }

        if (hideVisual && view.IsMine)
        {
            HideVisuals();
        }
    }

    private void Update()
    {
        if (view.IsMine)
        {
            UpdateRig();
        }
    }

    private void UpdateRig()
    {
        Transform headTarget = GameObject.FindGameObjectWithTag(PhotonManager.instance.vrRigHeadTag).transform;
        Transform leftHandTarget = GameObject.FindGameObjectWithTag(PhotonManager.instance.vrRigLeftHandTag).transform;
        Transform rightHandTarget = GameObject.FindGameObjectWithTag(PhotonManager.instance.vrRigRightHandTag).transform;

        Vector3 headPosition = headTarget.position;
        Quaternion headRotation = headTarget.rotation * Quaternion.Euler(headRotationOffset);

        Vector3 leftHandPosition = leftHandTarget.position;
        Quaternion leftHandRotation = leftHandTarget.rotation * Quaternion.Euler(leftHandRotationOffset);

        Vector3 rightHandPosition = rightHandTarget.position;
        Quaternion rightHandRotation = rightHandTarget.rotation * Quaternion.Euler(rightHandRotationOffset);

        // Send position and rotation data to all clients
        if (syncRigUsingRPC)
        {
            view.RPC("SyncRig", RpcTarget.Others, headPosition, headRotation, leftHandPosition, leftHandRotation, rightHandPosition, rightHandRotation);
        }

        // Update local rig
        head.position = headPosition;
        head.rotation = headRotation;

        leftHand.position = leftHandPosition;
        leftHand.rotation = leftHandRotation;

        rightHand.position = rightHandPosition;
        rightHand.rotation = rightHandRotation;

        // Update name text position
        nameText.transform.position = headPosition + Vector3.up * nameTextVerticalOffset;
    }

    void UpdateName()
    {
        if (view.Owner != null)
        {
            view.RPC("SyncName", RpcTarget.All, view.Owner.NickName);
        }
    }

    [PunRPC]
    public void SyncName(string name)
    {
        nameText.text = !string.IsNullOrEmpty(name) ? name : "no name";

        if (string.IsNullOrEmpty(name))
        {
            PhotonNetwork.NickName = "name";
        }
    }

    [PunRPC]
    public void SyncRig(Vector3 headPos, Quaternion headRot, Vector3 leftHandPos, Quaternion leftHandRot, Vector3 rightHandPos, Quaternion rightHandRot)
    {
        // Update positions and rotations on remote clients
        head.position = headPos;
        head.rotation = headRot;

        leftHand.position = leftHandPos;
        leftHand.rotation = leftHandRot;

        rightHand.position = rightHandPos;
        rightHand.rotation = rightHandRot;

        // Update name text position
        nameText.transform.position = headPos + Vector3.up * nameTextVerticalOffset;
    }

    private void HideVisuals()
    {
        foreach (Renderer renderer in head.gameObject.GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = false;
        }

        foreach (Renderer renderer in leftHand.gameObject.GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = false;
        }

        foreach (Renderer renderer in rightHand.gameObject.GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = false;
        }
    }
}
