using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HoodAlignToTarget : MonoBehaviour
{
    [Tooltip("Hinge Joint to rotate around")]
    public HingeJoint hood;
    [Tooltip("Object to reference when aiming. Typically the ShootSpawn")]
    public Transform indicator;
    private JointSpring hSpring;
    private GameObject target;
    [Tooltip("Angle to adjust to when shooting low. Dont forget to add to player input")]
    [SerializeField] private float LowAnlge;
    [Tooltip("Location for the hood to target to")]
    [SerializeField] private Vector3 TargetPose;
    [Tooltip("Rotation offset in deg for the hood")]
    [SerializeField] private float RotationOffset;
    [Tooltip("whether or not SWM should work")]
    [SerializeField] private bool SWM;
    private bool onLow;
    private Rigidbody rb;
    [HideInInspector] public bool overidePosition;
    [HideInInspector] public float OveridenPosition;
    // Start is called before the first frame update
    void Start()
    {
        OveridenPosition = 0;
        overidePosition = false;
        rb = GetComponent<Rigidbody>();
        hSpring = new JointSpring();
        target = new GameObject();
        target.tag = "ignore";
        target.name = "AimTarget";
        target.transform.SetParent(GameObject.Find("Field").transform);
        target.transform.position = TargetPose;
        if (!SWM)
        {
            hSpring.spring = 9000;
            hSpring.damper = 900;
        } else
        {
            hSpring.spring = 90000000;
            hSpring.damper = 8000000;
        }


        if (hood.connectedBody == null)
        {
            hood.connectedBody = hood.transform.parent.GetComponentInParent<Rigidbody>().transform.gameObject.GetComponent<Rigidbody>();
            hood.axis = new Vector3(1, 0, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (overidePosition)
        {
            hSpring.spring = 90000000;
            hSpring.damper = 7500000;
        }
        else
        {
            {
                hSpring.spring = 9000;
                hSpring.damper = 900;
            }
        }

        if (GameManager.canRobotMove)
        {
            if (overidePosition)
            {
                float Target;
                Target = OveridenPosition;
                if (Mathf.Abs(Target) > 180)
                {
                    Target -= 360 * (Target / Mathf.Abs(Target));
                }

                hSpring.targetPosition = Target;
                hood.useMotor = false;
                hood.useSpring = true;
                hood.spring = hSpring;
            } 
            else if (!onLow)
            {
                Quaternion targetShooterRotation;
                if (!SWM)
                {
                    targetShooterRotation = Quaternion.LookRotation(-indicator.position + target.transform.position, Vector3.up);
                }
                else
                {
                    targetShooterRotation = Quaternion.LookRotation(-indicator.position - rb.velocity + target.transform.position, Vector3.up);
                }

                float currentAngle = hood.transform.localEulerAngles.x + RotationOffset;

               

                if (Mathf.Abs(currentAngle) > 180)
                {
                    currentAngle -= 360 * (currentAngle / Mathf.Abs(currentAngle));
                }

                float Target = (targetShooterRotation.eulerAngles.x - currentAngle);

                if (Mathf.Abs(Target) > 180)
                {
                    Target -= 360 * (Target / Mathf.Abs(Target));
                }

                hSpring.targetPosition = Target;

                hood.useMotor = false;
                hood.useSpring = true;
                hood.spring = hSpring;
            } else
            {
                hSpring.targetPosition = LowAnlge;

                hood.useSpring = true;
                hood.useMotor = false;
                hood.spring = hSpring;
            }
        }
    }

    public void OnLow(InputAction.CallbackContext ctx)
    {
        onLow = ctx.action.triggered;
    }
}
