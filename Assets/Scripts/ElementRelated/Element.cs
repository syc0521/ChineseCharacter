using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Element : MonoBehaviour
{
    public int ID { private set; get; }
    public string nameStr { private set; get; }
    public ElementType type { private set; get; }
    public bool isJian { private set; get; }

    public TextMeshPro textMeshPro;

    private Vector3 desSize;

    private Tweener tweener;

    public OnValueChangedEventListener<bool> beSelected;

    private void Start()
    {
        beSelected = new OnValueChangedEventListener<bool>();
        desSize = new Vector3(1.5f, 1.5f, 1.5f);
        tweener = transform.DOScale(desSize, 0.25f);
        tweener.SetAutoKill(false);
        tweener.Pause();
        tweener.PlayForward();

        beSelected.OnValueChangedEvent += newValue =>
          {
              if(newValue)
              {
                  GetComponent<FloatSelf>().enabled = false;
              }             
          };
    }

    public void DestroySelf()
    {
        tweener.OnStepComplete(() =>
        {
            Destroy(gameObject);
        });
        tweener.PlayBackwards();
    }

    public void SetID(int ID)
    {
        this.ID = ID;
    }

    public void SetName(string name)
    {
        this.nameStr = name;

        Debug.Log(textMeshPro);
        textMeshPro.SetText(this.nameStr);
    }

    public void SetType(ElementType type)
    {
        this.type = type;
    }

    public void SetIsJian(bool isJian)
    {
        this.isJian = isJian;
    }

    public void SetMaterial(Material mat)
    {
        GetComponent<Renderer>().material = mat;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("OutSide"))
        {
            GetComponent<FloatSelf>().enabled = true;
        }
    }
}
