namespace Define
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MAPDATA
    {
        public enum SIDE
        { 
            UPSIDE,
            RIGHT,
            LEFT,
            DOWNSIDE
        }

    }

    public class Math
    {
        public static bool RandomBool()
        {
            int temp;

            temp = Random.Range(0, 2);

            return temp == 0 ? true : false;
        }
    }

}