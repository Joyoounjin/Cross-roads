using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> platform = new List<GameObject>(); // 플랫폼 저장
    public List<float> height = new List<float>(); // 플랫폼의 높이 저장 

    private int rndRange = 0; // 랜덤 선택된 인덱스의 값
    private float lastPos = 0; // 마지막으로 배치된 오브젝트의 Z 위치값
    private float lastScale = 0; // 마지막으로 배치된 오브젝트의 Z 방향값

    public void RandomGenerator() 
    {
        rndRange = Random.Range(0, platform.Count); // 랜덤 인덱스 선출 
        for (int i = 0; i < platform.Count; i++)
        {
            CreateLevelObject(platform[i], height[i], i);
        }
    }

    public void CreateLevelObject(GameObject obj, float height, int value) // 배치 함수 
    {
        if (rndRange == value) // 랜덤 선출 인덱스와 전달된 플랫폼이 같을 때 
        {
            GameObject go = Instantiate(obj) as GameObject;

            float offset = lastPos + (lastScale * 0.5f);
            offset += (go.transform.localScale.z) * 0.5f;

            Vector3 pos = new Vector3(0, height, offset);

            go.transform.position = pos;

            lastPos = go.transform.position.z;
            lastScale = go.transform.localScale.z;

            go.transform.parent = this.transform;
        }
    }
}
