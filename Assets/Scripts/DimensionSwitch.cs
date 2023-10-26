using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DimensionSwitch : MonoBehaviour
{
    [SerializeField] private GameObject[] dimensions;
    [SerializeField] private float timeBetweenSwitch;
    [SerializeField] private TMP_Text countdown;

    private Animator animator;
    private int currentDimension = 0;
    private float time;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > timeBetweenSwitch)
        {
            animator.SetTrigger("DimensionSwitch");
            time = 0f;
        }

        countdown.text = Math.Round(timeBetweenSwitch - time, 2).ToString();
    }

    public void SwitchDimension()
    {
        currentDimension++;
        if (currentDimension > dimensions.Length-1)
            currentDimension = 0;

        dimensions[currentDimension].SetActive(true);

        for (int i = 0; i < dimensions.Length; i++)
            if(i != currentDimension) dimensions[i].SetActive(false);
    }
}
