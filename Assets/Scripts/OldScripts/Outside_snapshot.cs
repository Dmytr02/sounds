using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Outside_snapshot : MonoBehaviour
{
    public bool snapshotActivated = false;
    public FMOD.Studio.EventInstance Outside;
    
    public EventReference outsideSnapshot;

    private void Start()
    {
        Outside = FMODUnity.RuntimeManager.CreateInstance(outsideSnapshot);
    }

    private void OnDestroy()
    {
        Outside.release();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Outside");
            Outside.start();
            snapshotActivated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Outside.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            snapshotActivated = false;
        }
    }
}
