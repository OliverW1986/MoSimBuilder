using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RollerBarIntake : MonoBehaviour
{
    [Tooltip("hinge Joint to spin when using button specefied in player input")]
    public HingeJoint Roller;
    [Tooltip("target velocity in RPM of the hinge")]
    public float speed;
    private JointMotor jointMotor;
    private bool onIntake;
    // Start is called before the first frame update
    void Start()
    {
        jointMotor = new JointMotor();

        jointMotor.force = 5000;
        jointMotor.freeSpin = true;

        Roller.useMotor = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (onIntake && GameManager.canRobotMove)
        {
            jointMotor.targetVelocity = speed;
        } else
        {
            jointMotor.targetVelocity = 0;
        }

        Roller.motor = jointMotor;
    }

    public void OnIntake(InputAction.CallbackContext ctx)
    {
        onIntake = ctx.action.triggered;
    }
}
