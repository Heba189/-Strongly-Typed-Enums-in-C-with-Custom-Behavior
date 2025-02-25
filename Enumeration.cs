//using System.Reflection;

//namespace SmartEnum;

//public abstract class Enumeration<IEnum> : IEquatable<Enumeration<IEnum>>
//    where IEnum : Enumeration<IEnum>
//{
//    private static readonly Dictionary<int, IEnum> Enumerations = CreateEnumerations();

//    //this means that we can only set the value once during initialization
//    protected Enumeration(int value, string name)
//    {
//        Value = value;
//        Name = name;
//    }
//    public int Value { get; protected init; }
//    public string Name { get; protected init; } = string.Empty;
//    public static IEnum? FromValue(int value)
//    {
//        return Enumerations.TryGetValue(
//            value,
//            out IEnum? enumeration) ? enumeration : default;
//    }
//    public static IEnum? FromName(string name)
//    {
//        return Enumerations
//              .Values
//              .SingleOrDefault(e => e.Name == name);
//    }
//    public bool Equals(Enumeration<IEnum>? other)
//    {
//        if (other is null)
//        {
//            return false;
//        }
//        return GetType() == other.GetType() &&
//               Value == other.Value;
//    }

//    public override bool Equals(object? obj)
//    {
//        return obj is Enumeration<IEnum> other && Equals(other);
//    }
//    public override int GetHashCode()
//    {
//        return base.GetHashCode();
//    }
//    public override string ToString()
//    {
//        return Name;
//    }
//    private static Dictionary<int, IEnum> CreateEnumerations()
//    {
//        var enumerationType = typeof(IEnum);
//        var fieldsForType = enumerationType.GetFields(
//            BindingFlags.Public |
//            BindingFlags.Static |
//            BindingFlags.FlattenHierarchy)
//            .Where(FieldInfo =>
//                   enumerationType.IsAssignableFrom(FieldInfo.FieldType))
//            .Select(FieldInfo =>
//               (IEnum)FieldInfo.GetValue(default)!);

//        return fieldsForType.ToDictionary(x => x.Value);
//    }
//}
using System.Reflection;

namespace SmartEnum
{
    public abstract class Enumeration<IEnum> : IEquatable<Enumeration<IEnum>>
        where IEnum : Enumeration<IEnum>
    {
        // Lazy initialization of the dictionary to cache the reflection result
        private static readonly Lazy<Dictionary<int, IEnum>> EnumerationsLazy =
            new Lazy<Dictionary<int, IEnum>>(CreateEnumerations);

        // Dictionary to store enum values by their integer value and string name
        private static readonly Lazy<Dictionary<string, IEnum>> NameLookupLazy =
            new Lazy<Dictionary<string, IEnum>>(CreateNameLookup);

        protected Enumeration(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public int Value { get; protected init; }
        public string Name { get; protected init; } = string.Empty;

        // Getter for Enumerations dictionary
        private static Dictionary<int, IEnum> Enumerations => EnumerationsLazy.Value;
        private static Dictionary<string, IEnum> NameLookup => NameLookupLazy.Value;

        // Method to get an enum by value
        public static IEnum? FromValue(int value)
        {
            return Enumerations.TryGetValue(value, out var enumeration) ? enumeration : default;
        }

        // Method to get an enum by name
        public static IEnum? FromName(string name)
        {
            return NameLookup.TryGetValue(name, out var enumeration) ? enumeration : default;
        }

        public bool Equals(Enumeration<IEnum>? other)
        {
            if (other is null)
            {
                return false;
            }
            return GetType() == other.GetType() &&
                   Value == other.Value;
        }

        public override bool Equals(object? obj)
        {
            return obj is Enumeration<IEnum> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }

        // Method to create the enumerations dictionary (cached result of reflection)
        private static Dictionary<int, IEnum> CreateEnumerations()
        {
            var enumerationType = typeof(IEnum);
            var fieldsForType = enumerationType.GetFields(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.FlattenHierarchy)
                .Where(FieldInfo =>
                    enumerationType.IsAssignableFrom(FieldInfo.FieldType))
                .Select(FieldInfo =>
                    (IEnum)FieldInfo.GetValue(default)!);

            return fieldsForType.ToDictionary(x => x.Value);
        }

        // Method to create the Name lookup dictionary (cached result of reflection)
        private static Dictionary<string, IEnum> CreateNameLookup()
        {
            return Enumerations.Values.ToDictionary(x => x.Name);
        }
    }
}
