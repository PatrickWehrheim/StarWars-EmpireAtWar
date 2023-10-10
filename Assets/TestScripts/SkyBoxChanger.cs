using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxChanger : MonoBehaviour
{
    [SerializeField] private Material _skybox;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = _skybox;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
