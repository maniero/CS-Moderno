using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;

namespace NovidadesCSharp {
    public class Program {
        public static int Main(string[] args) {
            //      public static async ValueTask<int> Main(string[] args) {
            //Digits();
            //OutVar();
            //ThrowAsExpression();
            //ValueTuple();
            //Embodied();
            //LocalFunction();
            //PatternMatching();
            //ValueTask();
            //Default();
            //RefVar();
            //NamedArguments();
            //In();
            //ReturnReadOnly();
            //SpanT();
            //Better betterness
            return 0;
        }
        private static void Digits() {
            WriteLine(0b_0110_0111_0001_0000);
            WriteLine(0x_FF_C8);
            WriteLine(123_456_789);
            WriteLine(1____2_34);
            WriteLine(1_010.111_1e1_00);
        }
        private static void OutVar() {
            if (int.TryParse(ReadLine(), out var valor))
                WriteLine(valor);
            else
                WriteLine("falhou");
            WriteLine(int.TryParse(ReadLine(), out _) ? "deu certo" : "falhou");
        }
        private static void ThrowAsExpression() {
            try {
                var x = ReadLine() == "abc" ? 10 : throw new Exception("Que tiro foi esse?");
                WriteLine(x);
            } catch (Exception ex) {
                WriteLine(ex.Message);
            }
        }
        private static void ValueTuple() {
            var a = (1, 1);
            WriteLine($"{a.GetType()} = {a}");
            var resultado = NewParse(ReadLine());
            if (resultado.Item1)
                WriteLine(resultado.Item2);
            else
                WriteLine("Bugou!");
            resultado = ImprovParse(ReadLine());
            //if (resultado.Ok) WriteLine(resultado.Value); else WriteLine("Bugou!");
            var resultado2 = ImprovParse(ReadLine());
            if (resultado2.Ok)
                WriteLine(resultado2.Value);
            else
                WriteLine("Bugou!");
            if (resultado2.Item1)
                WriteLine(resultado2.Item2);
            else
                WriteLine("Bugou!");
            var resultado3 = ImprovParse2(ReadLine());
            if (resultado3.Ok)
                WriteLine(resultado3.Value);
            else
                WriteLine("Bugou!");
            (bool funcionou, int valor) = ImprovParse(ReadLine());
            if (funcionou)
                WriteLine(valor);
            else
                WriteLine("Bugou!");
            (var funcionou2, var valor2) = ImprovParse(ReadLine());
            if (funcionou2)
                WriteLine(valor2);
            else
                WriteLine("Bugou!");
            (funcionou2, valor2) = ImprovParse(ReadLine());
            (funcionou, valor) = (true, 20);
            if (funcionou2)
                WriteLine(valor2);
            else
                WriteLine("Bugou!");
            WriteLine(resultado2 == (true, 10));
            (funcionou2, _) = ImprovParse(ReadLine());
            WriteLine(funcionou2);
            (var x, var y) = new Point(10, 20);
            WriteLine($"{x}, {y}");
            var final = (resultado, resultado2, resultado3);
            WriteLine($"{final.resultado.Item2}, {final.resultado2.Value}, {final.resultado3.Ok}");
        }
        private static (bool, int) NewParse(string text) => (int.TryParse(text, out var value), value);
        private static (bool Ok, int Value) ImprovParse(string text) => (int.TryParse(text, out var value), value);
        private static (bool Ok, int Value) ImprovParse2(string text) {
            (bool a, int b) x = (a: int.TryParse(text, out var value), b: value);
            return x;
        }
        private static void Embodied() => new Produto("Margarina").Imprime();
        private static void LocalFunction() {
            var antes = "Ganhei";
            WriteLine(Local("um pé de alface"));
            string Local(string texto) => antes + " " + texto + " na loteria"; // + depois;
            var depois = "mas ele apodreceu";
            var seq = GetSequence(1, 10).GetEnumerator();
            WriteLine(seq.Current);
            seq.MoveNext();
            WriteLine(seq.Current);
            seq.MoveNext();
            WriteLine(seq.Current);
        }
        private static IEnumerable<int> GetSequence(int low, int high) {
            if (low < 1)
                throw new ArgumentException("low is too low");
            if (high > 140)
                throw new ArgumentException("high is too high");
            IEnumerable<int> Iterator() {
                for (int i = low; i <= high; i++)
                    yield return i;
            }
            return Iterator();
        }
        private static void PatternMatching() {
            var produtos = new List<Produto> { new Produto("Abobrinha") { Estoque = 100, Ativo = false }, new Produção("Abacaxi") { Estoque = 200, Validade = DateTime.Now.AddDays(-5) }, new Atacado("Pepino") { Estoque = 300 }, };
            foreach (var produto in produtos) {
                switch (produto) {
                case Produção p when (p.Ativo && p.Estoque >= 200 && p.Validade <= DateTime.Now):
                    WriteLine($"{p.Nome} pode ser vendido por {p.PreçoEspecial}");
                    break;
                case Produção p when (p.Ativo && p.Estoque > 100):
                    WriteLine($"{p.Nome} pode ser vendido por {p.Preço}");
                    break;
                //                case Atacado a when (a.Validade <= DateTime.Now):
                case Atacado a:
                    WriteLine($"{a.Nome} Está proibido para venda neste momento");
                    break;
                case Produto p when (p.Ativo):
                    WriteLine($"{p.Nome} custa {p.Preço}");
                    break;
                }
            }
            object idadeDb = getIdadeFromDataBase();
            if (idadeDb is int idade || (idadeDb is string idadeStr && int.TryParse(idadeStr, out idade)))
                WriteLine(idade);
            else
                WriteLine("Não tem como saber a idade");
            dynamic d = 400M; //normalmente só faz sentido se for um parâmetro
            if (d is int)
                WriteLine("é int");
            if (d is null)
                WriteLine("é null");
            if (d is string)
                WriteLine("é string");
            else if (d is var _)
                WriteLine("não é um tipo válido");
        }
        public void PatternMatching<T>(T valor) where T : struct {
            switch (valor) {
            case int x:
                WriteLine(-x);
                break;
            case bool b:
                WriteLine(!b);
                break;
            default:
                WriteLine("tipo que não sei manipular");
                break;
            }
        }
        private static object getIdadeFromDataBase() => "45";
        private static void ValueTask() => WriteLine(GetLargestPrimeNumber(1000000).Result);
        private static async ValueTask<int> GetLargestPrimeNumber(int maxNumber) {
            var primes = new List<int>();
            await Task.Run(() => {
                bool isPrime;
                for (int number = 2; number <= maxNumber; number++) {
                    isPrime = true;
                    foreach (var prime in primes.Where(x => x <= Sqrt(number))) {
                        if (number % prime == 0) {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                        primes.Add(number);
                }
            });
            return primes.Max();
        }
        private static void Default() {
            int a = default;
            bool b = default;
            string c = default;
            int? d = default;
            Action<int, bool> action = default;
            Predicate<string> predicate = default;
            List<string> list = default;
            Dictionary<int, string> dictionary = default;
            int Add(int x, int y = default, int z = default) => x + y + z;
        }
        private static void NamedArguments() => _ = Volume(3, b: 4, 5);
        private static int Volume(int a = 1, int b = 1, int c = 1) {
            return a * b * c;
        }
        private static void RefVar() {
            int[] array = { 62, 63, 81, 83, 92, 93, 5, 6, 12, 18 };
            ref int par = ref Mundial(array); //storing as reference  
            WriteLine(par);
            ref var proximo = ref (par == 62 ? ref array[1] : ref array[9]);
            WriteLine(proximo);
            WriteLine();
            par = 2018;
            foreach (var item in array)
                WriteLine(item);
            ref int Mundial(int[] numeros) {
                for (int i = 0; i < numeros.Length; i++)
                    if (numeros[i] > 18)
                        return ref numeros[i];
                throw new Exception("Deve ser a lista de mundiais do Palmeiras");
            }
        }
        private static void ReturnReadOnly() {
            var array = new ImmutableArray<int>(0, 1, 2, 4, 8, 16);
            ref int item = ref array.ItemRef(3);
            WriteLine(item);
            item = 10;
            WriteLine(array.array[3]);
            ref readonly int itemRO = ref array.ItemRefRO(4);
            WriteLine(itemRO);
            //itemRO = 10;
            WriteLine(array.array[4]);
        }
        private static void In() {
            var pt1 = new Point4D(10, 20, 30, 40);
            var pt2 = pt1;
            var distance = CalculateDistance(in pt1, in pt2);

        }
        private static double CalculateDistance(in Point4D point1, in Point4D point2 = default) {
            double xDifference = point1.X - point2.X;
            double yDifference = point1.Y - point2.Y;
            double zDifference = point1.Z - point2.Z;
            double wDifference = point1.W - point2.W;
            return Sqrt(xDifference * xDifference + yDifference * yDifference + zDifference * zDifference + wDifference * wDifference);
        }
        private static void SpanT() {
            var arr = new byte[10];
            Span<byte> bytes = arr; // Implicit cast from T[] to Span<T>
            Span<byte> slicedBytes = bytes.Slice(start: 5, length: 2);
            slicedBytes[0] = 42;
            slicedBytes[1] = 43;
            WriteLine(slicedBytes[0]);
            WriteLine(slicedBytes[1]);
            WriteLine(arr[5] == slicedBytes[0]);
            WriteLine(arr[6] == slicedBytes[1]);
            //slicedBytes[2] = 44; // Throws IndexOutOfRangeException
            bytes[2] = 45; // OK
            WriteLine(arr[2] == bytes[2]);
            WriteLine(arr[2]);
            Span<byte> bytes2 = stackalloc byte[2] { 42, 43 };
            WriteLine(bytes2[0]);
            WriteLine(bytes2[1]);
            var str = "hello world";
            string worldString = str.Substring(startIndex: 7, length: 5); // Allocates
            var worldSpan = str.AsSpan().Slice(start: 7, length: 5); // No allocation
            WriteLine(worldSpan[0]);
            //worldSpan[0] = 'a'; // Error CS0200: indexer cannot be assigned to
            //Memory<T>
        }
        /*       void Hash<T>(T value) where T : unmanaged {
                   fixed (T* p = &value) {
                       // Do stuff...
                   }
               }*/

    }
    struct ImmutableArray<T> {
        public readonly T[] array;
        public ImmutableArray(params T[] array) => this.array = array;
        public ref T ItemRef(int i) => ref array[i];
        public ref readonly T ItemRefRO(int i) => ref array[i];
    }
    public class Produto {
        public string Nome { get; }
        public bool Ativo { get; set; } = true;
        public int Estoque { get; set; }
        public decimal Preço => 1000;
        virtual public decimal PreçoEspecial => Preço * 0.9M;
        public void Imprime() => WriteLine($"Produto {Nome} custa {Preço} mas posso fazer por {PreçoEspecial}");
        public Produto(string name) => Nome = name;
        ~Produto() => WriteLine("Destrutor");
    }
    public class Produção : Produto {
        override public decimal PreçoEspecial { get => Preço * 0.7M; }
        public DateTime? Validade { get; set; }
        public Produção(string name) : base(name) { }
    }
    public class Atacado : Produto {
        override public decimal PreçoEspecial { get => Preço * 0.8M; }
        private protected char Tipo => 'A';
        public Atacado(string name) : base(name) { }
    }
    public class Point {
        public int X { get; }
        public int Y { get; }
        public Point(int x, int y) { X = x; Y = y; }
    }
    public static class PointExt {
        public static void Deconstruct(this Point point, out int x, out int y) { x = point.X; y = point.Y; }
    }
    public struct Point4D {
        public double X;
        public double Y;
        public double Z;
        public double W;
        public Point4D(double x, double y, double z, double w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
    }
    public readonly struct RoPoint4D {
        public readonly double X;
        public readonly double Y;
        public readonly double Z;
        public readonly double W;
        public RoPoint4D(double x, double y, double z, double w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
    }
    public ref struct RefPoint4D {
        public double X;
        public double Y;
        public double Z;
        public double W;
        public RefPoint4D(double x, double y, double z, double w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
    }
    public readonly ref struct RefRoPoint4D {
        public readonly double X;
        public readonly double Y;
        public readonly double Z;
        public readonly double W;
        public RefRoPoint4D(double x, double y, double z, double w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
    }
    [Serializable]
    public class Exemplo {
        [field: NonSerialized]
        public string Interno { get; set; }
    }
    public class Base {
        public Base(int i, out int j) => j = i;
    }
    public class Derivada : Base {
        public Derivada(int i) : base(i, out var j) => WriteLine($"O valor de j é {j}");
    }
    public class UsingEnum<T> where T : Enum { }
    public class UsingDelegate<T> where T : Delegate { }
    public class Multicaster<T> where T : MulticastDelegate { }
    /*   class C {
           static S s = new S();
           unsafe public void M() {
               int p = s.myFixedField[5];
           }
       }*/
}
