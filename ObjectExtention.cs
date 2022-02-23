using System;
using System.Collections.Generic;

namespace iXtentions
{
    public static class ObjectExtention
    {
#pragma warning disable CS8602
#pragma warning disable CS8600
        public static List<string> GetValuesModify(this object newParam, object OldParam, params string[] RemoveProperty)
        {
            List<string> lreturn = new List<string>();
            try
            {
                var ListOldParam = OldParam.GetType().GetProperties();
                //var ListNewParam = newParam.GetType().GetProperties();
                foreach (var i in ListOldParam)
                {
                    //string _new _old;

                    string n = "";

                    try { n = newParam.GetType().GetProperty(i.Name).GetValue(newParam).ToString(); } catch (System.Exception) { }

                    string o = "";
                    try { o = i.GetValue(OldParam, null).ToString(); } catch (System.Exception) { }

                    if (!i.Name.MultContains(RemoveProperty))
                        if (i.PropertyType == typeof(string) ||
                        i.PropertyType == typeof(int) ||
                        i.PropertyType == typeof(DateTime))
                            if (n != o)
                                lreturn.Add($"{i.Name}: [old: {o.Replace("\r", "").Replace("\n", "")}] [new: {n.Replace("\r", "").Replace("\n", "")}]");

                }
                return lreturn;
            }
            catch (System.Exception)
            {
                return lreturn;
            }
        }


        public static List<string> ConvertNamePropertyObjectToListString<t>(this object obj)
        {
            try
            {
                List<string> stringao = new List<string>();
                if (obj == null) return new List<string>();
                var props = obj.GetType().GetProperties();
                foreach (var i in props)
                {
                    var prop = obj.GetType().GetProperty(i.Name).GetValue(obj);
                    if (prop is t)
                        if (((bool)prop) == true)
                            stringao.Add(i.Name);
                }
                return stringao;
            }
            catch (System.Exception) { throw; }
        }



    }

}