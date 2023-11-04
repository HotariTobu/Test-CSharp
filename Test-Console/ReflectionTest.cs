using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal class ReflectionTest
    {
        public static void Entry()
        {
            /*ParseType(typeof(ReflectionTest_A));
            ParseType(typeof(ReflectionTest_C));

            var ITypes = typeof(List<int>).FindInterfaces((interfaceType, obj) =>
              {

                  return true;
              }, "fc");

            var map = typeof(List<int>).GetInterfaceMap(typeof(IEnumerable<int>));

            var ctoc = typeof(ReflectionTest_C).IsAssignableTo(typeof(ReflectionTest_C));
            var ctol = typeof(ReflectionTest_C).IsAssignableTo(typeof(List<int>));

            var mc = typeof(ReflectionTest_D).GetMethods()[0];
            var mcps = mc.GetParameters();

            Parse2Types(typeof(ReflectionTest_C), mcps[0].ParameterType);
            Parse2Types(1.GetType(), 2.GetType());

            var fs = typeof(ReflectionTest_C).GetInterfaces();
            var ctoi = fs.Contains(typeof(IEnumerable));*/

            //ParseType(typeof(System.Collections.ObjectModel.ObservableCollection<int>));
            //ParseType(typeof(List<int>));
            //ParseType(typeof(int[]));

            //Parse2Types(typeof(int), typeof(double));
            //Parse2Types(typeof(double), typeof(double));

            var me1 = typeof(ReflectionTest_E).GetMethod("ME1");
            var me2 = typeof(ReflectionTest_E).GetMethod("ME2");

            //var rme1 = me1?.Invoke(null, new object[] { 1, 2, 5 });
            //var rme2 = me2?.Invoke(null, new object[] { 1 });
            var rme2 = me2?.Invoke(null, new object[] { 1, null });
            int? ni = null;
            //var t = ni.GetType();
            //var nit = typeof(ni);

            int f1i = 2;
            var mf1 = typeof(ReflectionTest_F).GetMethod("MF1");
            object[] args = new object[] { f1i };
            mf1.Invoke(null, args);
            f1i = (int)args[0];

            var f2s = "old";
            var mf2 = typeof(ReflectionTest_F).GetMethod("MF2");
            object[] af2 = new object[] { f2s };
            mf2.Invoke(null, af2);
            f2s.MF2();

            string? ns = null;
            var nst = GetType(ns);

            object? ons = ns;
            var onst = GetType(ons);

            ns = "f";
            nst = ns.GetType();

            ons = ns;
            onst = ons.GetType();

            //ParseType(typeof(List<>));
            var dddd = typeof(List<>).GetConstructor(new Type[] { typeof(IEnumerable<>) });
            var ddddd = typeof(List<>).GetConstructors().FirstOrDefault(m =>
            {
                var ps = m.GetParameters();
                if (ps.Length > 0)
                {
                    return ps[0].ParameterType.IsAssignableFrom(typeof(IEnumerable<>));
                }
                return false;
            });

            var G = new ReflectionTest_G();
            var vsf = typeof(ReflectionTest_G).GetField("Vs");
            var vsfv = vsf.GetValue(G);
            //var vsfv = vsf.GetValue(null);
            IEnumerable newvsfv = Enumerable.Range(40, 5);
            
            var vsftc = vsf.FieldType.GetConstructors().First(m =>
              {
                  var ps = m.GetParameters();
                  if (ps.Length > 0)
                  {
                      return ps[0].ParameterType.Name.StartsWith(nameof(IEnumerable));
                  }
                  return false;
              });
            var newvsfvv = vsftc.Invoke(new object[] { newvsfv });
            vsf.SetValue(G, newvsfvv);
            //vsf.SetValue(G, null);

            G.Vs = new System.Collections.ObjectModel.ObservableCollection<int>(Enumerable.Range(0, 10));

            {
                Type listType = typeof(List<>).MakeGenericType(typeof(int));
                MethodInfo? addMethod = listType.GetMethod("Add");
                ConstructorInfo? listConstructor = listType.GetConstructor(Type.EmptyTypes);
                object? list = listConstructor.Invoke(null);

                foreach (object? value in Enumerable.Range(40, 5))
                {
                    addMethod?.Invoke(list, new object?[] { value });
                }
                var gvsd = vsftc.Invoke(new object[] { list });
                vsf.SetValue(G, gvsd);
            }

            Func<int, int> f = r => r * 2;
            f.GetMethodInfo();

            var nid=default(int?);

            //ParseType(typeof(Dictionary<string, int>));
            var dic = new Dictionary<string, int>();
            dic.Add("Tom", 26);
            var dict = dic.GetType();
            IDictionary idic = dic;
            foreach (dynamic item in idic)
            {
                var dicit = item.GetType();
                var dicikt = item.Key.GetType();
                var dicivt = item.Value.GetType();
            }

            IEnumerable edic = dic;
            var edict = edic.GetType();

            ReflectionTest_H test_H = 5;
            Parse2Types(typeof(int), typeof(ReflectionTest_H));
            var e8 = ReflectionTest_H.MH1(8);
        }

        private static Type GetType<T>(T _) => typeof(T);
        public static dynamic ConvertTo(dynamic source, Type dest)
        {
            return Convert.ChangeType(source, dest);
        }

        private static void ParseType(Type type)
        {
            //var ArrayRank = type.GetArrayRank();
            var Constructors = type.GetConstructors();
            var DefaultMembers = type.GetDefaultMembers();
            var ElementType = type.GetElementType();
            //var EnumNames = type.GetEnumNames();
            //var EnumUnderlyingType = type.GetEnumUnderlyingType();
            //var EnumValues = type.GetEnumValues();
            var Events = type.GetEvents();
            var Fields = type.GetFields();
            //var GenericArguments = type.GetGenericArguments();
            //var GenericParameterConstraints = type.GetGenericParameterConstraints();
            //var GenericTypeDefinition = type.GetGenericTypeDefinition();
            ////var InterfaceMap = type.GetInterfaceMap();
            var Interfaces = type.GetInterfaces();
            ////var MemberWithSameMetadataDefinitionAs = type.GetMemberWithSameMetadataDefinitionAs();
            var Members = type.GetMembers();
            var Methods = type.GetMethods();
            var NestedTypes = type.GetNestedTypes();
            var Properties = type.GetProperties();
            ////var TypeArray = type.GetTypeArray();
            ////var TypeCode = type.GetTypeCode();
            ////var TypeHandle = type.GetTypeHandle();

            ////var MethodInfo = type.GetMethodInfo();
            ////var RuntimeBaseDefinition = type.GetRuntimeBaseDefinition();
            var RuntimeEvents = type.GetRuntimeEvents();
            var RuntimeFields = type.GetRuntimeFields();
            ////var RuntimeInterfaceMap = type.GetRuntimeInterfaceMap();
            var RuntimeMethods = type.GetRuntimeMethods();
            var RuntimeProperties = type.GetRuntimeProperties();

            var ExtensionMethods = type.GetExtensionMethods(Assembly.GetExecutingAssembly());
        }

        private static void Parse2Types(Type type1, Type type2)
        {
            var ope = type1 == type2;
            var equals = type1.Equals(type2);
            var from = type1.IsAssignableFrom(type2);
            var to = type1.IsAssignableTo(type2);
            var equivalent = type1.IsEquivalentTo(type2);
            var sub = type1.IsSubclassOf(type2);
        }
    }

    static class TypeExtension
    {
        public static IEnumerable<MethodInfo> GetExtensionMethods(this Type extendedType, Assembly assembly)
        {
            return from type in assembly.GetTypes()
                   where type.IsSealed && !type.IsGenericType && !type.IsNested
                   from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                   where method.IsDefined(typeof(ExtensionAttribute), false)
                   where method.GetParameters()[0].ParameterType == extendedType
                   select method;
            //https://stackoverflow.com/questions/299515/reflection-to-identify-extension-methods
        }
    }

    class ReflectionTest_A
    {
        int I;

        public void MA1() { MA2(); }
        void MA2() { }
    }

    static class ReflectionTest_B
    {
        public static void MB(this ReflectionTest_A a) { }
    }

    class ReflectionTest_C : List<int>
    {
    }

    static class ReflectionTest_D
    {
        public static void MD1<T>(this IEnumerable<T> ts) { }
        public static void MD2<T>(this IEnumerable ts) { }
    }

    static class ReflectionTest_E
    {
        public static double ME1(int a, double b) => a + b;
        public static double ME2(int a, double b = 4) => a + b;
    }

    static class ReflectionTest_F
    {
        public static void MF1(this ref int a)
        {
            a = 3;
        }

        public static void MF2(this string s)
        {
            s = "new";
        }
    }

    class ReflectionTest_G
    {
        public System.Collections.ObjectModel.ObservableCollection<int> Vs = new System.Collections.ObjectModel.ObservableCollection<int>(Enumerable.Range(1, 10));
    }

    class ReflectionTest_H
    {
        public object FH;
        public static implicit operator ReflectionTest_H(int value)
        {
            return new ReflectionTest_H { FH = value };
        }

        public static int MH1(ReflectionTest_H test_H) => (int)test_H.FH;
    }
}
