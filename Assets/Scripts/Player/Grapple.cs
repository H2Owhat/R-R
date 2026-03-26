using System.Collections;
using System.Drawing;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    Rigidbody rb;
    LineRenderer lr;
    DistanceJoint2D dj;
    public LayerMask grappleLayer;
    public bool isGrappling;
    Vector3 point;
    public Health playerHealth;
    public int hpdamage = 1;
    public PauseMenu pauseMenu;
    public DeathScreen deathScreen;
    PlayerInputManager playerInputManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();
        dj = GetComponent<DistanceJoint2D>();
        playerInputManager = GetComponent<PlayerInputManager>();
        dj.enabled = false;
        lr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInputManager.IsClicking && !pauseMenu.paused && !deathScreen.isDead && playerHealth.health >1 && !isGrappling)
        {
             point =Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Physics2D.OverlapCircle(point,0.1f,grappleLayer))
            {
                StartCoroutine(grappleDamage(hpdamage));

                isGrappling = true;
                lr.enabled = true;
                lr.SetPosition(0,transform.position);
                lr.SetPosition(1, point);


                dj.enabled = true;
                dj.connectedAnchor = point;
            }
        }

        if (!playerInputManager.IsClicking)
        {
            isGrappling= false;
            lr.enabled = false;
            dj.enabled = false;
        }

        if(isGrappling)
        {
            lr.enabled = true;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, point);
        }
    }

    private IEnumerator grappleDamage(int amount)
    {
        Debug.Log("Player Took Damage From Using Grapple");
        playerHealth.TakeDamageHopps(amount);
        yield return new WaitForSeconds(1f);
    }

}

/*
 *             Debug.Log("Player Took Damage");
 *             playerHealth.takeDamage(damage);
 */