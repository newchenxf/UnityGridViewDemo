using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//UI对象控制脚本的父类，可得到所有子对象
public class BaseUIController : MonoBehaviour
{
    private Dictionary<string, GameObject> view = new Dictionary<string, GameObject>();

    //获取所有子对象的引用
    private void load_all_object(GameObject root, string path)
    {
        foreach (Transform tf in root.transform)
        {
            if (this.view.ContainsKey(path + tf.gameObject.name))
            {
                Debug.LogWarning("Warning object is exist:" + path + tf.gameObject.name + "!");
                continue;
            }
            this.view.Add(path + tf.gameObject.name, tf.gameObject);
            load_all_object(tf.gameObject, path + tf.gameObject.name + "/");
        }

    }

    public virtual void Awake()
    {
        this.load_all_object(this.gameObject, "");
    }

    //找到子物体
    public GameObject findObjectByPath(string path)
    {
        if (view.ContainsKey(path))
        {
            return view[path];
        }
        else
        {
            Debug.LogError("BaseUIController find this GameObject failed, please check view path is existed !!!");
            return null;
        }
    }


    //Button事件绑定案例
    //this.setBtnClickListener("Container_RightBottom/btnBeginGame", onGameStart);
    public void setBtnClickListener(string view_name, UnityAction onclick)
    {
        Button bt = this.view[view_name].GetComponent<Button>();
        if (bt == null)
        {
            Debug.LogWarning("BaseUIController setBtnClickListener: not Button Component!");
            return;
        }

        bt.onClick.AddListener(onclick);
    }

    //Slider事件绑定案例
    //this.setSliderChangelistener("Container_RightBottom/Slider", onSliderChange);
    public void setSliderChangelistener(string view_name, UnityAction<float> on_value_changle)
    {
        Slider s = this.view[view_name].GetComponent<Slider>();
        if (s == null)
        {
            Debug.LogWarning("BaseUIController setSliderChangelistener: not Slider Component!");
            return;
        }

        s.onValueChanged.AddListener(on_value_changle);
    }
}


