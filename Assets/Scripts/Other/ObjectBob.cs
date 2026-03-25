using UnityEngine;

public class ObjectBob : MonoBehaviour
{
    [SerializeField] float BobAmount = .5f;
    [SerializeField] Vector2 originalPos;
    float dir = 1;
    float arb = 0;

    [Header("Speed that GameObject bobs at")]
    [SerializeField] float ArbChange = 2f;


    private float SinWave() {
        arb += ArbChange;
        return Mathf.Sin(Mathf.Deg2Rad * arb);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        originalPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate() {
        gameObject.transform.position = new Vector2(transform.position.x, originalPos.y + SinWave() * BobAmount);
    }
}
//