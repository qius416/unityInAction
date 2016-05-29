using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Controller scripts/FPS Input")]
public class FPSInput : MonoBehaviour {

    private CharacterController _charController;

    public float speed = 6.0f;

	// Use this for initialization
	void Start () {
        _charController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float _translateX = Input.GetAxis("Horizontal") * speed;
        float _translateY = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(_translateX * Time.deltaTime, 0, _translateY * Time.deltaTime);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}
