using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class GenerateHook : MonoBehaviour
{
    private GameObject _hookStem;
    private GameObject _hookBridge;
    private GameObject _hookClaw;
    
    [SerializeField] private float hookWidth = 0.5f;
    [SerializeField] private float hookStemHeight = 3f;
    [SerializeField] private float hookStemDepth = 0.5f;
    [SerializeField] private float hookBridgeLength = 2f;
    [SerializeField] private float hookBridgeHeight = 0.35f;
    [SerializeField] private float hookClawHeight = 1f;
    [SerializeField] private float hookClawDepth = 0.5f;

    private void Awake()
    {
        Startup();
    }

    // Start is called before the first frame update
    void Start()
    {
        Startup();
    }

    // Update is called once per frame
    void Update()
    {
        if (!EditorApplication.isPlaying)
        {
            if (_hookStem == null)
            {
                _hookStem = GameObject.CreatePrimitive(PrimitiveType.Cube);
                _hookStem.name = "HookStem";
                _hookStem.transform.parent = transform;
                _hookStem.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            
            _hookStem.transform.localScale = new Vector3(hookWidth*0.0254f, hookStemHeight*0.0254f, hookStemDepth*0.0254f);
            _hookStem.transform.localPosition = new Vector3(0, hookStemHeight*0.0254f * 0.5f, 0);

            if (_hookBridge == null)
            {
                _hookBridge = GameObject.CreatePrimitive(PrimitiveType.Cube);
                _hookBridge.name = "HookBridge";
                _hookBridge.transform.parent = transform;
                _hookBridge.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            
            _hookBridge.transform.localScale = new Vector3(hookWidth*0.0254f, hookBridgeHeight*0.0254f, hookBridgeLength*0.0254f);
            _hookBridge.transform.localPosition = new Vector3(0, (hookStemHeight*0.0254f) + (hookBridgeHeight*0.5f*0.0254f), (hookBridgeLength*0.0254f*0.5f)-(hookStemDepth*0.5f*0.0254f));

            if (_hookClaw == null)
            {
                _hookClaw = GameObject.CreatePrimitive(PrimitiveType.Cube);
                _hookClaw.name = "HookClaw";
                _hookClaw.transform.parent = transform;
                _hookClaw.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            
            _hookClaw.transform.localScale = new Vector3(hookWidth*0.0254f, hookClawHeight*0.0254f, hookClawDepth*0.0254f);
            _hookClaw.transform.localPosition = new Vector3(0, (hookStemHeight*0.0254f)-(hookClawHeight*0.0254f*0.5f), (hookBridgeLength*0.0254f) - (hookClawDepth*0.0254f*0.5f)-(hookStemDepth*0.5f*0.0254f));
        }
        else
        {
        }
    }

    private void Startup()
    {
        if (transform.Find("HookStem"))
        {
            _hookStem = transform.Find("HookStem").gameObject;
        }

        if (transform.Find("HookBridge"))
        {
            _hookBridge = transform.Find("HookBridge").gameObject;
        }

        if (transform.Find("HookClaw"))
        {
            _hookClaw = transform.Find("HookClaw").gameObject;
        }
    }
}
