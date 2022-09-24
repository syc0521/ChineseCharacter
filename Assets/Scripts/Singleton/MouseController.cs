using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseController : Singleton<MouseController>
{
    private GameControls gameControls;

    private Transform cameraNodeTrans;
    [Header("旋转视角速度")]
    public float yRotateSpeed = 20f;

    private bool mouseRightDown;

    private Vector2 mouseDragVec;
    private GameObject lastMouseDragHitObj;

    //被选中物体落地标记点
    public GameObject selectNode;
    private float selectOffset = 4f;

    //标记当前元素
    private GameObject curElementObj;
    //标记当前交互机关
    private GameObject curOrganObj;
    private GameObject curSelectNode;

    private bool selecting;

    private GameObject curConvertObj;

    public delegate void OnMouseLeftCancelledDelegate(Element currentElement);
    public event OnMouseLeftCancelledDelegate OnMouseLeftCancelledEvent;


    public override void OnAwake()
    {
        lastMouseDragHitObj = null;
        cameraNodeTrans = null;
        gameControls = new GameControls();
    }

    private void Start()
    {
        mouseRightDown = false;
        selecting = false;
        gameControls.GamePlay.MouseLeft.performed += ctx =>
        {
            //当左键点击时发送射线检测是否碰到可交互元素，如果是则进行拾取操作
            Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out RaycastHit hit,Mathf.Infinity,LayerMask.GetMask("Default","Ground"));
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Element"))
                {
                    AkSoundEngine.PostEvent("Play_PickUp_Effect", gameObject);
                    curElementObj = hit.collider.gameObject;
                    curElementObj.GetComponent<Element>().beSelected.Value = true;
                    if (GameController.Instance.isTutorial)
                    {
                        OutlineController.Instance?.SetOutline(curElementObj.GetComponent<Element>().ID);
                    }
                    curSelectNode = Instantiate(selectNode, curElementObj.transform.position, Quaternion.identity);                   
                    curElementObj.transform.parent = curSelectNode.transform;
                    curElementObj.GetComponent<Rigidbody>().useGravity = false;
                    curElementObj.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    curElementObj.GetComponent<Collider>().enabled = false;
                    curElementObj.transform.localPosition += new Vector3(0f, selectOffset, 0f);
                    selecting = true;
                }
                else if (hit.collider.gameObject.CompareTag("HiddenElement"))
                {
                    var hiddenElement = hit.collider.gameObject.GetComponent<HiddenElement>();
                    hiddenElement.Disclose();
                }
                Debug.Log(hit.collider.gameObject);
            }
            else
            {
                Debug.Log("NULL");
            }
        };

        gameControls.GamePlay.MouseLeft.canceled += ctx =>
        {
            if (curElementObj != null)
            {
                AkSoundEngine.PostEvent("Play_PickUp_Effect", gameObject);
                curElementObj.GetComponent<Element>().beSelected.Value = false;
                if (curOrganObj != null)
                {
                    //检测当前元素和机关是否匹配，匹配则交互，否则丢弃元素
                    if (ElementController.Instance.ElementMatchCheck(curElementObj.GetComponent<Element>(), curOrganObj.GetComponent<BaseOrgan>()))
                    {
                        curOrganObj.GetComponent<BaseOrgan>().Work(curElementObj.GetComponent<Element>().ID);
                        if (GameController.Instance.isTutorial)
                        {
                            OutlineController.Instance?.SetNormal(curElementObj.GetComponent<Element>().ID);
                        }
                        EffectController.Instance.PlayOneShot("ElementUsed", curElementObj.transform.position, obj =>
                        {
                            obj.GetComponent<ElementUsedEffect>().Init(curElementObj.GetComponent<Element>().nameStr);
                        });
                        curElementObj.GetComponent<Element>().DestroySelf();
                        if (curOrganObj.TryGetComponent<Shake>(out Shake tempShake))
                        {
                            tempShake.canShake = false;
                        }
                    }
                    else
                    {
                        curElementObj.GetComponent<Rigidbody>().useGravity = true;
                        curElementObj.GetComponent<Collider>().enabled = true;
                        curElementObj.transform.parent = null;
                    }
                }
                else
                {
                    curElementObj.GetComponent<Rigidbody>().useGravity = true;
                    if (GameController.Instance.isTutorial)
                    {
                        OutlineController.Instance?.SetNormal(curElementObj.GetComponent<Element>().ID);
                    }
                    curElementObj.GetComponent<Collider>().enabled = true;
                    curElementObj.transform.parent = null;
                }
                OnMouseLeftCancelledEvent?.Invoke(curElementObj.GetComponent<Element>());
            }
            if (curSelectNode != null)
                Destroy(curSelectNode);
            curElementObj = null;
            curOrganObj = null;
            selecting = false;
        };

        gameControls.GamePlay.MouseRight.performed += ctx =>
        {
            mouseRightDown = true;
        };

        gameControls.GamePlay.MouseRight.canceled += ctx =>
        {
            mouseRightDown = false;
            mouseDragVec = Vector2.zero;
        };

        gameControls.GamePlay.MouseDrag.performed += ctx =>
        {
            Vector2 dragVec = ctx.ReadValue<Vector2>();
            mouseDragVec = dragVec;

            if (selecting)
            {
                //如果已经选中元素则再鼠标移动时发射射线检测碰撞点，确保放下元素是落在正确的位置，以及标记可交互的当前机关
                Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Ground","Water"));
                Vector3 finalMouseScreenPos = Mouse.current.position.ReadValue();
                if (hit.collider != null)
                {
                    if (lastMouseDragHitObj != null && lastMouseDragHitObj.CompareTag("ElementMachine"))
                        lastMouseDragHitObj.GetComponent<RangeChecker>().SetInRange(false);

                    var hitPointScreenPos = Camera.main.WorldToScreenPoint(hit.point);
                    finalMouseScreenPos.z = hitPointScreenPos.z;

                    if (hit.collider.gameObject.CompareTag("Organ"))
                    {
                        curOrganObj = hit.collider.gameObject;
                    }
                    else
                    {
                        curOrganObj = null;
                    }

                    if (hit.collider.gameObject.CompareTag("ElementMachine"))
                    {
                        hit.collider.gameObject.GetComponent<RangeChecker>().SetInRange(true);
                    }
                    lastMouseDragHitObj = hit.collider.gameObject;
                }
                else
                {
                    var selectNodeScreenPos = Camera.main.WorldToScreenPoint(selectNode.transform.position);
                    finalMouseScreenPos.z = selectNodeScreenPos.z;
                    curOrganObj = null;
                    if (lastMouseDragHitObj != null && lastMouseDragHitObj.CompareTag("ElementMachine"))
                        lastMouseDragHitObj.GetComponent<RangeChecker>().SetInRange(false);
                }
                var finalMouseWorldPos = Camera.main.ScreenToWorldPoint(finalMouseScreenPos);
                curSelectNode.transform.position = finalMouseWorldPos;
            }
            else
            {
                RaycastHit[] hit;
                hit = Physics.RaycastAll(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), Mathf.Infinity);

                int i = 0;
                for (i = 0; i < hit.Length; i++)
                {
                    var hitObj = hit[i];

                    if (hitObj.collider != null)
                    {
                        if (hitObj.collider.gameObject.TryGetComponent(out Shake tempShake))
                        {
                            tempShake.ShakeSelf();
                        }
                    }

                    if (hitObj.collider != null && hitObj.collider.gameObject.CompareTag("ConvertObj"))
                    {
                        curConvertObj = hitObj.collider.gameObject;
                        break;
                    }

                }
                if (i >= hit.Length)
                    curConvertObj = null;
            }
        };

        gameControls.GamePlay.MouseRoll.performed += ctx =>
        {
            Vector2 rollValue = ctx.ReadValue<Vector2>();
            //if (rollValue.magnitude > 0)
            //{
            //    RaycastHit hit;
            //    Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out hit);
            //    if (hit.collider != null && hit.collider.gameObject.tag == "Element")
            //    {
            //        Element element = hit.collider.gameObject.GetComponent<Element>();
            //        ElementController.Instance.ElementConvert(element);
            //    }
            //}
            if (rollValue.magnitude > 0)
            {
                if (curConvertObj != null)
                {
                    AkSoundEngine.PostEvent("Play_Translation_Effect", gameObject);
                    curConvertObj.GetComponent<ConvertElementObj>().Convert();
                }
            }
        };
    }

    private void Update()
    {
        if (mouseRightDown)
        {
            if (cameraNodeTrans == null) cameraNodeTrans = GameObject.FindWithTag("CameraNode").transform;
            //通过旋转相机节点以实现视角旋转
            float yEuler = cameraNodeTrans.rotation.eulerAngles.y;
            yEuler += mouseDragVec.x * yRotateSpeed * Time.deltaTime;
            var finalRotation = Quaternion.Euler(0f, yEuler, 0f);
            cameraNodeTrans.rotation = finalRotation;
        }
    }

    private void OnEnable()
    {
        if (gameControls == null) return;
        gameControls.Enable();
    }

    private void OnDisable()
    {
        if (gameControls == null) return;
        gameControls.Disable();
    }
}
