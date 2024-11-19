using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

[ExecuteInEditMode]
public class GenerateDriveTrain : MonoBehaviour
{
    private GameObject _frontRail;
    private GameObject _backRail;
    private GameObject _leftRail;
    private GameObject _rightRail;
    private GameObject _driveTrain;
    private GameObject _frame;

    private GameObject _wheelChild;
    private GameObject _lfWheel;
    private GameObject _rfWheel;
    private GameObject _rrWheel;
    private GameObject _lrWheel;

    private GameObject _raycastChild;
    private GameObject _lf;
    private GameObject _rf;
    private GameObject _rr;
    private GameObject _lr;
    
    private Rigidbody _rb;
    
    [HideInInspector] public InputActionAsset inputAsset;
    
    private DriveController _driveController;
    
    private PlayerInput _playerInput;

    [Tooltip("In Inches")]
    [SerializeField] private float driveTrainWidth = 28;
    [Tooltip("In Inches")]
    [SerializeField] private float wheelWidth = 1.5f;
    [Tooltip("In Inches")]
    [SerializeField] private float wheelDiameter = 4;

    [SerializeField] private float drivetrainWeight = 60;

    [Tooltip("Max Drive Free Speed in ft/s")]
    [SerializeField] private float driveSpeed = 16;

    [Tooltip("Unitless acceleration force on the driveTrain")]
    [SerializeField] private float driveForce = 380;
    // Start is called before the first frame update

