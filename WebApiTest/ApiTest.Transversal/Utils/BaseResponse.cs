using Constant = ApiProduct.Shared.Common.Constant;

namespace ApiProduct.Shared.Utils
{
    /// <summary>
    /// Base de respuesta
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponse<T>
    {
        #region [Variables]
        public string CodigoError { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        #endregion

        #region [BaseResponse]
        public static BaseResponse<T> BaseResponseSuccess(T pData, string message = "")
        {
            var baseResponse = new BaseResponse<T>()
            {
                CodigoError = Constant.ResponseCode.SuccessCode,
                Message = (message == string.Empty ? Constant.ResponseMessage.SuccessMessage : message),
                Data = pData
            };
            return baseResponse;
        }

        public static BaseResponse<T> BaseResponseError(string pError = "")
        {
            var baseResponse = new BaseResponse<T>()
            {
                CodigoError = Constant.ResponseCode.ErrorCode,
                Message = Constant.ResponseMessage.ErrorMessage,
            };
            return baseResponse;
        }

        public static BaseResponse<T> BaseResponseWarning(T pData, string message = "")
        {
            var baseResponse = new BaseResponse<T>()
            {
                CodigoError = Constant.ResponseCode.WarningCode,
                Message = (message == string.Empty ? Constant.ResponseMessage.WarningMessage : message),
                Data = pData
            };
            return baseResponse;
        }
        #endregion
    }
}
