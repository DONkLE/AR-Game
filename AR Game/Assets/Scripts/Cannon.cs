using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Google.XR.ARCoreExtensions;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    private Camera localCamera;

    private Vector3 direction;

    public Button fireButton;

    public ARCloudAnchor cloudAnchor;

    public Rigidbody projectile;

    public float projectileForce;

    private void Start()
    {
        Button button = fireButton.GetComponent<Button>();
        button.onClick.AddListener(FireButtonPressed);
    }


    private void Update()
    {
        localCamera.transform.forward = direction;

        if (cloudAnchor.GetType() != typeof(ARCloudAnchor))
        {
            cloudAnchor = FindObjectOfType<ARCloudAnchor>();
        }
    }

    void FireButtonPressed()
    {

        Rigidbody clone;
        clone = Instantiate(projectile, localCamera.transform.position, localCamera.transform.rotation);
        clone.velocity = direction * projectileForce;
        clone.transform.parent = cloudAnchor.transform;

    }

}
