using System;

class Program {
    static void Main() {
        try {
            Console.WriteLine(Objeto.GetData());
        } catch (Exception ex) {
            Console.WriteLine("O dado não é válido de acordo com a exceção " + ex.Message);
        }
    }
}

public class Objeto {
    public static string GetData() {
        string data = Console.ReadLine();
        if (data == "") throw new InvalidDataException("O dado não pode ser vazio");
        if (!Validator.Validate(data)) throw new InvalidDataException("Os critérios de validação não foram satisfeitos"); return data;
    }
}

public class InvalidDataException : Exception {
    public InvalidDataException(string message) : base(message) { }
}