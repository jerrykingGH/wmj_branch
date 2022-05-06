using UnityEngine;
using BM;

public class GSProgramInit: MonoBehaviour
{
    public GameObject Logo_MovieClip;
    public GameObject Starting_MovieClip;

    private void Start()
    {
        GameObject LogoPrefab = Resources.Load("LogoAnim/UILogo") as GameObject;
        this.Logo_MovieClip = GameObject.Instantiate(LogoPrefab,this.transform);

        GSLogo GSLogo_Script = this.Logo_MovieClip.AddComponent<GSLogo>();
        GSLogo_Script.ProgramInit_Script = this;
    }

    private void Update()
    {
        AssetComponent.Update();
    }
}
