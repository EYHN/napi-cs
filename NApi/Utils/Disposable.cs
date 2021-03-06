using System;

namespace NApi.Utils
{
    public class Disposable : IDisposable
    {
        private readonly Action? _callOnDispose;

        public Disposable(Action? callOnDispose = null)
        {
            _callOnDispose = callOnDispose;
        }

        public bool Disposed { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void DisposeManaged()
        {
            _callOnDispose?.Invoke();
        }

        protected virtual void DisposeUnmanaged()
        {
        }

        private void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    DisposeManaged();
                }

                DisposeUnmanaged();

                Disposed = true;
            }
        }

        protected virtual void ThrowsIfDisposed()
        {
            if (Disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        ~Disposable()
        {
            Dispose(false);
        }

        public static Disposable From(params IDisposable[] disposables)
        {
            return new(() =>
            {
                foreach (var disposable in disposables)
                {
                    disposable.Dispose();
                }
            });
        }
    }
}
