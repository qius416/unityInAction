using UnityEngine;
using System.Collections;

public class Rayshooter : MonoBehaviour {

    // camera
    private Camera _camera;

	// Use this for initialization
	void Start () {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 gun = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2,0);
            Ray bullet = _camera.ScreenPointToRay(gun);
            RaycastHit hit;
            if(Physics.Raycast(bullet,out hit))
            {
                StartCoroutine(sphereIndicator(hit.point));
            }
        }
	}

    private IEnumerator sphereIndicator(Vector3 point)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = point;

        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}
