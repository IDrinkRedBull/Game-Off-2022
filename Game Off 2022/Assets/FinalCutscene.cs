using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCutscene : MonoBehaviour
{
    public GameObject blank ,cut1, cut2, cut3, cut4, cut5, blank2;
    public GameObject ui1;
    // Start is called before the first frame update
    void Start()
    {
        ui1.SetActive(false);
        StartCoroutine(cutscenes(blank, 8, false));

        StartCoroutine(cutscenes(cut1, 14, false));
        StartCoroutine(cutscenes(cut2, 14, true));

        StartCoroutine(cutscenes(cut2, 22, false));
        StartCoroutine(cutscenes(cut3, 22, true));

        StartCoroutine(cutscenes(cut3, 30, false));
        StartCoroutine(cutscenes(cut4, 30, true));

        StartCoroutine(cutscenes(cut4, 38, false));
        StartCoroutine(cutscenes(cut5, 38, true));

        StartCoroutine(cutscenes(cut5, 46, false));
        StartCoroutine(cutscenes(blank2, 46, true));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator cutscenes(GameObject z,float x, bool y)
    {
        yield return new WaitForSeconds(x);
        z.SetActive(y);
    }
}
