using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasController : MonoBehaviour
{
    [SerializeField]
    private Transform _targetTransform;
    [SerializeField]
    private OVRCameraRig _cameraRig;
    [SerializeField]
    public Transform _canvasTransform;
    [SerializeField]
    private float _offset = 5f;
    [SerializeField]
    private float smoothTime = 1f;

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        Vector3 pos = _targetTransform.position;
        pos.z += _offset;
        _targetTransform.position = pos;
    }

    private void FixedUpdate()
    {
        CanvasFollow();
    }

    private void CanvasFollow()
    {

        //Rotation
        Vector3 lookPos = _canvasTransform.position - _cameraRig.transform.position;
        var rotation = Quaternion.LookRotation(lookPos);
        _canvasTransform.rotation = Quaternion.Slerp(transform.rotation, rotation, smoothTime);

        //Position
        Vector3 cameraPos = _targetTransform.position;
        cameraPos.y = _canvasTransform.transform.position.y;
        _canvasTransform.position = Vector3.SmoothDamp(_canvasTransform.position, cameraPos, ref velocity, smoothTime);
    }
}
