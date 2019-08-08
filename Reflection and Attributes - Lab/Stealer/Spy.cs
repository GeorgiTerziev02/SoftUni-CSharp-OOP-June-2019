using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
    {
        Type classType = Type.GetType(investigatedClass);

        FieldInfo[] fields = classType.GetFields(BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.NonPublic |
            BindingFlags.Public);

        StringBuilder sb = new StringBuilder();

        object classInstance = Activator.CreateInstance(classType, new object[] { });

        sb.AppendLine($"Class under investigation: {classType}");


        foreach (var field in fields.Where(f => requestedFields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        MethodInfo[] publicMethodsInfo = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        MethodInfo[] nonPublicMethodsInfo = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        StringBuilder result = new StringBuilder();

        foreach (var field in classFields)
        {
            result.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in nonPublicMethodsInfo.Where(m => m.Name.StartsWith("get")))
        {
            result.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in publicMethodsInfo.Where(m => m.Name.StartsWith("set")))
        {
            result.AppendLine($"{method.Name} have to be private!");
        }

        return result.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);

        MethodInfo[] classPrivateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        StringBuilder result = new StringBuilder();

        result.AppendLine($"All Private Methods of Class: {className}")
            .AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var method in classPrivateMethods)
        {
            result.AppendLine(method.Name);
        }

        return result.ToString().TrimEnd();
    }

    public string CollectGettersAndSetter(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] classMethod = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        StringBuilder result = new StringBuilder();

        foreach (var method in classMethod.Where(m => m.Name.StartsWith("get")))
        {
            result.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in classMethod.Where(m => m.Name.StartsWith("set")))
        {
            result.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return result.ToString().TrimEnd();
    }
}