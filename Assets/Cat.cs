using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BalancaORaboACadaDezSegundos());
    }

    private IEnumerator BalancaORaboACadaDezSegundos()
    {
        yield return new WaitForSeconds(1);
        while(true)
        {
            animator.SetBool("balanca",true);
            yield return new WaitForSeconds(0.1f);
            animator.SetBool("balanca",false);
            yield return new WaitForSeconds(10);
        }
    }
}
