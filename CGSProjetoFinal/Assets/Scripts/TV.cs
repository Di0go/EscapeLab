using UnityEngine;
using System.Collections;

public class TV : MonoBehaviour
{
    //vars
    public float loopWaitTime;
    public float numberWaitTime;

    public Material[] tvMats;

    public Material offTex;

    public GameObject capsule;

    private MeshRenderer tvMat;

    public Material onMat;
    public Material offMat;

    private bool flag;

    private void Start()
    {
        tvMat = GetComponent<MeshRenderer>();
        flag = true;
    }

    private void Update()
    {
        if (flag)
        {
            StartCoroutine(ChangeTV());
            flag = false;
        }
    }

    public IEnumerator ChangeTV()
    {
        yield return new WaitForSeconds(loopWaitTime);
        capsule.GetComponent<MeshRenderer>().material = onMat;

        for (int i = 0; i < tvMats.Length; i++)
        {
            tvMat.material = tvMats[i];
            yield return new WaitForSeconds(numberWaitTime);
        }

        tvMat.material = offTex;
        capsule.GetComponent<MeshRenderer>().material = offMat;
        flag = true;
    }
}
