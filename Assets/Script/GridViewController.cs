using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridViewController : BaseUIController
{
    private GameObject GridView;
    private List<DataBean> mList = new List<DataBean>();
    // Start is called before the first frame update
    void Start()
    {
        GridView = findObjectByPath("ScrollView/Viewport/Content");
        initData();
        refreshUI(mList);
    }

    private void initData()
    {
        mList.Add(new DataBean("Food/ª™∑Ú±˝", "ª™∑Ú±˝"));
        mList.Add(new DataBean("Food/ø…¿÷", "ø…¿÷"));
        mList.Add(new DataBean("Food/øß∑»", "øß∑»"));
        mList.Add(new DataBean("Food/ƒÃ¿“", "ƒÃ¿“"));
        mList.Add(new DataBean("Food/∫∫±§", "∫∫±§"));
        mList.Add(new DataBean("Food/’‰÷ÈƒÃ≤Ë", "’‰÷ÈƒÃ≤Ë"));
        mList.Add(new DataBean("Food/ÃÕ≤", "ÃÕ≤"));
    }


    private void refreshUI(List<DataBean> dataList)
    {
        if (dataList == null || dataList.Count == 0)
            return;
        //GridLayoutGroup gridLayout = GridView.GetComponent<GridLayoutGroup>();
        GameObject designItemPrefab = Resources.Load("Prefab/GridItem") as GameObject;
        foreach (DataBean designItem in dataList)
        {
            if (designItemPrefab != null)
            {
                GameObject designItemObj = GameObject.Instantiate(designItemPrefab);
                designItemObj.transform.parent = GridView.transform;
                designItemObj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

                GameObject childImageObj = designItemObj.transform.GetChild(0).gameObject;
                Image clothImage = childImageObj.GetComponent<Image>();
                Debug.Log("icon path " + designItem.iconPath);
                //var sp = Resources.Load(designItem.iconPath) as Sprite;
                clothImage.sprite = Resources.Load<Sprite>(designItem.iconPath); ;

                GameObject titleObj = designItemObj.transform.GetChild(1).gameObject;
                Text titleText = titleObj.GetComponent<Text>();
                titleText.text = designItem.name;
             
            }
        }
    }
}
