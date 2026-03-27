namespace demo.proyect.common.Helpers.Results;

public class Messages
{
    public static string SuccessEntityCreation(string entity) => $"Se a registrado con exito un nuevo/a {entity}";
    public static string SuccessEntityUpdate(string id, string entity) => $"Se a actualizado con exito el registro {id} de {entity}";
    
    public static string EntityNameNotFound(string entityName) => $"Entidad {entityName}, no encontrada";
    public static string EntityNameNotFoundByPropertyAndValue(string entityName, string property, string value) => $"Entidad {entityName}, no encontrada por {property} con el valor {value}";

    private const string EntityNot = "Entidad no";
    public const string EntityNotFound = $"{EntityNot} encontrada";
    public const string EntityNotCreated = $"{EntityNot} Creada";
    public const string EntityNotUpdate = $"{EntityNot} Actualizada";
    public const string EntityNotDelete = $"{EntityNot} Eliminada";
}
