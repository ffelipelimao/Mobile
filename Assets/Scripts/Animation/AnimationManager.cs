using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimationSetup> animatorSetups;

    public enum AnimationType
    {
        RUN,
        IDLE,
        DEATH
    }

    public void Play(AnimationType type, float currentSpeedFactor = 1)
    {
        animatorSetups.ForEach(i =>
        {
            if (i.type == type)
            {
                animator.SetTrigger(i.trigger);
                animator.speed = i.speed * currentSpeedFactor;
            }
        });
    }
}

[System.Serializable]
public class AnimationSetup
{
    public AnimationManager.AnimationType type;
    public string trigger;
    public float speed = 1f;
}
