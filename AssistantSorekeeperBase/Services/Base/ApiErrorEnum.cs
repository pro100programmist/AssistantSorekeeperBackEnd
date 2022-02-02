using System.ComponentModel;

namespace AssistantSorekeeperBase.Services
{
    /// <summary>
    /// Ошибки в API
    /// </summary>
    public enum ApiErrorEnum
    {
        /// <summary>
        /// Ошибок нет
        /// </summary>
        [Description("Ошибок нет")]
        NoErrors = 0,

        [Description("Ошиба при сохранении.")]
        UnableToSaveChange,


        [Description("Неизвестная ошибка на сервере")]
        UnknownError
    }
}