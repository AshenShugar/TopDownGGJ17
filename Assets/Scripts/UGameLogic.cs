using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class UGameLogic
{
    public const int lengthOfSecond = 60;
    public const int tileWidth = 32;

    public static double TrueBearingsToRadians(double bearing)
    {
        return ((90 - bearing) / 180f * Math.PI);
    }

    //Convert radians to 360 degree clockwise from north bearings;
    public static double RadiansToTrueBearings(double radians)
    {
        double res = -radians * 180 / Math.PI + 90;
        if (res < 0)
        {
            res = res + 360;
        }
        return (res);
    }



    //Get the direction to a given point;
    public static double DirToPoint(double originX, double originY, double destX, double destY, Boolean inTrueBearings = true)
    {
        double ang;
        if (inTrueBearings)
        {
            /*
            if (Math.Abs(destX - originX) < 0.001f)
            {
                return 0;
            }
             */
            ang = Math.Atan2(destY- originY, destX - originX);
            ang = RadiansToTrueBearings(ang);
        }
        else
        {
            /*
            if (Math.Abs(destX - originX) < 0.001f)
            {
                return Math.PI / 2;
            }
             */
            ang = Math.Atan2(destY- originY, destX - originX);
        }
        return ang;
    }

}

