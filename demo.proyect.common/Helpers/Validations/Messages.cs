namespace demo.proyect.common.Helpers.Validations;

public class Messages
{
    public const string IsRequired = "Este Campo es Requerido*";
    public static string MinLength (string min = "1") => $"Este Campo Requiere un Minimo de {min} como Caracter*";
    public static string MaxLength (string max = "1") => $"Este Campo Requiere un Maximo de {max} como Caracter*";
}
