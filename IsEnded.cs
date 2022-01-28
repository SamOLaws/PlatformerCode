using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore;
using UnityEngine.UI;

public class IsEnded : MonoBehaviour
{
    public LayerMask Paul;

    public MeshRenderer EndZeroOne, EndZeroTwo, EndZeroThree;
    public MeshRenderer EndOneOne, EndOneTwo;
    public MeshRenderer EndTwoOne, EndTwoTwo, EndTwoThree;
    public MeshRenderer EndThreeOne, EndThreeTwo, EndThreeThree;

    public SpriteRenderer Door;

    public Transform WhereDoor;

    public float checkRadius;
    public int numberOfBeers;
    public int TotalBeers = 15;

    private bool IsAbleToFinish = false;
    private bool IsVpBeerFound;
    private bool IsPaulDoneYet;


    // Start is called before the first frame update
    void Start()
    {
        numberOfBeers = 0;
    }

    // Update is called once per frame
    void Update()
    {
        IsPaulDoneYet = Physics2D.OverlapCircle(WhereDoor.position, checkRadius, Paul);

        if (IsPaulDoneYet && IsAbleToFinish)
        {
            SceneManager.LoadScene(2);
        }

        if (numberOfBeers == 12)
        {
            EndZeroOne.sortingLayerName = "Hidden";
            EndZeroTwo.sortingLayerName = "Hidden";
            EndZeroThree.sortingLayerName = "Hidden";

            EndOneOne.sortingLayerName = "Paul";
            EndOneTwo.sortingLayerName = "Paul";

        }
        else if(numberOfBeers != 12 && IsVpBeerFound)
        {
            EndZeroOne.sortingLayerName = "Hidden";
            EndZeroTwo.sortingLayerName = "Hidden";
            EndZeroThree.sortingLayerName = "Hidden";

            EndTwoOne.sortingLayerName = "Paul";
            EndTwoTwo.sortingLayerName = "Paul";
            EndTwoThree.sortingLayerName = "Paul";

            Door.sortingLayerName = "Background";

            IsAbleToFinish = true;
        }

        if(numberOfBeers == 12 && IsVpBeerFound)
        {
            EndZeroOne.sortingLayerName = "Hidden";
            EndZeroTwo.sortingLayerName = "Hidden";
            EndZeroThree.sortingLayerName = "Hidden";

            EndTwoOne.sortingLayerName = "Hidden";
            EndTwoTwo.sortingLayerName = "Hidden";
            EndTwoThree.sortingLayerName = "Hidden";

            EndOneOne.sortingLayerName = "Hidden";
            EndOneTwo.sortingLayerName = "Hidden";

            EndThreeOne.sortingLayerName = "Paul";
            EndThreeTwo.sortingLayerName = "Paul";
            EndThreeThree.sortingLayerName = "Paul";

            Door.sortingLayerName = "Background";

            IsAbleToFinish = true;
        }
    }

    public void IncrementBeers()
    {
        Debug.Log("I have reached this");
        numberOfBeers += 1;
    }

    public void FoundVPBeer()
    {
        IsVpBeerFound = true;
    }
}
