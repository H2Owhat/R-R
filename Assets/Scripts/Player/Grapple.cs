using System.Collections;
using UnityEngine;
using Color = UnityEngine.Color;

public class Grapple : MonoBehaviour
{
    Rigidbody rb;
    LineRenderer lr;
    DistanceJoint2D dj;
    public LayerMask grappleLayer;
    public LayerMask hookLayer;
    public bool isGrappling;
    Vector3 mouseWorldPoint;
    public Health playerHealth;
    public int hpdamage = 1;
    public PauseMenu pauseMenu;
    public DeathScreen deathScreen;
    PlayerInputManager playerInputManager;
    public Color yarnColorValid;
    public Color yarnColorInvalid;
    public Color yarnColorGrapple;
    public bool isGrappleValid;
    public Transform grappleOrigin;
    public float maxGrappleRange = 20;
    Vector3 displacementToCursor;
    Vector3 grappleDir;
    RaycastHit2D hit;
    public GameObject cursor;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();
        dj = GetComponent<DistanceJoint2D>();
        playerInputManager = GetComponent<PlayerInputManager>();
        dj.enabled = false;
        lr.enabled = true;
        
    }


   

    // Update is called once per frame
     void Update()
    {
            lr.SetPosition(0, grappleOrigin.position);
        if(!isGrappling) {
            mouseWorldPoint = Camera.main.ScreenToWorldPoint(cursor.transform.position);
            displacementToCursor = mouseWorldPoint - grappleOrigin.position;
            grappleDir = displacementToCursor.normalized;
            hit = Physics2D.Raycast(grappleOrigin.position, grappleDir, Mathf.Min(displacementToCursor.magnitude, maxGrappleRange), grappleLayer);
            isGrappleValid = hit && (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground") || hit.collider.gameObject.layer == hookLayer);
        }
            

            if (isGrappleValid)
            {
                lr.startColor = yarnColorValid;
                lr.endColor = yarnColorValid;
                lr.SetPosition(1, hit.point);
            }
            else
            {
                lr.startColor = yarnColorInvalid;
                lr.endColor = yarnColorInvalid;
                lr.SetPosition(1, grappleOrigin.position + grappleDir * Mathf.Min(displacementToCursor.magnitude, maxGrappleRange));
            }

        if (playerInputManager.IsClicking && !pauseMenu.paused && !deathScreen.isDead && playerHealth.health > 1 && !isGrappling && isGrappleValid)
        {
                StartCoroutine(grappleDamage(hpdamage));

                isGrappling = true;
                lr.enabled = true;
                dj.enabled = true;
                dj.connectedAnchor = hit.point;
        }
        if(!playerInputManager.IsClicking)
        {
            isGrappling = false;
            dj.enabled = false;
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