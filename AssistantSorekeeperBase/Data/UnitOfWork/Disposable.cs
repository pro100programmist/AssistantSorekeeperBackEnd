using System;

namespace AssistantSorekeeperBase.Data
{
    /// <summary>
    /// Класс для вызова принудительной очистки ресурсов памяти
    /// </summary>
    public class Disposable : IDisposable
    {
        /// <summary>
        /// Флаг вызова метода освобождения ресурсов
        /// </summary>
        private bool isDisposed;

        /// <summary>
        /// Базовый деструктор
        /// </summary>
        ~Disposable()
        {
            Dispose(false);
        }

        /// <summary>
        /// Освобождение ресурсов памяти
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Освобождение ресурсов памяти
        /// </summary>
        /// <param name="disposing">Признак вызова метода очистки ресурсов для потомков класса</param>
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        /// <summary>
        /// Метод для расширения очистки ресурсов для потомков класса
        /// </summary>
        protected virtual void DisposeCore() { }
    }
}