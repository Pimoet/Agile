using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolders : MonoBehaviour
{
    public Abillity firstAbility;
    public Abillity secondAbility;
    float cooldownTime1;
    float cooldownTime2;
    float activeTime1;
    float activeTime2;

    enum AbilityState
    {
        ready,
        active,
        cooldown,
    }
    AbilityState state1 = AbilityState.ready;
    AbilityState state2 = AbilityState.ready;

    public KeyCode Ability1key;
    public KeyCode Ability2key;


    // Update is called once per frame
    void Update()
    {
        switch (state1)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(Ability1key))
                {
                    firstAbility.Activate(gameObject);
                    state1 = AbilityState.active;
                    activeTime1 = firstAbility.activeTime;
                }
                break;
            case AbilityState.active:
                if( activeTime1> 0 ) 
                {
                    activeTime1 -= Time.deltaTime;
                }
                else
                {
                    firstAbility.BeginCooldown(gameObject);
                    state1 = AbilityState.cooldown;
                    cooldownTime1 = firstAbility.cooldownTime; 
                }
                break;
            case AbilityState.cooldown:
                if (cooldownTime1 > 0)
                {
                    cooldownTime1 -= Time.deltaTime;
                }
                else
                {
                    state1 = AbilityState.ready;
                    
                }
                break;
        }

        switch (state2)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(Ability2key))
                {
                    secondAbility.Activate(gameObject);
                    state2 = AbilityState.active;
                    activeTime2 = secondAbility.activeTime;
                }
                break;
            case AbilityState.active:
                if (activeTime2 > 0)
                {
                    activeTime2 -= Time.deltaTime;
                }
                else
                {
                    secondAbility.BeginCooldown(gameObject);
                    state2 = AbilityState.cooldown;
                    cooldownTime2 = secondAbility.cooldownTime;
                }
                break;
            case AbilityState.cooldown:
                if (cooldownTime2 > 0)
                {
                    cooldownTime2 -= Time.deltaTime;
                }
                else
                {
                    state2 = AbilityState.ready;
                }
                break;
        }
    }
}
