using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBeer : MonoBehaviour
{
    public Transform IsThereBeer;
    public LayerMask IAmBeer;
    public Collider2D VPsBeer;
    public GameObject Paul;
    public GameObject Terrain;

    // Update is called once per frame
    void Update()
    {
        Collider2D[] IFoundBeer = Physics2D.OverlapCapsuleAll(IsThereBeer.position, new Vector3(1.75f, 2f, 1f), CapsuleDirection2D.Vertical, IsThereBeer.rotation.z, IAmBeer);

        foreach (Collider2D Beer in IFoundBeer)
        {
            if(Beer == VPsBeer)
            {
                Terrain.GetComponent<FoundSecret>().ChangeTerrain();
                Paul.GetComponent<Player_movement>().Launch();
                Beer.GetComponent<bob_Script>().DestroyGameObject(true);
            }
            else
            {
                Beer.GetComponent<bob_Script>().DestroyGameObject(false);
            }
        }
    }
}
