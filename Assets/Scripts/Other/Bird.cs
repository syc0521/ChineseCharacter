using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Bird : MonoBehaviour
{
    public Transform startTrans;
    public Transform endTrans;

    public Transform poolTrans;
    public Transform generateTrans;

    public float flyTime = 10f;
    public float flyInterval = 5f;
    public bool canDrink;
    private bool isFlying;

    private Renderer[] renderers;
    private Animator animator;


    private void Start()
    {
        isFlying = false;
        renderers = GetComponentsInChildren<Renderer>();
        animator = GetComponent<Animator>();
        GameObject.FindWithTag("SceneNode").GetComponent<SceneNode>().OnInitOverSceneEvent += () =>
        {
            InvokeRepeating("Determine", 0f, flyInterval);
        };

        Hide();
    }


    private void Determine()
    {
        if (isFlying) return;
        if (canDrink)
        {
            Drink();
        }
        else
        {
            FlyOnce();
        }
    }
    [ContextMenu("FlyOnce")]

    private void FlyOnce()
    {
        AkSoundEngine.PostEvent("Play_BirdFlying_Effect", gameObject);
        AkSoundEngine.PostEvent("Play_Crow_Effect", gameObject);
        DisClose();
        transform.forward = (endTrans.position - startTrans.position).normalized;
        isFlying = true;
        transform.DOMove(endTrans.position, flyTime).onComplete += () =>
        {
            isFlying = false;
            Hide();
            transform.position = startTrans.position;
        };
    }

    [ContextMenu("Drink")]
    private void Drink()
    {
        AkSoundEngine.PostEvent("Play_BirdFlying_Effect", gameObject);
        DisClose();
        transform.forward = (poolTrans.position - startTrans.position).normalized;
        isFlying=true;

        transform.DOMove(poolTrans.position, flyTime / 2).onComplete += () =>
        {
            ElementController.Instance.GenerateElementByID(23, generateTrans.position);
            animator.SetTrigger("Drink");
            AkSoundEngine.PostEvent("Play_Fire_Effect", gameObject);
            GetComponentInChildren<TextMeshPro>().gameObject.SetActive(false);
            DOVirtual.DelayedCall(3f, () =>
            {
                AkSoundEngine.PostEvent("Play_BirdFlying_Effect", gameObject);
                transform.forward = (endTrans.position - poolTrans.position).normalized;
                transform.DOMove(endTrans.position, flyTime / 2+2f).onComplete += () =>
                {
                    Hide();
                    transform.position = startTrans.position;
                    Destroy(gameObject);
                };
            });
        };
    }

    private void Hide()
    {
        foreach (var v in renderers)
        {
            v.enabled = false;
        }
    }

    private void DisClose()
    {
        foreach (var v in renderers)
        {
            v.enabled = true;
        }
    }

}
