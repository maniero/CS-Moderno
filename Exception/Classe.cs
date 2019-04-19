using System;
using System.Collections.Generic;
using System.Text;

public class Validator {
    public static bool Validate(string data) {
        if (data != null) throw new OutOfMemoryException();
        return true;
    }
}