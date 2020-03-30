using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace csharp_concepts
{

    public class Reflection
    {
        class Customer
        {
            public int id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string email;

            public string getEmail() { return email; }

            public void setEmail(string email) { this.email = email; }
        }
        public static void dismantle() {
            IEnumerable<Type> typesInTheAssembly = from t in Assembly.GetExecutingAssembly().GetTypes()
                                                   where t.IsClass && t.Namespace.Contains("entity")
                                                   select t;
            Console.WriteLine(string.Join(", ",typesInTheAssembly));

            Type type = typeof(Customer);
            Console.WriteLine($"class type: {type.FullName},ns: {type.Namespace},assembly: {type.AssemblyQualifiedName} ");
            TypeAttributes typeAttribute= type.Attributes;
            Console.WriteLine(typeAttribute.ToString());
            MemberInfo[] memberInfos = type.GetMembers();
            foreach(MemberInfo memberInfo in memberInfos) {
                Console.WriteLine($"member name: {memberInfo.Name},member type: {memberInfo.MemberType} ");
            }

            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Console.WriteLine($"property name: {propertyInfo.Name},property type: {propertyInfo.PropertyType} ");
            }

            MemberInfo[] methodInfos = type.GetMethods();
            foreach (MemberInfo memberInfo in methodInfos)
            {
                Console.WriteLine($"method name: {memberInfo.Name},method type: {memberInfo.MemberType} ");
            }

            FieldInfo[] fieldInfos = type.GetFields();
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                Console.WriteLine($"field name: {fieldInfo.Name},field type: {fieldInfo.FieldType} ");
            }
            ConstructorInfo constructorInfo = type.GetConstructor(Type.EmptyTypes);
            object customer = constructorInfo.Invoke(new object[] { });

            MethodInfo firstNameSetter = type.GetMethod("set_firstName");
            firstNameSetter.Invoke(customer, new object[] { "sameer" });

            MethodInfo firstNameGetter = type.GetMethod("get_firstName");
            object firstName = firstNameGetter.Invoke(customer, new object[] { });
            Console.WriteLine(firstName);
        }
    }
}
