using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManage : MonoBehaviour
{
    public TurretData standard;
    public TurretData missile;
    public TurretData laser;
    [SerializeField]
    private TurretData TurretSelect;
    public GameObject TurretSelectGo;
    public GameObject UpdateCanvas;
 
    private NodeData SelectNodeData;


    public Button Updatebutton;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()==false)//判断鼠标是否在UI上，如果是手机软件需要添加参数
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycastHit;
                bool isCollider=Physics.Raycast(ray,out raycastHit,1000, LayerMask.GetMask("Node"));//返回是否碰撞
                if (isCollider)
                {
                    SelectNodeData = raycastHit.collider.GetComponent<NodeData>();                     
                    if (SelectNodeData.turret==null)
                    {
                        if (MoneyManager.money >= TurretSelect.price)
                        {
                            MoneyManager.Instance.MinusMoney( TurretSelect.price);
                            MoneyManager.Instance. UpdateUI();
                            SelectNodeData.isUpdate = false;
                            SelectNodeData.CreateTurret(TurretSelect);
                           
                        }
                        else
                        {
                            MoneyManager.Instance.LockMoney();
                        }
                    }
                    else
                    {
                        Debug.Log(5);
                        if (TurretSelectGo == SelectNodeData.turret&&UpdateCanvas.activeInHierarchy )
                        { 
                            StopCoroutine("Hiden");
                            UpdateCanvas.SetActive(false);
                            Debug.Log(6);
                        }
                        else
                            Show(SelectNodeData.transform.position, SelectNodeData.isUpdate);

                        TurretSelectGo = SelectNodeData.turret;
                    }
                }
            }
        }
    }

    public void OnStandardSelected(bool isOn)
    {
        if (isOn)
        {
            TurretSelect = standard;
        }
    }
    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            TurretSelect =missile;
        }
    }
    public void OnLaserSelected(bool isOn)
    {
        if (isOn)
        {
            TurretSelect = laser;
        }
    }
    void Show(Vector3 pos,bool isUpdate=false)
    {
        UpdateCanvas.SetActive( true);
        Updatebutton.interactable = !isUpdate;
        UpdateCanvas.transform.position = pos+new Vector3(0,5,0);
        StartCoroutine("Hiden");
    }
     IEnumerator Hiden()
    {
        yield return new WaitForSeconds(1.5f); 
        UpdateCanvas.SetActive(false);
    }
    public void OnUpDateButton()
    {
        if (MoneyManager.money > SelectNodeData.turretData.UpdatePrice)
        {
            MoneyManager.Instance.MinusMoney(SelectNodeData.turretData.UpdatePrice);
            SelectNodeData.UpdateTurret();
        }
        else
        {
            MoneyManager.Instance.LockMoney();
        }
    }
    public void OnRetreatButton()
    {
        if (SelectNodeData.isUpdate)
        {
            MoneyManager.Instance.AddMoney(SelectNodeData.turretData.UpdatePrice);
            Debug.Log(7);
        }
        else
        {
            MoneyManager.Instance.AddMoney(SelectNodeData.turretData.price);
            Debug.Log(8);
        }

        SelectNodeData.DestroyTurret();
    }
}
