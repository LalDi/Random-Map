using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class Map : MonoBehaviour
{
    public Sprite data;
    public Map map_Right = null;
    public Map map_Left = null;
    public Map map_Upside = null;
    public Map map_DownSide = null;

    public bool isLive = false;
    public int x, y;

    /// <summary>
    /// 재귀함수를 통해 맵을 생성할 때, 생성될 맵이 가질 방향값과 데이터를 포함해주는 함수
    /// </summary>
    /// <param name="_data">맵이 가질 데이터</param>
    /// <param name="_maker">이 맵을 만든 기준이 된 맵</param>
    /// <param name="_side">_maker 기준에서 이 맵이 생성된 방향</param>
    public Map(Sprite _data, Map _maker, MAPDATA.SIDE _side)
    {
        data = _data;
        switch (_side)
        {
            case MAPDATA.SIDE.UPSIDE:
                map_DownSide = _maker;
                x = _maker.x;
                y = _maker.y + 1;
                break;
            case MAPDATA.SIDE.RIGHT:
                map_Left = _maker;
                x = _maker.x + 1;
                y = _maker.y;
                break;
            case MAPDATA.SIDE.LEFT:
                map_Right = _maker;
                x = _maker.x - 1;
                y = _maker.y;
                break;
            case MAPDATA.SIDE.DOWNSIDE:
                map_Upside = _maker;
                x = _maker.x;
                y = _maker.y - 1;
                break;
        }
    }

    /// <summary>
    /// 재귀를 통해 만드는 것이 아닌, 최초의 맵.
    /// (기준으로 삼을 맵 데이터가 없기에, 방향값을 넣지 않는다.)
    /// </summary>
    /// <param name="_data">맵이 가질 데이터</param>
    public Map(Sprite _data)
    {
        data = _data;
        x = 0;
        y = 0;
    }


    public GameObject CreateObject(GameObject _prefab)
    {
        int _x = x * 2;
        int _y = y * 2;

        GameObject _obj = Instantiate(_prefab, new Vector3(_x, _y, 0), Quaternion.identity);
        return _obj;
    }
}
