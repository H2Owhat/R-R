using UnityEngine;

public class normalAttack : MonoBehaviour
{
    private bool attacking = false;
    public bool violent = false;
    public attackTrigger aTrigger;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Attack") && !aTrigger.canHitCooldown)
        {
            Debug.Log("Attack Pressed");
            //Animation
            attacking = true;
            GetComponent<Animator>().SetBool("isAttacking", attacking);
            
            //Turning on damage variable
            violent = true;
        }
        if(Input.GetButtonUp("Attack"))
        {
            //Animation
            attacking = false;
            GetComponent<Animator>().SetBool("isAttacking", attacking);

            //Turning off damage variable
            violent = false;
        }
    }
}
