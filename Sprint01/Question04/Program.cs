using System;

namespace Question04
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = new DisposePatternImplementer();
            v.Dispose();
        }
    }

    public abstract class CloseableResource
    {
        public void Close()
        {
            Console.WriteLine("Closing");
        }
    }

    class DisposePatternImplementer: CloseableResource, IDisposable
    {
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Console.WriteLine("Disposing by developer");
                }
                else
                {
                    Console.WriteLine("Disposing by GC");
                }
                Close();
                disposed = true;
            }
        }

        ~DisposePatternImplementer()
        {
            Dispose(false);
        }
    }
}
