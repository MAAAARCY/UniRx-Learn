using System.Collections;
using System.Collections.Generic;
using UniRx;

/*
namespace Samples.Section2.MySubjects
{
    //独自実装Subject
    public class MySubject<T> : ISubject<T>, IDisposable
    {
        public bool IsStopped { get; } = false;
        public bool IsDisposed { get; } = false;

        private readonly object _lockObject = new object();

        private Exception error;

        public MySubject()
        {
            observers = new List<IObserver<T>>();
        }

        public void OnNext(T value)
        {
            if (IsStopped) return;
            lock (_lockObject)
            {
                ThrowIfDisposed();

                foreach (var observer in observers)
                {
                    observer.OnNext(value);
                }
            }
        }

        public void OnError(Exception error)
        {
            lock (_lockObject)
            {
                ThrowIfDisposed();
                if (IsStopped) return;
                this.error = error;

                try 
                {
                    foreach (var observer in observers)
                    {
                        observer.OnError(error);
                    }
                }
                finally{
                    Dispose();
                }
            }
        }

        public void OnCompleted()
        {
            lock (_lockObject)
            {
                ThrowIfDisposed();
                if (IsStopped) return;
                try
                {
                    foreach (var observer in observers)
                    {
                        observer.OnCompleted();
                    }
                }
                finally
                {
                    Dispose();
                }
            }
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            lock (_lockObject)
            {
                if (IsStopped)
                {
                    if (error != null)
                    {
                        observer.OnError(error);
                    }
                    else
                    {
                        observer.OnCompleted();
                    }

                    return Disposable.Empty;
                }

                observers.Add(observer);
                return new Subscription(this, observers);
            }
        }

        private void ThrowIfDisposed()
        {
            if (IsDisposed) throw new ObjectDisposedException("MySubject");
        }

        private sealed class Subscription : IDisposable
        {
            private readonly IObserver<T> _observer;
            private readonly MySubject<T> _parent;

            public Subscription(MySubject<T> parent, IObserver<T> observer)
            {
                this._parent = parent;
                this._observer = observer;
            }

            public void Dispose()
            {
                _parent.observers.Remove(_observer);
            }
        }

        public void Dispose()
        {
            lock (_lockObject)
            {
                if (!IsDisposed)
                {
                    observers.Clear();
                    observers = null;
                    error = null;
                }
            }
        }
    }
}
*/