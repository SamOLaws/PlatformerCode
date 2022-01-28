using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Combat : MonoBehaviour
{
    public Animator animator;
    public Transform HitBox;
    public LayerMask Enemy;

    public float time = 1f;

    private bool Hit;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Hit = Physics2D.OverlapCapsule(HitBox.position, new Vector3(1f, 2f, 1f), CapsuleDirection2D.Vertical, HitBox.rotation.z, Enemy);

        if (Hit)
        {
            animator.SetTrigger("Death");
            while(time > 0)
            {
                time -= Time.time;
            }
            SceneManager.LoadScene(3);
        }
    }
}
