using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    public static LevelChanger instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Fade()
    {
        animator.SetTrigger("Fade");
    }
    public void UnFade()
    {
        animator.SetTrigger("UnFade");
    }
}
