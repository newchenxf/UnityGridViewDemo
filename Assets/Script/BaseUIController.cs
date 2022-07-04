using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//UI������ƽű��ĸ��࣬�ɵõ������Ӷ���
public class BaseUIController : MonoBehaviour
{
    private Dictionary<string, GameObject> view = new Dictionary<string, GameObject>();

    //��ȡ�����Ӷ��������
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

    //�ҵ�������
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


    //Button�¼��󶨰���
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

    //Slider�¼��󶨰���
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


