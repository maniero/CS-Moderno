using System;
using System.Drawing;
using static System.Math;
using static System.Console;
public partial ref struct X { }
public ref partial struct Y { }

public static void Assert(bool condition, [CallerArgumentExpressiom("condition")] string message) { }

class Program {
    T Single<T>(this T[] array) {
        Assert(array != null);
        Assert(array.Length == 1);
        return array[0];
    }
    static void Main() {
        var p = GetPessoa();
        switch (p.Nome, p.Sobrenome) {
        case (string n, string s):
            return $"{n} {s}";
        case (string n, null):
            return n;
        case (null, string s):
            return $"Sr. {s}";
        case (null, null):
            return "Desconhecido";
        }
        var figure = new Point(0, 0);
        var area = figure switch
        {
            Line _ => 0,
            Rectangle r => r.Width * r.Height,
            Circle c => PI * c.Radius * c.Radius
        };
        var p1 = new Point(2, 1);
        Point p2 = new (2, 1);
        Point[] p3 = { new Point(1, 4), new Point(3, -2), new Point(9, 5) };
        Point[] p4 = { new (1, 4), new (3, -2), new (9, 5) };
        (int i, string j) = (default, default);
        (int i, string j) = default;
        (i, j) = default;
        int x = 0;
        WriteLine(Local());
        WriteLine(LocalStatic());
        WriteLine(x);
        static int LocalStatic() {
            int x = 1;
            return 1 + x;
        }
        int Local() {
            x = 1;
            return 1 + x;
        }
        WriteLine($@"Interpolação {DateTime.Now}
                        Multilinha");
        WriteLine(@$"Interpolação {DateTime.Now}
                    Multilinha");
        if (true) {
            using var f = new Resource();
            //statements
        }
    }
    public static (string Nome, string SobreNome) GetPessoa() => ("Antonio", "Maniero");
}

class Resource : IDisposable {
    public void Dispose() { }
}

struct Line { }
struct Circle { public int Radius { get; set; } }