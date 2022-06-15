using System;
using System.Collections.Generic;
using System.Linq;

namespace iXtensions.Extensions
{
    public static class ObjectExtension
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
        
        public static List<string> GetValuesModify_OnlyProperties(this object newParam, object OldParam, params string[] OnlyPorperties)
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

                    if (i.Name.MultContains(OnlyPorperties))
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


#pragma warning disable

        public static object GetPropertyValue(this object src, string propName)
            => src.GetType().GetProperty(propName).GetValue(src, null); // possível referencia nula

        public static object GetPropertyValue<T>(this object src, string propName)
            => (T)src.GetType().GetProperty(propName).GetValue(src, null);

        public static List<T> GetPage<T>(this List<T> list, int Page, int PageSize)
            => list.Skip(Page * PageSize).Take(PageSize).ToList();
        
        
        /// <summary>
        /// This method will return a pagination list, example, if you showing 3 items per page and having a 10 items 
        /// in your list, this method will return the 9 first items because 9 is divisible by 3, you have a list item 
        /// with 9 items and 3 per page
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="ItemPerPage"></param>
        /// <param name="MaxPage">If it's 0 then there's no limit</param>
        /// <returns></returns>
        public static List<T> GetPagination<T>(this List<T> list, int ItemsPerPage, int MaxPage = 0)
        {
            bool hasPage = true;
            int pageIndex = 0;
            if (list.Count < ItemsPerPage) { return list; }
            var nList = new List<T>();
            while (hasPage)
            {
                var itemsPage = list.Skip(pageIndex * ItemsPerPage).Take(ItemsPerPage).ToList();
                if (itemsPage.Count == ItemsPerPage) { nList.AddRange(itemsPage); pageIndex++; }
                else { hasPage = false; }
                if (MaxPage != 0) { if (pageIndex == MaxPage) { hasPage = false; } }
            }
            return nList;
        }

    }

}
