using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    // Start is called before the first frame update
    public float delayBetweenChildren = 1f;

    void Start()
    {
        GameObject parentObject = this.gameObject;
        //int numberOfRepeats = 3;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        StartCoroutine(DisableChildrenSequential());
        StartCoroutine(RepeatTheWork());
    }
    IEnumerator DisableChildrenSequential()
    {
        // Iterate through each child GameObject in the parent
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);

            yield return new WaitForSeconds(delayBetweenChildren); // Wait for the specified delay

            child.gameObject.SetActive(false); // Disable the child GameObject
        }
    }
    IEnumerator RepeatTheWork()
    {
        GameObject parentObject = this.gameObject;
        int index = 0;
        while (index <= parentObject.transform.childCount - 1)
        {
            Transform child = parentObject.transform.GetChild(index);
            child.gameObject.SetActive(true);

            yield return new WaitForSeconds(delayBetweenChildren); // Wait for the specified delay

            child.gameObject.SetActive(false); // Disable the child GameObje
                                               //StartCoroutine(DisableChildrenSequential());
            if (index == parentObject.transform.childCount - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }

        }
    }
    // Update is called once per frame
    void Update()
    {

   

    }


}

