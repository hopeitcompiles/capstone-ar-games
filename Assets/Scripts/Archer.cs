using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Archer : MonoBehaviour
{
    Animator animator;
    public event Action OnDancing;
    public event Action OnGreeting;
    private string greetingTrigger="greet";
    private bool dancing=false;
    private string[] idleAnimationTriggers;
    [SerializeField] private TextMeshProUGUI danceText;
    void Start()
    {
        danceText.text = "Dance";
        idleAnimationTriggers = new string[] { "dwarf","crazy","fall","hand","loser","reject", "threatening" };
        animator = GetComponent<Animator>();
        OnDancing += Archer_OnDancing;
        OnGreeting += Archer_OnGreeting;
        InvokeRepeating("RandomIdleAnimation", 10,10);
    }

    private void Archer_OnGreeting()
    {
        animator.SetTrigger(greetingTrigger);
    }

    private void Archer_OnDancing()
    {
        dancing = !dancing;
        danceText.text = dancing ? "Stop" : "Dance";
        animator.SetBool("dancing", dancing);
    }

    public void Dancing()
    {
        OnDancing?.Invoke();
        Debug.Log("OnDancing");
    }
    public void Greeting()
    {
        OnGreeting?.Invoke();
        Debug.Log("OnGreeting");
    }

    public void RandomIdleAnimation()
    {
        if (!dancing)
        {
            int animation = UnityEngine.Random.Range(0, idleAnimationTriggers.Length);
            animator.SetTrigger(idleAnimationTriggers[animation]);
            Debug.Log(idleAnimationTriggers[animation]);
        }
    }
}
