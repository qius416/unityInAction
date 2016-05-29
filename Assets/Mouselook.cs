using UnityEngine;

[AddComponentMenu("Controller scripts/Mouse look")]
public class Mouselook : MonoBehaviour {

    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axis = RotationAxes.MouseXAndY;

    // adjust horizontal mouse moving sensitivity
    public float SensitivityX = 8.0f;
    public float SensitivityY = 8.0f;

    public float minVert = -45.0f;
    public float maxVert = 45.0f;


    private float _rotationX = 0;
    // Use this for initialization
    void Start () {
        Rigidbody body = GetComponent<Rigidbody>();
        if(body != null)
        {
            body.freezeRotation = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(axis == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * SensitivityX, 0);
        }else if (axis == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * SensitivityY;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);
            float _rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * SensitivityY;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);
            float deltaY = Input.GetAxis("Mouse X") * SensitivityX;
            float _rotationY = transform.localEulerAngles.y + deltaY;
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
	}
}
