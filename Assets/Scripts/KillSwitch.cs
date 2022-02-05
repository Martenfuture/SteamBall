using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSwitch : MonoBehaviour
{
    public Vector3 LastCheckpoint;

    [SerializeField] private GameObject[] healthRenderers = new GameObject[0];
    [SerializeField] int newCheckpointDelay;

    private bool setCheckpoint;
    private bool isPlayerAlive = true;
    static float t = 0.0f;
    private void Start()
    {
        StartCoroutine(CheckpointCoroutine());
        GameEvents.killControl.onKillEnter += KillPlayer;
    }
    private void Update()
    {
        if (setCheckpoint && Vector3.Distance(LastCheckpoint, transform.position) >= 5f)
        {
            StartCoroutine(CheckpointCoroutine());
        }
        if (!isPlayerAlive)
        {
            shaderActivation();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Kill" && isPlayerAlive)
        {
            GameEvents.killControl.KillEnter();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Checkpoint")
        {
            LastCheckpoint = other.gameObject.transform.position;
        } else if (other.tag == "Kill" && isPlayerAlive)
        {
            GameEvents.killControl.KillEnter();
        }
    }

    void KillPlayer()
    {
        StartCoroutine(KillCoroutine());
    }

    IEnumerator KillCoroutine()
    {
        isPlayerAlive = false;
        GameEvents.puzzleButton.ToggleControls(false);
        yield return new WaitForSeconds(3);
        TeleportToCheckpoint();
        isPlayerAlive = true;
        t = 0.0f;
        GameEvents.puzzleButton.ToggleControls(true);
        foreach (GameObject objectDisolve in healthRenderers)
        {
            objectDisolve.GetComponent<Renderer>().material.SetFloat("Vector1_fe8ff95d24524161865dee8da3a4e0c9", 1);
        }
    }

    public void TeleportToCheckpoint ()
    {
        transform.position = LastCheckpoint + new Vector3(0, 1, 0);
    }

    IEnumerator CheckpointCoroutine()
    {
        setCheckpoint = false;
        LastCheckpoint = transform.position;
        yield return new WaitForSeconds(newCheckpointDelay);
        setCheckpoint = true;
    }

    private void shaderActivation()
    {
        float currentDissolveValue = Mathf.Lerp(1, 0, t);
        t += 0.4f * Time.deltaTime;
        foreach (GameObject objectDisolve in healthRenderers)
        {
            objectDisolve.GetComponent<Renderer>().material.SetFloat("Vector1_fe8ff95d24524161865dee8da3a4e0c9", currentDissolveValue);
        }
    }
}
