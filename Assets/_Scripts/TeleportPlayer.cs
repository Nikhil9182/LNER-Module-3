using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
   public OVRCameraRig cameraRig;
    

    private Vector3 teleportPos;

    public void OnTeleportSelect()
    {
        teleportPos = gameObject.transform.position;

        cameraRig.transform.position = new Vector3(teleportPos.x, cameraRig.transform.position.y, teleportPos.z);
    }
}
