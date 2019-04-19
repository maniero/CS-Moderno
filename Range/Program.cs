using System;
using static System.Console;
using System.Linq;
class Program {
    static void Main() {
        var frutas = new string[] { "Abacaxi", "Banana", "Figo", "Morango", "Pera", "Pêssego" };
        Processa(frutas);
        Processa(frutas.Skip(2).Take(3).ToArray());
        for (var i = 2; i < 5; i++) WriteLine(frutas[i]);
        for (var i = 2; i < frutas.Length - 2; i++) WriteLine(frutas[i]);
        foreach (var fruta in frutas[2..5]) WriteLine(fruta);
        foreach (var fruta in frutas[2..^1]) WriteLine(fruta);
        foreach (var fruta in frutas[2..]) WriteLine(fruta);
        foreach (var fruta in frutas[..^2]) WriteLine(fruta);
        foreach (var fruta in frutas[..]) WriteLine(fruta);
        if (!int.TryParse(ReadLine(), out var inicio)) return;
        if (!int.TryParse(ReadLine(), out var fim)) return;
        foreach (var fruta in frutas[inicio..fim]) WriteLine(fruta);
        var faixa = 2..5;
        foreach (var fruta in frutas[faixa]) WriteLine(fruta);
        Range faixa2 = 2..5;
        foreach (var fruta in frutas[faixa2]) WriteLine(fruta);
        Index x = 2;
        Index y = ^2;
        WriteLine(frutas[x]);
        WriteLine(frutas[y]);
        //       foreach (var fruta in frutas[5..2]) WriteLine(fruta);
        Processa(frutas[2..5]);
        WriteLine("MVPConf 2019"[3..^4]);
    }
    static void Processa(string[] frutas) {
        foreach (var fruta in frutas) WriteLine(fruta);
    }
}