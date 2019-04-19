using static System.Console;
//#nullable enable
public class Program {
    static void Main() {
        int? x = null;
        bool? b = null;
        string? s = null;
        string t = null;
        //s = default;
        //t = default; //"MVPConf 2019";
        //s = t;
        //t = s;
        //if (s != null)
        //    s = s.Substring(1, 2);
        WriteLine($"{x}, {b}, {s}, {t}");
        //WriteLine($"{s!.Length}, {t!.Length}");
        s ??= "nome em branco";
        WriteLine(s);
    }
}

//<NullableReferenceTypes>True</NullableReferenceTypes>