    void Awake()
    {
        if (EditorApplication.isPlaying) return;
        if (transform.Find("DriveTrain") == null) return;
        _driveTrain = transform.Find("DriveTrain").gameObject;

        if (transform.Find("DriveTrain").transform.Find("Frame") != null)
        {
            _frame = transform.Find("DriveTrain").transform.Find("Frame").gameObject;

            if (transform.Find("DriveTrain").transform.Find("Frame").transform.Find("FrontRail") != null)
            {
                _frontRail = transform.Find("DriveTrain").transform.Find("Frame").transform.Find("FrontRail")
                    .gameObject;
            }

            if (transform.Find("DriveTrain").transform.Find("Frame").transform.Find("BackRail") != null)
            {
                _backRail = transform.Find("DriveTrain").transform.Find("Frame").transform.Find("BackRail")
                    .gameObject;
            }

            if (transform.Find("DriveTrain").transform.Find("Frame").transform.Find("LeftRail") != null)
            {
                _leftRail = transform.Find("DriveTrain").transform.Find("Frame").transform.Find("LeftRail")
                    .gameObject;
            }

            if (transform.Find("DriveTrain").transform.Find("Frame").transform.Find("RightRail") != null)
            {
                _rightRail = transform.Find("DriveTrain").transform.Find("Frame").transform.Find("RightRail")
                    .gameObject;
            }
        }

        if (transform.Find("DriveTrain").transform.Find("Wheels") != null)
        {
            _wheelChild = transform.Find("DriveTrain").transform.Find("Wheels").gameObject;


            if (transform.Find("DriveTrain").transform.Find("Wheels").transform.Find("Lf"))
            {
                _lfWheel = transform.Find("DriveTrain").transform.Find("Wheels").transform.Find("Lf").gameObject;
            }

            if (transform.Find("DriveTrain").transform.Find("Wheels").transform.Find("Rf"))
            {
                _rfWheel = transform.Find("DriveTrain").transform.Find("Wheels").transform.Find("Rf").gameObject;
            }

            if (transform.Find("DriveTrain").transform.Find("Wheels").transform.Find("Lr"))
            {
                _lrWheel = transform.Find("DriveTrain").transform.Find("Wheels").transform.Find("Lr").gameObject;
            }

            if (transform.Find("DriveTrain").transform.Find("Wheels").transform.Find("Rr"))
            {
                _rrWheel = transform.Find("DriveTrain").transform.Find("Wheels").transform.Find("Rr").gameObject;
            }
        }

        if (transform.Find("DriveTrain").transform.Find("Raycast") != null)
        {
            _raycastChild = transform.Find("DriveTrain").transform.Find("Raycast").gameObject;


            if (transform.Find("DriveTrain").transform.Find("Raycast").transform.Find("Lf"))
            {
                _lf = transform.Find("DriveTrain").transform.Find("Raycast").transform.Find("Lf").gameObject;
            }

            if (transform.Find("DriveTrain").transform.Find("Raycast").transform.Find("Rf"))
            {
                _rf = transform.Find("DriveTrain").transform.Find("Raycast").transform.Find("Rf").gameObject;
            }

            if (transform.Find("DriveTrain").transform.Find("Raycast").transform.Find("Lr"))
            {
                _lr = transform.Find("DriveTrain").transform.Find("Raycast").transform.Find("Lr").gameObject;
            }

            if (transform.Find("DriveTrain").transform.Find("Raycast").transform.Find("Rr"))
            {
                _rr = transform.Find("DriveTrain").transform.Find("Raycast").transform.Find("Rr").gameObject;
            }
        }

        if (gameObject.GetComponent<Rigidbody>() != null)
        {
            _rb = gameObject.GetComponent<Rigidbody>();
        }

        if (gameObject.GetComponent<DriveController>() != null)
        {
            _driveController = gameObject.GetComponent<DriveController>();
        }

        if (gameObject.GetComponent<PlayerInput>() != null)
        {
            _playerInput = gameObject.GetComponent<PlayerInput>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (EditorApplication.isPlaying) return;
        //create frame model
        if (_driveTrain == null)
        {
            _driveTrain = new GameObject("DriveTrain");
            _driveTrain.transform.parent = transform;
        }

        if (_frame == null)
        {
            _frame = new GameObject("Frame");
            _frame.transform.parent = _driveTrain.transform;
        }

        if (_frontRail == null)
        {
            _frontRail = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _frontRail.name = "FrontRail";
            _frontRail.transform.parent = _frame.transform;
        }

        if (_backRail == null)
        {
            _backRail = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _backRail.name = "BackRail";
            _backRail.transform.parent = _frame.transform;
        }

        if (_leftRail == null)
        {
            _leftRail = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _leftRail.name = "LeftRail";
            _leftRail.transform.parent = _frame.transform;
        }

        if (_rightRail == null)
        {
            _rightRail = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _rightRail.name = "RightRail";
            _rightRail.transform.parent = _frame.transform;
        }

        _frontRail.transform.localPosition = new Vector3(0, 0, driveTrainWidth / 2.05f * 0.0254f);
        _backRail.transform.localPosition = new Vector3(0, 0, -driveTrainWidth / 2.05f * 0.0254f);
        _leftRail.transform.localPosition = new Vector3(-driveTrainWidth / 2.05f * 0.0254f, 0, 0);
        _rightRail.transform.localPosition = new Vector3(driveTrainWidth / 2.05f * 0.0254f, 0, 0);

        _frontRail.transform.localScale = new Vector3(driveTrainWidth * 0.0254f, 0.0254f * 2, 0.0254f);
        _backRail.transform.localScale = new Vector3(driveTrainWidth * 0.0254f, 0.0254f * 2, 0.0254f);
        _leftRail.transform.localScale = new Vector3(0.0254f, 0.0254f * 2, driveTrainWidth * 0.0254f);
        _rightRail.transform.localScale = new Vector3(0.0254f, 0.0254f * 2, driveTrainWidth * 0.0254f);

        //create wheels
        if (_wheelChild == null)
        {
            _wheelChild = new GameObject("Wheels");
            _wheelChild.transform.parent = _driveTrain.transform;
        }

        WheelCollider leftFrontWheel;
        if (_lfWheel == null)
        {
            _lfWheel = new GameObject();
            _lfWheel.name = "Lf";
            _lfWheel.transform.parent = _wheelChild.transform;
            leftFrontWheel = _lfWheel.AddComponent<WheelCollider>();
            _lfWheel.AddComponent<SwerveWheel>();
        }
        else
        {
            leftFrontWheel = _lfWheel.GetComponent<WheelCollider>();
        }

        _lfWheel.transform.localRotation = Quaternion.Euler(0, 0, 90);
        _lfWheel.transform.localScale =
            new Vector3(wheelDiameter * 0.0254f, wheelWidth / 2 * 0.0254f, wheelDiameter * 0.0254f);
        _lfWheel.transform.localPosition =
            new Vector3(-driveTrainWidth / 2 * 0.0254f + wheelDiameter / 2 * 0.0254f + 1.5f * 0.0254f, -0.0254f * 1,
                driveTrainWidth / 2 * 0.0254f - wheelDiameter / 2 * 0.0254f - 1.5f * 0.0254f);
        leftFrontWheel.radius = wheelDiameter / wheelWidth;

        WheelCollider rightFrontWheel;
        if (_rfWheel == null)
        {
            _rfWheel = new GameObject();
            _rfWheel.name = "Rf";
            _rfWheel.transform.parent = _wheelChild.transform;
            rightFrontWheel = _rfWheel.AddComponent<WheelCollider>();
            _rfWheel.AddComponent<SwerveWheel>();
        }
        else
        {
            rightFrontWheel = _rfWheel.GetComponent<WheelCollider>();
        }

        _rfWheel.transform.localRotation = Quaternion.Euler(0, 0, 90);
        _rfWheel.transform.localScale =
            new Vector3(wheelDiameter * 0.0254f, wheelWidth / 2 * 0.0254f, wheelDiameter * 0.0254f);
        _rfWheel.transform.localPosition =
            new Vector3(driveTrainWidth / 2 * 0.0254f - wheelDiameter / 2 * 0.0254f - 1.5f * 0.0254f, -0.0254f * 1,
                driveTrainWidth / 2 * 0.0254f - wheelDiameter / 2 * 0.0254f - 1.5f * 0.0254f);
        rightFrontWheel.radius = wheelDiameter / wheelWidth;

        WheelCollider leftRearWheel;
        if (_lrWheel == null)
        {
            _lrWheel = new GameObject();
            _lrWheel.name = "Lr";
            _lrWheel.transform.parent = _wheelChild.transform;
            leftRearWheel = _lrWheel.AddComponent<WheelCollider>();
            _lrWheel.AddComponent<SwerveWheel>();
        }
        else
        {
            leftRearWheel = _lrWheel.GetComponent<WheelCollider>();
        }

        _lrWheel.transform.localRotation = Quaternion.Euler(0, 0, 90);
        _lrWheel.transform.localScale =
            new Vector3(wheelDiameter * 0.0254f, wheelWidth / 2 * 0.0254f, wheelDiameter * 0.0254f);
        _lrWheel.transform.localPosition =
            new Vector3(-driveTrainWidth / 2 * 0.0254f + wheelDiameter / 2 * 0.0254f + 1.5f * 0.0254f, -0.0254f * 1,
                -driveTrainWidth / 2 * 0.0254f + wheelDiameter / 2 * 0.0254f + 1.5f * 0.0254f);
        leftRearWheel.radius = wheelDiameter / wheelWidth;

        WheelCollider rightRearWheel;
        if (_rrWheel == null)
        {
            _rrWheel = new GameObject();
            _rrWheel.name = "Rr";
            _rrWheel.transform.parent = _wheelChild.transform;
            rightRearWheel = _rrWheel.AddComponent<WheelCollider>();
            _rrWheel.AddComponent<SwerveWheel>();
        }
        else
        {
            rightRearWheel = _rrWheel.GetComponent<WheelCollider>();
        }

        _rrWheel.transform.localRotation = Quaternion.Euler(0, 0, 90);
        _rrWheel.transform.localScale =
            new Vector3(wheelDiameter * 0.0254f, wheelWidth / 2 * 0.0254f, wheelDiameter * 0.0254f);
        _rrWheel.transform.localPosition =
            new Vector3(driveTrainWidth / 2 * 0.0254f - wheelDiameter / 2 * 0.0254f - 1.5f * 0.0254f, -0.0254f * 1,
                -driveTrainWidth / 2 * 0.0254f + wheelDiameter / 2 * 0.0254f + 1.5f * 0.0254f);
        rightRearWheel.radius = wheelDiameter / wheelWidth;

        //create raycastObjects
        if (_raycastChild == null)
        {
            _raycastChild = new GameObject("Raycast");
            _raycastChild.transform.parent = _driveTrain.transform;
        }

        
        if (_lf == null)
        {
            _lf = new GameObject("Lf");
            _lf.transform.parent = _raycastChild.transform;
            var lfModel = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            DestroyImmediate(lfModel.GetComponent<CapsuleCollider>());
            lfModel.name = "LfModel";
            lfModel.transform.parent = _lf.transform;
            lfModel.transform.localPosition = new Vector3(0, 0, 0);
            lfModel.transform.localRotation = Quaternion.Euler(0, 0, 90);
        }

        _lf.transform.localPosition = new Vector3(
            -driveTrainWidth / 2 * 0.0254f + wheelDiameter / 2 * 0.0254f + 1.5f * 0.0254f,
            -0.0254f * 1 + (-0.0254f * wheelDiameter / 2) + (wheelDiameter * 0.0254f * 0.1f),
            driveTrainWidth / 2 * 0.0254f - wheelDiameter / 2 * 0.0254f - 1.5f * 0.0254f);
        _lf.transform.localScale = new Vector3(wheelWidth / 2 * 0.0254f, wheelDiameter * 0.0254f, wheelDiameter * 0.0254f);
        _lf.transform.Find("LfModel").transform.localPosition = new Vector3(0,
            (0.0254f * 1 - (0.0254f * -wheelDiameter / 2) - (wheelDiameter * 0.0254f * 0.1f) -0.0254f * 1)/(wheelDiameter * 0.0254f), 0);

        if (_rf == null)
        {
            _rf = new GameObject("Rf");
            _rf.transform.parent = _raycastChild.transform;
            var rfModel = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            DestroyImmediate(rfModel.GetComponent<CapsuleCollider>());
            rfModel.name = "RfModel";
            rfModel.transform.parent = _rf.transform;
            rfModel.transform.localPosition = new Vector3(0, 0, 0);
            rfModel.transform.localRotation = Quaternion.Euler(0, 0, 90);
        }

        _rf.transform.localPosition = new Vector3(
            driveTrainWidth / 2 * 0.0254f - wheelDiameter / 2 * 0.0254f - 1.5f * 0.0254f,
            -0.0254f * 1 + (-0.0254f * wheelDiameter / 2) + (wheelDiameter * 0.0254f * 0.1f),
            driveTrainWidth / 2 * 0.0254f - wheelDiameter / 2 * 0.0254f - 1.5f * 0.0254f);
        _rf.transform.localScale = new Vector3(wheelWidth / 2 * 0.0254f, wheelDiameter * 0.0254f, wheelDiameter * 0.0254f);
        _rf.transform.Find("RfModel").transform.localPosition = new Vector3(0,
            (0.0254f * 1 - (-0.0254f * wheelDiameter / 2) - (wheelDiameter * 0.0254f * 0.1f) -0.0254f * 1)/(wheelDiameter * 0.0254f), 0);

        if (_lr == null)
        {
            _lr = new GameObject("Lr");
            _lr.transform.parent = _raycastChild.transform;
            var lrModel = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            DestroyImmediate(lrModel.GetComponent<CapsuleCollider>());
            lrModel.name = "LrModel";
            lrModel.transform.parent = _lr.transform;
            lrModel.transform.localPosition = new Vector3(0, 0, 0);
            lrModel.transform.localRotation = Quaternion.Euler(0, 0, 90);
        }

        _lr.transform.localPosition = new Vector3(
            -driveTrainWidth / 2 * 0.0254f + wheelDiameter / 2 * 0.0254f + 1.5f * 0.0254f,
            -0.0254f * 1 + (-0.0254f * wheelDiameter / 2) + (wheelDiameter * 0.0254f * 0.1f),
            -driveTrainWidth / 2 * 0.0254f + wheelDiameter / 2 * 0.0254f + 1.5f * 0.0254f);
        _lr.transform.localScale = new Vector3(wheelWidth / 2 * 0.0254f, wheelDiameter * 0.0254f, wheelDiameter * 0.0254f);
        _lr.transform.Find("LrModel").transform.localPosition = new Vector3(0,
            (0.0254f * 1 - (-0.0254f * wheelDiameter / 2) - (wheelDiameter * 0.0254f * 0.1f) -0.0254f * 1)/(wheelDiameter * 0.0254f), 0);

        if (_rr == null)
        {
            _rr = new GameObject("Rr");
            _rr.transform.parent = _raycastChild.transform;
            var rrModel = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            DestroyImmediate(rrModel.GetComponent<CapsuleCollider>());
            rrModel.name = "RrModel";
            rrModel.transform.parent = _rr.transform;
            rrModel.transform.localPosition = new Vector3(0, 0, 0);
            rrModel.transform.localRotation = Quaternion.Euler(0, 0, 90);
        }

        _rr.transform.localPosition = new Vector3(
            driveTrainWidth / 2 * 0.0254f - wheelDiameter / 2 * 0.0254f - 1.5f * 0.0254f,
            -0.0254f * 1 + (-0.0254f * wheelDiameter / 2) + (wheelDiameter * 0.0254f * 0.1f),
            -driveTrainWidth / 2 * 0.0254f + wheelDiameter / 2 * 0.0254f + 1.5f * 0.0254f);
        _rr.transform.localScale = new Vector3(wheelWidth / 2 * 0.0254f, wheelDiameter * 0.0254f, wheelDiameter * 0.0254f);
        _rr.transform.Find("RrModel").transform.localPosition = new Vector3(0,
            (0.0254f * 1 - (-0.0254f * wheelDiameter / 2) - (wheelDiameter * 0.0254f * 0.1f) -0.0254f * 1)/(wheelDiameter * 0.0254f), 0);

        //setup Rb drivecontroller, and player input.

        if (_rb == null)
        {
            _rb = gameObject.AddComponent<Rigidbody>();
            _rb.interpolation = RigidbodyInterpolation.Interpolate;
            _rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            _rb.useGravity = true;
            _rb.drag = 3;
            _rb.angularDrag = 3;
        }

        _rb.mass = drivetrainWeight;


        if (_driveController == null)
        {
            _driveController = gameObject.AddComponent<DriveController>();
            _driveController.driveTrainParent = _driveTrain;
            _driveController.driveTrain = global::DriveTrain.Swerve;
            _driveController.rayCastDistance = 0.25f;
        }

        _driveController.maxSpeed = driveSpeed;

        _driveController.accelerationSpeed = driveForce;

        if (_playerInput == null)
        {
            _playerInput = gameObject.AddComponent<PlayerInput>();
            _playerInput.actions = inputAsset;
            _playerInput.defaultControlScheme = "Controls 1";
            _playerInput.neverAutoSwitchControlSchemes = true;
            _playerInput.notificationBehavior = PlayerNotifications.InvokeUnityEvents;
        }
    }
}
