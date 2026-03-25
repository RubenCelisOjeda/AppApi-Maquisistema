namespace ApiProduct.Shared.Common
{
    public class Constant
    {
        public struct ResponseMessage
        {
            public const string SuccessMessage = "Se ejecuto correctamente.";
            public const string WarningMessage = "No se pudo ejecutar la consulta.";
            public const string ErrorMessage = "Error al ejecutar la consulta.";

            public const string CodeNoValid = "Codigo ingresado es incorrecto";
            public const string CodeValid = "Codigo ingresado correctamente";
            public const string LoginInvalid = "Email y/o contraseña incorrecta.";
        }

        public struct ResponseCode
        {
            public const string SuccessCode = "00";
            public const string WarningCode = "01";
            public const string ErrorCode = "02";
        }
    }
}
