using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ConfusedDevelopProject.Core
{
    public static class SqlExtension
    {
        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <param name="parameters"></param>
        public static void SetParameters(this IDbCommand dbCommand, IDictionary<string, object> parameters)
        {
            if (parameters == null)
            {
                return;
            }
            foreach (var parameter in parameters)
            {
                if (parameter.Value != null)
                {
                    dbCommand.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                }
                else
                {
                    dbCommand.Parameters.Add(new SqlParameter(parameter.Key, DBNull.Value));
                }
            }
        }
        /// <summary>
        /// 设定字典对象值
        /// </summary>
        /// <param name="result">设定值结果</param>
        /// <param name="rdr">读取源</param>
        public static void SetReaderValue(this IDictionary<string, object> result, IDataReader rdr)
        {
            for (int i = 0; i < rdr.FieldCount; i++)
            {
                result[rdr.GetName(i).ToLower()] = rdr[i];
            }
        }

        /// <summary>
        /// DataReader转模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objReader"></param>
        /// <returns></returns>
        public static T ReaderToModel<T>(this IDataReader objReader, Type type)
        {

            using (objReader)
            {
                if (objReader.Read())
                {
                    Type modelType = type;
                    if (type == null)
                    {
                        modelType = typeof(T);
                    }
                    int count = objReader.FieldCount;
                    T model = Activator.CreateInstance<T>();
                    for (int i = 0; i < count; i++)
                    {
                        if (!IsNullOrDBNull(objReader[i]))
                        {
                            PropertyInfo pi = modelType.GetProperty(objReader.GetName(i), BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                            if (pi != null)
                            {
                                pi.SetValue(model, CheckType(objReader[i], pi.PropertyType), null);
                            }
                        }
                    }
                    return model;
                }
            }
            return default(T);
        }

        /// <summary>
        /// 判断指定对象是否是有效值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static bool IsNullOrDBNull(object obj)
        {
            return (obj == null || (obj is DBNull)) ? true : false;
        }

        /// <summary>
        /// 对可空类型进行判断转换(*要不然会报错)
        /// </summary>
        /// <param name="value">DataReader字段的值</param>
        /// <param name="conversionType">该字段的类型</param>
        /// <returns></returns>
        private static object CheckType(object value, Type conversionType)
        {
            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                    return null;
                System.ComponentModel.NullableConverter nullableConverter = new System.ComponentModel.NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }
            return Convert.ChangeType(value, conversionType);
        }
    }
}