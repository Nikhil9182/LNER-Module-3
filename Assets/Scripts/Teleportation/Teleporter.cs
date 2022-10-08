using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    #region Inspector

    [SerializeField]
    private OVRCameraRig _cameraRig;
    [SerializeField]
    private OVRHand _leftHand;
    [SerializeField] 
    private OVRHand _rightHand;
    [SerializeField, Tooltip("Add Ground layer to which the player will teleport")] 
    private LayerMask _groundLayer;

    [Space(10)]

    [SerializeField, Tooltip("Maximum distance to which a the teleporting ray can hit to interact with the ground")]
    private float _maxDistanceToTeleport = 20f;

    #endregion

    #region Private Members

    private OVRHand.HandFinger finger = OVRHand.HandFinger.Index;
    private OVRHand.TrackingConfidence confidence;

    #endregion

    private void Update()
    {
        CheckFingersPinch(CheckHand());
    }

    private void CheckFingersPinch(OVRHand hand)
    {
        if (hand == null)
            return;

        float ringFingerPinchStrength = hand.GetFingerPinchStrength(finger);
        confidence = hand.GetFingerConfidence(finger);

        if (ringFingerPinchStrength == 1 && confidence == OVRHand.TrackingConfidence.High)
        {
            RaycastHit hit;
            if (Physics.Raycast(hand.PointerPose.position, hand.PointerPose.TransformDirection(Vector3.forward), out hit, _maxDistanceToTeleport, _groundLayer))
            {
                Debug.DrawRay(hand.PointerPose.position, hand.PointerPose.TransformDirection(Vector3.forward) * _maxDistanceToTeleport, Color.red);
                //Teleport the camerRig
                _cameraRig.transform.position = hit.point;
            }
        }
    }

    private OVRHand CheckHand()
    {
        if (_leftHand.GetFingerIsPinching(finger)) { return _leftHand; }
        else if (_leftHand.GetFingerIsPinching(finger)) { return _rightHand; }
        else { return null; }
    }
}
