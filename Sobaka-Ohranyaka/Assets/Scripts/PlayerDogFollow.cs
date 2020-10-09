using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDogFollow : MonoBehaviour {

    [SerializeField]
    private Transform _playerTransform;
    private Vector3 _cameraOffset;
    [Range(0.01F, 1.0F)]
    public float smoothFactor = 0.5F;

    public bool LookAtPlayer = true;

	// Use this for initialization
	void Start () {
        _cameraOffset = transform.position - _playerTransform.position;

	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 newPos = _playerTransform.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
        if(LookAtPlayer){
            transform.LookAt(_playerTransform);
        }
	}
}
