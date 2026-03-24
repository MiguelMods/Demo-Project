namespace demo.proyect.common.Helpers.Results;

public class Messages
{
    public static string SuccessEntityCreation(string entity) => $"Se a registrado con exito un nuevo/a {entity}";
    public static string SuccessEntityUpdate(string id, string entity) => $"Se a actualizado con exito el registro {id} de {entity}";
}
