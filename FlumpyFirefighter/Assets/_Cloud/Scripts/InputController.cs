using System;
using UnityEngine;
using UnityEngine.InputSystem;
// Set the rotation of the player from the input of DS4
public class InputController : MonoBehaviour
{
    public static InputController m_Instance;
    public Gamepad controller = null;
    private Transform m_transform;
    public float m_Sansitivity = 4000;
    public Camera m_MainCam;
    GameObject decal;
    GameObject playerDecal;
    public bool decalOn;

    public AudioClip[] auds;
    AudioSource a;

    private void Awake()
    {
        m_Instance = this;
        this.controller = DS4.getConroller();
        m_transform = this.transform;
        a = GetComponent<AudioSource>();
    }
    void Start()
    {
        GameObject _decalPrefab = GameManager.m_Instance.decalPrefab;
        playerDecal = Instantiate(_decalPrefab,transform.position, Quaternion.identity);
        playerDecal.SetActive(false);
        decalOn = false;

    }

    void Update()
    {
        if (controller == null)
        {
            try
            {
                controller = DS4.getConroller();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        else
        {
            // Press circle button to reset rotation
            if (controller.buttonEast.isPressed)
            {
                // to do
                //float rot_x, rot_y, rot_z;
                //rot_x = this.transform.rotation.eulerAngles.x;
                //rot_y = m_MainCam.transform.rotation.eulerAngles.y;
                //rot_z = this.transform.rotation.eulerAngles.z;
                //m_transform.rotation = Quaternion.identity;

                m_transform.rotation = m_MainCam.gameObject.transform.rotation;

            }
            m_transform.rotation *= DS4.getXYZRotation(m_Sansitivity * Time.deltaTime);


            // Test button pressed
            if (Gamepad.current.rightTrigger.wasPressedThisFrame)
            {
                a.PlayOneShot(auds[0]);
            }else if (Gamepad.current.rightShoulder.wasPressedThisFrame)
            {
                a.PlayOneShot(auds[1]);
            }

            if (Gamepad.current.leftTrigger.wasPressedThisFrame)
            {
                //GameManager.m_Instance.firePutOut += 15;
            }
            ProjectDecal();
            if (Gamepad.current.squareButton.wasPressedThisFrame)
            {
                decalOn = !decalOn;
                playerDecal.SetActive(decalOn);
                
            }
            
        }
    }

    public void ProjectDecal()
    {
        RaycastHit hit;
        float distance = GameManager.m_Instance.detectDist;
        Transform player = WaterBallControll.m_Instance.player;
        int layer_mask = LayerMask.GetMask("Env", "Grounded");
        Vector3 dir = transform.up;
        

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layer_mask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);

            Debug.Log("Hit env and spawn decal");
            playerDecal.transform.position = hit.point;
            playerDecal.transform.rotation = Quaternion.identity;

            playerDecal.transform.parent = player;
        }
    }

    // unused
    // Rotates the camera around character's current position based on axis input.
    // PS4 - Right Analog Stick
    void updateCamRotation(Vector3 characterPosition)
    {

        // Set speed of rotation
        float rotationSpeed = 2;

        // Obtain Axes input.
        float rotateHorizontal = Input.GetAxis("RightStickX");
        float rotateVertical = Input.GetAxis("RightStickY");

        // Rotate camera about the character's current position.
        gameObject.transform.RotateAround(characterPosition, Vector3.up, rotateHorizontal * rotationSpeed);
        gameObject.transform.RotateAround(characterPosition, transform.right, rotateVertical * rotationSpeed);
    }
}