using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class MapManager : MonoBehaviour
{
    public Sprite[] mapData = new Sprite[3];
    public Map nowMap;
    public List<Map> maps = new List<Map>();
    public GameObject prefab;

    public void CreateClassMap()
    {
    }

    public void CreateInfinityMap()
    {
        Map newMap = new Map(mapData[Random.Range(0, 3)]);
        newMap.CreateObject(prefab);
        maps.Add(newMap);
        StartCoroutine(CreateMap(newMap));
        //CreateMap(newMap);
    }

    public IEnumerator CreateMap(Map _standard)
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 4; i++)
        {
            switch ((MAPDATA.SIDE)i)
            {
                case MAPDATA.SIDE.UPSIDE:
                    if (_standard.map_Upside == null)
                    {
                        if (Math.RandomBool())
                        {
                            Map newMap = new Map(mapData[Random.Range(0, 3)], _standard, MAPDATA.SIDE.UPSIDE);
                            _standard.map_Upside = newMap;
                            maps.Add(newMap);

                            CheckSide(newMap);

                            newMap.CreateObject(prefab);

                            StartCoroutine(CreateMap(newMap));
                            //CreateMap(newMap);
                        }
                    }
                    break;
                case MAPDATA.SIDE.RIGHT:
                    if (_standard.map_Right == null)
                    {
                        if (Math.RandomBool())
                        {
                            Map newMap = new Map(mapData[Random.Range(0, 3)], _standard, MAPDATA.SIDE.RIGHT);
                            _standard.map_Right = newMap;
                            maps.Add(newMap);

                            CheckSide(newMap);

                            newMap.CreateObject(prefab);

                            StartCoroutine(CreateMap(newMap));
                            //CreateMap(newMap);
                        }
                    }
                    break;
                case MAPDATA.SIDE.LEFT:
                    if (_standard.map_Left == null)
                    {
                        if (Math.RandomBool())
                        {
                            Map newMap = new Map(mapData[Random.Range(0, 3)], _standard, MAPDATA.SIDE.LEFT);
                            _standard.map_Left = newMap;
                            maps.Add(newMap);

                            CheckSide(newMap);

                            newMap.CreateObject(prefab);

                            StartCoroutine(CreateMap(newMap));
                            //CreateMap(newMap);
                        }
                    }
                    break;
                case MAPDATA.SIDE.DOWNSIDE:
                    if (_standard.map_DownSide == null)
                    {
                        if (Math.RandomBool())
                        {
                            Map newMap = new Map(mapData[Random.Range(0, 3)], _standard, MAPDATA.SIDE.DOWNSIDE);
                            _standard.map_DownSide = newMap;
                            maps.Add(newMap);

                            CheckSide(newMap);

                            newMap.CreateObject(prefab);

                            StartCoroutine(CreateMap(newMap));
                            //CreateMap(newMap);
                        }
                    }
                    break;
            }
            yield return null;
        }
    }

    public void CheckSide(Map _standard)
    {
        Map _side;

        _side = FindMap(_standard.x, _standard.y - 1);
        if (_side != null)
        { 
            _standard.map_Upside = _side;
            _side.map_DownSide = _standard;
        }

        _side = FindMap(_standard.x - 1, _standard.y);
        if (_side != null)
        {
            _standard.map_Left = _side;
            _side.map_Right = _standard;
        }

        _side = FindMap(_standard.x + 1, _standard.y);
        if (_side != null)
        {
            _standard.map_Right = _side;
            _side.map_Left = _standard;
        }

        _side = FindMap(_standard.x, _standard.y + 1);
        if (_side != null)
        {
            _standard.map_DownSide = _side;
            _side.map_Upside = _standard;
        }
    }

    public Map FindMap(int _x, int _y)
    {
        foreach (var item in maps)
        {
            if (item.x == _x && item.y == _y)
            {
                return item;
            }
        }
        return null;
    }
}
