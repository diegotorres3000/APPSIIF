using System;
namespace APPSIIF.Interfaces
{
    public interface IProgressInterface
    {
        void Show(string title = "Cargando");

        void Hide();
    }
}
