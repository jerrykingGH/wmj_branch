using BM;
using ET;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class GSLogo : MonoBehaviour
{
    public GSProgramInit ProgramInit_Script;

    // ������
    private System.Net.NetworkInformation.Ping ping;
    private System.Net.NetworkInformation.PingReply pr;
    private bool CheckNetIsOn = false;
    private float CheckNetWaitTime = 3.0f;
    private float CheckNetCurrentTime = 0f;
    public bool NetActive = false;
    public bool CheckNetComplete = false;

    // Logo�������
    public bool CheckLogoAnim = false;

    void Start()
    {
        Debug.LogWarning("�� ���� 1 ��ʼ�� 1.����Logo����; 2.������Starting��Դ; 3.ǰ��������󣬴���Starting����");
        this.CheckNetState();        
    }

    void Update()
    {
        // ��������Ƿ�����
        if (this.CheckNetIsOn)
        {
            if (pr.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                Debug.Log($"��ǰ������������...");
                this.CheckNetIsOn = false;
                this.NetActive = true;
                this.CheckNetComplete = true;
            }
            else
            {
                // ����Ӧ�����ӵȴ�ʱ��
                this.CheckNetCurrentTime += Time.deltaTime;
                // ���ڵȴ�ʱ�����޷����ӷ��������ж�Ϊ����������
                if (this.CheckNetCurrentTime>= CheckNetWaitTime)
                {
                    Debug.Log($"��ǰ����������...");
                    this.CheckNetIsOn = false;
                    this.NetActive = false;
                    this.CheckNetComplete = true;
                }                           
            }
        }
        // ���������ӽ���
        if (this.CheckNetComplete)
        {
            this.CheckNetComplete = false;

            GSSystemConfig.NetEnable = this.NetActive;

            this.CheckStartingStartingAsset();
        }

        // ���Logo�����Ƿ񲥷����
        if (this.CheckLogoAnim)
        {
            if (this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                this.CheckLogoAnim = false;
                this.CreateStartingScene();
                Destroy(this.gameObject);
                Debug.LogWarning("�� ���� 1����ɣ���");
            }                
        }
    }   


    // ����������ӣ��Ƿ��������������
    private void CheckNetState()
    {
        this.ping = new System.Net.NetworkInformation.Ping();
        try
        {
            this.pr = ping.Send($"124.70.94.18", 3000);
            this.CheckNetIsOn = true;
        }
        catch (System.Exception)
        {
            this.NetActive = false;
            this.CheckNetComplete = true;
        }        
    }

    // ���Starting�����Ƿ���Ҫ����
    private async void CheckStartingStartingAsset()
    {
        if (GSSystemConfig.NetEnable)
        {
            await this.UpdateStartingAsset();
        }
        // �����ȸ�����Ŀ¼
        AssetComponentConfig.HotfixPath = GSSystemConfig.GSFilelocation + "/../HotfixBundles/";
        AssetComponentConfig.DefaultBundlePackageName = "StartingScene";
        await AssetComponent.Initialize("StartingScene");

        this.CheckLogoAnim = true;
    }

    // ����Starting������Դ
    private async ETTask UpdateStartingAsset()
    {
        // ������Դ��������ַ
        AssetComponentConfig.BundleServerUrl = GSSystemConfig.GSBundlePathInServer;
        // �����ȸ�����Ŀ¼
        AssetComponentConfig.HotfixPath = GSSystemConfig.GSFilelocation + "/../HotfixBundles/";
        // ����Ĭ���ȸ�����
        AssetComponentConfig.DefaultBundlePackageName = "StartingScene";
        // �����ȸ����ֵ�;
        Dictionary<string, bool> updatePackageBundle = new Dictionary<string, bool>()
                {
                    {"StartingScene", false}
                };
        // ����ֵ��еİ����Ƿ���Ҫ����
        UpdateBundleDataInfo updateBundleDataInfo = await AssetComponent.CheckAllBundlePackageUpdate(updatePackageBundle);
        // ��Ҫ����
        if (updateBundleDataInfo.NeedUpdate)
        {
            // ����Starting����
            Debug.LogWarning("Strating��Ҫ���£���С��" + updateBundleDataInfo.NeedUpdateSize);
            await AssetComponent.DownLoadUpdate(updateBundleDataInfo);
        }
    }

    // ����Starting����
    private void CreateStartingScene()
    {
        GameObject StartingPrefab = AssetComponent.Load<GameObject>(out LoadHandler handler,BPath.UIStartingPath + "UIStarting.prefab");
        GameObject Starting = GameObject.Instantiate(StartingPrefab, this.gameObject.transform.parent);
        GSStarting GSStarting_Script = Starting.AddComponent<GSStarting>();
        GSStarting_Script.ProgramInit_Script = this.ProgramInit_Script;
        GSStarting_Script.loadHandler = handler;
    }
}
