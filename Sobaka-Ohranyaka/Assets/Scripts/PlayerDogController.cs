using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
using System.Linq;

public class PlayerDogController : MonoBehaviour {


    [SerializeField] private Animator _animator;
    private CharacterController _characterController;

    private float _gravity = 20.0f;
    private Vector3 _moveDirection = Vector3.zero;

    public float speed = 5.0F;

    public float rotationSpeed = 240F;


    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
    }

	private void Move()
	{
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 camForward_Dir = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 move = v * camForward_Dir + h * Camera.main.transform.right;

        if (move.magnitude > 1F) move.Normalize();

        move = transform.InverseTransformDirection(move);

        float turnAmount = Mathf.Atan2(move.x, move.y);

        transform.Rotate(0, turnAmount * rotationSpeed * Time.deltaTime, 0);

        if (_characterController.isGrounded)
        {
            _moveDirection = transform.forward * move.magnitude;
            _moveDirection *= speed;

        }

        _moveDirection.y -= _gravity * Time.deltaTime;

        _characterController.Move(_moveDirection * Time.deltaTime);

        Vector3 horVelocity = _characterController.velocity;

        horVelocity = new Vector3(_characterController.velocity.x, 0, _characterController.velocity.z);

        float horSpeed = horVelocity.magnitude;
        _animator.SetFloat("Speed", horSpeed);
	}


}
